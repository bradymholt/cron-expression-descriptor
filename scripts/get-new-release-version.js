#!/usr/bin/env npx jsh

usage(`
Usage:
  ${0} [major] [minor] [patch]

Examples:
  ${0} major
  ${0} minor
  ${0} patch

Reads the current release version, bumps it (major, minor, or patch) and returns the new version
`);

const [version_type] = args.assertCount(1);

const libCsproj = "lib/CronExpressionDescriptor.csproj";

const csProj = readFile(libCsproj);
const existingVersion = csProj.match(new RegExp("<Version>(.+)</Version>"))[1];
let [major, minor, patch] = existingVersion.split(".");

switch (version_type) {
    case "major":
        major = parseInt(major) + 1;
        minor = 0;
        patch = 0;
        break;
    case "minor":
        minor = parseInt(minor) + 1;
        patch = 0;
        break;
    case "patch":
        patch = parseInt(patch) + 1;
        break;
    default:
        throw new Error(`Unknown version type: ${version_type}`);
}
const newVersion = `${major}.${minor}.${patch}`;

echo(newVersion);
