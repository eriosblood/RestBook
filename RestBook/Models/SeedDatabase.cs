namespace RestBook.Models
{
    public static class SeedDatabase
    {
        public static void Seed(BookContext context)
        {
            
            if (context.Books.Any())
            {
                return;   
            }

            var books = new Book[]
            {
                 new Book{AuthorFirstName="Jerry",AuthorLastName="Seinfeld",Publisher="NBC", Price = 8.75m, Title = "I can't take it anymore!"},
                 new Book{AuthorFirstName="Harry",AuthorLastName="Bofunda",Publisher="CBS", Price = 7.75m, Title = "I'm an architect" },
                 new Book{AuthorFirstName="Elaine",AuthorLastName="Lambert",Publisher="TNT", Price = 8.50m, Title = "So you think you're sponge worthy?" },
                 new Book{AuthorFirstName="Cosmo",AuthorLastName="Kramer",Publisher="ABC", Price = 6.25m, Title = "Giddy up"},
                 new Book{AuthorFirstName="Robert",AuthorLastName="Olaf",Publisher="TBS", Price = 2.25m, Title = "Mail man"},
                 new Book{AuthorFirstName="Peterman",AuthorLastName="Troiano",Publisher="ESPN", Price = 1.29m, Title = "Boss man"},
                 new Book{AuthorFirstName="Peter",AuthorLastName="Piper",Publisher="COM", Price = 5.25m, Title = "Picks Peppers"},
                 new Book{AuthorFirstName="Jim",AuthorLastName="Jones",Publisher="REA", Price = 6.76m, Title = "How do you do?"},
                 new Book{AuthorFirstName="Jimmy",AuthorLastName="Sinefield",Publisher="CBS", Price = 8.78m, Title = "Hello Newman"},
                 new Book{AuthorFirstName="George",AuthorLastName="Costanza",Publisher="TNT", Price = 7.71m, Title = "I was in the pool!" },
                 new Book{AuthorFirstName="Elaine",AuthorLastName="Benes",Publisher="YIN", Price = 8.52m, Title = "I'm Queen of the castle" },
                 new Book{AuthorFirstName="Karl",AuthorLastName="Rutkis",Publisher="GEB", Price = 2.34m, Title = "What's going on?"},
                 new Book{AuthorFirstName="Newman",AuthorLastName="Newman",Publisher="ESPN", Price = 2.15m, Title = "It's fool proof"},
                 new Book{AuthorFirstName="Peterman",AuthorLastName="Peterman",Publisher="ORG", Price = 6.25m, Title = "Very interesting, let me buy it"},
                 new Book{AuthorFirstName="Frankie",AuthorLastName="Vernali",Publisher="EAR", Price = 5.25m, Title = "Apples and oranges"},
                 new Book{AuthorFirstName="Jim",AuthorLastName="Jones",Publisher="PLA", Price = 6.06m, Title = "Get it going"}

            };

            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}

