using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory { get; private set; }
    //public int inventorySize = 9;
    private void Awake()
    {
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }
    public void Add(InventoryItemData referenceData, int amount)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack(amount);
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData, amount);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
        }
    }
    public void Remove(InventoryItemData referenceData, int amount)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack(amount);
            if (value.stackSize == 0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }
        }
    }
    public InventoryItem Get(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }
    public bool TryGet(InventoryItemData referenceData, out int valueOutput)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            valueOutput = value.stackSize;
            return true;
        }
        valueOutput = 0;
        return false;
    }
    //public bool CheckedInventorySpace()
    //{
    //    if (inventory.Count < inventorySize)
    //        return true;
    //    else
    //        return false;
    //}
}