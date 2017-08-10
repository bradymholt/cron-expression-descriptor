
# Releasing

The following instructions are for building, packaging and releasing to NuGet.

1. Ensure [.NET Core SDK](https://www.microsoft.com/net/download/core#/sdk) version >= 1.0.4 is installed
2. Update `<Version/>` and `<PackageReleaseNotes/>` in `CronExpressionDescriptor/CronExpressionDescriptor.csproj`.
3. Ensure `NUGET_API_KEY` environment variable is set
4. Run these commands to build, pack, and push a NuGet package:

```
dotnet restore
dotnet pack CronExpressionDescriptor/CronExpressionDescriptor.csproj --configuration release
dotnet nuget push CronExpressionDescriptor/bin/release/*.nupkg -k $NUGET_API_KEY
```

5. Run these commands to create a GitHub tag:

```
git tag -a [VERSION_NUMBER] -m [VERSION_NOTES]
git push --tags
```

6. Navigate to [Draft New Release](https://github.com/bradyholt/cron-expression-descriptor/releases/new) on GitHub
7. Leave title and description blank so that git tag message will be used
8. Click **Publish release**