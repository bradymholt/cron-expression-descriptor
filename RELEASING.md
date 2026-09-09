
# Releasing

## Publishing library to NuGet

The `.github/workflows/publish.yml` GitHub Actions Workflow handles publishing new releases.  It packs and pushes the package to NuGet, commits the version bump to `master`, tags the release, and creates the GitHub Release.

The release tag is only created after the version bump commit lands on `master`, so a tag always points at a commit reachable from `master`.  The workflow shares a `master-push` concurrency group with the demo site workflow so the two cannot push to `master` at the same time, and it rebases and retries if `master` moves anyway.

If a run fails after the NuGet push, just re-run it: `master` still holds the old version so the same version number is recomputed, and `dotnet nuget push --skip-duplicate` makes re-publishing a no-op.

When the API key expires you will see a failure in the workflow ("The specified API key is invalid, has expired, or does not have permission to access the specified package").  You will need to regenerate the API key in [NuGet](https://www.nuget.org/account/apikeys) and update the `NUGET_API_KEY` [repository secret](https://github.com/bradymholt/cron-expression-descriptor/settings/secrets/actions).


## Deploying the Demo site

The demo site is automatically built and deployed using the `.github/workflows/demo_site.yml` GitHub Actions workflow.  The demo site is hosted on GitHub Pages.

