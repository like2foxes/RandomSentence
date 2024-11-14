#EFCore #SqlServer #AspNet #WebAPI
Create an API that connects to sql server and expose 2 endpoints: PostSentence, GetRandomSentence.

## Requirements
- PostSentence - As a user I want to be able to save a sentence as part of a pool of sentences.
- GetRandomSentence - As a user I want to be able to get a random sentence from the pool of sentences.

## Preparations: 
- Download sqlserver and understand how to connect to it.
- Get a connection string.

- [x] Start a new AspNet WebAPI project
- [x] Create an appsettings.json file with the sql server connection string
- [x] Install entity framework and entity framework for sql server and entity framework design
- [x] create an AppDbContext class in root/DB/ to inherit from DbContext
- [x] Inject Iconfiguration to AppDbContext
- [x] Create a sentence class (Should only have id and sentence)
- [x] Add DbSet to Context class 
- [x] Create migration
- [x] Update DB
- [x] Add handler for PostSentence
- [ ] Add handler for get random sentence

## Results
At the end of the hour I have finished all but the get method.

## Problems
1. I didn't know that I could use IConfiguration.GetConnectionStrings({name}) to automatically get the connection string if I put it in "ConnectionStrings" section in app.development.json.
2. For the connection string to work I had to add "TrustServerCertificate=True" to be able to connect.
3. Using the nuget cli to install packages has just install them directly in the working directory. Used the dotnet cli instead.
4. I haven't injected IConfiguration to AppDbContex, I have just passed the connection string as a parameter when registering sql server in Program.cs.
5. There was a problem with the get method that prevented me from finishing it in time: It seems that trying to use anonymous lambda in the MapGet method caused it to get a type of delegate I couldn't resolve. 
