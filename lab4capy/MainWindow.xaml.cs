using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace lab4capy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public class CTest
        {
            public int number { get; set; }
            public string fio { get; set; }
            public int rateM { get; set; }
            public int rateP { get; set; }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            string db_name = "C:\\Users\\Chudo\\source\\repos\\lab4\\db.db";
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=" + db_name + ";Version=3;");
            m_dbConnection.Open();

            Window1 dialog = new Window1();
            if (dialog.ShowDialog() == true)
            {
                int numI = 0;
                numI++;
                string numS = numI.ToString();
                string sql = "INSERT INTO fio (number, fio, rateM, rateP) VALUES (" + numS + ", '" + dialog.fio.Text + "', " + dialog.rateM.Text + "," + dialog.rateP.Text + ")";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                string sql1 = "SELECT * FROM fio ORDER BY number";
                SQLiteCommand command1 = new SQLiteCommand(sql1, m_dbConnection);
                SQLiteDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {
                    var datag = new CTest { number = int.Parse(reader["number"].ToString()), fio = reader["fio"].ToString(), rateM = int.Parse(reader["rateM"].ToString()), rateP = int.Parse(reader["rateP"].ToString()) };
                    data.Items.Add(datag);
                }
                command.ExecuteNonQuery();
                reader.Close();
            }
            m_dbConnection.Close();
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            string db_name = "C:\\Users\\Chudo\\source\\repos\\lab4\\db.db";
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=" + db_name + ";Version=3;");
            m_dbConnection.Open();
            Window1 dialog = new Window1();
            if (dialog.ShowDialog() == true)
            {
                string sql = "UPDATE fio SET fio = '" + dialog.fio.Text + "', rateM = " + dialog.rateM.Text + ", rateP = " + dialog.rateP.Text + " WHERE ...;
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
            m_dbConnection.Close();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            string db_name = "C:\\Users\\Chudo\\source\\repos\\lab4\\db.db";
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=" + db_name + ";Version=3;");
            m_dbConnection.Open();
            string sql = "DELETE FROM fio WHERE ..."
            m_dbConnection.Close();
        }
    }
}


