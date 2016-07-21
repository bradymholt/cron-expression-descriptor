**NOTE:** The build process should be done from Windows.  Building from Mac/Linux is not supported currently.

# Setup

- cd `/build`
- Dowload latest [nuget.exe](https://nuget.org/nuget.exe) and save
- Run 'nuget SetApiKey [API_KEY] -Source https://www.nuget.org/api/v2/package' to add NuGet API Key to NuGet config
- Install Ruby
- Install Bundler: `gem install bundler`
- Run `bundle install`

# Build

- cd `/build`
- Run `rake build`

# Release to NuGet

- cd `/build`
- Prepend line to `version.txt` with new version number and release notes
- Run `bundle exec rake release`

