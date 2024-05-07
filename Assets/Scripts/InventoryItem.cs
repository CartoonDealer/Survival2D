using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private InventoryItemSO inventoryItemSO;

    //private IInventoryItemOwner inventoryItemOwner;

    public InventoryItemSO GetInventoryItemSO()
    {
        return inventoryItemSO;
    }

    /*public IInventoryItemOwner GetInventoryItemOwner()  //��� ������ - ����� �� ��� ������ ������������ ����� ������
    {
        return inventoryItemOwner;
    }*/

    public void DestroySelf()
    {
        // ��� ���� �������� ��� �� ������ �� ������ ������� ������� �������, ��������, ��������� ����� ������� - ����� ���� ���� ������ � �� ��������� �������
        Destroy(gameObject);
    }

    /*public bool TryGetSameTypeOfItem(out InventoryItem** InventoryItem)
    {
        if (this isInventoryItem)
        {
            //����� ��������� ���� �� � ����� �������
            *InventoryItem = this asInventoryItem;
            return true;
        } else
        {
            plateKitchenObject = null;
            return false;
        }
    }*/

    public static InventoryItem SpawnInventoryItem(InventoryItemSO inventoryItemSO/*, IInventoryItemOwner inventoryItemOwner*/)  //����������� - ���� �������� ��� ��-������� ��� ���
    {
        Transform inventoryItemTransform = Instantiate(inventoryItemSO.prefab);

        InventoryItem inventoryItem = inventoryItemTransform.GetComponent<InventoryItem>();

        //inventoryItem.SetInventoryItemOwner(inventoryItemOwner);

        return inventoryItem;
    }
}
