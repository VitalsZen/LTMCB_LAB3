namespace Bai04
{
    partial class Dashboard4
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
            btServer4 = new Button();
            btClient4 = new Button();
            SuspendLayout();
            // 
            // btServer4
            // 
            btServer4.Location = new Point(100, 55);
            btServer4.Name = "btServer4";
            btServer4.Size = new Size(148, 59);
            btServer4.TabIndex = 0;
            btServer4.Text = "Server";
            btServer4.UseVisualStyleBackColor = true;
            btServer4.Click += btServer4_Click;
            // 
            // btClient4
            // 
            btClient4.Location = new Point(409, 55);
            btClient4.Name = "btClient4";
            btClient4.Size = new Size(145, 59);
            btClient4.TabIndex = 1;
            btClient4.Text = "Client";
            btClient4.UseVisualStyleBackColor = true;
            btClient4.Click += btClient4_Click;
            // 
            // Dashboard4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 190);
            Controls.Add(btClient4);
            Controls.Add(btServer4);
            Name = "Dashboard4";
            Text = "Dashboard4";
            ResumeLayout(false);
        }

        #endregion

        private Button btServer4;
        private Button btClient4;
    }
}