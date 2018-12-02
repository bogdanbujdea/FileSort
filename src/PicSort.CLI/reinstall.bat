dotnet tool uninstall -g picsort.cli
dotnet build
dotnet pack
dotnet tool install --global --add-source ./nupkg picsort.cli
pause