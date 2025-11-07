// FormLogin.cs
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ObuvSystem
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            buttonLogin.BackColor = Color.FromArgb(0, 250, 154);
            buttonGuest.BackColor = Color.FromArgb(127, 255, 0);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxLogin.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User user = DbHelper.Authenticate(textBoxLogin.Text, textBoxPassword.Text);
            if (user != null)
            {
                this.Hide();
                if (user.Role == "Авторизированный клиент")
                    new FormGoodsClient(user).Show();
                else if (user.Role == "Менеджер")
                    new FormGoodsManager(user).Show();
                else if (user.Role == "Администратор")
                    new FormGoodsAdmin(user).Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonGuest_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormGoodsGuest().Show();
        }
    }
}