using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
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

namespace StandupRandomizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private ObservableCollection<TeamMember> Team = new ObservableCollection<TeamMember>();
        public MainWindow()
        {
            InitializeComponent();
            GetTeam();
            this.MyEsriGrid.ItemsSource = Team;
            //Team.CollectionChanged += this.OnCollectionChanged;
            //((INotifyPropertyChanged)Team).PropertyChanged += new PropertyChangedEventHandler(MainWindow_PropertyChanged);
        }

        void MainWindow_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            MessageBox.Show("PropertyChanged!");
        }

        public void GetTeam()
        {
            Team = new ObservableCollection<TeamMember>();
            
            List<TeamMember> teamMembers = new List<TeamMember>();
            TeamMember author = new TeamMember();
            try
            {
                string usersEncoded = ConfigurationManager.AppSettings["Users"];
                string usersDencoded = System.Net.WebUtility.HtmlDecode(usersEncoded);
                string usersNoSlashes = usersDencoded.Replace(@"\", "");
                teamMembers = JsonConvert.DeserializeObject<List<TeamMember>>(usersNoSlashes);
                teamMembers = teamMembers.OrderBy(a => Guid.NewGuid()).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                string authorEncoded = ConfigurationManager.AppSettings["Author"];
                string authorDencoded = System.Net.WebUtility.HtmlDecode(authorEncoded);
                string authorNoSlashes = authorDencoded.Replace(@"\", "");
                author = JsonConvert.DeserializeObject<TeamMember>(authorNoSlashes);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            teamMembers.Add(author);
            ObservableCollection<TeamMember> teamList = new ObservableCollection<TeamMember>();

            foreach (TeamMember teamMember in teamMembers)
            {
                teamList.Add(teamMember);
            }

            Team = teamList;

        }

        private void TryAgain_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult areYouSure = MessageBox.Show("Are you sure?", "Reset Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (areYouSure == MessageBoxResult.Yes)
            {
                GetTeam();
                this.MyEsriGrid.ItemsSource = Team;
            }
        }

    }
}
