using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private InventoryItemSO inventoryItemSO;
    [SerializeField] private Transform inventory;


    private void Awake()
    {
        transform.Find("useBtn").GetComponent<Button>().onClick.AddListener(() =>
        {
            if(inventoryItemSO.itemOwner == inventory) {
                Debug.Log("Use");
            }
            else
            {
                inventoryItemSO.itemOwner.GetComponent<ShopProductLine>().SetActiveItem(inventoryItemSO);
                Debug.Log("ryjgrf afiget");
            }
            // inventoryItemSO.itemOwner.InteractItem();
        });
    }

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
