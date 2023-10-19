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
            SuspendLayout();
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(299, 12);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(75, 23);
            btnDisconnect.TabIndex = 0;
            btnDisconnect.Text = "연결끊기";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += BtnDisConnect_Click;
            // 
            // btnCommect
            // 
            btnCommect.Location = new Point(218, 12);
            btnCommect.Name = "btnCommect";
            btnCommect.Size = new Size(75, 23);
            btnCommect.TabIndex = 1;
            btnCommect.Text = "연결하기";
            btnCommect.UseVisualStyleBackColor = true;
            btnCommect.Click += btnConnect_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(386, 332);
            Controls.Add(btnCommect);
            Controls.Add(btnDisconnect);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnDisconnect;
        private Button btnCommect;
    }
}