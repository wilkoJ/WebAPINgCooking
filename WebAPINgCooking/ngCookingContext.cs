namespace WebAPINgCooking
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ngCookingContext : DbContext
    {
        public ngCookingContext()
            : base( "name=ngCookingContext" )
        {
        }

        public virtual DbSet<CategoryIngredient> CategoryIngredients { get; set; }
        public virtual DbSet<CategoryRecipe> CategoryRecipes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Entity<CategoryIngredient>()
                .Property( e => e.name )
                .IsUnicode( false );

            modelBuilder.Entity<CategoryIngredient>()
                .HasMany( e => e.Ingredients )
                .WithRequired( e => e.CategoryIngredient )
                .HasForeignKey( e => e.categoryId )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<CategoryRecipe>()
                .Property( e => e.name )
                .IsUnicode( false );

            modelBuilder.Entity<CategoryRecipe>()
                .HasMany( e => e.Recipes )
                .WithRequired( e => e.CategoryRecipe )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<Ingredient>()
                .Property( e => e.name )
                .IsUnicode( false );

            modelBuilder.Entity<Ingredient>()
                .Property( e => e.picture )
                .IsUnicode( false );

            modelBuilder.Entity<Ingredient>()
                .HasMany( e => e.Recipes )
                .WithMany( e => e.Ingredients )
                .Map( m => m.ToTable( "RecipeIngredient" ).MapLeftKey( "ingredientId" ).MapRightKey( "recipeId" ) );

            modelBuilder.Entity<Recipe>()
                .Property( e => e.name )
                .IsUnicode( false );

            modelBuilder.Entity<Recipe>()
                .Property( e => e.picture )
                .IsUnicode( false );

            modelBuilder.Entity<Recipe>()
                .Property( e => e.preparation )
                .IsUnicode( false );

            modelBuilder.Entity<Recipe>()
                .HasMany( e => e.Comments )
                .WithRequired( e => e.Recipe )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<User>()
                .Property( e => e.firstname )
                .IsUnicode( false );

            modelBuilder.Entity<User>()
                .Property( e => e.surname )
                .IsUnicode( false );

            modelBuilder.Entity<User>()
                .Property( e => e.email )
                .IsUnicode( false );

            modelBuilder.Entity<User>()
                .Property( e => e.password )
                .IsUnicode( false );

            modelBuilder.Entity<User>()
                .Property( e => e.city )
                .IsUnicode( false );

            modelBuilder.Entity<User>()
                .Property( e => e.picture )
                .IsUnicode( false );

            modelBuilder.Entity<User>()
                .Property( e => e.bio )
                .IsUnicode( false );

            modelBuilder.Entity<User>()
                .HasMany( e => e.Recipes )
                .WithRequired( e => e.User )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<User>()
                .HasMany( e => e.Comments )
                .WithRequired( e => e.User )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<Comment>()
                .Property( e => e.title )
                .IsUnicode( false );

            modelBuilder.Entity<Comment>()
                .Property( e => e.comment1 )
                .IsUnicode( false );
        }
    }
}
