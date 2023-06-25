using UnityEngine;
using TMPro;
using System.Collections;

public class MoneyUI : MonoBehaviour
{

    public TextMeshProUGUI moneyText;

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
