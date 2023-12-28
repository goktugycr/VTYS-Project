namespace VYSProject
{
    partial class islemTuru
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
            this.kitAl = new System.Windows.Forms.Button();
            this.rezAl = new System.Windows.Forms.Button();
            this.cikis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // kitAl
            // 
            this.kitAl.Location = new System.Drawing.Point(128, 155);
            this.kitAl.Name = "kitAl";
            this.kitAl.Size = new System.Drawing.Size(189, 104);
            this.kitAl.TabIndex = 0;
            this.kitAl.Text = "Kitap Ödünç";
            this.kitAl.UseVisualStyleBackColor = true;
            this.kitAl.Click += new System.EventHandler(this.kitAl_Click);
            // 
            // rezAl
            // 
            this.rezAl.Location = new System.Drawing.Point(483, 155);
            this.rezAl.Name = "rezAl";
            this.rezAl.Size = new System.Drawing.Size(188, 104);
            this.rezAl.TabIndex = 1;
            this.rezAl.Text = "Masa Rezervasyonu";
            this.rezAl.UseVisualStyleBackColor = true;
            this.rezAl.Click += new System.EventHandler(this.rezAl_Click);
            // 
            // cikis
            // 
            this.cikis.Location = new System.Drawing.Point(618, 344);
            this.cikis.Name = "cikis";
            this.cikis.Size = new System.Drawing.Size(132, 51);
            this.cikis.TabIndex = 2;
            this.cikis.Text = "Çıkış";
            this.cikis.UseVisualStyleBackColor = true;
            this.cikis.Click += new System.EventHandler(this.cikis_Click);
            // 
            // islemTuru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cikis);
            this.Controls.Add(this.rezAl);
            this.Controls.Add(this.kitAl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "islemTuru";
            this.Text = "islemTuru";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button kitAl;
        private System.Windows.Forms.Button rezAl;
        private System.Windows.Forms.Button cikis;
    }
}