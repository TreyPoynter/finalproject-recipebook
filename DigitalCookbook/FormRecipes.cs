namespace DigitalCookbook
{
    public partial class FormRecipes : Form
    {
        public FormRecipes()
        {
            InitializeComponent();
        }
        public FormRecipes(RecipeCard newCard)
        {
            InitializeComponent();
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
        public void AddRecipeCard(RecipeCard recipeCard)
        {
            recipeCard.Click += RecipeCard_Click;
            floRecipeCards.Controls.Add(recipeCard);
        }

        
    }
}