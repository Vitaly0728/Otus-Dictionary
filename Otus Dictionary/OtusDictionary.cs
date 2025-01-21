using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Otus_Dictionary
{
    public class OtusDictionary 
    {
        private KeyValuePair?[] _items;
        private int _sizeArray=32;
        public OtusDictionary()
        {
            _items = new KeyValuePair[_sizeArray];
        }
        
        public void Add(int key, string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Значение не может быть null.");

            int index = GetIndex(key);
            if (_items[index] != null && _items[index].Key != key)
            {                
                ResizeAndRehash();                
                index = GetIndex(key);
            }
            if (_items[index] != null && _items[index].Key == key)
                throw new ArgumentException("Элемент с таким ключом уже существует.");
            
            _items[index] = new KeyValuePair(key, value);
        }
        private int GetIndex(int key)
        {            
            return Math.Abs(key) % _items.Length;
        }
        private void ResizeAndRehash()
        {
            var oldItems = _items;

            _items = new KeyValuePair[_items.Length * 2];

            foreach (var item in oldItems)
            {
                if (item != null)
                {
                    int newIndex = GetIndex(item.Key);
                    _items[newIndex] = item;
                }
            }
        }

        public string Get(int key)
        {
            int index = GetIndex(key);

            if (_items[index] != null && _items[index].Key == key)
                return _items[index].Value;

            return null;
        }
        public string this[int key]
        {
            get => Get(key);
            set => Add(key, value);
        }
    }
}
