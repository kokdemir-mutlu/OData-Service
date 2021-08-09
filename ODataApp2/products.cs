namespace ODataApp2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("production.products")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            stocks = new HashSet<Stock>();
        }

        [Key]
        public int product_id { get; set; }

        [Required]
        [StringLength(255)]
        public string product_name { get; set; }

        [ForeignKey("brands")]
        public int brand_id { get; set; }

        [ForeignKey("categories")]
        public int category_id { get; set; }

        public short model_year { get; set; }

        public decimal list_price { get; set; }

        public virtual Brand brands { get; set; }

        public virtual Category categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> stocks { get; set; }
    }
}
