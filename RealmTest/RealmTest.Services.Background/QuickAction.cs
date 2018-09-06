using RealmTest.Core.Services.Dogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace RealmTest.Services.Background
{
    public sealed class QuickAction : IBackgroundTask
    {
        DogService _svc;
        public QuickAction()
        {
            _svc = new DogService();
        }
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            var a = _svc.ShowRandomDogs();
            _svc.CreateItems();
        }
    }
}
