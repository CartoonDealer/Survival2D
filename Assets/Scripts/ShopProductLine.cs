using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShopProductLine : MonoBehaviour
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
        //transformOffset = new Vector3(190, 0, 0);
        // ��� ������� ������ ������� �� �����
        for (int i = 0; i <= 3; i++)
        {  
            itemList.Add(allShopItemList.itemSOList[UnityEngine.Random.Range(0, allShopItemList.itemSOList.Count)]);
            //if (i>0) goodsTransformList[0].transform.position += transformOffset;
            Instantiate(itemList[i].prefab, goodsTransformList[i].position, goodsTransformList[i].rotation, goodsParent);
            itemList[i].itemOwner = transform;
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
        itemLabel.text = activeItem.name;
        //�������� ������
        itemDescription.text = activeItem.hint;
        //��������� ������
        itemPrice.text = activeItem.price.ToString();
    }
}
