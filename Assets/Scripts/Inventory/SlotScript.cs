using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{
    [SerializeField] private Image m_icon;
    [SerializeField] private TextMeshProUGUI m_label;
    [SerializeField] private GameObject m_stackObj;
    [SerializeField] private TextMeshProUGUI m_sftackLabel;
    private InventoryItemData data;

    public void Set(InventoryItem item)
    {
        data = item.data;
        m_icon.sprite = item.data.icon;
        m_label.text = item.data.itemName;
        if (item.stackSize <= 1)
        {
            m_stackObj.SetActive(false);
            return;
        }
        m_sftackLabel.text = item.stackSize.ToString();
    }
    public void Remove()
    {
        transform.parent.TryGetComponent<InventoryUIManager>(out InventoryUIManager inUIM);
        inUIM.inventoryManager.Remove(data, Int32.Parse(m_sftackLabel.text));
        inUIM.OnUpdateInventory();
    }
}
