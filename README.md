#  USEFUL .NET COMMANDS ON LINUX

Add package to project
```psw
dotnet add package <package> --version <version>
```
Create migrations

```psw
dotnet ef migrations add <MigrationName> 
```
Remove the last migrations
```psw
dotnet ef migrations remove 
```

Apply migrations

```psw
dotnet ef database update 
```


