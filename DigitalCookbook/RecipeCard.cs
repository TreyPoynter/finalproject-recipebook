using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            recipeImage = ByteArrayToImage(recipe.RecipeImage);
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
        private Image ByteArrayToImage(byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }
    }
}
