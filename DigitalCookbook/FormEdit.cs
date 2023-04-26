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
        private Image recipeImage;
        public FormEdit(Recipe recipeToEdit)
        {
            InitializeComponent();
            _recipe = recipeToEdit;
            recipeImage = ByteArrayToImage(recipeToEdit.RecipeImage);

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

        private void btnImageSelector_Click(object sender, EventArgs e)
        {
            _recipe.RecipeImage = ImageToByteArray(recipeImage);
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
        public Image ByteArrayToImage(byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
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
