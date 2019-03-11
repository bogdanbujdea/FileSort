dotnet tool uninstall -g FileSort.cli
dotnet build
dotnet pack
dotnet tool install --global --add-source ./nupkg FileSort.cli
pause