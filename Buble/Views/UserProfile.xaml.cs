using Buble.Repositories;
using Buble.ViewModels;
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

namespace Buble.Views
{
    /// <summary>
    /// Interaction logic for UserProfile.xaml
    /// </summary>
    public partial class UserProfile : UserControl
    {
        public UserProfile()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            //string query = "UPDATE [User] SET email = @email WHERE id = @id;";

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {

            //        //command.Parameters.AddWithValue("@Name", NameTextBox.Text.ToString());
            //        //command.Parameters.AddWithValue("@Email", "r@gmail.com");
            //        //command.Parameters.AddWithValue("@Username", UsernameTextBox.Text);
            //        //command.Parameters.AddWithValue("@Id", IdTextBox.Text);

            //        //command.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = nameTextBox.Text;
            //        command.Parameters.Add("@email", SqlDbType.NVarChar).Value = EmailTextBox.Text;
            //        command.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = new System.Data.SqlTypes.SqlGuid(IdTextBox.Text);
            //        //command.Parameters.Add("@MESSAGE", SqlDbType.NVarChar).Value = messageTextBox.Text;

            //        connection.Open();
            //        int rowsAffected = command.ExecuteNonQuery();
            //        connection.Close();

            //        Console.WriteLine("Rows affected: " + rowsAffected);
            //    }
            //}

            UserRepository repo = new UserRepository();
            repo.UpdatetById(IdTextBox.Text, NameTextBox.Text, UsernameTextBox.Text, EmailTextBox.Text);
        }
    }
}
