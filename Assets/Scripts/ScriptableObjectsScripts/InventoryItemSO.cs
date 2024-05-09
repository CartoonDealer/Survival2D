using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class InventoryItemSO : ScriptableObject
{

    public Transform prefab;
    public Sprite sprite;
    public string itemName;
    public string hint;  // подсказку в дальнейшем лучше сделать отдельным классом
    public float price;
    public Transform itemOwner;
}
