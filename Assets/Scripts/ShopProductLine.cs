using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShopProductLine : ItemHolder
{
    [Header("��� ���� ��� ������ �� �������� ������� ���� ������")]
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


    // ��� �� �������� �� ������ ������ ����������� ������� ��� ��������� "�� �����"
    private void OnAwake()
    {
        // ��� ������� ������ ������� �� �����
        List<InventoryItemSO> uniqueItemList = new List<InventoryItemSO>();
        uniqueItemList = allShopItemList.itemSOList;
        for (int i = 0; i <= 3; i++)
        {
            InventoryItemSO randomItem = uniqueItemList[UnityEngine.Random.Range(0, uniqueItemList.Count)];
            itemList.Add(randomItem);  //allShopItemList.itemSOList[UnityEngine.Random.Range(0, allShopItemList.itemSOList.Count)]);
            uniqueItemList.Remove(randomItem);
            
            Instantiate(itemList[i].prefab, goodsTransformList[i].position, goodsTransformList[i].rotation, goodsParent);
            itemList[i].itemOwner = this;
        }
        //����� �������� ��� �������� �������� �����
        SetActiveItem(itemList[0]);

    }

    public void SetActiveItem(InventoryItemSO item)
    {
        activeItem = item;
        //����� ������
        activeItemBorder.position = goodsTransformList[itemList.IndexOf(item)].position;
        //�������� ������
        itemLabel.text = activeItem.itemName;
        //�������� ������
        itemDescription.text = activeItem.hint;
        //��������� ������
        itemPrice.text = activeItem.price.ToString();
    }

    public override void InteractItem(InventoryItemSO item)
    {
        SetActiveItem(item);
    }
}
