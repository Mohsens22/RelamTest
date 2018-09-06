using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmTest.Core.Data
{
    public static class RealmContext
    {
        public static Realm GetInstance()
        {
            //var configuration = new SyncConfiguration(User.Current, new Uri("~/myRealm", UriKind.Relative)) { SchemaVersion = 1 };
            return Realm.GetInstance();
        }
    }
}
