# M-Usefull-Methods
Kullandığım Generic Methodlar


// Step 1: Authenticate (if this is the first time) Note you must also pass --store-password-in-clear-text on non-Windows systems.
$ dotnet nuget add source https://nuget.pkg.github.com/mesutozturk/index.json -n github -u mesutozturk -p 7d650105ce1f1b5e0baaf94a34689cfb4ab8ca03 
// Step 2: Pack
$ dotnet pack --configuration Release
// Step 3: Publish
$ dotnet nuget push "MUsefullMethods\bin\Release\UsefullMethods.1.0.0.nupkg" --source "GitHub"