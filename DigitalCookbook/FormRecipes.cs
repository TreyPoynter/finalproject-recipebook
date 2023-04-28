using System.Runtime.InteropServices;

namespace DigitalCookbook
{
    public partial class FormRecipes : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, IntPtr lParam);
        private const uint WM_SETICON = 0x80u;
        private const int ICON_BIG = 1;

        RecipeContext recipeDb;
        List<Recipe> foundRecipes;
        public FormRecipes()
        {
            InitializeComponent();
            recipeDb = new RecipeContext();
            foundRecipes = recipeDb.Recipes.Select(r => r).ToList();
            SendMessage(Handle, WM_SETICON, ICON_BIG, Icons.cookbook.Handle);

            DisplayRecipeCards();
        }
        public FormRecipes(RecipeCard newCard)
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
                MessageBox.Show("There was an issue adding the recipe");
            }
            SendMessage(Handle, WM_SETICON, ICON_BIG, Icons.cookbook.Handle);
            foundRecipes = recipeDb.Recipes.Select(r => r).ToList();
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
            if (txtSearchRecipe.Text != String.Empty && chkOnlyFavorites.Checked)
                foundRecipes = recipeDb.Recipes.Where(r => r.RecipeName.Contains(txtSearchRecipe.Text) && r.IsFavorited).ToList();
            else if (txtSearchRecipe.Text != String.Empty)
                foundRecipes = recipeDb.Recipes.Where(r => r.RecipeName.Contains(txtSearchRecipe.Text)).ToList();
            else
                foundRecipes = recipeDb.Recipes.Select(r => r).ToList();
            DisplayRecipeCards();
        }
        private void chkOnlyFavorites_CheckedChanged(object sender, EventArgs e)
        {
            if (txtSearchRecipe.Text != String.Empty && chkOnlyFavorites.Checked)
                foundRecipes = recipeDb.Recipes.Where(r => r.RecipeName.Contains(txtSearchRecipe.Text) && r.IsFavorited).ToList();
            else if (chkOnlyFavorites.Checked)
                foundRecipes = recipeDb.Recipes.Where(r => r.IsFavorited).ToList();
            else if (txtSearchRecipe.Text != String.Empty)
                foundRecipes = recipeDb.Recipes.Where(r => r.RecipeName.Contains(txtSearchRecipe.Text)).ToList();
            else
                foundRecipes = recipeDb.Recipes.Select(r => r).ToList();
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
            recipeCard.Click += RecipeCard_Click!;
            floRecipeCards.Controls.Add(recipeCard);
        }
        private void DisplayRecipeCards()
        {
            floRecipeCards.Controls.Clear();
            foreach (Recipe recipe in foundRecipes)
            {
                AddRecipeCard(recipe.CreateRecipeCard());
            }
        }
    }
}