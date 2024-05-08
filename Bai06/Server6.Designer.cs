namespace Bai06
{
    partial class Form3
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
            lvConnection = new ListBox();
            lbPort = new Label();
            tbPort = new TextBox();
            btListen = new Button();
            SuspendLayout();
            // 
            // lvConnection
            // 
            lvConnection.FormattingEnabled = true;
            lvConnection.Location = new Point(37, 116);
            lvConnection.Name = "lvConnection";
            lvConnection.Size = new Size(592, 224);
            lvConnection.TabIndex = 8;
            // 
            // lbPort
            // 
            lbPort.AutoSize = true;
            lbPort.Location = new Point(311, 16);
            lbPort.Name = "lbPort";
            lbPort.Size = new Size(35, 20);
            lbPort.TabIndex = 7;
            lbPort.Text = "Port";
            // 
            // tbPort
            // 
            tbPort.BorderStyle = BorderStyle.FixedSingle;
            tbPort.Enabled = false;
            tbPort.Location = new Point(311, 41);
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(125, 27);
            tbPort.TabIndex = 6;
            tbPort.Text = "8080";
            // 
            // btListen
            // 
            btListen.Location = new Point(37, 31);
            btListen.Name = "btListen";
            btListen.Size = new Size(137, 45);
            btListen.TabIndex = 5;
            btListen.Text = "Start Listen";
            btListen.UseVisualStyleBackColor = true;
            //btListen.Click += btListen_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 371);
            Controls.Add(lvConnection);
            Controls.Add(lbPort);
            Controls.Add(tbPort);
            Controls.Add(btListen);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lvConnection;
        private Label lbPort;
        private TextBox tbPort;
        private Button btListen;
    }
}