namespace DigitalCookbook
{
    partial class FormDetailedRecipe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetailedRecipe));
            this.picIsFavorite = new System.Windows.Forms.PictureBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnPreviousStep = new System.Windows.Forms.Button();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.rtbSteps = new System.Windows.Forms.RichTextBox();
            this.lblRecipeName = new System.Windows.Forms.Label();
            this.picRecipeImage = new System.Windows.Forms.PictureBox();
            this.chkEnableTTS = new System.Windows.Forms.CheckBox();
            this.chkEnableSpeechRec = new System.Windows.Forms.CheckBox();
            this.btnRepeat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picIsFavorite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipeImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picIsFavorite
            // 
            this.picIsFavorite.Image = global::DigitalCookbook.Images.favorite_icon;
            this.picIsFavorite.Location = new System.Drawing.Point(396, 12);
            this.picIsFavorite.Name = "picIsFavorite";
            this.picIsFavorite.Size = new System.Drawing.Size(62, 62);
            this.picIsFavorite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIsFavorite.TabIndex = 18;
            this.picIsFavorite.TabStop = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Location = new System.Drawing.Point(751, 408);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(205, 73);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Location = new System.Drawing.Point(464, 408);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(205, 73);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnPreviousStep
            // 
            this.btnPreviousStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreviousStep.Location = new System.Drawing.Point(464, 212);
            this.btnPreviousStep.Name = "btnPreviousStep";
            this.btnPreviousStep.Size = new System.Drawing.Size(205, 72);
            this.btnPreviousStep.TabIndex = 15;
            this.btnPreviousStep.Text = "Previous Step";
            this.btnPreviousStep.UseVisualStyleBackColor = true;
            this.btnPreviousStep.Click += new System.EventHandler(this.btnPreviousStep_Click);
            // 
            // btnNextStep
            // 
            this.btnNextStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextStep.Location = new System.Drawing.Point(760, 212);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(196, 72);
            this.btnNextStep.TabIndex = 14;
            this.btnNextStep.Text = "Next Step";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // rtbSteps
            // 
            this.rtbSteps.Enabled = false;
            this.rtbSteps.Location = new System.Drawing.Point(464, 61);
            this.rtbSteps.Name = "rtbSteps";
            this.rtbSteps.Size = new System.Drawing.Size(492, 145);
            this.rtbSteps.TabIndex = 13;
            this.rtbSteps.Text = "Step 0: Make Recipe";
            // 
            // lblRecipeName
            // 
            this.lblRecipeName.AutoSize = true;
            this.lblRecipeName.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRecipeName.Location = new System.Drawing.Point(464, 12);
            this.lblRecipeName.Name = "lblRecipeName";
            this.lblRecipeName.Size = new System.Drawing.Size(242, 46);
            this.lblRecipeName.TabIndex = 12;
            this.lblRecipeName.Text = "RECIPE NAME";
            // 
            // picRecipeImage
            // 
            this.picRecipeImage.Image = global::DigitalCookbook.Images._default;
            this.picRecipeImage.Location = new System.Drawing.Point(12, 12);
            this.picRecipeImage.Name = "picRecipeImage";
            this.picRecipeImage.Size = new System.Drawing.Size(446, 469);
            this.picRecipeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRecipeImage.TabIndex = 11;
            this.picRecipeImage.TabStop = false;
            // 
            // chkEnableTTS
            // 
            this.chkEnableTTS.AutoSize = true;
            this.chkEnableTTS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkEnableTTS.Location = new System.Drawing.Point(733, 290);
            this.chkEnableTTS.Name = "chkEnableTTS";
            this.chkEnableTTS.Size = new System.Drawing.Size(223, 32);
            this.chkEnableTTS.TabIndex = 19;
            this.chkEnableTTS.Text = "Enable Text to Speech";
            this.chkEnableTTS.UseVisualStyleBackColor = true;
            this.chkEnableTTS.CheckedChanged += new System.EventHandler(this.chkEnableTTS_CheckedChanged);
            // 
            // chkEnableSpeechRec
            // 
            this.chkEnableSpeechRec.AutoSize = true;
            this.chkEnableSpeechRec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkEnableSpeechRec.Location = new System.Drawing.Point(686, 328);
            this.chkEnableSpeechRec.Name = "chkEnableSpeechRec";
            this.chkEnableSpeechRec.Size = new System.Drawing.Size(270, 32);
            this.chkEnableSpeechRec.TabIndex = 20;
            this.chkEnableSpeechRec.Text = "Enable Speech Recognition";
            this.chkEnableSpeechRec.UseVisualStyleBackColor = true;
            this.chkEnableSpeechRec.CheckedChanged += new System.EventHandler(this.chkEnableSpeechRec_CheckedChanged);
            // 
            // btnRepeat
            // 
            this.btnRepeat.BackgroundImage = global::DigitalCookbook.Images.repeat;
            this.btnRepeat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRepeat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRepeat.Location = new System.Drawing.Point(675, 212);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(79, 72);
            this.btnRepeat.TabIndex = 21;
            this.btnRepeat.UseVisualStyleBackColor = true;
            this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
            // 
            // FormDetailedRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 493);
            this.Controls.Add(this.btnRepeat);
            this.Controls.Add(this.chkEnableTTS);
            this.Controls.Add(this.picIsFavorite);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnPreviousStep);
            this.Controls.Add(this.btnNextStep);
            this.Controls.Add(this.rtbSteps);
            this.Controls.Add(this.lblRecipeName);
            this.Controls.Add(this.picRecipeImage);
            this.Controls.Add(this.chkEnableSpeechRec);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormDetailedRecipe";
            this.Text = "Digital Cookbook - RECIPE NAME";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDetailedRecipe_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picIsFavorite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipeImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picIsFavorite;
        private Button btnEdit;
        private Button btnBack;
        private Button btnPreviousStep;
        private Button btnNextStep;
        private RichTextBox rtbSteps;
        private Label lblRecipeName;
        private PictureBox picRecipeImage;
        private CheckBox chkEnableTTS;
        private CheckBox chkEnableSpeechRec;
        private Button btnRepeat;
    }
}