# Contributing

Thanks for being willing to contribute!

**Working on your first Pull Request?** You can learn how from this *free* series
[How to Contribute to an Open Source Project on GitHub](https://egghead.io/courses/how-to-contribute-to-an-open-source-project-on-github).

## Project setup

1. Ensure [.NET Core SDK](https://www.microsoft.com/net/download/core#/sdk) version >= 1.0.4 is installed
2. Fork and clone the repo
3. `dotnet restore` to install dependencies
4. Create a branch for your PR

## Add yourself as a contributor

Update the `README.md` file and add your name to the _Contributors_ list

## i18n

If you are adding a language translation you will need to do the following:

1. Determine the language culture name (LCN) to use.  You can reference [Table of Language Culture Names, Codes, and ISO Values Method](https://msdn.microsoft.com/en-us/library/ee825488(v=cs.20).aspx) for help.
2. Add a `Resources.[LCN].resx` file than provides the translation.  You can use one of the existing ones as a pattern.  In general, please use only the first part of the culture name which denotes the language itself and not the country/region.  This will allow the translation to be used more widely.  However, if the language is very much specific to a country/region then using the second part of of the name is appropriate.  For example, there are 5 culture names for Germany (de-AT, de-DE, dr-LI, de-LU, de-CH) but we only have a resource file named `Resources.de.resx`.  This allows this translation to be used for any of the specific culture names that would be passed in at runtime.  However, for Chinese, we have `Resources.zh-CN.resx` defined because the translation is Chinese Simplified and specific to China itself.
3. Create a TestsFormats.[LCN].cs file in CronExpressionDescriptor.Test project with tests for the translation.  You can use one of the existing test files as a pattern.
4. Add the translation to the `README.md` i18n list and the <Description/> section of the CronExpressionDescriptor/CronExpressionDescriptor.csproj file

## Committing and Pushing changes

1. Run tests with `dotnet test` from the `CronExpressionDescriptor.Test` folder (or, `dotnet test test/Test.csproj` from root folder).
2. Commit and push changes up to GitHub
1. [Create a Pull Request](https://help.github.com/articles/creating-a-pull-request/).  Please use a simple description that explains the changes in brief.
