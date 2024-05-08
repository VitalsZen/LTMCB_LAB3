namespace Bai06
{
    partial class Dashboard6
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
            btUser = new Button();
            btServer = new Button();
            SuspendLayout();
            // 
            // btUser
            // 
            btUser.Location = new Point(45, 50);
            btUser.Name = "btUser";
            btUser.Size = new Size(130, 65);
            btUser.TabIndex = 0;
            btUser.Text = "Client";
            btUser.UseVisualStyleBackColor = true;
            btUser.Click += btUser_Click;
            // 
            // btServer
            // 
            btServer.Location = new Point(225, 50);
            btServer.Name = "btServer";
            btServer.Size = new Size(134, 65);
            btServer.TabIndex = 1;
            btServer.Text = "Server";
            btServer.UseVisualStyleBackColor = true;
            btServer.Click += btServer_Click;
            // 
            // Dashboard6
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(407, 153);
            Controls.Add(btServer);
            Controls.Add(btUser);
            Name = "Dashboard6";
            Text = "Form4";
            ResumeLayout(false);
        }

        #endregion

        private Button btUser;
        private Button btServer;
    }
}