
# Releasing

## Publishing library to NuGet

The following instructions are for building, packaging and releasing the library to NuGet.

1. Ensure [.NET Core SDK](https://www.microsoft.com/net/download/core#/sdk) version >= 1.0.4 is installed
2. Update `<Version/>` and `<PackageReleaseNotes/>` in `lib/onExpressionDescriptor.csproj`.
3. Ensure `NUGET_API_KEY` environment variable is set
4. Run these commands to build, pack, and push a NuGet package:

```
dotnet restore
dotnet pack lib/CronExpressionDescriptor.csproj --configuration release
dotnet nuget push lib/bin/release/*.nupkg -k $NUGET_API_KEY
```

5. Run these commands to create a GitHub tag:

```
git tag -a [VERSION_NUMBER] -m [VERSION_NOTES]
git push --tags
```

6. Navigate to [Draft New Release](https://github.com/bradyholt/cron-expression-descriptor/releases/new) on GitHub
7. Leave title and description blank so that git tag message will be used
8. Click **Publish release**

## Deploying the Demo site

The [demo site](https://cronexpressiondescriptor.azurewebsites.net) is automatically deployed to the Azure App Service by a GitHub deployment hook configured in Azure.

![image](https://user-images.githubusercontent.com/759811/29218928-1521b88c-7e7c-11e7-8f81-4ff96dc0ccf5.png)
