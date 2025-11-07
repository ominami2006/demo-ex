// FormOrderEdit.cs
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ObuvSystem
{
    public partial class FormOrderEdit : Form
    {
        private int? currentZakazID;
        private Form parentForm;
        private DataTable orderItemsTable = new DataTable();

        public FormOrderEdit(int? zakazID, Form parent)
        {
            InitializeComponent();
            currentZakazID = zakazID;
            parentForm = parent;
            this.Text = zakazID == null ? "Добавить заказ" : "Редактировать заказ";
        }

        private void FormOrderEdit_Load(object sender, EventArgs e)
        {
            SetupControls();
            LoadCombos();
            if (currentZakazID != null)
                LoadOrder();
        }

        private void SetupControls()
        {
            dataGridViewItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "ItemID", HeaderText = "ItemID", Visible = false });
            dataGridViewItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "Artikul", HeaderText = "Артикул", Width = 100 });
            dataGridViewItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "Naimenovanie", HeaderText = "Наименование", Width = 300 });
            dataGridViewItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "Количество", Width = 100 });
        }

        private void LoadCombos()
        {
            // === Клиенты ===
            DataTable dtClients = DbHelper.GetClients();
            comboBoxClient.DataSource = dtClients;
            comboBoxClient.DisplayMember = "FIO";
            comboBoxClient.ValueMember = "UserID";  // ДОЛЖНО БЫТЬ ТОЧНО "UserID"

            // === Пункты выдачи ===
            DataTable dtPunkty = DbHelper.GetPunktyVydachi();
            comboBoxPunkt.DataSource = dtPunkty;
            comboBoxPunkt.DisplayMember = "Adres";
            comboBoxPunkt.ValueMember = "PunktID";  // ДОЛЖНО БЫТЬ ТОЧНО "PunktID"

            // === Статус ===
            comboBoxStatus.Items.AddRange(new[] { "Новый", "Завершен" });
            comboBoxStatus.SelectedIndex = 0;

            // === Товары ===
            DataTable dtGoods = DbHelper.GetGoods();
            comboBoxArtikul.DataSource = dtGoods;
            comboBoxArtikul.DisplayMember = "Artikul";
            comboBoxArtikul.ValueMember = "Artikul";
        }

        private void comboBoxArtikul_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxArtikul.SelectedValue != null)
            {
                string artikul = comboBoxArtikul.SelectedValue.ToString();
                DataTable dt = DbHelper.GetGoods();
                DataRow[] rows = dt.Select($"Artikul = '{artikul}'");
            }
        }

        private void LoadOrder()
        {
            DataTable dt = DbHelper.GetOrders();
            DataRow[] rows = dt.Select($"ZakazID = {currentZakazID}");
            if (rows.Length > 0)
            {
                DataRow r = rows[0];
                dateTimePickerZakaz.Value = Convert.ToDateTime(r["DataZakaza"]);
                dateTimePickerDostavka.Value = Convert.ToDateTime(r["DataDostavki"]);
                textBoxKod.Text = r["Kod"].ToString();
                comboBoxStatus.Text = r["Status"].ToString();

                // Принудительно устанавливаем SelectedValue
                object punktID = r["PunktID"];
                object userID = r["UserID"];

                if (punktID != DBNull.Value)
                    comboBoxPunkt.SelectedValue = punktID;
                else
                    comboBoxPunkt.SelectedIndex = -1;

                if (userID != DBNull.Value)
                    comboBoxClient.SelectedValue = userID;
                else
                    comboBoxClient.SelectedIndex = -1;
            }
            LoadOrderItems();
        }

        private void LoadOrderItems()
        {
            if (currentZakazID != null)
            {
                DataTable dt = DbHelper.GetOrderItems(currentZakazID.Value);
                dataGridViewItems.DataSource = null;
                dataGridViewItems.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    string artikul = row["Artikul"].ToString();
                    string naim = row["Naimenovanie"].ToString();
                    int qty = Convert.ToInt32(row["Quantity"]);
                    int itemID = row["ItemID"] != DBNull.Value ? Convert.ToInt32(row["ItemID"]) : -1;

                    int idx = dataGridViewItems.Rows.Add(itemID, artikul, naim, qty);
                    dataGridViewItems.Rows[idx].Tag = itemID;
                }
            }
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            if (comboBoxArtikul.SelectedValue == null) return;

            string artikul = comboBoxArtikul.SelectedValue.ToString();
            int qty = (int)numericUpDownQuantity.Value;

            // Проверяем, есть ли уже такой артикул
            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                if (row.Cells["Artikul"].Value?.ToString() == artikul)
                {
                    row.Cells["Quantity"].Value = (int)row.Cells["Quantity"].Value + qty;
                    return;
                }
            }

            // Добавляем новую строку
            DataTable dt = DbHelper.GetGoods();
            DataRow[] goods = dt.Select($"Artikul = '{artikul}'");
            string naim = goods.Length > 0 ? goods[0]["Naimenovanie"].ToString() : artikul;

            dataGridViewItems.Rows.Add(-1, artikul, naim, qty);
        }

        private void buttonRemoveItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewItems.CurrentRow != null && !dataGridViewItems.CurrentRow.IsNewRow)
            {
                dataGridViewItems.Rows.Remove(dataGridViewItems.CurrentRow);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                // --- Валидация ---
                if (!int.TryParse(textBoxKod.Text, out int kod))
                    throw new Exception("Введите корректный код");

                if (comboBoxPunkt.SelectedValue == null)
                    throw new Exception("Выберите пункт выдачи");

                if (comboBoxClient.SelectedValue == null)
                    throw new Exception("Выберите клиента");

                if (dataGridViewItems.Rows.Count == 0 ||
                    (dataGridViewItems.Rows.Count == 1 && dataGridViewItems.Rows[0].IsNewRow))
                    throw new Exception("Добавьте хотя бы один товар");

                // --- Безопасное чтение ---
                int punktID = Convert.ToInt32(comboBoxPunkt.SelectedValue);
                int userID = Convert.ToInt32(comboBoxClient.SelectedValue);

                // --- Сохранение ---
                if (currentZakazID == null)
                {
                    int newID = DbHelper.AddOrder(
                        dateTimePickerZakaz.Value.Date,
                        dateTimePickerDostavka.Value.Date,
                        punktID, userID, kod, comboBoxStatus.Text);

                    foreach (DataGridViewRow row in dataGridViewItems.Rows)
                    {
                        if (row.IsNewRow) continue;
                        string artikul = row.Cells["Artikul"].Value.ToString();
                        int qty = Convert.ToInt32(row.Cells["Quantity"].Value);
                        DbHelper.AddOrderItem(newID, artikul, qty);
                    }
                }
                else
                {
                    DbHelper.UpdateOrder(
                        currentZakazID.Value,
                        dateTimePickerZakaz.Value.Date,
                        dateTimePickerDostavka.Value.Date,
                        punktID, userID, kod, comboBoxStatus.Text);

                    // Удаляем старые
                    foreach (DataGridViewRow row in dataGridViewItems.Rows)
                    {
                        if (row.Tag is int itemID && itemID > 0)
                            DbHelper.DeleteOrderItem(itemID);
                    }

                    // Добавляем новые
                    foreach (DataGridViewRow row in dataGridViewItems.Rows)
                    {
                        if (row.IsNewRow) continue;
                        string artikul = row.Cells["Artikul"].Value.ToString();
                        int qty = Convert.ToInt32(row.Cells["Quantity"].Value);
                        DbHelper.AddOrderItem(currentZakazID.Value, artikul, qty);
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}