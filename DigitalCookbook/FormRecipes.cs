namespace DigitalCookbook
{
    public partial class FormRecipes : Form
    {
        RecipeContext recipeDb;
        List<Recipe> recipes;
        public FormRecipes()
        {
            InitializeComponent();
            recipeDb = new RecipeContext();
            recipes = recipeDb.Recipes.Select(r => r).ToList();

            DisplayRecipeCards();
        }
        public FormRecipes(RecipeCard? newCard)
        {
            recipeDb = new RecipeContext();
            InitializeComponent();
            try
            {
                recipeDb.Recipes.Add(newCard.GetRecipe());
                recipeDb.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed Adding Recipe");
            }

            recipes = recipeDb.Recipes.Select(r => r).ToList();
            DisplayRecipeCards();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FormCreate formCreate = new FormCreate();
            formCreate.Tag = this;
            formCreate.StartPosition = FormStartPosition.Manual;
            formCreate.Location = Location;
            formCreate.Show();
            Hide();
        }
        private void FormRecipes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void txtSearchRecipe_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchRecipe.Text != String.Empty)
            {
                recipes = recipeDb.Recipes.Where(r => r.RecipeName.Contains(txtSearchRecipe.Text)).ToList();
                DisplayRecipeCards();
            }
            else
            {
                recipes = recipeDb.Recipes.Select(r => r).ToList();
                DisplayRecipeCards();
            }
        }
        private void chkOnlyFavorites_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOnlyFavorites.Checked)
                recipes = recipeDb.Recipes.Where(r => r.IsFavorited).ToList();
            else
                recipes = recipeDb.Recipes.Select(r => r).ToList();
            DisplayRecipeCards();

        }
        private void RecipeCard_Click(object sender, EventArgs e)
        {
            RecipeCard clickedCard = (RecipeCard)sender;
            FormDetailedRecipe formDetailed = new FormDetailedRecipe(clickedCard.GetRecipe());
            formDetailed.Tag = this;
            formDetailed.StartPosition = FormStartPosition.Manual;
            formDetailed.Location = Location;
            formDetailed.Show();
            Hide();
        }
        private void AddRecipeCard(RecipeCard recipeCard)
        {
            recipeCard.Click += RecipeCard_Click;
            floRecipeCards.Controls.Add(recipeCard);
        }

        private void DisplayRecipeCards()
        {
            floRecipeCards.Controls.Clear();
            foreach (Recipe recipe in recipes)
            {
                AddRecipeCard(recipe.CreateRecipeCard());
            }
        }

        
    }
}