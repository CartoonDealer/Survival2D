using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShopProductLine : MonoBehaviour
{
    [Header("Это поле для списка из которого магазин берёт товары")]
    [SerializeField] private ItemListSO allShopItemList;

    private List<InventoryItemSO> itemList;

    [SerializeField] private List<Transform> goodsTransformList;
    //private Vector3 transformOffset;
    [SerializeField] private Transform goodsParent;

    [SerializeField] private InventoryItemSO activeItem;
    [SerializeField] private TextMeshProUGUI itemLabel;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private Transform activeItemBorder;

    

    private void Awake()
    {
        itemList = new List<InventoryItemSO>();
        OnAwake();
    }


    // тут мы выбираем из общего списка продаваемых товаров что выставить "на полку"
    private void OnAwake()
    {
        //transformOffset = new Vector3(190, 0, 0);
        // тут выводим иконки товаров на полку
        for (int i = 0; i <= 3; i++)
        {  
            itemList.Add(allShopItemList.itemSOList[UnityEngine.Random.Range(0, allShopItemList.itemSOList.Count)]);
            //if (i>0) goodsTransformList[0].transform.position += transformOffset;
            Instantiate(itemList[i].prefab, goodsTransformList[i].position, goodsTransformList[i].rotation, goodsParent);
            itemList[i].itemOwner = transform;
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
        itemLabel.text = activeItem.name;
        //описание товара
        itemDescription.text = activeItem.hint;
        //стоимость товара
        itemPrice.text = activeItem.price.ToString();
    }
}
