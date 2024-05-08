namespace Bai03
{
    partial class TCPServer3
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
            btListen = new Button();
            tbPort = new TextBox();
            lbPort = new Label();
            lvConnection = new ListBox();
            SuspendLayout();
            // 
            // btListen
            // 
            btListen.Location = new Point(42, 51);
            btListen.Name = "btListen";
            btListen.Size = new Size(137, 45);
            btListen.TabIndex = 0;
            btListen.Text = "Start Listen";
            btListen.UseVisualStyleBackColor = true;
            btListen.Click += btListen_Click;
            // 
            // tbPort
            // 
            tbPort.BorderStyle = BorderStyle.FixedSingle;
            tbPort.Enabled = false;
            tbPort.Location = new Point(316, 61);
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(125, 27);
            tbPort.TabIndex = 2;
            tbPort.Text = "8080";
            // 
            // lbPort
            // 
            lbPort.AutoSize = true;
            lbPort.Location = new Point(316, 36);
            lbPort.Name = "lbPort";
            lbPort.Size = new Size(35, 20);
            lbPort.TabIndex = 3;
            lbPort.Text = "Port";
            // 
            // lvConnection
            // 
            lvConnection.FormattingEnabled = true;
            lvConnection.Location = new Point(42, 136);
            lvConnection.Name = "lvConnection";
            lvConnection.Size = new Size(592, 224);
            lvConnection.TabIndex = 4;
            // 
            // TCPServer2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lvConnection);
            Controls.Add(lbPort);
            Controls.Add(tbPort);
            Controls.Add(btListen);
            Name = "TCPServer2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btListen;
        private TextBox tbPort;
        private Label lbPort;
        private ListBox lvConnection;
    }
}