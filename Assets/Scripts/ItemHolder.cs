using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ItemHolder : MonoBehaviour
{
    public abstract void InteractItem(InventoryItemSO item);
}
