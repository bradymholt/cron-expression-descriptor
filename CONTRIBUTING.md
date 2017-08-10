# Contributing

Thanks for being willing to contribute!

**Working on your first Pull Request?** You can learn how from this *free* series
[How to Contribute to an Open Source Project on GitHub][egghead]

## Project setup

1. Ensure [.NET Core SDK](https://www.microsoft.com/net/download/core#/sdk) version >= 1.0.4 is installed
2. Fork and clone the repo
3. `dotnet restore` to install dependencies
4. Create a branch for your PR

## Add yourself as a contributor

Update the `README.md` file and add your name to the _Contributors_ list

## i18n

If you are adding a language translation you will need to do the following:

1. Add a Resources.[*].resx file than provides the translation.  You can use one of the existing ones as a pattern.
2. Create a TestsFormats.[*].cs file in CronExpressionDescriptor.Test project with tests for the translation.  You can use one of the existing test files as a pattern.

## Committing and Pushing changes

1. Run tests with `dotnet test` from the `CronExpressionDescriptor.Test` folder (or, _dotnet test CronExpressionDescriptor.Test/CronExpressionDescriptor.Test.csproj_ from root folder).
2. Commit and push changes up to GitHub
1. [Create a Pull Request](https://help.github.com/articles/creating-a-pull-request/).  Please use a simple description that explains the changes in brief.
