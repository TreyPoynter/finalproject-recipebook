using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace DigitalCookbook
{
    public partial class FormDetailedRecipe : Form
    {
        bool enabledTTS = false;
        private SpeechSynthesizer speechSyn;
        private uint _currentStep;
        private bool xButton = true;
        private readonly Recipe _recipe;
        public FormDetailedRecipe(Recipe selectedRecipe)
        {
            speechSyn = new SpeechSynthesizer();
            InitializeComponent();
            _currentStep = 0;
            _recipe = selectedRecipe;
            ShowDetails();
            Point pos = picIsFavorite.Parent.PointToScreen(picIsFavorite.Location);
            pos = picRecipeImage.PointToClient(pos);
            picIsFavorite.Parent = picRecipeImage;
            picIsFavorite.Location = pos;
            picIsFavorite.BackColor = Color.Transparent;
            Text = $"Digital Cookbook - {_recipe.RecipeName}";
        }
        private void FormDetailedRecipe_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (xButton)
                Application.Exit();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            xButton = false;
            FormRecipes formRecipes = new FormRecipes();
            formRecipes.Tag = this;
            formRecipes.StartPosition = FormStartPosition.Manual;
            formRecipes.Location = Location;
            formRecipes.Show();
            Close();
        }
        private void btnNextStep_Click(object sender, EventArgs e)
        {
            if (_currentStep < _recipe.Steps.Split("~~").Length - 1)
            {
                ++_currentStep;
                DisplayStep();
            }
        }
        private void btnRepeatStep_Click(object sender, EventArgs e)
        {
            if (_currentStep > 0)
            {
                --_currentStep;
                DisplayStep();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormEdit editForm = new FormEdit(_recipe);
            editForm.Tag = this;
            editForm.StartPosition = FormStartPosition.Manual;
            editForm.Location = Location;
            editForm.Show();
            Hide();
        }
        private void chkEnableTTS_CheckedChanged(object sender, EventArgs e)
        {
            enabledTTS = chkEnableTTS.Checked;

            if (enabledTTS)
                TextToSpeech(rtbSteps.Text);
        }

        private void ShowDetails()
        {
            lblRecipeName.Text = _recipe.RecipeName;
            picRecipeImage.Image = _recipe.ByteArrayToImage();
            picIsFavorite.Visible = _recipe.IsFavorited;
            DisplayStep();
        }
        private void DisplayStep()
        {
            rtbSteps.Text = $"Step {_currentStep + 1} : {_recipe.Steps.Split("~~")[_currentStep]}";

            if (enabledTTS)
                TextToSpeech(rtbSteps.Text);
        }

        private void TextToSpeech(string text)
        {
            speechSyn.SpeakAsync(text);
        }
    }
}
