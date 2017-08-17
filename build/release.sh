#!/bin/bash

# Halt immediately on any error
set -e
set -o pipefail

# cd to root dir
cd $(dirname $0)/../

if [[ $# -ne 2 ]]; then
  echo 'Usage: release.sh version "Release notes..."'
  echo 'e.g. release.sh 2.0.0 "Fixed DOW bug causing exception"'
  echo 'or buildrelease.sh 2.0.0-rc1'
  exit 1
fi

if [[ `git status --porcelain` ]]; then
  echo "All changes must be committed first."
  exit 1
fi

: ${NUGET_API_KEY?"NUGET_API_KEY must be set"}
: ${GITHUB_API_TOKEN?"GITHUB_API_TOKEN must be set"}

VERSION=$1
NOTES=$2
PRERELEASE=false
# If version contains a '-' character (i.e. 2.0.0-alpha-1) we will consider this a pre-release
if [[ $VERSION == *"-"* ]]; then
  PRERELEASE=true
fi

dotnet restore

# Run tests
dotnet test -c release test/Test.csproj

# Update CronExpressionDescriptor.csproj with version and release notes
sed -i.bak "s|\(<Version>\)[^<>]*\(</Version>\)|\1$VERSION\2|" lib/CronExpressionDescriptor.csproj
sed -i.bak "s|\(<PackageReleaseNotes>\)[^<>]*\(</PackageReleaseNotes>\)|\1$NOTES\2|" lib/CronExpressionDescriptor.csproj
rm CronExpressionDescriptor.csproj.bak

# Build, pack, and push to NuGet
dotnet build -c release -p:SignAssembly=True,PublicSign=True lib/CronExpressionDescriptor.csproj
dotnet pack -c release --no-build lib/CronExpressionDescriptor.csproj
dotnet nuget push lib/bin/release/CronExpressionDescriptor.$VERSION.nupkg -k $NUGET_API_KEY

# Commit changes to project file
git commit -am  "New release: $VERSION"

# Create release tag
git tag -a $VERSION -m "${NOTES}"
git push --tags

# Create release on GitHub
curl -H "Authorization: token $GITHUB_API_TOKEN" -X POST -d '{"tag_name":"$VERSION", "prerelease": $PRERELEASE}' https://api.github.com/repos/bradyholt/cron-expression-descriptor/releases
