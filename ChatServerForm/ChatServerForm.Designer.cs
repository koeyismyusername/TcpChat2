namespace ChatServerForm
{
    partial class ChatServerForm
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
            btnExit = new Button();
            btnStart = new Button();
            lBoxMessages = new ListBox();
            lBoxClients = new ListBox();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.Location = new Point(510, 12);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 0;
            btnExit.Text = "종료하기";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(429, 12);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 1;
            btnStart.Text = "시작하기";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // lBoxMessages
            // 
            lBoxMessages.FormattingEnabled = true;
            lBoxMessages.ItemHeight = 15;
            lBoxMessages.Location = new Point(200, 45);
            lBoxMessages.Name = "lBoxMessages";
            lBoxMessages.Size = new Size(385, 274);
            lBoxMessages.TabIndex = 2;
            // 
            // lBoxClients
            // 
            lBoxClients.FormattingEnabled = true;
            lBoxClients.ItemHeight = 15;
            lBoxClients.Location = new Point(12, 45);
            lBoxClients.Name = "lBoxClients";
            lBoxClients.Size = new Size(182, 274);
            lBoxClients.TabIndex = 3;
            // 
            // ChatServerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 331);
            Controls.Add(lBoxClients);
            Controls.Add(lBoxMessages);
            Controls.Add(btnStart);
            Controls.Add(btnExit);
            Name = "ChatServerForm";
            Text = "Server";
            ResumeLayout(false);
        }

        #endregion

        private Button btnExit;
        private Button btnStart;
        private ListBox lBoxMessages;
        private ListBox lBoxClients;
    }
}