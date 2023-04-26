namespace DigitalCookbook
{
    partial class RecipeCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picRecipeImage = new System.Windows.Forms.PictureBox();
            this.lblRecipeName = new System.Windows.Forms.Label();
            this.picFavoriteIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFavoriteIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picRecipeImage
            // 
            this.picRecipeImage.Enabled = false;
            this.picRecipeImage.Location = new System.Drawing.Point(0, 0);
            this.picRecipeImage.Name = "picRecipeImage";
            this.picRecipeImage.Size = new System.Drawing.Size(130, 119);
            this.picRecipeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRecipeImage.TabIndex = 0;
            this.picRecipeImage.TabStop = false;
            // 
            // lblRecipeName
            // 
            this.lblRecipeName.AutoSize = true;
            this.lblRecipeName.Enabled = false;
            this.lblRecipeName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRecipeName.Location = new System.Drawing.Point(0, 122);
            this.lblRecipeName.Name = "lblRecipeName";
            this.lblRecipeName.Size = new System.Drawing.Size(55, 23);
            this.lblRecipeName.TabIndex = 1;
            this.lblRecipeName.Text = "label1";
            // 
            // picFavoriteIcon
            // 
            this.picFavoriteIcon.Image = global::DigitalCookbook.Images.favorite_icon;
            this.picFavoriteIcon.Location = new System.Drawing.Point(87, 3);
            this.picFavoriteIcon.Name = "picFavoriteIcon";
            this.picFavoriteIcon.Size = new System.Drawing.Size(40, 40);
            this.picFavoriteIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFavoriteIcon.TabIndex = 2;
            this.picFavoriteIcon.TabStop = false;
            // 
            // RecipeCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picFavoriteIcon);
            this.Controls.Add(this.lblRecipeName);
            this.Controls.Add(this.picRecipeImage);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "RecipeCard";
            this.Size = new System.Drawing.Size(130, 148);
            this.Load += new System.EventHandler(this.RecipeCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picRecipeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFavoriteIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picRecipeImage;
        private Label lblRecipeName;
        private PictureBox picFavoriteIcon;
    }
}
