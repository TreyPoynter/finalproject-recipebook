namespace DigitalCookbook
{
    partial class FormCreate
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
            this.rchSteps = new System.Windows.Forms.RichTextBox();
            this.chkIsFavorited = new System.Windows.Forms.CheckBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnImageSelector = new System.Windows.Forms.Button();
            this.picRecipeImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRecipeName = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.picIsFavorite = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIsFavorite)).BeginInit();
            this.SuspendLayout();
            // 
            // rchSteps
            // 
            this.rchSteps.Location = new System.Drawing.Point(464, 172);
            this.rchSteps.Name = "rchSteps";
            this.rchSteps.Size = new System.Drawing.Size(456, 230);
            this.rchSteps.TabIndex = 16;
            this.rchSteps.Text = "";
            // 
            // chkIsFavorited
            // 
            this.chkIsFavorited.AutoSize = true;
            this.chkIsFavorited.Location = new System.Drawing.Point(786, 110);
            this.chkIsFavorited.Name = "chkIsFavorited";
            this.chkIsFavorited.Size = new System.Drawing.Size(134, 32);
            this.chkIsFavorited.TabIndex = 15;
            this.chkIsFavorited.Text = "Is Favorited";
            this.chkIsFavorited.UseVisualStyleBackColor = true;
            this.chkIsFavorited.CheckedChanged += new System.EventHandler(this.chkIsFavorited_CheckedChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(715, 408);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(205, 73);
            this.btnCreate.TabIndex = 14;
            this.btnCreate.Text = "Add Recipe";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(464, 408);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(205, 73);
            this.btnBack.TabIndex = 13;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnImageSelector
            // 
            this.btnImageSelector.Location = new System.Drawing.Point(464, 94);
            this.btnImageSelector.Name = "btnImageSelector";
            this.btnImageSelector.Size = new System.Drawing.Size(241, 63);
            this.btnImageSelector.TabIndex = 12;
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
            this.picRecipeImage.TabIndex = 11;
            this.picRecipeImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(464, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 28);
            this.label1.TabIndex = 10;
            this.label1.Text = "Recipe Name :";
            // 
            // txtRecipeName
            // 
            this.txtRecipeName.Location = new System.Drawing.Point(464, 43);
            this.txtRecipeName.Name = "txtRecipeName";
            this.txtRecipeName.Size = new System.Drawing.Size(379, 34);
            this.txtRecipeName.TabIndex = 9;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // picIsFavorite
            // 
            this.picIsFavorite.Image = global::DigitalCookbook.Images.favorite_icon;
            this.picIsFavorite.Location = new System.Drawing.Point(396, 12);
            this.picIsFavorite.Name = "picIsFavorite";
            this.picIsFavorite.Size = new System.Drawing.Size(62, 62);
            this.picIsFavorite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIsFavorite.TabIndex = 17;
            this.picIsFavorite.TabStop = false;
            this.picIsFavorite.Visible = false;
            // 
            // FormCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 493);
            this.Controls.Add(this.picIsFavorite);
            this.Controls.Add(this.rchSteps);
            this.Controls.Add(this.chkIsFavorited);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnImageSelector);
            this.Controls.Add(this.picRecipeImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRecipeName);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormCreate";
            this.Text = "Digital Cookbook - Add a Recipe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCreate_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picRecipeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIsFavorite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox rchSteps;
        private CheckBox chkIsFavorited;
        private Button btnCreate;
        private Button btnBack;
        private Button btnImageSelector;
        private PictureBox picRecipeImage;
        private Label label1;
        private TextBox txtRecipeName;
        private OpenFileDialog openFileDialog1;
        private PictureBox picIsFavorite;
    }
}