using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Runtime.Remoting.Messaging;

namespace knihovna
{
    internal class SQLClass
    {
        public static string Cs { get; private set; }
        public static SQLiteConnection Connection { get; private set; }
        private SQLiteCommand prikaz;
        public SQLClass()
        {
            Cs = @"URI=file:../../../databaze.db";
            Connection = new SQLiteConnection(Cs);
        }
        public static void Connect()
        {
            try
            {
                Connection.Open();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public static void Disconnect() {
            try
            {
                Connection.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        
        public static void KnihaZakaznikEdit(int IdKnihy, int IdČlena)
        {
            try
            {
                Connect();
                SQLiteCommand prikaz = new SQLiteCommand(Connection);
                prikaz.CommandText = "UPDATE knihy SET IdČlena = " + IdČlena + " WHERE IdKnihy = " + IdKnihy + ";";
                prikaz.ExecuteNonQuery();
                Disconnect();
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        public static void NewKniha(string Název, int IdŽánru, int IdAutora)
        {
            try
            {
                Connect();
                SQLiteCommand prikaz = new SQLiteCommand(Connection);
                prikaz.CommandText = "INSERT INTO knihy(Název, IdAutora, IdŽánru, IdČlena) VALUES(@Název, @IdAutora, @IdŽánru, -1);";
                prikaz.Parameters.AddWithValue("@IdAutora", IdAutora);
                prikaz.Parameters.AddWithValue("@Název", Název);
                prikaz.Parameters.AddWithValue("@IdŽánru", IdŽánru);
                prikaz.ExecuteNonQuery();
                Disconnect();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public static void NewAutor(string Jméno, string Příjmení)
        {
            try
            {
                Connect();
                SQLiteCommand prikaz = new SQLiteCommand(Connection);
                prikaz.CommandText = "INSERT INTO autoři(Jméno, Příjmení) VALUES(@Jméno, @Příjmení);";
                prikaz.Parameters.AddWithValue("@Jméno", Jméno);
                prikaz.Parameters.AddWithValue("@Příjmení", Příjmení);
                prikaz.ExecuteNonQuery();
                Disconnect();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public static void NewZakaznik(string Jméno, string Příjmení)
        {
            try
            {
                Connect();
                SQLiteCommand prikaz = new SQLiteCommand(Connection);
                prikaz.CommandText = "INSERT INTO členové(Jméno, Příjmení) VALUES(@Jméno, @Příjmení);";
                prikaz.Parameters.AddWithValue("@Jméno", Jméno);
                prikaz.Parameters.AddWithValue("@Příjmení", Příjmení);
                prikaz.ExecuteNonQuery();
                Disconnect();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public static string[] FindZakaznik(string Jméno, string Příjmení, string IdČlena)
        {
            try
            {
                SQLiteCommand prikaz = new SQLiteCommand(Connection);
                string command = "";
                if (Jméno != "")
                {
                    command += " Jméno='" + Jméno + "'";
                }
                if (Příjmení != "")
                {
                    if (command.Length > 3)
                    {
                        command += " AND ";
                    }
                    command += " Příjmení='" + Příjmení + "'";
                }
                if (IdČlena != "")
                {
                    if (command.Length > 3)
                    {
                        command += " AND ";
                    }
                    command += " IdČlena='" + IdČlena + "'";
                }
                Connect();
                string[] exitString = new string[3];
                prikaz.CommandText = "SELECT * FROM členové WHERE" + command + ";";
                using (var reader = prikaz.ExecuteReader()) { while (reader.Read()) { exitString[0] = (string)reader["Jméno"]; exitString[1] = (string)reader["Příjmení"]; exitString[2] = Convert.ToInt64(reader["IdČlena"]).ToString(); } }
                Disconnect();

                return exitString;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return null; }
        }
        public static int FindAutorByName(string Jméno)
        {
            try
            {
                Connect();
                SQLiteCommand prikaz = new SQLiteCommand(Connection);
                string command = "";
                int a = -1;
                if (Jméno != "")
                {
                    command += "WHERE Jméno = '" + Jméno + "' OR Příjmení = '" + Jméno + "';";
                    prikaz.CommandText = "SELECT * FROM autoři " + command;
                    using (var reader = prikaz.ExecuteReader()) { while (reader.Read()) { a = Convert.ToInt32(reader["IdAutora"]); } }
                }
                Disconnect();
                return a;
            }
            catch (Exception ex) { return -1; }
        }
        public static int FindZanrByName(string Název)
        {
            try
            {
                Connect();
                SQLiteCommand prikaz = new SQLiteCommand(Connection);
                int a = -1;
                prikaz.CommandText = "SELECT * FROM žánry WHERE Název = '" + Název.ToLower() + "';";
                using (var reader = prikaz.ExecuteReader()) { while (reader.Read()) { a =  Convert.ToInt32(reader["IdŽánru"]); } }
                Disconnect();
                return a;
            }
            catch (Exception ex) { return -1; }
        }
        
        public static BindingList<Kniha> FindKniha(int IdKnihy, string Název, int IdAutora, int IdŽánru, int IdČlena)
        {
            BindingList<Kniha> list = new BindingList<Kniha>();
            SQLiteCommand prikaz = new SQLiteCommand(Connection);
            Connect();
            try
            {
                prikaz.CommandText = "SELECT * FROM knihy WHERE IdKnihy= @IdKnihy OR Název= @Název OR IdAutora= @IdAutora OR IdŽánru= @IdŽánru OR IdČlena= @IdČlena;";
                prikaz.Parameters.AddWithValue("@IdKnihy", IdKnihy);
                prikaz.Parameters.AddWithValue("@Název", Název);
                prikaz.Parameters.AddWithValue("@IdAutora", IdAutora);
                prikaz.Parameters.AddWithValue("@IdŽánru", IdŽánru);
                prikaz.Parameters.AddWithValue("@IdČlena", IdČlena);
                if (IdKnihy == -1 && Název == "" && IdŽánru == -1 && IdAutora == -1 && IdČlena == -1)
                {
                    prikaz.CommandText = "SELECT * FROM knihy;";
                }
                using (var reader = prikaz.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Kniha(Convert.ToInt32(reader["IdKnihy"]), (string)reader["Název"], Convert.ToInt32(reader["IdAutora"]), Convert.ToInt32(reader["IdŽánru"]), Convert.ToInt32(reader["IdČlena"])));
                    }
                    Disconnect();
                    
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return list;
        }
        public static BindingList<Zakaznik> ListZakaznik()
        {
            Connect();
            BindingList<Zakaznik> list = new BindingList<Zakaznik>();
            SQLiteCommand prikaz = new SQLiteCommand(Connection);
            prikaz.CommandText = "SELECT * FROM členové";
            using (var reader = prikaz.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Zakaznik(Convert.ToInt32(reader["IdČlena"]), (string)reader["Jméno"], (string)reader["Příjmení"]));
                }
                Disconnect();
            }
            return list;
        }
        public static BindingList<Autor> ListAutor()
        {
            Connect();
            BindingList<Autor> list = new BindingList<Autor>();
            SQLiteCommand prikaz = new SQLiteCommand(Connection);
            prikaz.CommandText = "SELECT * FROM autoři";
            using (var reader = prikaz.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Autor(Convert.ToInt32(reader["IdAutora"]), (string)reader["Jméno"], (string)reader["Příjmení"]));
                }
                Disconnect();
            }
            return list;
        }
        public static BindingList<Zanr> ListZanr()
        {
            Connect();
            BindingList<Zanr> list = new BindingList<Zanr>();
            SQLiteCommand prikaz = new SQLiteCommand(Connection);
            prikaz.CommandText = "SELECT * FROM žánry";
            using (var reader = prikaz.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Zanr(Convert.ToInt32(reader["IdŽánru"]), (string)reader["Název"]));
                }
                Disconnect();
            }
            return list;
        }
    }
}