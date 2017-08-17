
# Releasing

## Publishing library to NuGet

The following instructions are for building, packaging and releasing the library to NuGet.

1. Ensure [.NET Core SDK](https://www.microsoft.com/net/download/core#/sdk) version >= 1.0.4 is installed
2. Update `<Version/>` and `<PackageReleaseNotes/>` in `lib/onExpressionDescriptor.csproj`.
3. Ensure `NUGET_API_KEY` environment variable is set
4. Run the following command:

```
./build/release.sh [VERSION_NUMBER] "[RELEASE_NOTES]"
```

This will:

1. Run tests
2. Create NuGet package
3. Upload NuGet package
4. Create a git tag for the release
4. Create a Relese on GitHub

## Deploying the Demo site

The [demo site](https://cronexpressiondescriptor.azurewebsites.net) is automatically deployed to the Azure App Service by a GitHub deployment hook configured in Azure.

![image](https://user-images.githubusercontent.com/759811/29218928-1521b88c-7e7c-11e7-8f81-4ff96dc0ccf5.png)
