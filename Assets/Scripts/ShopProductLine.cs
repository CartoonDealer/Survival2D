using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopProductLine : ItemHolder
{
    [Header("��� ���� ��� ������ �� �������� ������� ���� ������")]
    [SerializeField] private ItemListSO allShopItemList;
    [SerializeField] private Player player;

    private List<InventoryItemSO> itemList;
    private List<int> itemIndexList;

    [SerializeField] private List<Transform> goodsTransformList;
   
    [SerializeField] private Transform goodsParent;

    [SerializeField] private InventoryItemSO activeItem;

    [SerializeField] private TextMeshProUGUI itemLabel;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private Transform activeItemBorder;
    [SerializeField] private Button buyButton;

    

    private void Awake()
    {

        itemList = new List<InventoryItemSO>();
        itemIndexList = new List<int>(allShopItemList.itemSOList.Count);
        OnAwake();

        buyButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            player.TryToBuy(activeItem);
        });
    }


    // ��� �� �������� �� ������ ������ ����������� ������� ��� ��������� "�� �����"
    private void OnAwake()
    {
        
        // ��� ������� ������ ������� �� �����
        
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
