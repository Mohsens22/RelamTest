using Realms;
using RealmTest.Core.Data;
using RealmTest.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmTest.Core.Services.Dogs
{
    public class DogService
    {
        GenericRepository<Dog> repo;
        Realm _instance;
        Random r;
        public DogService()
        {
            _instance = RealmContext.GetInstance();
            repo = new GenericRepository<Dog>(_instance);
            r = new Random();
        }
        void CreateItems()
        {
            for (int i = 0; i < 300; i++)
            {
                var nx = r.Next(100);
                repo.Create(new Dog() { Age = nx });
            }
            for (int i = 0; i < 100; i++)
                repo.Create(new Dog() { Age = i });

        }
        public IRealmCollection<Dog> ShowRandomDogs()
        {
            if (!_instance.All<Dog>().Any())
                CreateItems();

            var nxt = r.Next(100);
            return _instance.All<Dog>().Where(z => z.Age == nxt).AsRealmCollection();
        }
    }
}
