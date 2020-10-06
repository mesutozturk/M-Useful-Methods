# M-Usefull-Methods
Kullandığım Generic Methodlar
![WindowsCI](https://github.com/mesutozturk/M-Useful-Methods/workflows/WindowsCI/badge.svg?branch=main&event=push)
![UbuntuCI](https://github.com/mesutozturk/M-Useful-Methods/workflows/UbuntuCI/badge.svg?branch=main&event=push)

// Step 1: Authenticate (if this is the first time) Note you must also pass --store-password-in-clear-text on non-Windows systems.
$ dotnet nuget add source https://nuget.pkg.github.com/mesutozturk/index.json -n github -u mesutozturk -p xx 
// Step 2: Pack
$ dotnet pack --configuration Release
// Step 3: Publish
$ dotnet nuget push "MUsefulMethods\bin\Release\UsefullMethods.1.0.0.nupkg" --source "GitHub"

dotnet nuget push MUsefulMethods\bin\Release\UsefullMethods.1.0.0.nupkg --api-key xxx --source https://api.nuget.org/v3/index.json
