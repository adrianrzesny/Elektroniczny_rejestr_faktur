namespace Faktury.Widoki
{
    partial class LoginMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbltytul = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblHaslo = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtHasło = new System.Windows.Forms.TextBox();
            this.btnZaloguj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbltytul
            // 
            this.lbltytul.AutoSize = true;
            this.lbltytul.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbltytul.ForeColor = System.Drawing.Color.Black;
            this.lbltytul.Location = new System.Drawing.Point(496, 231);
            this.lbltytul.Name = "lbltytul";
            this.lbltytul.Size = new System.Drawing.Size(207, 29);
            this.lbltytul.TabIndex = 0;
            this.lbltytul.Text = "Panel logowania";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblLogin.ForeColor = System.Drawing.Color.Black;
            this.lblLogin.Location = new System.Drawing.Point(415, 334);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(60, 25);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "Login";
            // 
            // lblHaslo
            // 
            this.lblHaslo.AutoSize = true;
            this.lblHaslo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblHaslo.ForeColor = System.Drawing.Color.Black;
            this.lblHaslo.Location = new System.Drawing.Point(415, 389);
            this.lblHaslo.Name = "lblHaslo";
            this.lblHaslo.Size = new System.Drawing.Size(62, 25);
            this.lblHaslo.TabIndex = 2;
            this.lblHaslo.Text = "Hasło";
            // 
            // txtLogin
            // 
            this.txtLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtLogin.Location = new System.Drawing.Point(528, 329);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(247, 30);
            this.txtLogin.TabIndex = 3;
            this.txtLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLogin_KeyPress);
            // 
            // txtHasło
            // 
            this.txtHasło.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtHasło.Location = new System.Drawing.Point(528, 384);
            this.txtHasło.Name = "txtHasło";
            this.txtHasło.PasswordChar = '*';
            this.txtHasło.Size = new System.Drawing.Size(247, 30);
            this.txtHasło.TabIndex = 4;
            this.txtHasło.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHasło_KeyPress);
            // 
            // btnZaloguj
            // 
            this.btnZaloguj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnZaloguj.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnZaloguj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnZaloguj.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnZaloguj.Location = new System.Drawing.Point(648, 439);
            this.btnZaloguj.Name = "btnZaloguj";
            this.btnZaloguj.Size = new System.Drawing.Size(127, 36);
            this.btnZaloguj.TabIndex = 5;
            this.btnZaloguj.Text = "Zaloguj";
            this.btnZaloguj.UseVisualStyleBackColor = false;
            this.btnZaloguj.Click += new System.EventHandler(this.btnZaloguj_Click);
            // 
            // LoginMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.btnZaloguj);
            this.Controls.Add(this.txtHasło);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblHaslo);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.lbltytul);
            this.Name = "LoginMenu";
            this.Size = new System.Drawing.Size(1200, 750);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltytul;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblHaslo;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtHasło;
        private System.Windows.Forms.Button btnZaloguj;
    }
}
