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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenShelf));
            this.VideoSourceButton = new System.Windows.Forms.Button();
            this.VideoFormatButton = new System.Windows.Forms.Button();
            this.ContinueButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.VideoBox = new System.Windows.Forms.PictureBox();
            this.BookText = new System.Windows.Forms.TextBox();
            this.ThoughtWorkerText = new System.Windows.Forms.TextBox();
            this.Log = new System.Windows.Forms.Button();
            this.ShowLogs = new System.Windows.Forms.Button();
            this.StatusText = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ResetTimer = new System.Windows.Forms.Timer(this.components);
            this.TransactionTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.VideoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // VideoSourceButton
            // 
            this.VideoSourceButton.Location = new System.Drawing.Point(36, 473);
            this.VideoSourceButton.Name = "VideoSourceButton";
            this.VideoSourceButton.Size = new System.Drawing.Size(163, 23);
            this.VideoSourceButton.TabIndex = 14;
            this.VideoSourceButton.Text = "Video Source";
            this.VideoSourceButton.UseVisualStyleBackColor = true;
            this.VideoSourceButton.Visible = false;
            this.VideoSourceButton.Click += new System.EventHandler(this.VideoSourceButton_Click);
            // 
            // VideoFormatButton
            // 
            this.VideoFormatButton.Location = new System.Drawing.Point(36, 444);
            this.VideoFormatButton.Name = "VideoFormatButton";
            this.VideoFormatButton.Size = new System.Drawing.Size(163, 23);
            this.VideoFormatButton.TabIndex = 13;
            this.VideoFormatButton.Text = "Video Format";
            this.VideoFormatButton.UseVisualStyleBackColor = true;
            this.VideoFormatButton.Visible = false;
            this.VideoFormatButton.Click += new System.EventHandler(this.VideoFormatButton_Click);
            // 
            // ContinueButton
            // 
            this.ContinueButton.Location = new System.Drawing.Point(237, 411);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(61, 23);
            this.ContinueButton.TabIndex = 12;
            this.ContinueButton.Text = "Continue";
            this.ContinueButton.UseVisualStyleBackColor = true;
            this.ContinueButton.Visible = false;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(164, 402);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(67, 23);
            this.StopButton.TabIndex = 11;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(84, 402);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(60, 23);
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
            this.VideoBox.Location = new System.Drawing.Point(60, 91);
            this.VideoBox.Name = "VideoBox";
            this.VideoBox.Size = new System.Drawing.Size(363, 246);
            this.VideoBox.TabIndex = 9;
            this.VideoBox.TabStop = false;
            // 
            // BookText
            // 
            this.BookText.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BookText.Font = new System.Drawing.Font("Garamond", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BookText.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.BookText.Location = new System.Drawing.Point(488, 103);
            this.BookText.Multiline = true;
            this.BookText.Name = "BookText";
            this.BookText.ReadOnly = true;
            this.BookText.Size = new System.Drawing.Size(348, 95);
            this.BookText.TabIndex = 15;
            this.BookText.Text = "Chosen Book";
            // 
            // ThoughtWorkerText
            // 
            this.ThoughtWorkerText.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ThoughtWorkerText.Font = new System.Drawing.Font("Garamond", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThoughtWorkerText.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.ThoughtWorkerText.Location = new System.Drawing.Point(488, 218);
            this.ThoughtWorkerText.Multiline = true;
            this.ThoughtWorkerText.Name = "ThoughtWorkerText";
            this.ThoughtWorkerText.ReadOnly = true;
            this.ThoughtWorkerText.Size = new System.Drawing.Size(348, 100);
            this.ThoughtWorkerText.TabIndex = 16;
            this.ThoughtWorkerText.Text = "Chosen User";
            // 
            // Log
            // 
            this.Log.Enabled = false;
            this.Log.Location = new System.Drawing.Point(616, 383);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(75, 23);
            this.Log.TabIndex = 17;
            this.Log.Text = "LOG";
            this.Log.UseVisualStyleBackColor = true;
            this.Log.Visible = false;
            this.Log.Click += new System.EventHandler(this.Log_Click);
            // 
            // ShowLogs
            // 
            this.ShowLogs.Location = new System.Drawing.Point(697, 383);
            this.ShowLogs.Name = "ShowLogs";
            this.ShowLogs.Size = new System.Drawing.Size(75, 23);
            this.ShowLogs.TabIndex = 18;
            this.ShowLogs.Text = "Show Logs";
            this.ShowLogs.UseVisualStyleBackColor = true;
            this.ShowLogs.Visible = false;
            this.ShowLogs.Click += new System.EventHandler(this.ShowLogs_Click);
            // 
            // StatusText
            // 
            this.StatusText.BackColor = System.Drawing.SystemColors.Control;
            this.StatusText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatusText.Font = new System.Drawing.Font("Garamond", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusText.Location = new System.Drawing.Point(488, 324);
            this.StatusText.Multiline = true;
            this.StatusText.Name = "StatusText";
            this.StatusText.ReadOnly = true;
            this.StatusText.Size = new System.Drawing.Size(345, 37);
            this.StatusText.TabIndex = 19;
            this.StatusText.Text = "Status: ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(708, 123);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // ResetTimer
            // 
            this.ResetTimer.Interval = 3000;
            this.ResetTimer.Tick += new System.EventHandler(this.ResetTimer_Tick);
            // 
            // TransactionTimer
            // 
            this.TransactionTimer.Interval = 1000;
            // 
            // OpenShelf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 459);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.ShowLogs);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.ThoughtWorkerText);
            this.Controls.Add(this.BookText);
            this.Controls.Add(this.VideoSourceButton);
            this.Controls.Add(this.VideoFormatButton);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.VideoBox);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
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
        private System.Windows.Forms.Button Log;
        private System.Windows.Forms.Button ShowLogs;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox BookText;
        public System.Windows.Forms.TextBox ThoughtWorkerText;
        public System.Windows.Forms.TextBox StatusText;
        private System.Windows.Forms.Timer ResetTimer;
        private System.Windows.Forms.Timer TransactionTimer;
    }
}

