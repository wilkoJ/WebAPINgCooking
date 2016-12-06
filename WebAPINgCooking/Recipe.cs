namespace WebAPINgCooking
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Recipe")]
    public partial class Recipe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recipe()
        {
            Comments = new HashSet<Comment>();
            Ingredients = new HashSet<Ingredient>();
        }

        public int recipeId { get; set; }

        public int userId { get; set; }

        public int categoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        public string picture { get; set; }

        public int calories { get; set; }

        [Required]
        public string preparation { get; set; }

        public virtual CategoryRecipe CategoryRecipe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
