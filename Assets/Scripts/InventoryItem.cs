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

    /*public IInventoryItemOwner GetInventoryItemOwner()  //тут вопрос - важны ли нам другие собственники кроме игрока
    {
        return inventoryItemOwner;
    }*/

    public void DestroySelf()
    {
        // тут надо добавить что мы делаем со слотом который занимал предмет, например, запустить метод очистки - чтобы слот стал пустым и не отображал предмет
        Destroy(gameObject);
    }

    /*public bool TryGetSameTypeOfItem(out InventoryItem** InventoryItem)
    {
        if (this isInventoryItem)
        {
            //здесь проверяем есть ли у такой предмет
            *InventoryItem = this asInventoryItem;
            return true;
        } else
        {
            plateKitchenObject = null;
            return false;
        }
    }*/

    public static InventoryItem SpawnInventoryItem(InventoryItemSO inventoryItemSO/*, IInventoryItemOwner inventoryItemOwner*/)  //закоменчено - кому спавнить или по-другому чьё оно
    {
        Transform inventoryItemTransform = Instantiate(inventoryItemSO.prefab);

        InventoryItem inventoryItem = inventoryItemTransform.GetComponent<InventoryItem>();

        //inventoryItem.SetInventoryItemOwner(inventoryItemOwner);

        return inventoryItem;
    }
}
