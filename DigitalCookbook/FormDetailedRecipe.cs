using System.Threading;
using System.Runtime.InteropServices;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace DigitalCookbook
{
    public partial class FormDetailedRecipe : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, IntPtr lParam);
        private const uint WM_SETICON = 0x80u;
        private const int ICON_BIG = 1;
        bool enabledTTS = false;
        bool enabledSpeechRec = false;
        private SpeechSynthesizer speechSyn;
        SpeechRecognitionEngine speechRec;
        private uint _currentStep;
        private bool xButton = true;
        private readonly Recipe _recipe;
        public FormDetailedRecipe(Recipe selectedRecipe)
        {
            speechSyn = new SpeechSynthesizer();
            speechRec = new SpeechRecognitionEngine();
            speechRec.SetInputToDefaultAudioDevice();
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
            SendMessage(Handle, WM_SETICON, ICON_BIG, Icons.cookbook.Handle);
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
            speechSyn.Dispose();
            Close();
        }
        private void btnNextStep_Click(object sender, EventArgs e)
        {
            NextStep();
        }
        private void btnRepeatStep_Click(object sender, EventArgs e)
        {
            RepeatStep();
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
        private void chkEnableSpeechRec_CheckedChanged(object sender, EventArgs e)
        {
            enabledSpeechRec = chkEnableSpeechRec.Checked;
        }

        private void NextStep()
        {
            if (_currentStep < _recipe.Steps.Split("~~").Length - 1)
            {
                ++_currentStep;
                DisplayStep();
            }
        }
        private void RepeatStep()
        {
            if (_currentStep > 0)
            {
                --_currentStep;
                DisplayStep();
            }
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
        private async void GetCommand()
        {
            RecognitionResult result = null;
            Grammar word = new DictationGrammar();
            speechRec.LoadGrammar(word);
            speechRec.RecognizeAsync();
            try
            {
                
            }
            catch (Exception)
            {
                MessageBox.Show("Mic not found");
            }
        }
    }
}
