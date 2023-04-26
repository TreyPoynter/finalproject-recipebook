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
    public partial class FormDetailedRecipe : Form
    {
        private uint _currentStep;
        private bool xButton = true;
        private readonly Recipe _recipe;
        public FormDetailedRecipe(Recipe selectedRecipe)
        {
            InitializeComponent();
            _currentStep = 0;
            _recipe = selectedRecipe;
            ShowDetails();
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

        public void ShowDetails()
        {
            lblRecipeName.Text = _recipe.RecipeName;
            picRecipeImage.Image = _recipe.ByteArrayToImage();
            picIsFavorite.Visible = _recipe.IsFavorited;
            DisplayStep();
        }
        public void DisplayStep()
        {
            rtbSteps.Text = $"Step {_currentStep + 1} : {_recipe.Steps.Split("~~")[_currentStep]}";
        }
    }
}
