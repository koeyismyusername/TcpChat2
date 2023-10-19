namespace ChatClientForm
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
            btnDisconnect = new Button();
            btnCommect = new Button();
            btnSend = new Button();
            labelRoomId = new Label();
            numRoomId = new NumericUpDown();
            tBoxUsername = new TextBox();
            labelUsername = new Label();
            tBoxMessage = new TextBox();
            lBoxMessages = new ListBox();
            ((System.ComponentModel.ISupportInitialize)numRoomId).BeginInit();
            SuspendLayout();
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(299, 12);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(75, 52);
            btnDisconnect.TabIndex = 0;
            btnDisconnect.Text = "연결끊기";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += BtnDisConnect_Click;
            // 
            // btnCommect
            // 
            btnCommect.Location = new Point(218, 12);
            btnCommect.Name = "btnCommect";
            btnCommect.Size = new Size(75, 52);
            btnCommect.TabIndex = 1;
            btnCommect.Text = "연결하기";
            btnCommect.UseVisualStyleBackColor = true;
            btnCommect.Click += btnConnect_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(299, 297);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 2;
            btnSend.Text = "전송하기";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // labelRoomId
            // 
            labelRoomId.AutoSize = true;
            labelRoomId.Location = new Point(12, 14);
            labelRoomId.Name = "labelRoomId";
            labelRoomId.Size = new Size(49, 15);
            labelRoomId.TabIndex = 3;
            labelRoomId.Text = "RoomId";
            // 
            // numRoomId
            // 
            numRoomId.Location = new Point(78, 12);
            numRoomId.Name = "numRoomId";
            numRoomId.Size = new Size(120, 23);
            numRoomId.TabIndex = 4;
            numRoomId.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // tBoxUsername
            // 
            tBoxUsername.Location = new Point(78, 41);
            tBoxUsername.Name = "tBoxUsername";
            tBoxUsername.Size = new Size(120, 23);
            tBoxUsername.TabIndex = 5;
            tBoxUsername.Text = "짱구";
            tBoxUsername.TextChanged += tBoxUsername_TextChanged;
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(12, 44);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(60, 15);
            labelUsername.TabIndex = 6;
            labelUsername.Text = "Username";
            // 
            // tBoxMessage
            // 
            tBoxMessage.Location = new Point(12, 297);
            tBoxMessage.Name = "tBoxMessage";
            tBoxMessage.Size = new Size(281, 23);
            tBoxMessage.TabIndex = 7;
            // 
            // lBoxMessages
            // 
            lBoxMessages.FormattingEnabled = true;
            lBoxMessages.ItemHeight = 15;
            lBoxMessages.Location = new Point(12, 77);
            lBoxMessages.Name = "lBoxMessages";
            lBoxMessages.Size = new Size(362, 214);
            lBoxMessages.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(386, 332);
            Controls.Add(lBoxMessages);
            Controls.Add(tBoxMessage);
            Controls.Add(labelUsername);
            Controls.Add(tBoxUsername);
            Controls.Add(numRoomId);
            Controls.Add(labelRoomId);
            Controls.Add(btnSend);
            Controls.Add(btnCommect);
            Controls.Add(btnDisconnect);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numRoomId).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDisconnect;
        private Button btnCommect;
        private Button btnSend;
        private Label labelRoomId;
        private NumericUpDown numRoomId;
        private TextBox tBoxUsername;
        private Label labelUsername;
        private TextBox tBoxMessage;
        private ListBox lBoxMessages;
    }
}