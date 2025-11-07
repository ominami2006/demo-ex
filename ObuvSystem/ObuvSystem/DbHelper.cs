// DbHelper.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ObuvSystem
{
    public static class DbHelper
    {
        private static string connStr = @"Data Source=adclg1;Initial Catalog=ObuvDB;Integrated Security=True";

        public static User Authenticate(string login, string password)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT u.UserID, r.RoleName, u.FIO FROM Users u JOIN Roles r ON u.RoleID = r.RoleID WHERE u.Login = @login AND u.Password = @password", conn);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new User { UserID = reader.GetInt32(0), Role = reader.GetString(1), FIO = reader.GetString(2) };
                }
                return null;
            }
        }

        public static DataTable GetGoods(string search = "", string postavshik = "", string sort = "")
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"
                    SELECT t.Artikul, t.Naimenovanie, t.EdIzm, t.Cena, p.Nazvanie AS Postavshik, pr.Nazvanie AS Proizvoditel, 
                           k.Nazvanie AS Kategoria, t.Skidka, t.Kolvo, t.Opisanie, t.Foto
                    FROM Tovar t
                    JOIN Postavshiki p ON t.PostID = p.PostID
                    JOIN Proizvoditeli pr ON t.ProizID = pr.ProizID
                    JOIN Kategorii k ON t.KatID = k.KatID
                    WHERE 1=1";
                if (!string.IsNullOrEmpty(search))
                    query += " AND (t.Naimenovanie LIKE @search OR t.Opisanie LIKE @search OR pr.Nazvanie LIKE @search OR p.Nazvanie LIKE @search OR k.Nazvanie LIKE @search)";
                if (!string.IsNullOrEmpty(postavshik) && postavshik != "Все поставщики")
                    query += " AND p.Nazvanie = @postavshik";
                if (!string.IsNullOrEmpty(sort))
                    query += " ORDER BY t.Kolvo " + (sort == "ASC" ? "ASC" : "DESC");
                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrEmpty(search)) cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                if (!string.IsNullOrEmpty(postavshik) && postavshik != "Все поставщики") cmd.Parameters.AddWithValue("@postavshik", postavshik);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetPostavshiki()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Nazvanie FROM Postavshiki", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetProizvoditeli()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Nazvanie FROM Proizvoditeli", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetKategorii()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Nazvanie FROM Kategorii", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetPunktyVydachi()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT PunktID, Adres FROM PunktyVydachi", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetClients()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT UserID, FIO FROM Users WHERE RoleID = 3", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetOrders()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"
            SELECT 
                z.ZakazID, 
                z.DataZakaza, 
                z.DataDostavki, 
                z.PunktID,        -- ДОБАВЛЕНО
                z.UserID,         -- ДОБАВЛЕНО
                p.Adres, 
                u.FIO, 
                z.Kod, 
                z.Status
            FROM Zakaz z
            JOIN PunktyVydachi p ON z.PunktID = p.PunktID
            JOIN Users u ON z.UserID = u.UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetOrderItems(int zakazID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT zi.ItemID, zi.Artikul, t.Naimenovanie, zi.Quantity FROM ZakazItems zi JOIN Tovar t ON zi.Artikul = t.Artikul WHERE zi.ZakazID = @zakazID", conn);
                cmd.Parameters.AddWithValue("@zakazID", zakazID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public static void AddOrUpdateGood(string artikul, string naim, string ed, decimal cena, int postID, int proizID, int katID, int skidka, int kolvo, string opis, string foto, bool isNew)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = isNew ?
                    "INSERT INTO Tovar (Artikul, Naimenovanie, EdIzm, Cena, PostID, ProizID, KatID, Skidka, Kolvo, Opisanie, Foto) VALUES (@art, @naim, @ed, @cena, @post, @proiz, @kat, @skidka, @kolvo, @opis, @foto)" :
                    "UPDATE Tovar SET Naimenovanie=@naim, EdIzm=@ed, Cena=@cena, PostID=@post, ProizID=@proiz, KatID=@kat, Skidka=@skidka, Kolvo=@kolvo, Opisanie=@opis, Foto=@foto WHERE Artikul=@art";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@art", artikul);
                cmd.Parameters.AddWithValue("@naim", naim);
                cmd.Parameters.AddWithValue("@ed", ed);
                cmd.Parameters.AddWithValue("@cena", cena);
                cmd.Parameters.AddWithValue("@post", postID);
                cmd.Parameters.AddWithValue("@proiz", proizID);
                cmd.Parameters.AddWithValue("@kat", katID);
                cmd.Parameters.AddWithValue("@skidka", skidka);
                cmd.Parameters.AddWithValue("@kolvo", kolvo);
                cmd.Parameters.AddWithValue("@opis", opis);
                cmd.Parameters.AddWithValue("@foto", (object)foto ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public static bool CanDeleteGood(string artikul)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ZakazItems WHERE Artikul = @art", conn);
                cmd.Parameters.AddWithValue("@art", artikul);
                return (int)cmd.ExecuteScalar() == 0;
            }
        }

        public static void DeleteGood(string artikul)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Tovar WHERE Artikul = @art", conn);
                cmd.Parameters.AddWithValue("@art", artikul);
                cmd.ExecuteNonQuery();
            }
        }

        public static int AddOrder(DateTime dataZakaza, DateTime dataDostavki, int punktID, int userID, int kod, string status)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Zakaz (DataZakaza, DataDostavki, PunktID, UserID, Kod, Status) OUTPUT INSERTED.ZakazID VALUES (@dz, @dd, @p, @u, @k, @s)", conn);
                cmd.Parameters.AddWithValue("@dz", dataZakaza);
                cmd.Parameters.AddWithValue("@dd", dataDostavki);
                cmd.Parameters.AddWithValue("@p", punktID);
                cmd.Parameters.AddWithValue("@u", userID);
                cmd.Parameters.AddWithValue("@k", kod);
                cmd.Parameters.AddWithValue("@s", status);
                return (int)cmd.ExecuteScalar();
            }
        }

        public static void UpdateOrder(int zakazID, DateTime dataZakaza, DateTime dataDostavki, int punktID, int userID, int kod, string status)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Zakaz SET DataZakaza=@dz, DataDostavki=@dd, PunktID=@p, UserID=@u, Kod=@k, Status=@s WHERE ZakazID=@id", conn);
                cmd.Parameters.AddWithValue("@dz", dataZakaza);
                cmd.Parameters.AddWithValue("@dd", dataDostavki);
                cmd.Parameters.AddWithValue("@p", punktID);
                cmd.Parameters.AddWithValue("@u", userID);
                cmd.Parameters.AddWithValue("@k", kod);
                cmd.Parameters.AddWithValue("@s", status);
                cmd.Parameters.AddWithValue("@id", zakazID);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteOrder(int zakazID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Zakaz WHERE ZakazID = @id", conn);
                cmd.Parameters.AddWithValue("@id", zakazID);
                cmd.ExecuteNonQuery();
            }
        }

        public static void AddOrderItem(int zakazID, string artikul, int quantity)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO ZakazItems (ZakazID, Artikul, Quantity) VALUES (@z, @a, @q)", conn);
                cmd.Parameters.AddWithValue("@z", zakazID);
                cmd.Parameters.AddWithValue("@a", artikul);
                cmd.Parameters.AddWithValue("@q", quantity);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteOrderItem(int itemID)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM ZakazItems WHERE ItemID = @id", conn);
                cmd.Parameters.AddWithValue("@id", itemID);
                cmd.ExecuteNonQuery();
            }
        }

        public static void UploadImage(PictureBox pb, string oldPath)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Images|*.jpg;*.png;*.jpeg" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(ofd.FileName);
                Bitmap resized = new Bitmap(img, 300, 200);
                string fileName = Path.GetFileName(ofd.FileName);
                string newPath = Path.Combine(Application.StartupPath, "Images", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(newPath));
                resized.Save(newPath);
                pb.Image = resized;
                if (!string.IsNullOrEmpty(oldPath) && File.Exists(oldPath))
                    File.Delete(oldPath);
            }
        }
    }

    public class User
    {
        public int UserID { get; set; }
        public string Role { get; set; }
        public string FIO { get; set; }
    }
}