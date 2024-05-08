namespace Lab3
{
    partial class UDPServer1
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
            lbMessage = new Label();
            lbPort = new Label();
            tbPort = new TextBox();
            lbMessages = new ListBox();
            SuspendLayout();
            // 
            // lbMessage
            // 
            lbMessage.AutoSize = true;
            lbMessage.Location = new Point(40, 74);
            lbMessage.Name = "lbMessage";
            lbMessage.Size = new Size(67, 20);
            lbMessage.TabIndex = 12;
            lbMessage.Text = "Message";
            // 
            // lbPort
            // 
            lbPort.AutoSize = true;
            lbPort.Location = new Point(40, 10);
            lbPort.Name = "lbPort";
            lbPort.Size = new Size(35, 20);
            lbPort.TabIndex = 11;
            lbPort.Text = "Port";
            // 
            // tbPort
            // 
            tbPort.BorderStyle = BorderStyle.FixedSingle;
            tbPort.Location = new Point(40, 33);
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(170, 27);
            tbPort.TabIndex = 8;
            tbPort.Text = "8080";
            // 
            // lbMessages
            // 
            lbMessages.FormattingEnabled = true;
            lbMessages.Location = new Point(40, 110);
            lbMessages.Name = "lbMessages";
            lbMessages.Size = new Size(465, 104);
            lbMessages.TabIndex = 14;
            // 
            // UDP_Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 248);
            Controls.Add(lbMessages);
            Controls.Add(lbMessage);
            Controls.Add(lbPort);
            Controls.Add(tbPort);
            Name = "UDP_Server";
            Text = "UDP_Server";
            Load += UDP_Server_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbMessage;
        private Label lbPort;
        private TextBox tbPort;
        private ListBox lbMessages;
    }
}