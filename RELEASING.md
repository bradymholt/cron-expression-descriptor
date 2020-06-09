
# Releasing

## Publishing library to NuGet

The following instructions are for building, packaging and releasing the library to NuGet.

1. Ensure [.NET Core SDK](https://www.microsoft.com/net/download/core#/sdk) version >= 2.0.0 is installed
2. Ensure Node.js version >= 4 is installed and that jBash is installed globally (`npm i -g jbash`).
3. Ensure `NUGET_API_KEY` and `GITHUB_API_TOKEN` environment variables are set
4. Run the `scripts/release.js` command, passing in the version and release notes:

```
./scripts/release.js [VERSION_NUMBER] "[RELEASE_NOTES]"
```

This will:

1. Run tests
2. Create NuGet package
3. Upload NuGet package
4. Create a git tag for the release
5. Create a Relese on GitHub
6. Upload the .nupkg file as a release asset to GitHub

### Pre-releases

To publish a pre-release version, add a "-" suffix to the version, such as "1.0.1-alpha" or "2.18-beta".  By default Nuget will not update to pre-release versions.

## Deploying the Demo site

The demo site is automatically built and deployed using the `.github/workflows/demo_site.yml` GitHub Actions workflow.

