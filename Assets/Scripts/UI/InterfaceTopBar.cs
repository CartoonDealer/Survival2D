using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class InterfaceTopBar : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] private TextMeshProUGUI moneyBalance;

    // Start is called before the first frame update
    void Start()
    {
        moneyBalance = transform.Find("MoneyBalanceText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyBalance.text = player.Money.ToString("0.00");

    }
}
