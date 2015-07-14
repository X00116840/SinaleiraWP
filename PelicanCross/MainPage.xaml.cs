using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PelicanCross.Resources;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace PelicanCross
{

    public partial class MainPage : PhoneApplicationPage, INotifyPropertyChanged
    {
        // Data context for the local database
        public DataContext gameDB;
        
               
        // Define an observable collection property that controls can bind to.
        public ObservableCollection<GameTable> _playersList;

        public ObservableCollection<GameTable> PlayersList{
            get { return _playersList; }
            set{if (_playersList != value)
                {_playersList = value;
                 NotifyPropertyChanged("PlayersList");}}}
        

        // Constructor
        public MainPage(){

            InitializeComponent();
            Application.Current.Host.Settings.EnableFrameRateCounter = false;


            
	        // Connect to the database and instantiate data context.
            gameDB = new GameDataContext(GameDataContext.DBConnectionString);
            this.DataContext = this;
            }

        
            //UI Event Handlers
            
            private void newGameAddButton_Click(object sender, RoutedEventArgs e){
                NavigationService.Navigate(new Uri("/TrafficLights.xaml", UriKind.Relative));

                //addPlayer(newGameTextBox.Text, 0);
                App pname = Application.Current as App;
                pname.PName = newGameTextBox.Text;

                App ppoints = Application.Current as App;
                ppoints.PPoints = 0;
                
                
            }
                
            private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
            {
                App pname = Application.Current as App;
                App ppoints = Application.Current as App;
                if(ppoints.PPoints > 0)
                {
                    addPlayer(pname.PName, ppoints.PPoints);
                
                }
            }
        
           public void addPlayer(string name, double points){
                //Adding new player to the list
                GameTable newPlayer = new GameTable { PlayerName = name, PlayerPoints = points };
                PlayersList.Add(newPlayer);
     
                gameDB.GetTable<GameTable>().InsertOnSubmit(newPlayer);
                
                
                
            }

            
            
            private void newGameTextBox_GotFocus(object sender, RoutedEventArgs e){
                newGameTextBox.Text = String.Empty;}

            private void deletePlayerButton_Click(object sender, RoutedEventArgs e){

                var button = sender as Button;

                if (button != null)
                {

                    GameTable playerForDelete = button.DataContext as GameTable;
                    PlayersList.Remove(playerForDelete);
                    gameDB.GetTable<GameTable>().DeleteOnSubmit(playerForDelete);
                    gameDB.SubmitChanges();
                    this.Focus();
                }
            }

            protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
            { base.OnNavigatedFrom(e); gameDB.SubmitChanges(); }

            protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e){
                var PlayersInDB = from GameTable players in gameDB.GetTable<GameTable>() select players;                
                PlayersList = new ObservableCollection<GameTable>(PlayersInDB);
               
                base.OnNavigatedTo(e);}

            #region INotifyPropertyChanged Members
            public event PropertyChangedEventHandler PropertyChanged;

            // Used to notify the app that a property has changed.
            private void NotifyPropertyChanged(string propertyName)
            {if (PropertyChanged != null) {PropertyChanged(this, new PropertyChangedEventArgs(propertyName));}}

            #endregion
    }

        public class GameDataContext : DataContext{
            public static string DBConnectionString = "DataSource=isostore:/Game.sdf";
            public GameDataContext(string connectionString): base(connectionString){ }
            public Table<GameTable> PlayersList;}
    
        [Table] public class GameTable : INotifyPropertyChanged, INotifyPropertyChanging{

            private int _playerId;
            private string _playerName;
            private double _playerPoints;
            
            [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
            
            public int PlayerId{
                get { return _playerId; }
                set{if (_playerId != value){
                    NotifyPropertyChanging("PlayerId");
                    _playerId = value;
                    NotifyPropertyChanged("PlayerId");}}}

            [Column] public string PlayerName{
                get { return _playerName; }
                set{if (_playerName != value){
                    NotifyPropertyChanging("PlayerName");
                    _playerName = value;
                    NotifyPropertyChanged("PlayerName");}}}

            [Column] public double PlayerPoints{
                get { return _playerPoints; }
                set{if (_playerPoints != value){
                    NotifyPropertyChanging("PlayerPoints");
                    _playerPoints = value;
                    NotifyPropertyChanged("PlayerPoints");}}}

            #region INotifyPropertyChanged Members

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged(string propertyName)
            {if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }}

            #endregion

            #region INotifyPropertyChanging Members

            public event PropertyChangingEventHandler PropertyChanging;

            private void NotifyPropertyChanging(string propertyName)
            {if (PropertyChanging != null){PropertyChanging(this, new PropertyChangingEventArgs(propertyName));}}

            #endregion
            
        }

}