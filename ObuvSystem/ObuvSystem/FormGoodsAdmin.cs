// FormGoodsAdmin.cs
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ObuvSystem
{
    public partial class FormGoodsAdmin : Form
    {
        private User user;
        private string currentSearch = "", currentPost = "", currentSort = "";

        public FormGoodsAdmin(User u)
        {
            InitializeComponent();
            user = u;
            labelFIO.Text = user.FIO;
        }

        private void FormGoodsAdmin_Load(object sender, EventArgs e)
        {
            LoadFilters();
            LoadGoods();
        }


        private void LoadFilters()
        {
            DataTable dt = DbHelper.GetPostavshiki();
            comboBoxPostavshik.Items.Add("Все поставщики");
            foreach (DataRow row in dt.Rows)
                comboBoxPostavshik.Items.Add(row["Nazvanie"]);
            comboBoxPostavshik.SelectedIndex = 0;

            comboBoxSort.Items.Add("По возрастанию");
            comboBoxSort.Items.Add("По убыванию");
            comboBoxSort.SelectedIndex = 0;
        }

        private void LoadGoods()
        {
            DataTable dt = DbHelper.GetGoods(currentSearch, currentPost, currentSort == "По возрастанию" ? "ASC" : "DESC");
            dataGridViewGoods.DataSource = dt;
            FormatGrid();
        }

        private void FormatGrid()
        {
            // 1. Скрываем колонку с путём к фото
            if (dataGridViewGoods.Columns.Contains("Foto"))
                dataGridViewGoods.Columns["Foto"].Visible = false;

            // 2. Добавляем колонку с изображением (если ещё нет)
            if (!dataGridViewGoods.Columns.Contains("ImgCol"))
            {
                var imgCol = new DataGridViewImageColumn
                {
                    HeaderText = "Фото",
                    Name = "ImgCol",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dataGridViewGoods.Columns.Insert(0, imgCol);
            }

            // 3. Подписываемся на форматирование ячеек
            dataGridViewGoods.CellFormatting -= DataGridViewGoods_CellFormatting;
            dataGridViewGoods.CellFormatting += DataGridViewGoods_CellFormatting;

            // 4. Подсветка строк
            foreach (DataGridViewRow row in dataGridViewGoods.Rows)
            {
                if (row.IsNewRow) continue;

                int skidka = Convert.ToInt32(row.Cells["Skidka"].Value);
                int kolvo = Convert.ToInt32(row.Cells["Kolvo"].Value);

                if (skidka > 15)
                    row.DefaultCellStyle.BackColor = Color.FromArgb(46, 139, 87); // тёмно-зелёный
                if (kolvo == 0)
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
            }
        }

        private void DataGridViewGoods_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid == null || e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var column = grid.Columns[e.ColumnIndex];

            // === Форматирование цены со скидкой ===
            if (column.Name == "Cena")
            {
                if (e.Value is decimal cena)
                {
                    int skidka = Convert.ToInt32(grid.Rows[e.RowIndex].Cells["Skidka"].Value);
                    if (skidka > 0)
                    {
                        decimal newCena = cena * (1 - skidka / 100m);
                        e.Value = $"{cena:C} → {newCena:C}";
                        e.CellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        e.Value = $"{cena:C}";
                    }
                    e.FormattingApplied = true;
                }
            }

            // === Фото ===
            else if (column.Name == "ImgCol")
            {
                string fotoPath = grid.Rows[e.RowIndex].Cells["Foto"].Value as string;
                Image img;

                if (!string.IsNullOrEmpty(fotoPath) && File.Exists(fotoPath))
                    img = Image.FromFile(fotoPath);
                else
                    img = Properties.Resources.picture;

                // Масштабируем до 80x60 (или подгони под нужный размер)
                img = new Bitmap(img, new Size(80, 60));
                e.Value = img;
                e.FormattingApplied = true;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            new FormGoodEdit(null, this).ShowDialog();
            LoadGoods();
        }

        private void dataGridViewGoods_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewGoods.CurrentRow != null && !dataGridViewGoods.CurrentRow.IsNewRow)
            {
                string artikul = dataGridViewGoods.CurrentRow.Cells["Artikul"].Value.ToString();
                new FormGoodEdit(artikul, this).ShowDialog();
                LoadGoods();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewGoods.CurrentRow != null && !dataGridViewGoods.CurrentRow.IsNewRow)
            {
                string artikul = dataGridViewGoods.CurrentRow.Cells["Artikul"].Value.ToString();
                if (!DbHelper.CanDeleteGood(artikul))
                {
                    MessageBox.Show("Товар используется в заказах. Удаление невозможно.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Удалить товар?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DbHelper.DeleteGood(artikul);
                    LoadGoods();
                }
            }
        }

        private void buttonOrders_Click(object sender, EventArgs e)
        {
            new FormOrders(user, true).ShowDialog();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Close();
        }


        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            currentSearch = textBoxSearch.Text;
            LoadGoods();
        }

        private void comboBoxPostavshik_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPost = comboBoxPostavshik.SelectedItem.ToString();
            LoadGoods();
        }

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSort = comboBoxSort.SelectedItem.ToString();
            LoadGoods();
        }
    }
}