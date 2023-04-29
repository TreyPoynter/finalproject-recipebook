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
        private SpeechSynthesizer speechSyn;
        private SpeechRecognitionEngine recEngine;
        private Choices choices;
        private uint _currentStep;
        private bool xButton = true;
        private readonly Recipe _recipe;
        public FormDetailedRecipe(Recipe selectedRecipe)
        {
            speechSyn = new SpeechSynthesizer();
            recEngine = new SpeechRecognitionEngine();
            choices = new Choices();
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
            choices.Add(new string[] { "next", "repeat" });
        }
        private void FormDetailedRecipe_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (xButton)
            {
                xButton = false;
                Application.Exit();
            }
                
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
            else
            {
                speechSyn.SpeakAsyncCancelAll();

            }
                
        }
        private void chkEnableSpeechRec_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableSpeechRec.Checked)
                GetCommand();
            else
            {
                recEngine.SpeechRecognized -= RecEngine_SpeechRecognized;
                recEngine.RecognizeAsyncStop();
            }
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
            {
                speechSyn.SpeakAsyncCancelAll();
                TextToSpeech(rtbSteps.Text);
            }
        }
        private void TextToSpeech(string text)
        {
            speechSyn.SpeakAsync(text);
        }
        private void GetCommand()
        {
            Grammar gr = new Grammar(new GrammarBuilder(choices));

            try
            {
                recEngine.RequestRecognizerUpdate();
                recEngine.LoadGrammar(gr);
                recEngine.SpeechRecognized += RecEngine_SpeechRecognized;
                recEngine.SetInputToDefaultAudioDevice();
                recEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception)
            {
                MessageBox.Show("Mic not found");
            }
        }
        private void RecEngine_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToLower().ToString())
            {
                case "next":
                    NextStep();
                    break;
                case "repeat":
                    RepeatStep();
                    break;
            }
        }
    }
}
