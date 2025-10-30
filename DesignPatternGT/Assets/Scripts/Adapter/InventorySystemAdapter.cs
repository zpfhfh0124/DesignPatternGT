using System.Collections.Generic;
using UnityEngine;

namespace Adapter
{
    public class InventorySystemAdapter : InventorySystem, IInventorySystem
    {
        private List<InventoryItem> _cloudIventory;

        public void SyncInventories()
        {
            var _cloudIventory = GetInventory();
            
            Debug.Log("Synchronizing local drive and cloud inventories");
        }

        public void AddItem(InventoryItem item, SaveLocation location)
        {
            if (location == SaveLocation.Cloud) 
                AddItem(item);

            if (location == SaveLocation.Local) 
                Debug.Log("Adding item to local drive and on the cloud");

            if (location == SaveLocation.Both)
                Debug.Log("Adding item to local drive and on the cloud");
        }

        public void RemoveItem(InventoryItem item, SaveLocation loacation)
        {
            Debug.Log("Remove item from local/cloud/both");
        }

        public List<InventoryItem> GetInventory(SaveLocation location)
        {
            Debug.Log("Get inventory from local/cloud/both");
            return new List<InventoryItem>();
        }
    }
}