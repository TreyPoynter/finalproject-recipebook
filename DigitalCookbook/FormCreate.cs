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
    public partial class FormCreate : Form
    {
        private Image? image;
        private bool xButton = true;
        public FormCreate()
        {
            InitializeComponent();
            Point pos = picIsFavorite.Parent.PointToScreen(picIsFavorite.Location);
            pos = picRecipeImage.PointToClient(pos);
            picIsFavorite.Parent = picRecipeImage;
            picIsFavorite.Location = pos;
            picIsFavorite.BackColor = Color.Transparent;
        }
        private void FormCreate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (xButton)
                Application.Exit();
        }
        private void btnImageSelector_Click(object sender, EventArgs e)
        {
            image = ShowFileDiaglog();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            BackToMainMenu();
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (ValidateRecipe())
            {
                RecipeCard newRecipeCard = CreateRecipeCard();
                BackToMainMenu(newRecipeCard);
            }
        }
        private void chkIsFavorited_CheckedChanged(object sender, EventArgs e)
        {
            picIsFavorite.Visible = chkIsFavorited.Checked;
        }

        private Image? ShowFileDiaglog()
        {
            Image? image = null;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select an Image";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures).ToString();
            fileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                btnImageSelector.Text = fileDialog.SafeFileName;
                image = Image.FromFile(fileDialog.FileName);
                picRecipeImage.Image = image;
            }
            return image;
        }
        private bool ValidateRecipe()
        {
            if (String.IsNullOrWhiteSpace(txtRecipeName.Text))
            {
                MessageBox.Show("Recipe must have a name");
                return false;
            }
            if (image == null)
            {
                MessageBox.Show("Recipe must have an image");
                return false;
            }
            if (String.IsNullOrWhiteSpace(rchSteps.Text))
            {
                MessageBox.Show("Recipe must atleast 1 step");
                return false;
            }
            return true;
        }
        public RecipeCard CreateRecipeCard()
        {
            string[] steps = rchSteps.Text.Split("\n");
            Recipe recipe = new Recipe(txtRecipeName.Text, ImageToByteArray(image), chkIsFavorited.Checked, String.Join("~~", steps));

            RecipeCard card = recipe.CreateRecipeCard();
            card.Name = $"crd{recipe.RecipeName}";
            return card;
        }
        private void BackToMainMenu()
        {
            FormRecipes formRecipes = new FormRecipes();
            xButton = false;
            formRecipes.Tag = this;
            formRecipes.StartPosition = FormStartPosition.Manual;
            formRecipes.Location = Location;
            formRecipes.Show();
            Close();
        }
        private void BackToMainMenu(RecipeCard recipeCard)
        {
            FormRecipes formRecipes = new FormRecipes(recipeCard);
            xButton = false;
            formRecipes.Tag = this;
            formRecipes.StartPosition = FormStartPosition.Manual;
            formRecipes.Location = Location;
            formRecipes.Show();
            Close();
        }
        public byte[] ImageToByteArray(Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

    }
}
