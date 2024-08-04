using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Utilities
{
    public class GenericObjectPool<T> where T : class
    {
        private List<PooledItem<T>> pooledItems = new ();

        protected T GetItem<U>() where U : T
        {
            if (pooledItems.Count > 0)
            {
                PooledItem<T> item = pooledItems.Find(item => !item.isUsed && item.item is U);
                if (item != null)
                {
                    item.isUsed = true;
                    return item.item;
                }
            }
            return CreatePooledItem<U>();
        }

        private T CreatePooledItem<U>() where U : T
        {
            PooledItem<T> newItem = new PooledItem<T>();
            newItem.item = CreateItem<U>();
            newItem.isUsed = true;
            pooledItems.Add(newItem);
            return newItem.item;
        }

        protected virtual T CreateItem<U>() where U : T
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

