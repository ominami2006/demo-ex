// FormGoodEdit.cs
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ObuvSystem
{
    public partial class FormGoodEdit : Form
    {
        private string currentArtikul;
        private Form parentForm;

        public FormGoodEdit(string artikul, Form parent)
        {
            InitializeComponent();
            currentArtikul = artikul;
            parentForm = parent;
        }

        private void FormGoodEdit_Load(object sender, EventArgs e)
        {
            LoadCombos();
            if (currentArtikul != null)
            {
                LoadGood();
                textBoxArtikul.ReadOnly = true;
            }
            else
            {
                textBoxArtikul.Text = "NEW" + DateTime.Now.Ticks;
            }
        }

        private void LoadCombos()
        {
            DataTable dt;
            dt = DbHelper.GetPostavshiki();
            comboBoxPostavshik.DataSource = dt;
            comboBoxPostavshik.DisplayMember = "Nazvanie";
            comboBoxPostavshik.ValueMember = "PostID";

            dt = DbHelper.GetProizvoditeli();
            comboBoxProizvoditel.DataSource = dt;
            comboBoxProizvoditel.DisplayMember = "Nazvanie";
            comboBoxProizvoditel.ValueMember = "ProizID";

            dt = DbHelper.GetKategorii();
            comboBoxKategoria.DataSource = dt;
            comboBoxKategoria.DisplayMember = "Nazvanie";
            comboBoxKategoria.ValueMember = "KatID";
        }

        private void LoadGood()
        {
            DataTable dt = DbHelper.GetGoods("", "", "");
            DataRow[] rows = dt.Select($"Artikul = '{currentArtikul}'");
            if (rows.Length > 0)
            {
                DataRow r = rows[0];
                textBoxArtikul.Text = r["Artikul"].ToString();
                textBoxNaim.Text = r["Naimenovanie"].ToString();
                textBoxEdIzm.Text = r["EdIzm"].ToString();
                textBoxCena.Text = r["Cena"].ToString();
                comboBoxPostavshik.SelectedValue = dt.Select($"Nazvanie = '{r["Postavshik"]}'")[0]["PostID"];
                comboBoxProizvoditel.SelectedValue = dt.Select($"Nazvanie = '{r["Proizvoditel"]}'")[0]["ProizID"];
                comboBoxKategoria.SelectedValue = dt.Select($"Nazvanie = '{r["Kategoria"]}'")[0]["KatID"];
                numericUpDownSkidka.Value = Convert.ToInt32(r["Skidka"]);
                numericUpDownKolvo.Value = Convert.ToInt32(r["Kolvo"]);
                richTextBoxOpis.Text = r["Opisanie"].ToString();
                string foto = r["Foto"].ToString();

                if (!string.IsNullOrEmpty(foto) && File.Exists(foto))
                    pictureBoxFoto.Image = Image.FromFile(foto);


            }
        }

        private void pictureBoxFoto_Click(object sender, EventArgs e)
        {
            string oldPath = pictureBoxFoto.Tag as string;
            DbHelper.UploadImage(pictureBoxFoto, oldPath);
            pictureBoxFoto.Tag = pictureBoxFoto.ImageLocation;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxArtikul.Text)) throw new Exception("Введите артикул");
                decimal cena = decimal.Parse(textBoxCena.Text);
                if (cena < 0) throw new Exception("Цена не может быть отрицательной");
                int kolvo = (int)numericUpDownKolvo.Value;
                if (kolvo < 0) throw new Exception("Количество не может быть отрицательным");

                int postID = (int)comboBoxPostavshik.SelectedValue;
                int proizID = (int)comboBoxProizvoditel.SelectedValue;
                int katID = (int)comboBoxKategoria.SelectedValue;

                string fotoPath = pictureBoxFoto.Tag as string;

                DbHelper.AddOrUpdateGood(textBoxArtikul.Text, textBoxNaim.Text, textBoxEdIzm.Text, cena, postID, proizID, katID,
                    (int)numericUpDownSkidka.Value, kolvo, richTextBoxOpis.Text, fotoPath, currentArtikul == null);

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