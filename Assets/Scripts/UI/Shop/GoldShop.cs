using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class GoldShop : MonoBehaviour
{
    [SerializeField] private ItemGoldShop[] _items;
    [SerializeField] private TMP_Text _coinsText;

    private int test = 0;

    private void Start()
    {
        string postscript = " Yan";

        if (YandexGame.savesData.language == "ru")
            postscript = " ян";

        foreach (ItemGoldShop item in _items)
        {
            item.SetupPrice(postscript);
        }
    }

    private void OnEnable()
    {
        YandexGame.PurchaseSuccessEvent += AddCoins;
    }

    private void OnDisable()
    {
        YandexGame.PurchaseSuccessEvent -= AddCoins;
    }

    private void AddCoins(string id)
    {
        foreach (ItemGoldShop item in _items)
        {
            if(item.ItemId == id)
            {
                test += item.Coins;
                _coinsText.text = test.ToString();
                break;
            }
        }
    }
}
