

using System.Collections.Generic;

namespace ipz_labar1
{
    public class MyItem
    {
        private static long _counter = 0;
        private static List<MyItem> _items = new List<MyItem>();

        public static List<MyItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public static long Counter
        {
            get { return _counter; }
            set { _counter = value; }
        }

        public long number { get; private set; }

        public string name { get; set; }
        public long id { get; set; }
        public string type { get; set; }
        public long count { get; set; }
        public double price { get; set; }

        public MyItem()
        {
            number = ++_counter;
        }

        public static int CompareName(MyItem A, MyItem B)
        {
            return A.name.CompareTo(B.name);
        }

        public static int ComparePrice(MyItem A, MyItem B)
        {
            return A.price.CompareTo(B.price);
        }

        public static int CompareCount(MyItem A, MyItem B)
        {
            return A.count.CompareTo(B.count);
        }

        public static int CompareType(MyItem A, MyItem B)
        {
            return A.type.CompareTo(B.type);
        }

        public static int CompareNumber(MyItem A, MyItem B)
        {
            return A.number.CompareTo(B.number);
        }

        public static int CompareID(MyItem A, MyItem B)
        {
            return A.id.CompareTo(B.id);
        }
    }
}
