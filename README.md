
# MemeGen

MemeGen is a ASP .NET Core Project. The purpose of this Webapplication is the generation of custom Memes. You can use your own pictures as Template or you can re-use one of the predefined Meme-Templates.  

The Users is able to create and save his collection of Memes within his profile.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

What things you need to install the software and how to install them

```
Give examples
```

### Installing

### Database Models Creation

The Database is MySQL. To create the Models out of MySQL you have to run following command:
```
dotnet ef dbcontext scaffold "server=localhost;database=MGM;user=root;pwd=1234;" "Pomelo.EntityFrameworkCore.MySql" -o ..\MGM.CQRS\Models -f
```

## Running the tests

## Deployment

## Built With

- Visual Studio 2017
- .NET CORE 2.2
- Microsoft SQL Server 2017

## Authors

* **Athavan Theivakulasingham**

See also the list of [contributors](https://github.com/Athiiii/MemeGen/contributors) who participated in this project.

## License
It's only a Project to train my programming skills. 

## Hosting
This Application runs on **Enter domain**

## Mockup

* This image shows the relationship between all Modals and Windows 
![MockupView](documentation/mockup.png?raw=true "Title")

* This image shows the Dabase Schema with the relations
![DBView](documentation/databaseMockupMySQL.png?raw=true "Title")
