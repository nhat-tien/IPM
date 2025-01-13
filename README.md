# International Project Management System

> [!WARNING]
> WIP: Project still not working properly

## Features

## Getting started
### Prerequisite
- PostgreSQL
- .NET Core SDK 8.0
- NodeJS (v20 or later)
- Entity Framework Core Tools (dotnet tool install --global dotnet-ef) 

### Development 
> [!tip]
> ```bash
> # make file ipm executable
> chmod +x ipm
> # run with flag --help to see available commands
> ./ipm --help
> ```
> ```txt
>  a small script to make dev life better
>  usage: ipm [command]
>
>  command:  fe:dev          run fe dev
>            fe:build        build fe
>            fe:install      install fe dependencies
>            be:run          run
>            be:dev          run and hot reload
>            mg:new <name>   make new migration
>            mg:remove       remove migration
>            db:update       update database
>            db:drop         drop database
> ```

#### 1. Clone this repo 
```bash
git clone https://github.com/nhat-tien/IPM.git
```
#### 2. Setup database connection
- Start your PostgreSQL database
- Copy `appsettings.Example.json` to `appsettings.Development.json`
- Fill out the database connection info

#### 3. Run development 
```bash
./ipm be:run
```

### Production 
> [!NOTE]  
> Work in progress

## More
[Documents](/docs/README.md)

## Will fix
- [ ] Prevent users sign up with role

## Feature Wishlist
- [x] Implement JWT
- [ ] Implement Google OAuth
