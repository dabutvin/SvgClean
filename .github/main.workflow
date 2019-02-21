workflow "PRs" {
  on = "pull_request"
  resolves = ["dotnet test"]
}

action "dotnet build" {
  uses = "twitchax/actions/dotnet/cli@master"
  args = "build"
}

action "dotnet test" {
  uses = "twitchax/actions/dotnet/cli@master"
  needs = ["dotnet build"]
  args = "test"
}
