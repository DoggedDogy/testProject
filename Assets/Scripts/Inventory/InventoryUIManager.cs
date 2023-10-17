using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public GameObject m_slotPrefab;

    private void Awake()
    {
        //inventoryManager = GetComponent<InventoryManager>();
    }
    public void OnEnable()
    {
        OnUpdateInventory();
    }
    public void OnUpdateInventory()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        DrawInventory();
    }
    private void DrawInventory()
    {
        foreach(InventoryItem item in inventoryManager.inventory)
        {
            AddInventorySlot(item);
        }
    }
    public void AddInventorySlot(InventoryItem item)
    {
        GameObject obj = Instantiate(m_slotPrefab);
        obj.transform.SetParent(transform, false);

        SlotScript slot = obj.GetComponent<SlotScript>();
        slot.Set(item);
    }
}
