namespace Image2Age
{
    partial class Form1
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
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.openFileImage = new System.Windows.Forms.OpenFileDialog();
            this.pictureBoxInput = new System.Windows.Forms.PictureBox();
            this.rb120 = new System.Windows.Forms.RadioButton();
            this.rb144 = new System.Windows.Forms.RadioButton();
            this.rb168 = new System.Windows.Forms.RadioButton();
            this.rb200 = new System.Windows.Forms.RadioButton();
            this.rb220 = new System.Windows.Forms.RadioButton();
            this.pictureBoxOutput = new System.Windows.Forms.PictureBox();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.Location = new System.Drawing.Point(13, 13);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadImage.TabIndex = 0;
            this.buttonLoadImage.Text = "Load Image";
            this.buttonLoadImage.UseVisualStyleBackColor = true;
            this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
            // 
            // openFileImage
            // 
            this.openFileImage.FileName = "image.png";
            this.openFileImage.Filter = "Image Files|*.png";
            this.openFileImage.Title = "Image Selector";
            // 
            // pictureBoxInput
            // 
            this.pictureBoxInput.Location = new System.Drawing.Point(12, 59);
            this.pictureBoxInput.Name = "pictureBoxInput";
            this.pictureBoxInput.Size = new System.Drawing.Size(315, 186);
            this.pictureBoxInput.TabIndex = 1;
            this.pictureBoxInput.TabStop = false;
            // 
            // rb120
            // 
            this.rb120.AutoSize = true;
            this.rb120.Checked = true;
            this.rb120.Location = new System.Drawing.Point(56, 292);
            this.rb120.Name = "rb120";
            this.rb120.Size = new System.Drawing.Size(112, 17);
            this.rb120.TabIndex = 2;
            this.rb120.TabStop = true;
            this.rb120.Text = "120x120 - 2 player";
            this.rb120.UseVisualStyleBackColor = true;
            // 
            // rb144
            // 
            this.rb144.AutoSize = true;
            this.rb144.Location = new System.Drawing.Point(56, 315);
            this.rb144.Name = "rb144";
            this.rb144.Size = new System.Drawing.Size(112, 17);
            this.rb144.TabIndex = 3;
            this.rb144.Text = "144x144 - 3 player";
            this.rb144.UseVisualStyleBackColor = true;
            // 
            // rb168
            // 
            this.rb168.AutoSize = true;
            this.rb168.Location = new System.Drawing.Point(56, 338);
            this.rb168.Name = "rb168";
            this.rb168.Size = new System.Drawing.Size(112, 17);
            this.rb168.TabIndex = 4;
            this.rb168.Text = "168x168 - 4 player";
            this.rb168.UseVisualStyleBackColor = true;
            // 
            // rb200
            // 
            this.rb200.AutoSize = true;
            this.rb200.Location = new System.Drawing.Point(56, 361);
            this.rb200.Name = "rb200";
            this.rb200.Size = new System.Drawing.Size(112, 17);
            this.rb200.TabIndex = 6;
            this.rb200.Text = "200x200 - 6 player";
            this.rb200.UseVisualStyleBackColor = true;
            // 
            // rb220
            // 
            this.rb220.AutoSize = true;
            this.rb220.Location = new System.Drawing.Point(56, 384);
            this.rb220.Name = "rb220";
            this.rb220.Size = new System.Drawing.Size(112, 17);
            this.rb220.TabIndex = 7;
            this.rb220.Text = "220x220 - 8 player";
            this.rb220.UseVisualStyleBackColor = true;
            // 
            // pictureBoxOutput
            // 
            this.pictureBoxOutput.Location = new System.Drawing.Point(333, 59);
            this.pictureBoxOutput.Name = "pictureBoxOutput";
            this.pictureBoxOutput.Size = new System.Drawing.Size(327, 186);
            this.pictureBoxOutput.TabIndex = 8;
            this.pictureBoxOutput.TabStop = false;
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(333, 13);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(75, 23);
            this.buttonConvert.TabIndex = 9;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(565, 13);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save Map";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "aoe2scenario";
            this.saveFileDialog.FileName = "map";
            this.saveFileDialog.Title = "NewMap";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.pictureBoxOutput);
            this.Controls.Add(this.rb220);
            this.Controls.Add(this.rb200);
            this.Controls.Add(this.rb168);
            this.Controls.Add(this.rb144);
            this.Controls.Add(this.rb120);
            this.Controls.Add(this.pictureBoxInput);
            this.Controls.Add(this.buttonLoadImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.OpenFileDialog openFileImage;
        private System.Windows.Forms.PictureBox pictureBoxInput;
        private System.Windows.Forms.RadioButton rb120;
        private System.Windows.Forms.RadioButton rb144;
        private System.Windows.Forms.RadioButton rb168;
        private System.Windows.Forms.RadioButton rb200;
        private System.Windows.Forms.RadioButton rb220;
        private System.Windows.Forms.PictureBox pictureBoxOutput;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

