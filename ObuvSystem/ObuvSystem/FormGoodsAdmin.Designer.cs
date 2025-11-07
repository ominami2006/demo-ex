namespace ObuvSystem
{
    partial class FormGoodsAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGoodsAdmin));
            this.labelFIO = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonOrders = new System.Windows.Forms.Button();
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.comboBoxPostavshik = new System.Windows.Forms.ComboBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.dataGridViewGoods = new System.Windows.Forms.DataGridView();
            this.panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoods)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFIO.Location = new System.Drawing.Point(15, 18);
            this.labelFIO.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(89, 24);
            this.labelFIO.TabIndex = 0;
            this.labelFIO.Text = "labelFIO";
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Location = new System.Drawing.Point(1272, 64);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(117, 31);
            this.buttonLogout.TabIndex = 1;
            this.buttonLogout.Text = "Выход";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.Color.White;
            this.panelFilters.Controls.Add(this.buttonAdd);
            this.panelFilters.Controls.Add(this.buttonDelete);
            this.panelFilters.Controls.Add(this.buttonOrders);
            this.panelFilters.Controls.Add(this.comboBoxSort);
            this.panelFilters.Controls.Add(this.comboBoxPostavshik);
            this.panelFilters.Controls.Add(this.textBoxSearch);
            this.panelFilters.Controls.Add(this.labelFIO);
            this.panelFilters.Controls.Add(this.buttonLogout);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(0, 0);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(1432, 119);
            this.panelFilters.TabIndex = 3;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Location = new System.Drawing.Point(924, 64);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(108, 31);
            this.buttonAdd.TabIndex = 7;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Location = new System.Drawing.Point(1040, 64);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(108, 31);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonOrders
            // 
            this.buttonOrders.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.buttonOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOrders.Location = new System.Drawing.Point(1156, 64);
            this.buttonOrders.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonOrders.Name = "buttonOrders";
            this.buttonOrders.Size = new System.Drawing.Size(108, 31);
            this.buttonOrders.TabIndex = 5;
            this.buttonOrders.Text = "Заказы";
            this.buttonOrders.UseVisualStyleBackColor = false;
            this.buttonOrders.Click += new System.EventHandler(this.buttonOrders_Click);
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Location = new System.Drawing.Point(485, 65);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(195, 31);
            this.comboBoxSort.TabIndex = 4;
            this.comboBoxSort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSort_SelectedIndexChanged);
            // 
            // comboBoxPostavshik
            // 
            this.comboBoxPostavshik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPostavshik.FormattingEnabled = true;
            this.comboBoxPostavshik.Location = new System.Drawing.Point(285, 65);
            this.comboBoxPostavshik.Name = "comboBoxPostavshik";
            this.comboBoxPostavshik.Size = new System.Drawing.Size(194, 31);
            this.comboBoxPostavshik.TabIndex = 3;
            this.comboBoxPostavshik.SelectedIndexChanged += new System.EventHandler(this.comboBoxPostavshik_SelectedIndexChanged);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(17, 65);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(262, 32);
            this.textBoxSearch.TabIndex = 2;
            this.textBoxSearch.Text = "Поиск…";
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
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
            this.dataGridViewGoods.Location = new System.Drawing.Point(0, 119);
            this.dataGridViewGoods.Name = "dataGridViewGoods";
            this.dataGridViewGoods.RowHeadersVisible = false;
            this.dataGridViewGoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGoods.Size = new System.Drawing.Size(1432, 425);
            this.dataGridViewGoods.TabIndex = 4;
            this.dataGridViewGoods.DoubleClick += new System.EventHandler(this.dataGridViewGoods_DoubleClick);
            // 
            // FormGoodsAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1432, 544);
            this.Controls.Add(this.dataGridViewGoods);
            this.Controls.Add(this.panelFilters);
            this.Font = new System.Drawing.Font("Times New Roman", 15.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FormGoodsAdmin";
            this.Text = "Управление товарами (Администратор)";
            this.Load += new System.EventHandler(this.FormGoodsAdmin_Load);
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoods)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.DataGridView dataGridViewGoods;
        private System.Windows.Forms.ComboBox comboBoxPostavshik;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonOrders;
        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
    }
}