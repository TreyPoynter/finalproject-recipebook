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
    public partial class FormEdit : Form
    {
        private Recipe? _recipe;
        public FormEdit(Recipe recipeToEdit)
        {
            InitializeComponent();
            _recipe = recipeToEdit;

            rchSteps.Text = String.Empty;
            picRecipeImage.Image = _recipe.RecipeImage;
            picIsFavorite.Visible = _recipe.IsFavorited;
            txtRecipeName.Text = _recipe.RecipeName;
            chkIsFavorited.Checked = _recipe.IsFavorited;
            foreach (string step in _recipe.Steps)
            {
                rchSteps.Text += $"{step}\n";
            }
        }

        private void btnImageSelector_Click(object sender, EventArgs e)
        {
            _recipe.RecipeImage = ShowFileDiaglog();
        }

        private void chkIsFavorited_CheckedChanged(object sender, EventArgs e)
        {
            picIsFavorite.Visible = chkIsFavorited.Checked;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            // DO THIS LATER
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // DO THIS LATER
        }

        private Image? ShowFileDiaglog()
        {
            Image image = _recipe.RecipeImage;
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
    }
}
