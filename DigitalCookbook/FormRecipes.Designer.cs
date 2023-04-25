namespace DigitalCookbook
{
    partial class FormRecipes
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreate = new System.Windows.Forms.Button();
            this.floRecipeCards = new System.Windows.Forms.FlowLayoutPanel();
            this.chkOnlyFavorites = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(393, 38);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(148, 60);
            this.btnCreate.TabIndex = 9;
            this.btnCreate.Text = "Add Recipe";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // floRecipeCards
            // 
            this.floRecipeCards.AutoScroll = true;
            this.floRecipeCards.Location = new System.Drawing.Point(12, 108);
            this.floRecipeCards.Name = "floRecipeCards";
            this.floRecipeCards.Size = new System.Drawing.Size(908, 365);
            this.floRecipeCards.TabIndex = 8;
            // 
            // chkOnlyFavorites
            // 
            this.chkOnlyFavorites.AutoSize = true;
            this.chkOnlyFavorites.Location = new System.Drawing.Point(712, 53);
            this.chkOnlyFavorites.Name = "chkOnlyFavorites";
            this.chkOnlyFavorites.Size = new System.Drawing.Size(208, 32);
            this.chkOnlyFavorites.TabIndex = 7;
            this.chkOnlyFavorites.Text = "Show only Favorites";
            this.chkOnlyFavorites.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search Recipe by Name :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(319, 34);
            this.textBox1.TabIndex = 5;
            // 
            // FormRecipes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 493);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.floRecipeCards);
            this.Controls.Add(this.chkOnlyFavorites);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormRecipes";
            this.Text = "Digital Cookbook - Main Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRecipes_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCreate;
        private FlowLayoutPanel floRecipeCards;
        private CheckBox chkOnlyFavorites;
        private Label label1;
        private TextBox textBox1;
    }
}