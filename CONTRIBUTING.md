# Contributing

Thanks for being willing to contribute!

**Working on your first Pull Request?** You can learn how from GitHub's guide to [contributing to a project](https://docs.github.com/en/get-started/exploring-projects-on-github/contributing-to-a-project).

## Project setup

1. Install the [.NET SDK](https://dotnet.microsoft.com/download) version listed in [global.json](global.json)
2. Fork and clone the repo
3. `dotnet restore` to install dependencies
4. Create a branch for your PR

## i18n

If you are adding a language translation you will need to do the following:

1. Determine the culture name to use. See [Localization in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/localization) and the [list of culture names](https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-lcid/a9eac961-e77d-41a6-90a5-ce1a8b0cdb9c) for help. In general, please use only the language part of the culture name (e.g. `de`, not `de-DE`) so the translation is used for every region that speaks the language. Use a region-specific name (e.g. `es-MX`) only when the translation is specific to that region.
2. Add a `lib/Resources.[culture].resx` file that provides the translation. You can use one of the existing ones as a pattern.
3. Add a `test/TestFormats.[culture].cs` file with tests for the translation. You can use one of the existing test files as a pattern.
4. Add the translation to:
   - the language table in [README.md](README.md)
   - the language list in [demo/Pages/Index.razor](demo/Pages/Index.razor)
   - the `<Description>` in [lib/CronExpressionDescriptor.csproj](lib/CronExpressionDescriptor.csproj)

   `dotnet test` fails if a translation is missing from the README or the demo.

## Running the demo site

```bash
cd demo
dotnet watch
```

## Committing and pushing changes

1. Run tests with `dotnet test test/Test.csproj` from the root folder.
2. Commit and push changes up to GitHub.
3. [Create a Pull Request](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/creating-a-pull-request). Please use a simple description that explains the changes in brief.
