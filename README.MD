# DotNetEfCoreConsoleBlogging

### Illustrate an anomaly between EF LocalDB and SqLite using the same classes

Basically the problem is that in the SqLite version when a new Blog that contains some Posts are added to the current DbContext (BloggingContext) the relationship exists 
between the Blogs and it's Posts can be seen.
Once that specific context is released, after a SaveChanges() the relationship is gone although the individual Blogs and Posts are still in the SqLite database. 
With the LoclDB version the relationship is maintained between closing and reopening the context.

This project is a console app utilitizing the same .net core libraries as the [WPF, and UWP sample](https://github.com/jhalbrecht/EfBlogging) version in this 
more complex project reposotiry of mine.
I noticed an oddity and was asked to file an issue on the ef repository with a simplified code set. The WPF / LocalDB version of the project worked as expected where
the UWP / SqLite version exibitied the odd behavior documented in this simplified console app. The BLog and Post classes were taken directly from 
Microsoft examples such as [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/index).

I wrote up some extensive documentation of the problem here;
Issue #1 [Microsoft.EntityFrameworkCore.Sqlite DbContext SaveChanges() inconsistent behavior](https://github.com/jhalbrecht/EfBlogging/issues/1)

Don't forget to 
* Add-Migration Initial
* Update-Database


I've set a couple `Debugger.Breakpoin();` in the code at good spots to examine the current context Blogs inspect for multiple Posts in the Blog.Posts `List<T>`

