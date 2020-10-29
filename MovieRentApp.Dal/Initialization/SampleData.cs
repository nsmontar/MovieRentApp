using System.Collections.Generic;
using MovieRentApp.Models.Entities;

namespace MovieRentApp.Dal.Initialization
{
    public static class SampleData
    {
        public static IEnumerable<Movie> GetAllMovieRecords() => new List<Movie>
        {
            new Movie
            {
                Title = "Swordfish",
                Duration = 95,
                Author = "Dominic Sena",
                Description = "Swordfish is a 2001 American action thriller film directed by Dominic Sena, written by Skip Woods, produced by Joel Silver, and starring John Travolta, Hugh Jackman, Halle Berry, Don Cheadle, Vinnie Jones and Sam Shepard. The film centers on Stanley Jobson, an ex-con and computer hacker who is targeted for recruitment into a bank robbery conspiracy because of his formidable hacking skills."
            },
            new Movie
            {
                Title = "Pirates of Silicon Valley",
                Duration = 120,
                Author = "Martyn Burke",
                Description = "Pirates of Silicon Valley is a 1999 American biographical drama television film directed by Martyn Burke and starring Noah Wyle as Steve Jobs and Anthony Michael Hall as Bill Gates. Spanning the years 1971–1997 and based on Paul Freiberger and Michael Swaine's 1984 book Fire in the Valley: The Making of the Personal Computer, it explores the impact that the rivalry between Jobs (Apple Computer) and Gates (Microsoft) had on the development of the personal computer. The film premiered on TNT on June 20, 1999."
            },
            new Movie
            {
                Title = "The Fifth Estate",
                Duration = 108,
                Author = "Bill Condon",
                Description = "The Fifth Estate is a 2013 biographical thriller film directed by Bill Condon, about the news-leaking website WikiLeaks. The film stars Benedict Cumberbatch as its editor-in-chief and founder Julian Assange, and Daniel Brühl as its former spokesperson Daniel Domscheit-Berg.[6] Anthony Mackie, David Thewlis, Alicia Vikander, Stanley Tucci, and Laura Linney are featured in supporting roles.[7] The film's screenplay was written by Josh Singer based in-part on Domscheit-Berg's book Inside WikiLeaks: My Time with Julian Assange at the World's Most Dangerous Website (2011), as well as WikiLeaks: Inside Julian Assange's War on Secrecy (2011) by British journalists David Leigh and Luke Harding. The film's name is a reference to people who operate in the manner of journalists outside the normal constraints imposed on the mainstream media."
            },
        };

        public static IEnumerable<User> GetAllUserRecords() => new List<User>
        {
            new User
            {
                FirstName = "Tammy",
                LastName = "Foster",
                EmailAddress = "TammyDFoster@rhyta.com",
                Password = "LeeMau3GaoTh"
            },
            new User
            {
                FirstName = "Michael",
                LastName = "Williams",
                EmailAddress = "MichaelJWilliams@dayrep.com",
                Password = "oCh2quahcoo"
            },
            new User
            {
                FirstName = "Sarah",
                LastName = "Perkins",
                EmailAddress = "SarahJPerkins@jourrapide.com",
                Password = "Quai8phei"
            }
        };
    }
}