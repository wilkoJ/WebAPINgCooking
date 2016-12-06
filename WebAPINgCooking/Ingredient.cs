namespace WebAPINgCooking
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ingredient")]
    public partial class Ingredient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ingredient()
        {
            Recipes = new HashSet<Recipe>();
        }

        public int ingredientId { get; set; }

        public int cateogryId { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        public string picture { get; set; }

        public int calories { get; set; }

        public virtual CategoryIngredient CategoryIngredient { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
