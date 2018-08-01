#!/usr/bin/env npx jbash

/* Releases CronExpressionDescriptor
   This includes: running tests, building in release mode, signing, packaging, publishing on
   NuGet, creating a GitHub release, uploading .nupkg to GitHub release.

   Example:
     release.js 2.0.0 "Fixed DOW bug causing exception" */

// Halt on an error
set("-e");

// cd to root dir
cd(`${__dirname}/../`);

if (args.length != 2) {
  echo(`
Usage: release.js version "Release notes..."
Example:
  release.js 2.0.0 "Fixed DOW bug causing exception"`);
  exit(1);
}

if ($(`git status --porcelain`)) {
  echo(`All changes must be committed first.`);
  exit(1);
}

let version = args[0];
let notes = args[1];
let preRelease = version.indexOf("-") > -1; // If version contains a '-' character (i.e. 2.0.0-alpha-1) we will consider this a pre-release

let releasePath = "lib/bin/release";
let nupkgFile = `CronExpressionDescriptor.${version}.nupkg`;
let libCsproj = "lib/CronExpressionDescriptor.csproj";
let ghRepo = "bradymholt/cron-expression-descriptor";

eval(`dotnet restore`);
eval(`dotnet test -c release test/Test.csproj`);

// Update CronExpressionDescriptor.csproj with version and release notes
let csProj = readFile(libCsproj);
csProj = csProj.replace(
  /<Version>[\s\S]*?<\/Version>/,
  `<Version>${version}</Version>`
);
csProj = csProj.replace(
  /<PackageReleaseNotes>[\s\S]*?<\/PackageReleaseNotes>/,
  `<PackageReleaseNotes>${notes}</PackageReleaseNotes>`
);
writeFile(libCsproj, csProj);

// Build, pack, and push to NuGet
eval(`dotnet build -c release ${libCsproj}`);
eval(`dotnet pack -c release --no-build ${libCsproj}`);
eval(`dotnet nuget push ${releasePath}/${nupkgFile} -k ${env.NUGET_API_KEY}`);

// Commit changes to project file
eval(`git commit -am "New release: ${version}"`);

// Create release tag
eval(`git tag -a ${version} -m "${notes}"`);
eval(`git push --follow-tags`);

// Create release on GitHub
let response = $(`curl -f -H "Authorization: token ${env.GITHUB_API_TOKEN}" \
  -d '{"tag_name":"${version}", "name":"${version}","body":"${notes}","prerelease": ${preRelease}}' \
  https://api.github.com/repos/${ghRepo}/releases`
);

let releaseId = JSON.parse(response).id;

// Get the release id and then upload the and upload the .nupkg
eval(`curl -H "Authorization: token ${env.GITHUB_API_TOKEN}" -H "Content-Type: application/octet-stream" \
  --data-binary @"${releasePath}/${nupkgFile}" \
  https://uploads.github.com/repos/${ghRepo}/releases/${releaseId}/assets?name=${nupkgFile}`);

echo(`DONE!  Released version ${version} to NuGet and GitHub.`);
