﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
	private static MoneyDisplay  instance;
	public static MoneyDisplay Instance { get => instance; }

	public MoneyPocket Pocket;

    public Text CreditCurrencyText;
    public Text EtherCurrencyText;

    public GameObject CreditCurrencyMiniature;
    public GameObject EtherCurrencyMiniature;

	void Awake()
	{
		if(instance == null)
			instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}
	}

	private void Start()
    {
        UpdateDisplay();
        Pocket.Money.OnValueUpdated.AddListener(() => UpdateDisplay());
        Pocket.Ether.OnValueUpdated.AddListener(() => UpdateDisplay());
    }

    private void UpdateDisplay()
    {
        CreditCurrencyText.text = Pocket.Money.ToString();
        EtherCurrencyText.text = Pocket.Ether.ToString();
    }

    public void SwipeCurrency()
    {
        if (CreditCurrencyMiniature.gameObject.activeSelf)
        {
			ShowEther();
		}
        else
        {
			ShowCredits();
		}
    }

	public void ShowCredits()
	{
		CreditCurrencyMiniature.gameObject.SetActive(true);
		CreditCurrencyText.gameObject.SetActive(true);

		EtherCurrencyMiniature.gameObject.SetActive(false);
		EtherCurrencyText.gameObject.SetActive(false);
	}

	public void ShowEther()
	{
		CreditCurrencyMiniature.gameObject.SetActive(false);
		CreditCurrencyText.gameObject.SetActive(false);

		EtherCurrencyMiniature.gameObject.SetActive(true);
		EtherCurrencyText.gameObject.SetActive(true);
	}
}
