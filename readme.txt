A simple .netcore MVC solution for a TODO list 
Solution can use Entity framework in memory database implementation,mock data implemantation and sql server implementation.You can choose 
whichever you want by just changing the service by dependency injection.
If you want to use sql server implementation you must create tables in SQL server database.
Using steps are following:

services.AddTransient<IToDoListRepository, MockToDoListRepository>();   //If you want to use mock data
services.AddTransient<IToDoListRepository, InMemoryToDoListRepository>();   // IF you want to use EFCore in memory implementation
services.AddDbContext<TODOContext>(options=>options.UseSqlServer("Server=localhost;Database=TODO;Trusted_Connection=True;"));   //If you want to use
												SQL server database