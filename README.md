# International Project Management System

> [!WARNING]
> WIP: Project still not working properly

## Features

## Getting started
### Prerequisite
- PostgreSQL
- .NET Core SDK 8.0
- Entity Framework Core Tools (dotnet tool install --global dotnet-ef) 

> [!TIP]
> ```bash
> # make file dn executable
> chmod +x ipm
> # run with flag --help to see available commands
> ./ipm --help
> ```
> ```txt
>  A small script to make dev life better
>  USAGE: ipm [COMMAND]
>
>  COMMAND:  fe:dev          Run FE dev
>            fe:build        Build FE
>            fe:install      Install FE dependencies
>            be:run          Run
>            be:dev          Run and hot reload
>            mg:new <name>   Make new migration
>            mg:remove       Remove migration
>            db:update       Update database
>            db:drop         Drop database
> ```

### Development 
```bash
# Build front-end
./ipm fe:build
# Run back-end 
./ipm be:run
```

### Production 

## More
[Documents](/docs/README.md)

## Will fix
- [ ] Prevent users sign up with role

## Feature Wishlist
- [x] Implement JWT
- [ ] Implement Google OAuth
