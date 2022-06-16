using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AudiobookRent.Models
{
    public class Books
    {
        [Key]
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int PublisherID { get; set; }

    }
}