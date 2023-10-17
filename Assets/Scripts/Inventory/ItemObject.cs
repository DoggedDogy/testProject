using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;
    public InventoryManager inventoryManager;
    public int amount;

    private void Awake()
    {
        inventoryManager = FindObjectsOfType<InventoryManager>()[0].GetComponent<InventoryManager>();
    }
    public void OnHandlePickupItem()
    {
        if (true)
        {
            inventoryManager.Add(referenceItem, amount);
            Destroy(gameObject);
        }
    }
}
