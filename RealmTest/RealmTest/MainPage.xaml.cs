using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RealmTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public Realm Instance;
        public MainPage()
        {
            this.InitializeComponent();
        }
        IRealmCollection<Dog> _dogz;
        public IRealmCollection<Dog> Dogz
        {
            get => _dogz;
            set
            {
                if (_dogz != value)
                {
                    _dogz = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("Dogz"));
                }
            }
        }
        Random r = new Random();

        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Instance = Realm.GetInstance();
            if (!Instance.All<Dog>().AsRealmCollection().Any())
            {
                for (int i = 0; i < 300; i++)
                {
                    Instance.Write(() =>
                    {
                        var nx = r.Next(100);
                        Instance.Add(new Dog() { Age = nx });
                    });

                }
                for (int i = 0; i < 100; i++)
                {
                    Instance.Write(() =>
                    {
                        Instance.Add(new Dog() { Age = i });
                    });
                }
            }

            var nxt = r.Next(100);
            Dogz = Instance.All<Dog>().Where(z => z.Age == nxt).AsRealmCollection();


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var nxt = r.Next(100);
            Dogz = Instance.All<Dog>().Where(z => z.Age == nxt).AsRealmCollection();
        }
    }

    public class Dog : RealmObject
    {
        public int Age { get; set; }
    }
}
