using System.Data;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace DigitalCookbook
{
    public partial class FormEdit : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, IntPtr lParam);
        private const uint WM_SETICON = 0x80u;
        private const int ICON_BIG = 1;
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
            Text = $"Digital Cookbook - {_recipe.RecipeName} : Edit Mode";
            SendMessage(Handle, WM_SETICON, ICON_BIG, Icons.cookbook.Handle);
            foreach (string step in _recipe.Steps.Split("~~"))
            {
                if (step != string.Empty)
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
            if (_recipe != null)
                _recipe.RecipeImage = ImageHelper.ImageToByteArray(recipeImage);
        }
        private void chkIsFavorited_CheckedChanged(object sender, EventArgs e)
        {
            picIsFavorite.Visible = chkIsFavorited.Checked;
        }
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                try
                {
                    _recipe = recipeDB.Recipes.Find(recipeID);
                }
                catch (Exception)
                {
                    MessageBox.Show("There was an error on our end updating your recipe");
                }

                if (_recipe != null)
                {
                    _recipe.RecipeName = txtRecipeName.Text;
                    _recipe.IsFavorited= chkIsFavorited.Checked;
                    _recipe.RecipeImage = ImageHelper.ImageToByteArray(recipeImage);
                    _recipe.Steps = String.Join("~~", rchSteps.Text.Split('\n').Where(t => t != String.Empty));
                    try
                    {
                        recipeDB.Recipes.Update(_recipe);
                        recipeDB.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("There was an error on our end updating your recipe");
                    }
                }

                xButton = false;
                FormDetailedRecipe detailedRecipe = new FormDetailedRecipe(_recipe!);
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
                    MessageBox.Show($"Failed to delete {recipeToDelete.RecipeName}");
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
