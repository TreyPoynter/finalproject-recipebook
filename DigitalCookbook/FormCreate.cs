using System.Data;
using System.Runtime.InteropServices;

namespace DigitalCookbook
{
    public partial class FormCreate : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, IntPtr lParam);
        private const uint WM_SETICON = 0x80u;
        private const int ICON_BIG = 1;
        private Image image;
        private bool xButton = true;
        public FormCreate()
        {
            InitializeComponent();
            image = Images._default;
            Point pos = picIsFavorite.Parent.PointToScreen(picIsFavorite.Location);
            pos = picRecipeImage.PointToClient(pos);
            picIsFavorite.Parent = picRecipeImage;
            picIsFavorite.Location = pos;
            picIsFavorite.BackColor = Color.Transparent;
            SendMessage(Handle, WM_SETICON, ICON_BIG, Icons.cookbook.Handle);
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

        private Image ShowFileDiaglog()
        {
            Image image = Images._default;
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
            if (String.IsNullOrWhiteSpace(rchSteps.Text))
            {
                MessageBox.Show("Recipe must atleast 1 step");
                return false;
            }
            return true;
        }
        public RecipeCard CreateRecipeCard()
        {
            string[] steps = rchSteps.Text.Split("\n").Where(t => t != String.Empty).ToArray();
            Recipe recipe = new Recipe(txtRecipeName.Text, ImageHelper.ImageToByteArray(image), chkIsFavorited.Checked, String.Join("~~", steps));

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
    }
}
