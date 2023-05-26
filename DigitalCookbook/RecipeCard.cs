namespace DigitalCookbook
{
    public partial class RecipeCard : UserControl
    {
        private Recipe recipe;
        private Image recipeImage;
        public RecipeCard(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
            recipeImage = recipe.ByteArrayToImage();
        }
        private void RecipeCard_Load(object sender, EventArgs e)
        {
            Point pos = picFavoriteIcon.Parent.PointToScreen(picFavoriteIcon.Location);
            pos = picRecipeImage.PointToClient(pos);
            picFavoriteIcon.Parent = picRecipeImage;
            picFavoriteIcon.Location = pos;
            picFavoriteIcon.BackColor = Color.Transparent;
            picRecipeImage.Image = recipeImage;
            picFavoriteIcon.Visible = recipe.IsFavorited;
            lblRecipeName.Text = recipe.RecipeName;
        }

        public Recipe GetRecipe()
        {
            return recipe;
        }
        private void RecipeCard_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.LightGray;
        }
        private void RecipeCard_MouseLeave(object sender, EventArgs e)
        {
            BackColor = DefaultBackColor;
        }
    }
}
