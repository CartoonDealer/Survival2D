using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

public class ShopProductLine : ItemHolder
{
    [Header("Это поле для списка из которого магазин берёт товары")]
    [SerializeField] private ItemListSO allShopItemList;

    private List<InventoryItemSO> itemList;
    private List<int> itemIndexList;

    [SerializeField] private List<Transform> goodsTransformList;
   
    [SerializeField] private Transform goodsParent;

    [SerializeField] private InventoryItemSO activeItem;
    [SerializeField] private TextMeshProUGUI itemLabel;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private Transform activeItemBorder;

    

    private void Awake()
    {
        itemList = new List<InventoryItemSO>();
        itemIndexList = new List<int>(allShopItemList.itemSOList.Count);
        OnAwake();
    }


    // тут мы выбираем из общего списка продаваемых товаров что выставить "на полку"
    private void OnAwake()
    {
        
        // тут выводим иконки товаров на полку
        
        for (int i = 0; i < allShopItemList.itemSOList.Count; i++)
        {
            itemIndexList.Add(i);
        }

        for (int i = 0; i <= 3; i++)
        {
            int index = UnityEngine.Random.Range(0, itemIndexList.Count);

            itemList.Add(allShopItemList.itemSOList[itemIndexList[index]]);  
            itemIndexList.RemoveAt(index);
            
            Instantiate(itemList[i].prefab, goodsTransformList[i].position, goodsTransformList[i].rotation, goodsParent);
            itemList[i].itemOwner = this;
        }
        //задаём активный при открытии магазина товар
        SetActiveItem(itemList[0]);

    }

    public void SetActiveItem(InventoryItemSO item)
    {
        activeItem = item;
        //рамка иконки
        activeItemBorder.position = goodsTransformList[itemList.IndexOf(item)].position;
        //название товара
        itemLabel.text = activeItem.itemName;
        //описание товара
        itemDescription.text = activeItem.hint;
        //стоимость товара
        itemPrice.text = activeItem.price.ToString();
    }

    public override void InteractItem(InventoryItemSO item)
    {
        SetActiveItem(item);
    }
}
