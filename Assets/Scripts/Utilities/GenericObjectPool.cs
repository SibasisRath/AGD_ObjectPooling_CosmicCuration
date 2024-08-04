using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Utilities
{
    public class GenericObjectPool<T> where T : class
    {
        private List<PooledItem<T>> pooledItems = new ();

        protected T GetItem()
        {
            if (pooledItems.Count > 0)
            {
                PooledItem<T> item = pooledItems.Find(item => !item.isUsed);
                if (item != null)
                {
                    item.isUsed = true;
                    return item.item;
                }
            }
            return CreatePooledItem();
        }

        private T CreatePooledItem()
        {
            PooledItem<T> newItem = new PooledItem<T>();
            newItem.item = CreateItem();
            newItem.isUsed = true;
            pooledItems.Add(newItem);
            return newItem.item;
        }

        protected virtual T CreateItem()
        {
            throw new NotImplementedException();
        }

        public void ReturnItem(T itemForReturn)
        {
            PooledItem<T> itemToBeReturned = pooledItems.Find(i => i.item.Equals(itemForReturn));
            itemToBeReturned.isUsed = false;
        }

        public class PooledItem<T>
        {
            public T item;
            public bool isUsed;
        }
    }
}

