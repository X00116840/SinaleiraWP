using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PelicanCross
{
    
    public partial class TrafficLights : PhoneApplicationPage
    {

        Accelerometer accelerometer;
        int i = 0;
        public int points = 0;
        public double points = 0;

     

        //Constructor
        public TrafficLights()
        {
 

            InitializeComponent();
        
            //Accelerometer
            if(!Accelerometer.IsSupported){MessageBox.Show("No accelerometer found");}
            if (accelerometer == null){
                accelerometer = new Accelerometer();
                accelerometer.TimeBetweenUpdates = TimeSpan.FromSeconds(1);
                accelerometer.CurrentValueChanged += new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(accelerometerEventHandler);
                accelerometer.Start();}}
        
            private void accelerometerEventHandler(object sender, SensorReadingEventArgs<AccelerometerReading> e){
                Dispatcher.BeginInvoke(()=>UpdateUI(e.SensorReading));}


            public void UpdateUI(AccelerometerReading accelerometerReading){
                Vector3 accelerator = accelerometerReading.Acceleration;
                points = points + (accelerator.Z+accelerator.X) + 1;
                readings.Text = "Speed: " + points + "\nTimer: " + i++.ToString();
            
                Brush brushRed      = new SolidColorBrush(Colors.Red);
                Brush brushAmber    = new SolidColorBrush(Colors.Yellow);
                Brush brushGreen    = new SolidColorBrush(Colors.Green);
                Brush brushGray     = new SolidColorBrush(Colors.Gray);
            
                //Start Red
                if (i == 1){
                    amberLight.Fill = brushGray;
                    redLight.Fill = brushRed;
                    greenLight.Fill = brushGray;}
                //In 2 seconds Go Green
                 if (i == 2){
                    amberLight.Fill = brushGray;
                    redLight.Fill   = brushGray;
                    greenLight.Fill = brushGreen;}
                 //In 4 seconds Go Amber
                if (i == 3){
                    amberLight.Fill = brushAmber;
                    redLight.Fill = brushGray;
                    greenLight.Fill = brushGray;}
                //In 6 seconds Go Red again
                if(i==4){
                    redLight.Fill = brushRed;
                    greenLight.Fill = brushGray;
                    amberLight.Fill = brushGray;} 
                //Wait 1 second and give the score
                if (i == 6){
                    accelerometer.Stop();
                    if (Math.Round(points) > 0)
                    {
                        MessageBox.Show("You made " + Math.Round(points) + " points!");
                       NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                        //points = Math.Round(points);
                        App ppoints = Application.Current as App;
                        ppoints.PPoints = Math.Round(points);

                    }
                    else{
                        MessageBox.Show("Oh No, you didn't cross the street correctly. Player disclassified, (" + points + " points!)");
                       NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                    }
                    }
                
               }
            //End Accelerometer      
                  

        }
    }
