using System;
using System.ComponentModel;
using Realms;
using RealmTest.Core.Domain;
using RealmTest.Core.Services.Dogs;
using RealmTest.Utils;

namespace RealmTest.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        DogService _svc;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainVM()
        {
            _svc = new DogService();
            SomeCommand = new MyCommand()
            {
                CanExecuteFunc = obj => true,
                ExecuteFunc = ChangeItems
            };
            Dogz = _svc.ShowRandomDogs();
        }
        private void ChangeItems(object obj) => Dogz = _svc.ShowRandomDogs();
        IRealmCollection<Dog> _dogzvalue;
        public IRealmCollection<Dog> Dogz
        {
            get => _dogzvalue;
            set
            {
                if (_dogzvalue != value)
                {
                    _dogzvalue = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("Dogz"));

                }
            }
        }
        public MyCommand SomeCommand
        {
            get;
            set;
        }
    }
}
