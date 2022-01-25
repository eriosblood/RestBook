# Cascade_Backend_Developer_Assessment
# Joshua Stone 01/24/2022

# Our BooksController contains all of our good API methods and work. Each of the requested HTTPGet's are found here as 
# well as the stored procedure calls. You can run the project and be set up with a local db along with seed data thanks to SeedDatabase in models.

# 1.  [HttpGet("GetSortedBooksPublisherAuthorTitle")]

# 2.  [HttpGet("GetSortedBooksAuthorTitle")]

# 3. 
#     CREATE TABLE [dbo].[Books] (
#     [Id]              INT             IDENTITY (1, 1) NOT NULL,
#     [Publisher]       NVARCHAR (MAX)  NULL,
#     [Title]           NVARCHAR (MAX)  NULL,
#     [AuthorLastName]  NVARCHAR (MAX)  NULL,
#     [AuthorFirstName] NVARCHAR (MAX)  NULL,
#     [Price]           DECIMAL (18, 2) NULL
#      );

# 4. [HttpGet("GetSortedBooksPublisherAuthorTitleSproc")]
#    [HttpGet("GetSortedBooksAuthorTitleSproc")]


# 5. [HttpGet("GetTotalBooksPrice")]

# 6. You would want to batch items up in transactions to avoid the round trips going back to the database server and back to the backend for every single item. 
#    You can also use BulkCopy or sql insert commands with parameters and execute them all in one batch.

# 7. [HttpGet("GetMlaCitation/{id}")]

# 8. [HttpGet("GetChicagoCitation/{id}")]