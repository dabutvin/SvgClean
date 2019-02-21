workflow "CI" {
  on = "push"
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

workflow "Release" {
  on = "release"
  resolves = ["dotnet nuget push"]
}

action "dotnet build -c Release" {
  uses = "twitchax/actions/dotnet/cli@master"
  args = "build -c Release"
}

action "dotnet pack -c Release" {
  uses = "twitchax/actions/dotnet/cli@master"
  args = "pack -c Release"
  needs = ["dotnet build -c Release"]
}

action "dotnet nuget push" {
  uses = "twitchax/actions/dotnet/nuget-push@master"
  needs = ["dotnet pack -c Release"]
  args = "SvgClean/bin/Release/SvgClean.*.nupkg"
  secrets = ["NUGET_KEY"]
}
