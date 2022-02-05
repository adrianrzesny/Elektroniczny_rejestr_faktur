namespace Faktury.Widoki
{
    partial class Faktury
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
            this.lblFaktury = new System.Windows.Forms.Label();
            this.lblPozycjeFaktur = new System.Windows.Forms.Label();
            this.btnDodajFakture = new System.Windows.Forms.Button();
            this.btnEdytujFakture = new System.Windows.Forms.Button();
            this.btnusunFakture = new System.Windows.Forms.Button();
            this.gvFaktury = new System.Windows.Forms.DataGridView();
            this.gvFakturyPozycje = new System.Windows.Forms.DataGridView();
            this.btnWyloguj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvFaktury)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFakturyPozycje)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFaktury
            // 
            this.lblFaktury.AutoSize = true;
            this.lblFaktury.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblFaktury.ForeColor = System.Drawing.Color.Black;
            this.lblFaktury.Location = new System.Drawing.Point(15, 16);
            this.lblFaktury.Name = "lblFaktury";
            this.lblFaktury.Size = new System.Drawing.Size(77, 25);
            this.lblFaktury.TabIndex = 2;
            this.lblFaktury.Text = "Faktury";
            // 
            // lblPozycjeFaktur
            // 
            this.lblPozycjeFaktur.AutoSize = true;
            this.lblPozycjeFaktur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPozycjeFaktur.ForeColor = System.Drawing.Color.Black;
            this.lblPozycjeFaktur.Location = new System.Drawing.Point(15, 352);
            this.lblPozycjeFaktur.Name = "lblPozycjeFaktur";
            this.lblPozycjeFaktur.Size = new System.Drawing.Size(144, 25);
            this.lblPozycjeFaktur.TabIndex = 3;
            this.lblPozycjeFaktur.Text = "Pozycje faktury";
            // 
            // btnDodajFakture
            // 
            this.btnDodajFakture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDodajFakture.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDodajFakture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDodajFakture.Location = new System.Drawing.Point(20, 701);
            this.btnDodajFakture.Name = "btnDodajFakture";
            this.btnDodajFakture.Size = new System.Drawing.Size(127, 36);
            this.btnDodajFakture.TabIndex = 4;
            this.btnDodajFakture.Text = "Dodaj";
            this.btnDodajFakture.UseVisualStyleBackColor = false;
            this.btnDodajFakture.Click += new System.EventHandler(this.btnDodajFakture_Click);
            // 
            // btnEdytujFakture
            // 
            this.btnEdytujFakture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEdytujFakture.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEdytujFakture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEdytujFakture.Location = new System.Drawing.Point(153, 701);
            this.btnEdytujFakture.Name = "btnEdytujFakture";
            this.btnEdytujFakture.Size = new System.Drawing.Size(127, 36);
            this.btnEdytujFakture.TabIndex = 5;
            this.btnEdytujFakture.Text = "Edytuj";
            this.btnEdytujFakture.UseVisualStyleBackColor = false;
            this.btnEdytujFakture.Click += new System.EventHandler(this.btnEdytujFakture_Click);
            // 
            // btnusunFakture
            // 
            this.btnusunFakture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnusunFakture.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnusunFakture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnusunFakture.Location = new System.Drawing.Point(286, 701);
            this.btnusunFakture.Name = "btnusunFakture";
            this.btnusunFakture.Size = new System.Drawing.Size(127, 36);
            this.btnusunFakture.TabIndex = 6;
            this.btnusunFakture.Text = "Usuń";
            this.btnusunFakture.UseVisualStyleBackColor = false;
            this.btnusunFakture.Click += new System.EventHandler(this.btnusunFakture_Click);
            // 
            // gvFaktury
            // 
            this.gvFaktury.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gvFaktury.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFaktury.Location = new System.Drawing.Point(20, 44);
            this.gvFaktury.MultiSelect = false;
            this.gvFaktury.Name = "gvFaktury";
            this.gvFaktury.ReadOnly = true;
            this.gvFaktury.RowHeadersVisible = false;
            this.gvFaktury.RowHeadersWidth = 51;
            this.gvFaktury.RowTemplate.Height = 24;
            this.gvFaktury.Size = new System.Drawing.Size(1157, 289);
            this.gvFaktury.TabIndex = 7;
            this.gvFaktury.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFaktury_CellContentClick);
            this.gvFaktury.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFaktury_CellDoubleClick);
            // 
            // gvFakturyPozycje
            // 
            this.gvFakturyPozycje.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gvFakturyPozycje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFakturyPozycje.Location = new System.Drawing.Point(20, 380);
            this.gvFakturyPozycje.Name = "gvFakturyPozycje";
            this.gvFakturyPozycje.ReadOnly = true;
            this.gvFakturyPozycje.RowHeadersVisible = false;
            this.gvFakturyPozycje.RowHeadersWidth = 51;
            this.gvFakturyPozycje.RowTemplate.Height = 24;
            this.gvFakturyPozycje.Size = new System.Drawing.Size(1157, 302);
            this.gvFakturyPozycje.TabIndex = 9;
            this.gvFakturyPozycje.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFakturyPozycje_CellClick);
            // 
            // btnWyloguj
            // 
            this.btnWyloguj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnWyloguj.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnWyloguj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWyloguj.Location = new System.Drawing.Point(1050, 5);
            this.btnWyloguj.Name = "btnWyloguj";
            this.btnWyloguj.Size = new System.Drawing.Size(127, 36);
            this.btnWyloguj.TabIndex = 9;
            this.btnWyloguj.Text = "Wyloguj";
            this.btnWyloguj.UseVisualStyleBackColor = false;
            this.btnWyloguj.Click += new System.EventHandler(this.btnWyloguj_Click);
            // 
            // Faktury
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.btnWyloguj);
            this.Controls.Add(this.gvFakturyPozycje);
            this.Controls.Add(this.gvFaktury);
            this.Controls.Add(this.btnusunFakture);
            this.Controls.Add(this.btnEdytujFakture);
            this.Controls.Add(this.btnDodajFakture);
            this.Controls.Add(this.lblPozycjeFaktur);
            this.Controls.Add(this.lblFaktury);
            this.Name = "Faktury";
            this.Size = new System.Drawing.Size(1200, 750);
            ((System.ComponentModel.ISupportInitialize)(this.gvFaktury)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFakturyPozycje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFaktury;
        private System.Windows.Forms.Label lblPozycjeFaktur;
        private System.Windows.Forms.Button btnDodajFakture;
        private System.Windows.Forms.Button btnEdytujFakture;
        private System.Windows.Forms.Button btnusunFakture;
        private System.Windows.Forms.DataGridView gvFaktury;
        private System.Windows.Forms.DataGridView gvFakturyPozycje;
        private System.Windows.Forms.Button btnWyloguj;
    }
}
