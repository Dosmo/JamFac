using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model
{
    class Rating
    {
        public string TestPerson { get; set; }
        public string Comment { get; set;}
        /* Da klassen hedder rating kan variablen ikke hedde det. */
        public int aRating { get; set; }
        public Rating(string TestPerson, string Comment, int Rating) {
            this.TestPerson = TestPerson;
            this.Comment = Comment;
            this.aRating = Rating;
        }
    }
}
