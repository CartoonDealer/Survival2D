using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ItemHolder
{
    private List<InventoryItemSO> inventoryItemList;
    [SerializeField] Transform itemParentPrefab;
    [SerializeField] Transform parentsHolderCanvas;
    [SerializeField] Transform firstItemPosition;
    [SerializeField] int itemsInRow;

    [SerializeField] GameObject inventoryInterface;
    [SerializeField] Transform inventoryCanvasForUpdating;
    

    public override void InteractItem(InventoryItemSO item)
    {
        Debug.Log("юз из инвентаря");
    }

    private void Start()
    {
        inventoryItemList = new List<InventoryItemSO>();
    }

    public void SpawnItems()
    {
        //задаём ширину родительского префаба
        //itemParentPrefab.GetComponent<RectTransform>().s
        Vector3 offsetVector = new Vector3(140, 0, 0);
        Vector3 offsetVector2 = new Vector3(-700, -140, 0);
        int i = 0;
        if (inventoryItemList.Count > 0)
        {
            foreach (InventoryItemSO item in inventoryItemList)
            {
                //Vector3 position = itemParentPrefab.position + (offsetVector * i);
                Transform parentTransform = Instantiate(itemParentPrefab, (firstItemPosition.position + (offsetVector * i) +(offsetVector2 * (i / itemsInRow))), parentsHolderCanvas.rotation, parentsHolderCanvas);
                Transform clonePrefab = Instantiate(item.prefab, parentTransform);

                item.itemOwner = this; // это надо менять
                i++;
            }
        }
    }
    public void AddItemToInventory(InventoryItemSO item)
    {
        inventoryItemList.Add(item);
    }

    public void RemoveItemFromInventory(InventoryItemSO item)
    {
        inventoryItemList.Remove(item);
    }

    public void OnInterfaceDeactivation()
    {
        int nbChildren = inventoryCanvasForUpdating.childCount;
        for (int i = nbChildren - 1; i >= 0; i--)
        {
            DestroyImmediate(inventoryCanvasForUpdating.GetChild(i).gameObject);
        }
        inventoryInterface.SetActive(false);
    }
}
