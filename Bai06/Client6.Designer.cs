namespace Bai06
{
    partial class Form2
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
            lbMessage = new ListBox();
            tbMessage = new TextBox();
            btSend = new Button();
            SuspendLayout();
            // 
            // lbMessage
            // 
            lbMessage.FormattingEnabled = true;
            lbMessage.Location = new Point(50, 45);
            lbMessage.Name = "lbMessage";
            lbMessage.Size = new Size(471, 224);
            lbMessage.TabIndex = 0;
            // 
            // tbMessage
            // 
            tbMessage.Location = new Point(50, 295);
            tbMessage.Multiline = true;
            tbMessage.Name = "tbMessage";
            tbMessage.Size = new Size(471, 46);
            tbMessage.TabIndex = 1;
            // 
            // btSend
            // 
            btSend.Location = new Point(568, 295);
            btSend.Name = "btSend";
            btSend.Size = new Size(175, 46);
            btSend.TabIndex = 2;
            btSend.Text = "Send";
            btSend.UseVisualStyleBackColor = true;
            btSend.Click += btSend_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(788, 383);
            Controls.Add(btSend);
            Controls.Add(tbMessage);
            Controls.Add(lbMessage);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbMessage;
        private TextBox tbMessage;
        private Button btSend;
    }
}