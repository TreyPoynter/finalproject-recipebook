using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCookbook
{
    public sealed class Recipe
    {
        private string _recipeName = String.Empty;
        private byte[] _recipeImage;
        private bool _isFavorited;
        private string _steps = String.Empty;

        public int RecipeID { get; set; }
        public string RecipeName
        {
            get { return _recipeName; }
            set { _recipeName = value; }
        }
        public byte[] RecipeImage
        {
            get { return _recipeImage; }
            set { _recipeImage = value; }
        }
        public bool IsFavorited
        {
            get { return _isFavorited; }
            set { _isFavorited = value; }
        }
        public string Steps
        {
            get { return _steps; }
            set { _steps = value; }
        }

        public Recipe()
        {}

        public Recipe(string recipeName, byte[] recipeImage, bool isFavorite, string steps)
        {
            RecipeName = recipeName;
            RecipeImage = recipeImage;
            IsFavorited = isFavorite;
            Steps = steps;
        }

        public RecipeCard CreateRecipeCard()
        {
            return new RecipeCard(this);
        }
        public Image ByteArrayToImage()
        {
            using (MemoryStream memstr = new MemoryStream(RecipeImage))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }
    }
}
