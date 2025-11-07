// FormGoodsClient.cs
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ObuvSystem
{
    public partial class FormGoodsClient : Form
    {
        private User user;

        public FormGoodsClient(User u)
        {
            InitializeComponent();
            user = u;
            labelFIO.Text = user.FIO;
        }

        private void FormGoodsClient_Load(object sender, EventArgs e)
        {
            LoadGoods();
        }

        private void LoadGoods() => LoadGoodsGrid(DbHelper.GetGoods());

        private void LoadGoodsGrid(DataTable dt)
        {
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

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Close();
        }
    }
}