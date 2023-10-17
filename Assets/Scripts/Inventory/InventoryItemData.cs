using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu( menuName = "Inventory/Item")]
public class InventoryItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int itemID;
    public int itemStackSize;
}
