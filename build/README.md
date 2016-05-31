
# Setup

- Install NuGet (https://nuget.org/nuget.exe)
- Run 'nuget SetApiKey' to add NuGet API Key to NuGet config
- Install Ruby
- Install Bundler: `gem install bundler`
- cd `/build`
- Run `bundle install`

# Build

- cd `/build`
- Run `rake build`

# Release to NuGet

- cd `/build`
- Append new line to `version.txt` with new version number and release notes
- Run `rake release`

