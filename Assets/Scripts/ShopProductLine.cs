using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopProductLine : MonoBehaviour
{
    [Header("Это поле для списка из которого магазин берёт товары")]
    [SerializeField] private ItemListSO allShopItemList;

    [SerializeField] private List<Transform> goodsTransformList;
    private Vector3 transformOffset;
    [SerializeField] private Transform goodsParent;

    private List<InventoryItemSO> itemList;

    private void Awake()
    {
        itemList = new List<InventoryItemSO>();
        OnAwake();
    }


    // тут мы выбираем из общего списка продаваемых товаров что выставить "на полку"
    private void OnAwake()
    {
        transformOffset = new Vector3(190, 0, 0);
        


        for (int i = 0; i <= 3; i++)
        {
            
            
            itemList.Add(allShopItemList.itemSOList[UnityEngine.Random.Range(0, allShopItemList.itemSOList.Count)]);
            if (i>0) goodsTransformList[0].transform.position += transformOffset;
            Instantiate(itemList[i].prefab, goodsTransformList[0].position, goodsTransformList[0].rotation, goodsParent);
        }
    }
}
