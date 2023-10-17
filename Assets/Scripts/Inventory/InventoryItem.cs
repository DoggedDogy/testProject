using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public InventoryItemData data { get; private set; }
    public int stackSize { get; private set; }

    public InventoryItem(InventoryItemData source, int amount)
    {
        data = source;
        AddToStack(amount);
    }
    public void AddToStack(int amount)
    {
        stackSize += amount;
    }
    // Update is called once per frame
    public void RemoveFromStack(int amount)
    {
        stackSize-= amount;
    }
    public void ClearItem()
    {
        data = null;
        stackSize = 0;
    }
    public bool RoomLeftInStack(int amountToAdd)
    {
        if (stackSize + amountToAdd <= data.itemStackSize)
            return true;
        else
            return false;
    }
}
