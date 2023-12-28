namespace VYSProject
{
    partial class kitapForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.kitAl = new System.Windows.Forms.Button();
            this.myKit = new System.Windows.Forms.Button();
            this.cikis = new System.Windows.Forms.Button();
            this.tumKit = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(602, 228);
            this.dataGridView1.TabIndex = 0;
            // 
            // kitAl
            // 
            this.kitAl.Location = new System.Drawing.Point(681, 12);
            this.kitAl.Name = "kitAl";
            this.kitAl.Size = new System.Drawing.Size(129, 65);
            this.kitAl.TabIndex = 1;
            this.kitAl.Text = "Kitap Ödünç Al";
            this.kitAl.UseVisualStyleBackColor = true;
            this.kitAl.Click += new System.EventHandler(this.kitAl_Click);
            // 
            // myKit
            // 
            this.myKit.Location = new System.Drawing.Point(681, 175);
            this.myKit.Name = "myKit";
            this.myKit.Size = new System.Drawing.Size(129, 65);
            this.myKit.TabIndex = 2;
            this.myKit.Text = "Ödünç Alınan Kitaplarım";
            this.myKit.UseVisualStyleBackColor = true;
            this.myKit.Click += new System.EventHandler(this.myKit_Click);
            // 
            // cikis
            // 
            this.cikis.Location = new System.Drawing.Point(759, 391);
            this.cikis.Name = "cikis";
            this.cikis.Size = new System.Drawing.Size(99, 47);
            this.cikis.TabIndex = 3;
            this.cikis.Text = "Çıkış";
            this.cikis.UseVisualStyleBackColor = true;
            this.cikis.Click += new System.EventHandler(this.cikis_Click);
            // 
            // tumKit
            // 
            this.tumKit.Location = new System.Drawing.Point(133, 419);
            this.tumKit.Name = "tumKit";
            this.tumKit.ReadOnly = true;
            this.tumKit.Size = new System.Drawing.Size(100, 22);
            this.tumKit.TabIndex = 4;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 422);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(115, 16);
            this.label.TabIndex = 5;
            this.label.Text = "Kayıtlı Kitap Sayısı";
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(92, 260);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(146, 22);
            this.search.TabIndex = 6;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "İsim Arama";
            // 
            // kitapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.search);
            this.Controls.Add(this.label);
            this.Controls.Add(this.tumKit);
            this.Controls.Add(this.cikis);
            this.Controls.Add(this.myKit);
            this.Controls.Add(this.kitAl);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "kitapForm";
            this.Text = "kitapForm";
            this.Load += new System.EventHandler(this.kitapForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button kitAl;
        private System.Windows.Forms.Button myKit;
        private System.Windows.Forms.Button cikis;
        private System.Windows.Forms.TextBox tumKit;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.Label label1;
    }
}