#!/usr/bin/env node

/* Releases CronExpressionDescriptor
   This includes: running tests, building in release mode, signing, packaging, publishing on
   NuGet, creating a GitHub release, uploading .nupkg to GitHub release.

   Example:
     release.sh 2.0.0 "Fixed DOW bug causing exception" */

// jsbash
_p = process; args = _p.argv.slice(2); cd = _p.chdir; exit = _p.exit; env = _p.env; echo = console.log;
_e = "utf-8"; _fs = require("fs"); readFile = (path, encoding = _e) => { return _fs.readFileSync(path, { encoding }) }; writeFile = (path, contents, encoding = _e) => { _fs.writeFileSync(path, contents, { encoding }) };
$$ = (cmd, stream) => { r = (require("child_process").execSync(cmd, { stdio: stream ? "inherit" : "pipe" }) ); return !!r ? r.toString().replace(/\n$/, "") : null; };
$ = cmd => { return $$(cmd, true); };
//

// cd to root dir
cd(`${__dirname}/../`);

if (args.length != 2) {
  echo(`
Usage: release.sh version "Release notes..."'
  release.js 2.0.0 "Fixed DOW bug causing exception"'
  release.js 2.0.0-rc1`);
  exit(1);
}

if ($$(`git status --porcelain`)) {
  echo(`All changes must be committed first.`);
  //exit(1);
}

let version = args[0];
let notes = args[1];
let preRelease = version.indexOf("-") > -1; // If version contains a '-' character (i.e. 2.0.0-alpha-1) we will consider this a pre-release

let releasePath = "lib/bin/release";
let nupkgFile = `CronExpressionDescriptor.${version}.nupkg`;
let libCsproj = "lib/CronExpressionDescriptor.csproj";
let ghRepo = "bradyholt/cron-expression-descriptor";

$(`dotnet restore`);
$(`dotnet test -c release test/Test.csproj`);

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
$(`dotnet build -c release -p:SignAssembly=True,PublicSign=True ${libCsproj}`);
$(`dotnet pack -c release --no-build ${libCsproj}`);
//$(`dotnet nuget push ${releasePath}/${nupkgFile} -k ${env.NUGET_API_KEY}`);

// Commit changes to project file
$(`git commit -am "New release: ${version}"`);

// Create release tag
$(`git tag -a ${version} -m "${notes}"`);
$(`git push --tags`);

// Create release on GitHub
let response = $$(`curl -f -H "Authorization: token ${env.GITHUB_API_TOKEN}" \
  -d '{"tag_name":"${version}", "name":"${version}","body":"${notes}","prerelease": ${preRelease}}' \
  https://api.github.com/repos/${ghRepo}/releases`
);

let releaseId = JSON.parse(response).id;

// Get the release id and then upload the and upload the .nupkg
$(`curl -H "Authorization: token ${env.GITHUB_API_TOKEN}" -H "Content-Type: application/octet-stream" \
  --data-binary @"${releasePath}/${nupkgFile}" \
  https://uploads.github.com/repos/${ghRepo}/releases/${releaseId}/assets?name=${nupkgFile}`);
