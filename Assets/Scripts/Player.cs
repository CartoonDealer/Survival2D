using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float Money { get; set; }
    private float Hungry { get; set; }
    private uint Morale { get; set; }
    private float Cleaness { get; set; }

    [SerializeField] private ItemHolder inventory;

    // Start is called before the first frame update
    void Start()
    {
        Money = 20.0f;
        Hungry = 80f;
        Morale = 70;
        Cleaness = 95;

    }

    public void TryToBuy(InventoryItemSO item)
    {
        if (CheckBalance(item.price))
        {
            Money -= item.price;
            //inventory.AddItem(item);
        }
    }

    private bool CheckBalance(float amount)
    {
        return amount <= Money;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
