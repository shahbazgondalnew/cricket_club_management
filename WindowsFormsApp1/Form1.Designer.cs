namespace WindowsFormsApp1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.updateBut = new System.Windows.Forms.Button();
            this.userNameText = new System.Windows.Forms.TextBox();
            this.passtext = new System.Windows.Forms.TextBox();
            this.nameLab = new System.Windows.Forms.Label();
            this.statePass = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // updateBut
            // 
            this.updateBut.Location = new System.Drawing.Point(207, 158);
            this.updateBut.Name = "updateBut";
            this.updateBut.Size = new System.Drawing.Size(75, 23);
            this.updateBut.TabIndex = 1;
            this.updateBut.Text = "Login";
            this.updateBut.UseVisualStyleBackColor = true;
            this.updateBut.Click += new System.EventHandler(this.updateBut_Click);
            // 
            // userNameText
            // 
            this.userNameText.Location = new System.Drawing.Point(86, 50);
            this.userNameText.Name = "userNameText";
            this.userNameText.Size = new System.Drawing.Size(196, 20);
            this.userNameText.TabIndex = 3;
            this.userNameText.TextChanged += new System.EventHandler(this.nametext_TextChanged);
            // 
            // passtext
            // 
            this.passtext.Location = new System.Drawing.Point(86, 97);
            this.passtext.Name = "passtext";
            this.passtext.Size = new System.Drawing.Size(196, 20);
            this.passtext.TabIndex = 4;
            this.passtext.TextChanged += new System.EventHandler(this.passtext_TextChanged);
            // 
            // nameLab
            // 
            this.nameLab.AutoSize = true;
            this.nameLab.Location = new System.Drawing.Point(25, 53);
            this.nameLab.Name = "nameLab";
            this.nameLab.Size = new System.Drawing.Size(57, 13);
            this.nameLab.TabIndex = 5;
            this.nameLab.Text = "UserName";
            this.nameLab.Click += new System.EventHandler(this.label1_Click);
            // 
            // statePass
            // 
            this.statePass.AutoSize = true;
            this.statePass.Location = new System.Drawing.Point(25, 97);
            this.statePass.Name = "statePass";
            this.statePass.Size = new System.Drawing.Size(53, 13);
            this.statePass.TabIndex = 6;
            this.statePass.Text = "Password";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 402);
            this.Controls.Add(this.statePass);
            this.Controls.Add(this.nameLab);
            this.Controls.Add(this.passtext);
            this.Controls.Add(this.userNameText);
            this.Controls.Add(this.updateBut);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button updateBut;
        private System.Windows.Forms.TextBox userNameText;
        private System.Windows.Forms.TextBox passtext;
        private System.Windows.Forms.Label nameLab;
        private System.Windows.Forms.Label statePass;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

