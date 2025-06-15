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
- [ ] Catch email existing SQL error
- [ ] Prevent users sign up with role
- [ ] Data return in order by createDate 

## Feature Wishlist
- [x] Implement JWT
- [ ] Implement Google OAuth
