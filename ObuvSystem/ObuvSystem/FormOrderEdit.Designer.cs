namespace ObuvSystem
{
    partial class FormOrderEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrderEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxKod = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPunkt = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dateTimePickerZakaz = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDostavka = new System.Windows.Forms.DateTimePicker();
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.groupBoxItems = new System.Windows.Forms.GroupBox();
            this.buttonRemoveItem = new System.Windows.Forms.Button();
            this.comboBoxArtikul = new System.Windows.Forms.ComboBox();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.groupBoxItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Дата заказа:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Дата доставки:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Пункт выдачи:";
            // 
            // textBoxKod
            // 
            this.textBoxKod.Location = new System.Drawing.Point(248, 190);
            this.textBoxKod.Name = "textBoxKod";
            this.textBoxKod.Size = new System.Drawing.Size(287, 32);
            this.textBoxKod.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Клиент:";
            // 
            // comboBoxPunkt
            // 
            this.comboBoxPunkt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPunkt.FormattingEnabled = true;
            this.comboBoxPunkt.Location = new System.Drawing.Point(248, 114);
            this.comboBoxPunkt.Name = "comboBoxPunkt";
            this.comboBoxPunkt.Size = new System.Drawing.Size(287, 31);
            this.comboBoxPunkt.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Код:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(94, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Статус:";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(98, 546);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(437, 38);
            this.buttonSave.TabIndex = 21;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(98, 590);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(437, 38);
            this.buttonCancel.TabIndex = 22;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // dateTimePickerZakaz
            // 
            this.dateTimePickerZakaz.Location = new System.Drawing.Point(248, 34);
            this.dateTimePickerZakaz.Name = "dateTimePickerZakaz";
            this.dateTimePickerZakaz.Size = new System.Drawing.Size(287, 32);
            this.dateTimePickerZakaz.TabIndex = 23;
            // 
            // dateTimePickerDostavka
            // 
            this.dateTimePickerDostavka.Location = new System.Drawing.Point(248, 72);
            this.dateTimePickerDostavka.Name = "dateTimePickerDostavka";
            this.dateTimePickerDostavka.Size = new System.Drawing.Size(287, 32);
            this.dateTimePickerDostavka.TabIndex = 24;
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(248, 152);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(287, 31);
            this.comboBoxClient.TabIndex = 25;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "Новый",
            "Завершен"});
            this.comboBoxStatus.Location = new System.Drawing.Point(248, 227);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(287, 31);
            this.comboBoxStatus.TabIndex = 26;
            // 
            // groupBoxItems
            // 
            this.groupBoxItems.Controls.Add(this.buttonRemoveItem);
            this.groupBoxItems.Controls.Add(this.comboBoxArtikul);
            this.groupBoxItems.Controls.Add(this.numericUpDownQuantity);
            this.groupBoxItems.Controls.Add(this.buttonAddItem);
            this.groupBoxItems.Controls.Add(this.label8);
            this.groupBoxItems.Controls.Add(this.label7);
            this.groupBoxItems.Controls.Add(this.dataGridViewItems);
            this.groupBoxItems.Location = new System.Drawing.Point(24, 274);
            this.groupBoxItems.Name = "groupBoxItems";
            this.groupBoxItems.Size = new System.Drawing.Size(590, 266);
            this.groupBoxItems.TabIndex = 27;
            this.groupBoxItems.TabStop = false;
            this.groupBoxItems.Text = "Товары в заказе";
            // 
            // buttonRemoveItem
            // 
            this.buttonRemoveItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveItem.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRemoveItem.Location = new System.Drawing.Point(307, 222);
            this.buttonRemoveItem.Name = "buttonRemoveItem";
            this.buttonRemoveItem.Size = new System.Drawing.Size(264, 32);
            this.buttonRemoveItem.TabIndex = 30;
            this.buttonRemoveItem.Text = "Удалить выбранное";
            this.buttonRemoveItem.UseVisualStyleBackColor = false;
            this.buttonRemoveItem.Click += new System.EventHandler(this.buttonRemoveItem_Click);
            // 
            // comboBoxArtikul
            // 
            this.comboBoxArtikul.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxArtikul.FormattingEnabled = true;
            this.comboBoxArtikul.Location = new System.Drawing.Point(111, 28);
            this.comboBoxArtikul.Name = "comboBoxArtikul";
            this.comboBoxArtikul.Size = new System.Drawing.Size(196, 31);
            this.comboBoxArtikul.TabIndex = 31;
            this.comboBoxArtikul.SelectedIndexChanged += new System.EventHandler(this.comboBoxArtikul_SelectedIndexChanged);
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Location = new System.Drawing.Point(397, 29);
            this.numericUpDownQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(174, 32);
            this.numericUpDownQuantity.TabIndex = 30;
            this.numericUpDownQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.buttonAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddItem.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddItem.Location = new System.Drawing.Point(21, 222);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(280, 32);
            this.buttonAddItem.TabIndex = 29;
            this.buttonAddItem.Text = "Добавить товар";
            this.buttonAddItem.UseVisualStyleBackColor = false;
            this.buttonAddItem.Click += new System.EventHandler(this.buttonAddItem_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(313, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 23);
            this.label8.TabIndex = 28;
            this.label8.Text = "Кол-во:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 23);
            this.label7.TabIndex = 28;
            this.label7.Text = "Артикул:";
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.AllowUserToAddRows = false;
            this.dataGridViewItems.AllowUserToDeleteRows = false;
            this.dataGridViewItems.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Location = new System.Drawing.Point(21, 66);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.ReadOnly = true;
            this.dataGridViewItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewItems.Size = new System.Drawing.Size(550, 150);
            this.dataGridViewItems.TabIndex = 0;
            // 
            // FormOrderEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(626, 657);
            this.Controls.Add(this.groupBoxItems);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.comboBoxClient);
            this.Controls.Add(this.dateTimePickerDostavka);
            this.Controls.Add(this.dateTimePickerZakaz);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxPunkt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxKod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 15.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FormOrderEdit";
            this.Text = "Добавить/Редактировать заказ";
            this.Load += new System.EventHandler(this.FormOrderEdit_Load);
            this.groupBoxItems.ResumeLayout(false);
            this.groupBoxItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxKod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxPunkt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DateTimePicker dateTimePickerZakaz;
        private System.Windows.Forms.DateTimePicker dateTimePickerDostavka;
        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.GroupBox groupBoxItems;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.ComboBox comboBoxArtikul;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonRemoveItem;
    }
}