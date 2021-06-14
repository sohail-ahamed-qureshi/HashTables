using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementationOfHashTables
{
    class MyMapNode<K, V>
    {
        private int size;
        private LinkedList<KeyValue<K, V>>[] items;

        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        /// <summary>
        /// returns hashcode of the key user wants to find
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        /// <summary>
        /// returns linkedlist that is pointed by the position(hashcode)
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        protected LinkedList<KeyValue<K, V>> GetLinkedList(int pos)
        {
            LinkedList<KeyValue<K, V>> linkedlist = items[pos];
            if(linkedlist == null)
            {
                linkedlist = new LinkedList<KeyValue<K, V>>();
                items[pos] = linkedlist;
            }
            return linkedlist;
        }
        /// <summary>
        /// returns back the value that is pointed out by the key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V GetV(K key)
        {
            int pos = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(pos);
            foreach (KeyValue<K,V> item in linkedlist)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }
        /// <summary>
        /// adds a new key and value to hashtable.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(K key, V value)
        {
            int pos = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(pos);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
            linkedlist.AddLast(item);
        }
        /// <summary>
        /// removes the value from the hashtable using key.
        /// </summary>
        /// <param name="key"></param>
        public void Remove(K key)
        {
            int pos = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(pos);
            bool isFound = false;
            KeyValue<K,V> foundItem = default(KeyValue<K,V>) ;
            foreach(KeyValue<K, V> item in linkedlist)
            {
                if (item.Key.Equals(key))
                {
                    isFound = true;
                    foundItem = item;
                }
                if(isFound == true)
                {
                    linkedlist.Remove(foundItem);
                }
            }
        }
    }



    public struct KeyValue<k, v>
    {
        public k Key { get; set; }
        public v Value { get; set; }
    }
}
