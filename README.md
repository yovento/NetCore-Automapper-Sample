Hello there! I’m **John**, hope this project can help you to learn something or maybe as an start for future projects.

Feel free to grab this code and work on it, if it helps you please don't forget to leave a star.

Let me present this repo.



## NetCore-Automapper-Sample

This is a sample .NetCore 3.1 application which tries to show the way that you can use Automapper to return DTO objects from an ASP.Net Core WebApi, the project is not intended to be used as a template and actually it does not implements much of good practices like interface management and others but with it you can see a clear example of how to return DTO and not your model classes.

**This application** creates an internal in memory database of 2 users (you can change the size of the database in **/Data/DummyDatabase.cs** **GetSampleData** method), this database is added in the **ConfigureServices** method in the **Startup** class as a Singleton so it will preserve the data until you stop the application.

This app does not have UI so you will need to use **PostMan** or other API test application to see it working, the main controller is called Users and has expose all the different actions to interact with the DummyDatabase.

## Sample HTTP Methods
These are simple tests methods to help you build the test requests.  

### GET All
Get all records from the DummyDatabase


Sample CURL:

```
curl -i -X GET \
 'https://localhost:5001/api/users/'
```
### GET One
Get the first record which match with the provided Id (Guid).


Sample CURL:

```
curl -i -X GET \
 'https://localhost:5001/api/Users/3d45b4ff-82a8-4c84-afb5-1bd6aff6d247'
```

### POST
This method adds a record to the DummyDatabase 


Sample CURL:

```
curl -i -X POST \
   -H "Content-Type:application/json" \
   -d \
'{
  "Name": "Test User :)",
  "BirthDate": "1989-11-24",
  "IdentificationNumber": "000000000"
}' \
 'https://localhost:5001/api/users/'
```

### PUT
This method updates a record in the DummyDatabase 


Sample CURL:

```
curl -i -X PUT \
   -H "Content-Type:application/json" \
   -d \
'{
  "Name": "Test User Modified",
  "BirthDate": "1990-04-11",
  "IdentificationNumber": "1111111111"
}' \
 'https://localhost:5001/api/users/a7bed133-8329-4f07-b3bb-be28b5e44b7a'
```

### DELETE
This method deletes the first record which match with the provided id (Guid)


Sample CURL:

```
curl -i -X DELETE \
 'https://localhost:5001/api/users/cd7b3e8c-ed9f-4b72-85ab-bf1d69e7f01e'
```
