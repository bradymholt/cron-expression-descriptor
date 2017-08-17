#!/bin/bash

# Releases CronExpressionDescriptor
# This includes: running tests, building in release mode, signing, packaging, publishing on
# NuGet, creating a GitHub release, uploading .nupkg to GitHub release.
#
# Example:
#   release.sh 2.0.0 "Fixed DOW bug causing exception"

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
RELEASE_PATH="lib/bin/release"
NUPKG_FILE="CronExpressionDescriptor.$VERSION.nupkg"
LIB_CSPROJ="lib/CronExpressionDescriptor.csproj"
GH_REPO="bradyholt/cron-expression-descriptor"

dotnet restore

# Run tests
dotnet test -c release test/Test.csproj

# Update CronExpressionDescriptor.csproj with version and release notes
sed -i.bak "s|\(<Version>\)[^<>]*\(</Version>\)|\1$VERSION\2|" $LIB_CSPROJ
sed -i.bak "s|\(<PackageReleaseNotes>\)[^<>]*\(</PackageReleaseNotes>\)|\1$NOTES\2|" $LIB_CSPROJ
rm ${LIB_CSPROJ}.bak

# Build, pack, and push to NuGet
dotnet build -c release -p:SignAssembly=True,PublicSign=True $LIB_CSPROJ
dotnet pack -c release --no-build $LIB_CSPROJ
dotnet nuget push "$RELEASE_PATH/$NUPKG_FILE" -k $NUGET_API_KEY

# Commit changes to project file
git commit -am  "New release: $VERSION"

# Create release tag
git tag -a $VERSION -m "${NOTES}"
git push --tags

# Create release on GitHub
RELEASE_RESPONSE=$(curl -H "Authorization: token $GITHUB_API_TOKEN" -d "{\"tag_name\":\"$VERSION\",\"prerelease\": $PRERELEASE}" https://api.github.com/repos/$GH_REPO/releases)

# Get the release id and then upload the and upload the .nupkg
eval $(echo "$RELEASE_RESPONSE" | grep -m 1 "id.:" | grep -w id | tr : = | tr -cd '[[:alnum:]]=')
[ "$id" ] || { echo "Error: Failed to get release id for tag: $VERSION"; echo "$RELEASE_RESPONSE" | awk 'length($0)<100' >&2; exit 1; }
curl -H "Authorization: token $GITHUB_API_TOKEN"  -H "Content-Type: application/octet-stream" --data-binary @"$RELEASE_PATH/$NUPKG_FILE" https://uploads.github.com/repos/$GH_REPO/releases/$id/assets?name=$NUPKG_FILE
