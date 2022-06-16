using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AudiobookRent.Models
{
    public class Publishers
    {
        [Key]
        public int PublisherID { get; set; }
        public string Name { get; set; }

    }
}