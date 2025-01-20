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

#### 1. Clone this repo 
```bash
git clone https://github.com/nhat-tien/IPM.git
```
#### 2. Setup database connection
- Start your PostgreSQL database
- Copy `src/IPM.WebApi/appsettings.Example.json` to `src/IPM.WebApi/appsettings.Development.json`
- Fill out the database connection infomation

#### 3. Run migration 
```bash
./ipm db:update
```

#### 4. Run development 
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
- [ ] Data return in order by createDate 

## Feature Wishlist
- [x] Implement JWT
- [ ] Implement Google OAuth
