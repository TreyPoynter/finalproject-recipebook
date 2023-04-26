namespace DigitalCookbook
{
    partial class FormEdit
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
            this.picIsFavorite = new System.Windows.Forms.PictureBox();
            this.rchSteps = new System.Windows.Forms.RichTextBox();
            this.chkIsFavorited = new System.Windows.Forms.CheckBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnImageSelector = new System.Windows.Forms.Button();
            this.picRecipeImage = new System.Windows.Forms.PictureBox();
            this.txtRecipeName = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
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
            this.picIsFavorite.TabIndex = 26;
            this.picIsFavorite.TabStop = false;
            this.picIsFavorite.Visible = false;
            // 
            // rchSteps
            // 
            this.rchSteps.Location = new System.Drawing.Point(464, 121);
            this.rchSteps.Name = "rchSteps";
            this.rchSteps.Size = new System.Drawing.Size(456, 188);
            this.rchSteps.TabIndex = 25;
            this.rchSteps.Text = "";
            // 
            // chkIsFavorited
            // 
            this.chkIsFavorited.AutoSize = true;
            this.chkIsFavorited.Location = new System.Drawing.Point(786, 68);
            this.chkIsFavorited.Name = "chkIsFavorited";
            this.chkIsFavorited.Size = new System.Drawing.Size(134, 32);
            this.chkIsFavorited.TabIndex = 24;
            this.chkIsFavorited.Text = "Is Favorited";
            this.chkIsFavorited.UseVisualStyleBackColor = true;
            this.chkIsFavorited.CheckedChanged += new System.EventHandler(this.chkIsFavorited_CheckedChanged);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(464, 329);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(456, 73);
            this.btnSaveChanges.TabIndex = 23;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnImageSelector
            // 
            this.btnImageSelector.Location = new System.Drawing.Point(464, 52);
            this.btnImageSelector.Name = "btnImageSelector";
            this.btnImageSelector.Size = new System.Drawing.Size(241, 63);
            this.btnImageSelector.TabIndex = 21;
            this.btnImageSelector.Text = "Select an image";
            this.btnImageSelector.UseVisualStyleBackColor = true;
            this.btnImageSelector.Click += new System.EventHandler(this.btnImageSelector_Click);
            // 
            // picRecipeImage
            // 
            this.picRecipeImage.Image = global::DigitalCookbook.Images._default;
            this.picRecipeImage.InitialImage = global::DigitalCookbook.Images.krabby_patty;
            this.picRecipeImage.Location = new System.Drawing.Point(12, 12);
            this.picRecipeImage.Name = "picRecipeImage";
            this.picRecipeImage.Size = new System.Drawing.Size(446, 469);
            this.picRecipeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRecipeImage.TabIndex = 20;
            this.picRecipeImage.TabStop = false;
            // 
            // txtRecipeName
            // 
            this.txtRecipeName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRecipeName.Location = new System.Drawing.Point(464, 12);
            this.txtRecipeName.Name = "txtRecipeName";
            this.txtRecipeName.Size = new System.Drawing.Size(379, 34);
            this.txtRecipeName.TabIndex = 18;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(464, 408);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(456, 73);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "Delete Recipe";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 493);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.picIsFavorite);
            this.Controls.Add(this.rchSteps);
            this.Controls.Add(this.chkIsFavorited);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.btnImageSelector);
            this.Controls.Add(this.picRecipeImage);
            this.Controls.Add(this.txtRecipeName);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormEdit";
            this.Text = "Digital Cookbook - RECIPE NAME : Edit Mode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEdit_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picIsFavorite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipeImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picIsFavorite;
        private RichTextBox rchSteps;
        private CheckBox chkIsFavorited;
        private Button btnSaveChanges;
        private Button btnImageSelector;
        private PictureBox picRecipeImage;
        private TextBox txtRecipeName;
        private Button btnDelete;
        private OpenFileDialog openFileDialog1;
    }
}