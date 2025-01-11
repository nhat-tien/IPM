# DOCUMENT 

## Short Description
### About 

### Technology
- ASP.NET core
- SvelteKit

### Why I choose SvelteKit
- Easy to learn 
- Fast and small bundle
- I want to learn Svelte

## Table of contents
- [Architecture](/docs/architecture.md)

## Notes

### Resource Model
Each entity in domain at least has:
- 4 usecase folders (create, update, delete, getall)
    - Each usecase folder has an interface, a handler (or a request dto)
- 2 class: interface repo and impl repo
- 1 endpointmap class 
- 2 validators
- Add map feature to infras entity
- Register service at UseCaseService, ValidatorService, InfrastureService

