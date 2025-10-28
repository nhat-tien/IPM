<h1 align="center">International Project Management System</h1>

[![License](https://img.shields.io/badge/License-MIT-green.svg?style=plastic)](LICENSE)
[![.Net Core](https://img.shields.io/badge/.Net%20Core-8.0-blue?style=plastic&logo=dotnet)](https://dotnet.microsoft.com/)
[![SvelteKit](https://img.shields.io/badge/SvelteKit-2.21-orange?style=plastic&logo=svelte)](https://svelte.dev/)

> [!WARNING]
> WIP: Project under development 

## Getting started
### Prerequisite
- PostgreSQL
- .NET Core SDK 8.0
- NodeJS (v20 or later)
- Entity Framework Core Tools (dotnet tool install --global dotnet-ef) 
- MinIO - Object storage server

### Development 

**1. Clone this repo**

```bash
git clone https://github.com/nhat-tien/IPM.git
```

> [!tip]
> ```bash
> # make file ipm executable
> chmod +x ipm
>
> # run with flag --help to see available commands
> ./ipm --help
>
> # Run this if you want to add it to PATH, 
> # then you can run just by 'ipm', no need './ipm'
> ./ipm path:add
> ```


**2. Setup database connection**

*2.1. Manual*
- Start your PostgreSQL database

*2.2. Or Docker Compose*
- Open `docker-compose.yml` and fill out the needed information.
- Then run docker compose
```bash
docker compose up -d
```

*2.3. Set up .Env in application*
- Copy `src/IPM.WebApi/appsettings.Example.json` to `src/IPM.WebApi/appsettings.Development.json`
- Fill out the database connection infomation

**3. Run migration**
```bash
./ipm db:update
```

**4. Build frontend**
```bash
./ipm fe:build
```

**5. Run development**
```bash
./ipm be:run
```

**API Documents**
In url `/docs`

### Production 
> [!NOTE]  
> Work in progress

## More
[Documents](/docs/README.md)

## Will fix
- [x] Prevent users sign up with role
- [x] Catch email existing SQL error
- [x] Data return in order by createDate 

## Feature Wishlist
- [ ] Implement Google OAuth
- [x] Implement JWT

## Screenshot
![](/docs/images/screenshot-from-2025-06-27-22-58-16.png)

## Todo
- [ ] Audit log
- [ ] Forget password
- [ ] Lock account
- [ ] Admin:End all project in quarter
- [ ] Admin:List reported project
- [ ] Admin:Send Email
- [ ] Admin:Active "admin role" for user
- [ ] Excel report

## Features

### Authenticate
- Login, sign-up (JWT, access-refresh token)

### Project management
- CRUD project
- Report project
- Cancel project
- Add member, role management
- Upload file, download file, delete file, update information of files

### Profile
- Update profile
- Upload avatar

