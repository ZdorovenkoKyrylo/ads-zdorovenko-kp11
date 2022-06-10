using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS_Hashtable
{
    class HashTable
    {
       public  Entry[] Table;
       public  double Loadness;
       public int Size;

        public HashTable()
        {
            Table = new Entry[11];
            Loadness = 0;
            Size = 0;
        }
        public void insertEntry(Key key, Value value)
        {
            if (Loadness >= 0.6)
            {
                Console.WriteLine("\nRehashing\n");
                Rehashing();
            }

            Entry entry = new Entry(key, value);
            entry.Value.Password = "" + passwordHash(entry.Value.Password);

            int hash = getHash(key);
            int dHash = doubleHash(key);
            int index = hash;

            for (int k = 1; Table[index] != null && Table[index].Key.username != key.username; k++)
            {

                index = (hash + k * dHash) % Table.Length;
            }

            if (Table[index] == null)
            {
                Size++;
                Loadness = Math.Round(1.0 * Size / Table.Length, 3);
            }
            Table[index] = entry;
        }
        public long hashCode(Key key)
        {
            long sum = 0;
            for (int i = 0; i < key.username.Length; i++)
                sum += 36 * (i + 1) * (int)key.username[i];
            return sum;
        }
        public int getHash(Key key)
        {
            return (int)(hashCode(key) % Table.Length);
        }
        public int doubleHash(Key key)
        {
            return (int)(Table.Length - 1 - (hashCode(key) % (Table.Length - 1)));
        }
        public long passwordHash(String password)
        {
            long hash = 0;
            for (int i = 1; i <= password.Length; i++)
                hash += password[i - 1] * i;
            return hash;
        }
        public bool removeEntry(Key key)
        {
            int hash1 = getHash(key);
            int hash2 = (int)(Table.Length - 1 - (hashCode(key) % (Table.Length - 1)));
            int hash = hash1;

            for (int k = 1; Table[hash] != null && Table[hash].Key.username != key.username; k++)
                hash = (hash1 + k * hash2) % Table.Length;

            if (Table[hash] != null)
            {
                Table[hash] = new Entry(new Key("DELETED"), new Value(null, null, new Date()));
                Size--; Loadness = (double)Size / Table.Length;
                return true;
            }
            else
                return false;
        }
        public Entry findEntry(Key key)
        {
            int hash1 = getHash(key);
            int hash2 = (int)(Table.Length - 1 - (hashCode(key) % (Table.Length - 1)));
            int hash = hash1;

            for (int k = 1; Table[hash] != null && Table[hash].Key.username != key.username; k++)
                hash = (hash1 + k * hash2) % Table.Length;

            return Table[hash];
        }
        public void Rehashing()
        {
            int oCap = Table.Length;
            int nCap = oCap * 2;

            Entry[] newTable = new Entry[nCap];

            for (int i = 0; i < oCap; i++)
            {
                if (Table[i] == null || Table[i].Key.username == "DELETED")
                    continue;
                int hash = (int)(hashCode(Table[i].Key) % nCap);
                int doubleHash = (int)(nCap - 1 - (hashCode(Table[i].Key) % (nCap - 1)));
                int k = 1;
                int index = hash;
                while (newTable[index] != null)
                {
                    index = (hash + k * doubleHash) % nCap;
                    k++;
                }
                newTable[index] = Table[i];
            }

            Table = newTable;
            Loadness = (double)Size / nCap;
        }

        public Entry[] getTable()
        {
            return Table;
        }
    }
}
