using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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

        //void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    //Get the sender observable collection
        //    ObservableCollection<TeamMember> obsSender = sender as ObservableCollection<TeamMember>;
        //    NotifyCollectionChangedAction action = e.Action;
        //    //if (action == NotifyCollectionChangedAction.Add)
        //    //    lblStatus.Content = "New person added";
        //    //if (action == NotifyCollectionChangedAction.Remove)
        //    //    lblStatus.Content = "Person deleted";
        //}

        public void GetTeam()
        {
            Team = new ObservableCollection<TeamMember>();

            List<TeamMember> teamMembers = new List<TeamMember>() {
                new TeamMember() { FirstName = "Alan", LastName = "Zhang", Position = "Developer" },
                new TeamMember() { FirstName = "Alberto", LastName = "Casas", Position = "Developer" },
                new TeamMember() { FirstName = "Cole", LastName = "Collins", Position = "Developer" },
                new TeamMember() { FirstName = "Josh", LastName = "Ray", Position = "Project Owner", Finished = true },
                new TeamMember() { FirstName = "Kalen", LastName = "Gibbons", Position = "Developer" },
                new TeamMember() { FirstName = "Marco", LastName = "Guzman", Position = "Developer" },
                new TeamMember() { FirstName = "Preethi", LastName = "Varamballi", Position = "Business Analyst" },
                new TeamMember() { FirstName = "Ruben", LastName = "Rivera", Position = "Developer" },
                new TeamMember() { FirstName = "Stephen", LastName = "Wittenberg", Position = "Developer" },
                new TeamMember() { FirstName = "Teresa", LastName = "Dolan", Position = "Business Analyst" }
            }.OrderBy(a => Guid.NewGuid()).ToList();

            teamMembers.Add(new TeamMember() { FirstName = "Patrick", LastName = "Fortunato", Position = "Scrum Master / Developer" });

            ObservableCollection<TeamMember> teamList = new ObservableCollection<TeamMember>();

            foreach (TeamMember teamMember in teamMembers)
                teamList.Add(teamMember);

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
