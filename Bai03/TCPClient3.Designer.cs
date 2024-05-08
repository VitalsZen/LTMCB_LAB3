namespace Bai03
{
    partial class TCPClient3
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
            btSend = new Button();
            lbMessage = new Label();
            lbPort = new Label();
            lbIP = new Label();
            tbMessage = new TextBox();
            tbPort = new TextBox();
            tbIP = new TextBox();
            btConnect = new Button();
            btDisconnect = new Button();
            SuspendLayout();
            // 
            // btSend
            // 
            btSend.Location = new Point(300, 263);
            btSend.Name = "btSend";
            btSend.Size = new Size(94, 29);
            btSend.TabIndex = 13;
            btSend.Text = "Send";
            btSend.UseVisualStyleBackColor = true;
            btSend.Click += btSend_Click;
            // 
            // lbMessage
            // 
            lbMessage.AutoSize = true;
            lbMessage.Location = new Point(29, 99);
            lbMessage.Name = "lbMessage";
            lbMessage.Size = new Size(67, 20);
            lbMessage.TabIndex = 12;
            lbMessage.Text = "Message";
            // 
            // lbPort
            // 
            lbPort.AutoSize = true;
            lbPort.Location = new Point(359, 22);
            lbPort.Name = "lbPort";
            lbPort.Size = new Size(35, 20);
            lbPort.TabIndex = 11;
            lbPort.Text = "Port";
            // 
            // lbIP
            // 
            lbIP.AutoSize = true;
            lbIP.Location = new Point(29, 22);
            lbIP.Name = "lbIP";
            lbIP.Size = new Size(21, 20);
            lbIP.TabIndex = 10;
            lbIP.Text = "IP";
            // 
            // tbMessage
            // 
            tbMessage.BorderStyle = BorderStyle.FixedSingle;
            tbMessage.Location = new Point(29, 122);
            tbMessage.Multiline = true;
            tbMessage.Name = "tbMessage";
            tbMessage.Size = new Size(500, 119);
            tbMessage.TabIndex = 9;
            // 
            // tbPort
            // 
            tbPort.BorderStyle = BorderStyle.FixedSingle;
            tbPort.Location = new Point(359, 45);
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(170, 27);
            tbPort.TabIndex = 8;
            // 
            // tbIP
            // 
            tbIP.BorderStyle = BorderStyle.FixedSingle;
            tbIP.Location = new Point(29, 45);
            tbIP.Name = "tbIP";
            tbIP.Size = new Size(247, 27);
            tbIP.TabIndex = 7;
            // 
            // btConnect
            // 
            btConnect.Location = new Point(152, 263);
            btConnect.Name = "btConnect";
            btConnect.Size = new Size(94, 29);
            btConnect.TabIndex = 14;
            btConnect.Text = "Connect";
            btConnect.UseVisualStyleBackColor = true;
            btConnect.Click += btConnect_Click;
            // 
            // btDisconnect
            // 
            btDisconnect.Location = new Point(435, 263);
            btDisconnect.Name = "btDisconnect";
            btDisconnect.Size = new Size(94, 29);
            btDisconnect.TabIndex = 15;
            btDisconnect.Text = "Disconnect";
            btDisconnect.UseVisualStyleBackColor = true;
            btDisconnect.Click += btDisconnect_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 323);
            Controls.Add(btDisconnect);
            Controls.Add(btConnect);
            Controls.Add(btSend);
            Controls.Add(lbMessage);
            Controls.Add(lbPort);
            Controls.Add(lbIP);
            Controls.Add(tbMessage);
            Controls.Add(tbPort);
            Controls.Add(tbIP);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btSend;
        private Label lbMessage;
        private Label lbPort;
        private Label lbIP;
        private TextBox tbMessage;
        private TextBox tbPort;
        private TextBox tbIP;
        private Button btConnect;
        private Button btDisconnect;
    }
}