namespace OpenShelf
{
    partial class OpenShelf
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
            this.VideoSourceButton = new System.Windows.Forms.Button();
            this.VideoFormatButton = new System.Windows.Forms.Button();
            this.ContinueButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.VideoBox = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.VideoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // VideoSourceButton
            // 
            this.VideoSourceButton.Location = new System.Drawing.Point(33, 289);
            this.VideoSourceButton.Name = "VideoSourceButton";
            this.VideoSourceButton.Size = new System.Drawing.Size(163, 23);
            this.VideoSourceButton.TabIndex = 14;
            this.VideoSourceButton.Text = "Video Source";
            this.VideoSourceButton.UseVisualStyleBackColor = true;
            this.VideoSourceButton.Click += new System.EventHandler(this.VideoSourceButton_Click);
            // 
            // VideoFormatButton
            // 
            this.VideoFormatButton.Location = new System.Drawing.Point(33, 260);
            this.VideoFormatButton.Name = "VideoFormatButton";
            this.VideoFormatButton.Size = new System.Drawing.Size(163, 23);
            this.VideoFormatButton.TabIndex = 13;
            this.VideoFormatButton.Text = "Video Format";
            this.VideoFormatButton.UseVisualStyleBackColor = true;
            this.VideoFormatButton.Click += new System.EventHandler(this.VideoFormatButton_Click);
            // 
            // ContinueButton
            // 
            this.ContinueButton.Location = new System.Drawing.Point(135, 217);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(61, 23);
            this.ContinueButton.TabIndex = 12;
            this.ContinueButton.Text = "Continue";
            this.ContinueButton.UseVisualStyleBackColor = true;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(80, 217);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(49, 23);
            this.StopButton.TabIndex = 11;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(33, 217);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(41, 23);
            this.StartButton.TabIndex = 10;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // VideoBox
            // 
            this.VideoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VideoBox.ErrorImage = null;
            this.VideoBox.InitialImage = null;
            this.VideoBox.Location = new System.Drawing.Point(33, 30);
            this.VideoBox.Name = "VideoBox";
            this.VideoBox.Size = new System.Drawing.Size(163, 160);
            this.VideoBox.TabIndex = 9;
            this.VideoBox.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(214, 28);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 68);
            this.textBox1.TabIndex = 15;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(214, 122);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(144, 68);
            this.textBox2.TabIndex = 16;
            // 
            // OpenShelf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 348);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.VideoSourceButton);
            this.Controls.Add(this.VideoFormatButton);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.VideoBox);
            this.Name = "OpenShelf";
            this.Text = "OpenShelf";
            this.Load += new System.EventHandler(this.OpenShelf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VideoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button VideoSourceButton;
        private System.Windows.Forms.Button VideoFormatButton;
        private System.Windows.Forms.Button ContinueButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.PictureBox VideoBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

