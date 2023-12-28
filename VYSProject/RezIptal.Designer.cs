namespace VYSProject
{
    partial class RezIptal
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
            this.rezIp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rezIp
            // 
            this.rezIp.Location = new System.Drawing.Point(50, 12);
            this.rezIp.Name = "rezIp";
            this.rezIp.Size = new System.Drawing.Size(265, 193);
            this.rezIp.TabIndex = 0;
            this.rezIp.Text = "Rezervasyon Iptal";
            this.rezIp.UseVisualStyleBackColor = true;
            this.rezIp.Click += new System.EventHandler(this.rezIp_Click);
            // 
            // RezIptal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 217);
            this.Controls.Add(this.rezIp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RezIptal";
            this.Text = "RezIptal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button rezIp;
    }
}