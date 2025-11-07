// FormOrders.cs
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ObuvSystem
{
    public partial class FormOrders : Form
    {
        private User user;
        private bool isAdmin;

        public FormOrders(User u, bool admin)
        {
            InitializeComponent();
            user = u;
            isAdmin = admin;
        }

        private void FormOrders_Load(object sender, EventArgs e)
        {
            LoadOrders();
            if (isAdmin)
            {
                buttonAdd.Visible = true;
                buttonDelete.Visible = true;
            }
        }

        private void LoadOrders()
        {
            dataGridViewOrders.DataSource = DbHelper.GetOrders();

            // Скрываем ID
            if (dataGridViewOrders.Columns.Contains("PunktID"))
                dataGridViewOrders.Columns["PunktID"].Visible = false;
            if (dataGridViewOrders.Columns.Contains("UserID"))
                dataGridViewOrders.Columns["UserID"].Visible = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            new FormOrderEdit(null, this).ShowDialog();
            LoadOrders();
        }

        private void dataGridViewOrders_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewOrders.CurrentRow != null && !dataGridViewOrders.CurrentRow.IsNewRow)
            {
                int id = Convert.ToInt32(dataGridViewOrders.CurrentRow.Cells["ZakazID"].Value);
                new FormOrderEdit(id, this).ShowDialog();
                LoadOrders();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.CurrentRow != null && !dataGridViewOrders.CurrentRow.IsNewRow)
            {
                int id = Convert.ToInt32(dataGridViewOrders.CurrentRow.Cells["ZakazID"].Value);
                if (MessageBox.Show("Удалить заказ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DbHelper.DeleteOrder(id);
                    LoadOrders();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}