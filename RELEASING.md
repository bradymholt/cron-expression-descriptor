
1. Update `<Version/>` and `<PackageReleaseNotes/>` in `CronExpressionDescriptor/CronExpressionDescriptor.csproj`.
```
dotnet restore
dotnet pack CronExpressionDescriptor/CronExpressionDescriptor.csproj --configuration release
```
