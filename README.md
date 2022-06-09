# movies
## Theme - Movies 

This project was designed to be similiar to https://www.imdb.com/. Each movie has basic information (title, description, year, poster...), it can have one or more gneres and it has people (actors, directors, producers).

**Techonlogies used: HTML, CSS, Angular, ASP.NET**


## Functionalities

Project has different user roles.
**Unauthorized users** can see and search all the movies by different criteria (movie name, movie type, genre, actors...).
**Authorized users** can, apart from everything above, rate the movies, comment and add them to a watchlist.
**Admin** can insert, update and delete records from all tables.
The login was done with a token that has a limited duration.
There is also a **mailing list** done with **Background worker**.
**Unit tests** are written for some of the projects.


## Project structure

The solution is divided into multiple layers: API, Application, BusinessLogic, DataAccess, Domain, Email, Implementation.
Also layers for unit testing: Api.Test, BusinessLogic.Test, Implementation.Test.
