namespace Bai06
{
    partial class Form1
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
            btConnect = new Button();
            tbUsername = new TextBox();
            SuspendLayout();
            // 
            // btConnect
            // 
            btConnect.Location = new Point(67, 89);
            btConnect.Name = "btConnect";
            btConnect.Size = new Size(134, 46);
            btConnect.TabIndex = 0;
            btConnect.Text = "Confirm";
            btConnect.UseVisualStyleBackColor = true;
            btConnect.Click += tbConnect_Click;
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(40, 41);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(185, 27);
            tbUsername.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(261, 172);
            Controls.Add(tbUsername);
            Controls.Add(btConnect);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btConnect;
        private TextBox tbUsername;
    }
}
