using Realms;

namespace RealmTest.Core.Domain
{
    class Count : RealmObject
    {
        public RealmInteger<int> Counter { get; set; }
    }
}
