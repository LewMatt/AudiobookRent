using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AudiobookRent.Models
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; }

    }
}