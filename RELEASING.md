
1. Ensure [.NET Core SDK](https://www.microsoft.com/net/download/core#/sdk) version >= 1.0.4 is installed
2. Update `<Version/>` and `<PackageReleaseNotes/>` in `CronExpressionDescriptor/CronExpressionDescriptor.csproj`.
3. Ensure `NUGET_API_KEY` environment variable is set
4. Run these commands:

```
dotnet restore
dotnet pack CronExpressionDescriptor/CronExpressionDescriptor.csproj --configuration release
dotnet nuget push CronExpressionDescriptor/bin/release/*.nupkg -k $NUGET_API_KEY
```
