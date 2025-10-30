using System;
using UnityEngine;

namespace Adapter
{
    public class ClientAdapter : MonoBehaviour
    {
        public InventoryItem item;
        InventorySystem _inventorySystem;
        IInventorySystem _inventorySystemAdapter;

        private void Start()
        {
            _inventorySystem = new InventorySystem();
            _inventorySystemAdapter = new InventorySystemAdapter();
        }

        void OnGUI()
        {
            if (GUILayout.Button("Add Item (no adapter)"))
                _inventorySystem.AddItem(item);

            if (GUILayout.Button("Add Item (with adapter)"))
                _inventorySystemAdapter.AddItem(item, SaveLocation.Both);
        }
    }
}