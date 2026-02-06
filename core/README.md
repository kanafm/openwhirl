Usage:
```
cd openwhirl
dotnet clean core

# compile
dotnet build core

# run the compiled application
dotnet ./core/bin/Debug/net8.0/Core.dll
```

Development:
```
# builds and runs the application (useful for development)
dotnet run --project core
```

The entrypoint is [Program.cs](./Program.cs)