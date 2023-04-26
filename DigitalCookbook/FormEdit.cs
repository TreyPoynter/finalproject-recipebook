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
        int recipeID;
        private RecipeContext recipeDB;
        private bool xButton = true;
        private Recipe? _recipe;
        private Image recipeImage;
        public FormEdit(Recipe recipeToEdit)
        {
            recipeDB = new RecipeContext();
            InitializeComponent();
            _recipe = recipeToEdit;
            recipeImage = recipeToEdit.ByteArrayToImage();
            recipeID = recipeToEdit.RecipeID;

            Point pos = picIsFavorite.Parent.PointToScreen(picIsFavorite.Location);
            pos = picRecipeImage.PointToClient(pos);
            picIsFavorite.Parent = picRecipeImage;
            picIsFavorite.Location = pos;
            picIsFavorite.BackColor = Color.Transparent;
            rchSteps.Text = String.Empty;
            picRecipeImage.Image = recipeImage;
            picIsFavorite.Visible = _recipe.IsFavorited;
            txtRecipeName.Text = _recipe.RecipeName;
            chkIsFavorited.Checked = _recipe.IsFavorited;
            foreach (string step in _recipe.Steps.Split("~~"))
            {
                rchSteps.Text += $"{step}\n";
            }
        }
        private void FormEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (xButton)
                Application.Exit();
        }
        private void btnImageSelector_Click(object sender, EventArgs e)
        {
            recipeImage = ShowFileDiaglog();
            _recipe.RecipeImage = ImageToByteArray(recipeImage);
        }

        private void chkIsFavorited_CheckedChanged(object sender, EventArgs e)
        {
            picIsFavorite.Visible = chkIsFavorited.Checked;
        }
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                Recipe? updatedRecipe = recipeDB.Recipes.Find(recipeID);

                if (updatedRecipe != null)
                {
                    updatedRecipe.RecipeName = txtRecipeName.Text;
                    updatedRecipe.IsFavorited= chkIsFavorited.Checked;
                    updatedRecipe.RecipeImage = ImageToByteArray(recipeImage);
                    updatedRecipe.Steps = String.Join("~~", rchSteps.Text.Split('\n'));
                    _recipe = updatedRecipe;
                    try
                    {
                        recipeDB.Recipes.Update(updatedRecipe);
                        recipeDB.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error saving recipe changes");
                    }
                }

                xButton = false;
                FormDetailedRecipe detailedRecipe = new FormDetailedRecipe(_recipe);
                detailedRecipe.Tag = this;
                detailedRecipe.StartPosition = FormStartPosition.Manual;
                detailedRecipe.Location = Location;
                detailedRecipe.Show();
                Close();
            }
            
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Recipe? recipeToDelete = recipeDB.Recipes.Find(recipeID);

            if (recipeToDelete != null)
            {
                try
                {
                    recipeDB.Recipes.Remove(recipeToDelete);
                    recipeDB.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show($"Failed to delete {_recipe.RecipeName}");
                }
            }

            xButton = false;
            FormRecipes formRecipes = new FormRecipes();
            formRecipes.Tag = this;
            formRecipes.StartPosition = FormStartPosition.Manual;
            formRecipes.Location = Location;
            formRecipes.Show();
            Close();
        }

        private Image ShowFileDiaglog()
        {
            Image image = recipeImage;
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
        public byte[] ImageToByteArray(Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        private bool ValidateFields()
        {
            if (String.IsNullOrWhiteSpace(txtRecipeName.Text))
            {
                MessageBox.Show("Recipe must have a name");
                return false;
            }
            else if (String.IsNullOrWhiteSpace(rchSteps.Text))
            {
                MessageBox.Show("Recipe must have atleast 1 step");
                return false;
            }
            return true;
        }
    }
}
