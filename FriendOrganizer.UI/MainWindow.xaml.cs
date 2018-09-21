using FriendOrganizer.UI.Data;
using FriendOrganizer.Model;
using FriendOrganizer.DataAccess;
using Microsoft.Win32;
using System.Text;
using System.Windows;

namespace FriendOrganizer.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Connection conn = new Connection();
            conn.ConnectToDB();
        }

        private void ChoseFileHandler(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "CSV Files (*.CSV)|*.CSV";
            

            if (fileDialog.ShowDialog() == true)
            {
                FileInput.Text = fileDialog.FileName;
                FriendDataService friendService = new FriendDataService();

                StringBuilder allUsers = new StringBuilder();
                System.Collections.Generic.IEnumerator<Friend> iterator = friendService.GetAll().GetEnumerator();
                while (iterator.MoveNext())
                {
                    Friend user = iterator.Current;
                    allUsers.AppendLine($"{user.FirstName} {user.LastName}");
                }

                UsersList.Text = allUsers.ToString();           
            };
          
        }

        private void LoadFromDBHandler(object sender, RoutedEventArgs e)
        {
            Connection conn = new Connection();
            UsersList.Text = conn.getDBData();
        }
    }
}
