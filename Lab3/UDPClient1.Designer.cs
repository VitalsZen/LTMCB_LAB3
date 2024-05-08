namespace Lab3
{
    partial class UDPClient1
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbIP = new TextBox();
            tbPort = new TextBox();
            tbMessage = new TextBox();
            lbIP = new Label();
            lbPort = new Label();
            lbMessage = new Label();
            btSend = new Button();
            SuspendLayout();
            // 
            // tbIP
            // 
            tbIP.BorderStyle = BorderStyle.FixedSingle;
            tbIP.Location = new Point(44, 50);
            tbIP.Name = "tbIP";
            tbIP.Size = new Size(247, 27);
            tbIP.TabIndex = 0;
            // 
            // tbPort
            // 
            tbPort.BorderStyle = BorderStyle.FixedSingle;
            tbPort.Location = new Point(374, 50);
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(170, 27);
            tbPort.TabIndex = 1;
            // 
            // tbMessage
            // 
            tbMessage.BorderStyle = BorderStyle.FixedSingle;
            tbMessage.Location = new Point(44, 127);
            tbMessage.Multiline = true;
            tbMessage.Name = "tbMessage";
            tbMessage.Size = new Size(500, 119);
            tbMessage.TabIndex = 2;
            // 
            // lbIP
            // 
            lbIP.AutoSize = true;
            lbIP.Location = new Point(44, 27);
            lbIP.Name = "lbIP";
            lbIP.Size = new Size(21, 20);
            lbIP.TabIndex = 3;
            lbIP.Text = "IP";
            // 
            // lbPort
            // 
            lbPort.AutoSize = true;
            lbPort.Location = new Point(374, 27);
            lbPort.Name = "lbPort";
            lbPort.Size = new Size(35, 20);
            lbPort.TabIndex = 4;
            lbPort.Text = "Port";
            // 
            // lbMessage
            // 
            lbMessage.AutoSize = true;
            lbMessage.Location = new Point(44, 104);
            lbMessage.Name = "lbMessage";
            lbMessage.Size = new Size(67, 20);
            lbMessage.TabIndex = 5;
            lbMessage.Text = "Message";
            // 
            // btSend
            // 
            btSend.Location = new Point(450, 268);
            btSend.Name = "btSend";
            btSend.Size = new Size(94, 29);
            btSend.TabIndex = 6;
            btSend.Text = "Send";
            btSend.UseVisualStyleBackColor = true;
            btSend.Click += btSend_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(583, 309);
            Controls.Add(btSend);
            Controls.Add(lbMessage);
            Controls.Add(lbPort);
            Controls.Add(lbIP);
            Controls.Add(tbMessage);
            Controls.Add(tbPort);
            Controls.Add(tbIP);
            Name = "Form1";
            Text = "UDP Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbIP;
        private TextBox tbPort;
        private TextBox tbMessage;
        private Label lbIP;
        private Label lbPort;
        private Label lbMessage;
        private Button btSend;
    }
}