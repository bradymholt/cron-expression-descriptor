
# Releasing

## Publishing library to NuGet

The `.github/workflows/publish.yml` GitHub Actions Workflow handles publishing new releases.

When the API key expires you will see a failure in the workflow ("The specified API key is invalid, has expired, or does not have permission to access the specified package").  You will need to regenerate the API key in [NuGet](https://www.nuget.org/account/apikeys) and update the `NUGET_API_KEY` [repository secret](https://github.com/bradymholt/cron-expression-descriptor/settings/secrets/actions).


## Deploying the Demo site

The demo site is automatically built and deployed using the `.github/workflows/demo_site.yml` GitHub Actions workflow.  The demo site is hosted on GitHub Pages.

