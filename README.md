# Pressford Consulting News
Deliver news stories to all employees.

Deployed to https://pressfordconsultingnews.azurewebsites.net/

#### Logins
I've setup a couple of dummy logins:

- Publisher login: publisher@pressford.com / publisher
- Employee login: employee@pressford.com / password

You can register your own employess enabled user. The login functionality is very basic, using Microsoft Identity.

#### Setup
You will need Node installed

- Clone this repo
- Run the `RestorePackages.cmd` file
- Update the `DefaultConnection` in _web.config_ if you're not using the local sql server database.
- Use `Task Runner Explorer` in visual studio to run `gulp install` so that js/css files are created.

Should be good to go. I've used Entity Framework Code-First, so the database and tables will be created when the project is run.

Once you've create the publisher/employee users on the register page you will need to create the publisher role.
- Connect to the SQL Server database
- Create the `Publisher` role in the `AspNetRoles` table
- Get the user Id (a GUID) of the admin user
- Add the user id and role id to the `AspNetUserRoles` table
This should really be implemented in the interface, but I haven't had time to do that properly.

