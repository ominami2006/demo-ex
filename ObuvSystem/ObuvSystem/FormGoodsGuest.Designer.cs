namespace ObuvSystem
{
    partial class FormGoodsGuest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGoodsGuest));
            this.labelFIO = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewGoods = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoods)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFIO.Location = new System.Drawing.Point(21, 18);
            this.labelFIO.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(62, 24);
            this.labelFIO.TabIndex = 0;
            this.labelFIO.Text = "Гость";
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Location = new System.Drawing.Point(1304, 10);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(150, 41);
            this.buttonLogout.TabIndex = 1;
            this.buttonLogout.Text = "Выход";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.labelFIO);
            this.panel1.Controls.Add(this.buttonLogout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1469, 57);
            this.panel1.TabIndex = 3;
            // 
            // dataGridViewGoods
            // 
            this.dataGridViewGoods.AllowUserToAddRows = false;
            this.dataGridViewGoods.AllowUserToDeleteRows = false;
            this.dataGridViewGoods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGoods.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewGoods.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewGoods.ColumnHeadersHeight = 50;
            this.dataGridViewGoods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGoods.Location = new System.Drawing.Point(0, 57);
            this.dataGridViewGoods.Name = "dataGridViewGoods";
            this.dataGridViewGoods.ReadOnly = true;
            this.dataGridViewGoods.RowHeadersVisible = false;
            this.dataGridViewGoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGoods.Size = new System.Drawing.Size(1469, 350);
            this.dataGridViewGoods.TabIndex = 4;
            // 
            // FormGoodsGuest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1469, 407);
            this.Controls.Add(this.dataGridViewGoods);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 15.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FormGoodsGuest";
            this.Text = "Просмотр товаров (Гость)";
            this.Load += new System.EventHandler(this.FormGoodsGuest_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoods)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewGoods;
    }
}