#!/usr/bin/env npx jsh

usage(`
Usage:
  ${0} new_version_number

Examples:
  ${0} 2.23.0
  ${0} 3.0.0
  ${0} 1.23.5

Releases CronExpressionDescriptor
This includes: running tests, building in release mode, signing, packaging, and publishing to NuGet.
`);

const [newVersionNumber] = args.assertCount(1);
const NUGET_API_KEY = env.assert("NUGET_API_KEY");

// cd to root dir
cd(`${__dirname}/../`);

// Determine new version
let libCsproj = "lib/CronExpressionDescriptor.csproj";
let nupkgFile = `CronExpressionDescriptor.${newVersionNumber}.nupkg`;
let releasePath = "lib/bin/release";

let csProj = readFile(libCsproj);
csProj = csProj.replace(
    /<Version>[\s\S]*?<\/Version>/,
    `<Version>${newVersionNumber}</Version>`
);
writeFile(libCsproj, csProj);

exec(`dotnet restore`);
exec(`dotnet test -c release test/Test.csproj`);

// Build, pack, and push to NuGet
exec(`dotnet build -c release ${libCsproj}`);
exec(`dotnet pack -c release --no-build ${libCsproj}`);
exec(`dotnet nuget push ${releasePath}/${nupkgFile} -k ${NUGET_API_KEY}`);

echo(`DONE!  Released version ${newVersionNumber} to NuGet.`);
return;
