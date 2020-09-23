# CNX - Backend Test

&nbsp;&nbsp;&nbsp;&nbsp; Project developed as a personal challenge and for learning purposes.

## Features

**1 - User registration and authentication using JWT:**  

&nbsp;&nbsp;&nbsp;&nbsp; Web api capable of registering and authenticating a user through JWT.  

**2 - Weather conditions:**  

&nbsp;&nbsp;&nbsp;&nbsp; Through the already authenticated user, the web api is capable of consulting the current weather conditions on user's hometown, integrating with WeatherMaps.

**3 - Spotify playlists recommendation:**   

After discovering the user's current weather conditions, the web api is able to integrate with Spotify and, depending on the current temperature, suggest different types of playlist to the user.  

## Requirements

&nbsp;&nbsp;&nbsp;&nbsp; **1** - .Net Core 3.1

&nbsp;&nbsp;&nbsp;&nbsp; **2** - SqlServer

## Installing

### 1 - Database

&nbsp;&nbsp;&nbsp;&nbsp; **1** - This project was developed using EF code first and SqlServer, so you have 2 options to create the database.  

#### Option 1: Executing the database script

&nbsp;&nbsp;&nbsp;&nbsp; **1.1** - Simply run the script in "./Resources/database_script.sql" to restore the database.

#### Option 2: Using migrations

&nbsp;&nbsp;&nbsp;&nbsp; **1.1** - Make sure you have dotnet Entity Framework installed on you machine.

&nbsp;&nbsp;&nbsp;&nbsp; **1.2** - Create the database and update the ConnectionStrings, as mentioned on step **3**

&nbsp;&nbsp;&nbsp;&nbsp; **1.3** - On the directory "./cnx/CNX" , run the command:
```
dotnet ef database update
```
**If you created the database manually and now want to update it using migrations, you will need to clean "Migrations" directory and initialize migrations first. See: https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli for more details**
### 2 - Keys

&nbsp;&nbsp;&nbsp;&nbsp; **1** - Update appsettings.json with your WeatherMaps and Spotify's authentication keys.
You can use these if you want to save time:
```
  "WeatherMapsApiConfiguration": {
    "ApiKey": "6a743072d97325ae4670dbefa8e3886f"
  },
  "SpotifyApiConfiguration": {
    "ClientId": "ba9f414c86814e4c869fd40e41029622",
    "ClientSecret": "8115269e04584034813950c189d06001"
  }
```
**Be aware that these are personal keys and will be deactivated soon.**

### 3 - Database ConnectionString

&nbsp;&nbsp;&nbsp;&nbsp; **1** - Make sure you update the ConnectionStrings section with the correct one on appsettings.json, following your server name and SqlServer instance.

### 4 - Email setup (OPTIONAL)

&nbsp;&nbsp;&nbsp;&nbsp;**1** - If you want to use the endpoint to reset users passwords, you will need to configure appsettings.json with a Google Gmail account credentions on:

```
"EmailConfiguration": {
    "DisplayName": "xxx",
    "Host": "smtp.gmail.com",
    "Mail": "from",
    "Password": "pwd",
    "Port": 587
  }
```

## NOTES

* The web api is fully documented using Swagger (maybe not fully, but you get it :) ). Swagger-ui is configured to open on the root endpoint. Ex:http://localhost:5000 
* You can find a Postman collection file on "./Resources". Import that file into your Postman to have all endpoints already configured and ready to use. Be aware that you will still need to configure the url (if you change the port or something like that) and manually change the Bearer token on the requests headers after authentication
* To use Swagger-ui to test the api, first login into the api using the endpoint *"POST v1/authentication/login"*. The response will contain a JWT token. Use this token on the top right button on Swagger-ui, called "Authorize". **Don't forget to input the word "Bearer " as the token prefix, otherwise, it wont't work. Ex: Bearer  xxxyyyzzz**


