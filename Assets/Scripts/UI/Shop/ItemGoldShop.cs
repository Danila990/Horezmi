using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class ItemGoldShop : MonoBehaviour
{
    public string ItemId => _itemId;
    public int Coins => _coins;

    [SerializeField] private int _coins;
    [SerializeField] private string _itemId;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private TMP_Text _coinsText;

    public void SetupPrice(string postscript)
    {
        _priceText.text = YandexGame.PurchaseByID(_itemId).priceValue + postscript;
        _coinsText.text = _coins.ToString();
    }

    public void BuyItem()
    {
        if (YandexGame.auth)
            YandexGame.BuyPayments(_itemId);
        else
            YandexGame.AuthDialog();
    }
}
