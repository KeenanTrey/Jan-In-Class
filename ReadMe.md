# Notes on setting up client servier in Visual Studio

1. Create Web Application project (Use separate names for project and solution)
2. Update Nuget packages
3. Add a class library project for the BLL/DAL
4. Add a class library project for the entities 
5. Add a nuget package for all project (Entity framework 6)
6. Add references between the projects
 - WebApp needs to access both libraries
 - BLL/DAL needs to access the Entities
