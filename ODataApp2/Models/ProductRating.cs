using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ODataApp2.Models
{
    [Table("production.product_ratings")]
    public partial class ProductRating
    {
        //private static int proId = 1;

        [Key]
        public int id { get; set; }
        public int rating { get; set; }
        public int product_id { get; set; }
        public virtual Product Product { get; set; }

        //public static int generateId()
        //{
        //    return proId++;
        //}

    }
}