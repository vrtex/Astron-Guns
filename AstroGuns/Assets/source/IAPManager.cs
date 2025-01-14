﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyMobile;

public class IAPManager : MonoBehaviour
{
    private static IAPManager instance;
    public static IAPManager Instance { get => instance; }
    public IAPProduct[] products;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        if(!InAppPurchasing.IsInitialized())
            InAppPurchasing.InitializePurchasing();
        InAppPurchasing.PurchaseCompleted += InAppPurchasing_PurchaseCompleted;

        products = InAppPurchasing.GetAllIAPProducts();
    }

    private void InAppPurchasing_PurchaseCompleted(IAPProduct obj)
    {
        //throw new System.NotImplementedException();
        PurchaseCompletedHandler(obj);
    }

    // Purchase the sample product
    public void PurchaseSampleProduct(string product)
    {
        // EM_IAPConstants.Sample_Product is the generated name constant of a product named "Sample Product"
        InAppPurchasing.Purchase(product);
    }

    // Successful purchase handler
    void PurchaseCompletedHandler(IAPProduct product)
    {
        // Compare product name to the generated name constants to determine which product was bought
        switch (product.Name)
        {
            case EM_IAPConstants.Product_ether_60:
                MoneyPocket.Instance.Ether.Add(60);
                break;
            case EM_IAPConstants.Product_ether_150:
                MoneyPocket.Instance.Ether.Add(150);
                break;
            case EM_IAPConstants.Product_ether_360:
                MoneyPocket.Instance.Ether.Add(360);
                break;
            case EM_IAPConstants.Product_ether_900:
                MoneyPocket.Instance.Ether.Add(900);
                break;
            case EM_IAPConstants.Product_super_mega_pack:
                MoneyPocket.Instance.Ether.Add(600);
                WarehouseManager.Instance.AddChest(3);
                WarehouseManager.Instance.AddChest(4);
                WarehouseManager.Instance.AddChest(4);
                break;
                //case EM_IAPConstants.Another_Sample_Product:
                //    Debug.Log("Another_Sample_Product was purchased. The user should be granted it now.");
                //    break;
                // More products here...
        }
    }

    //WarehouseManager.Instance.AddChest(3);
				//WarehouseManager.Instance.AddChest(3);
				//WarehouseManager.Instance.AddChest(4);
				//WarehouseManager.Instance.AddChest(4);
				//MoneyPocket.Instance.Ether.ActualValue += 600;

    // Failed purchase handler
    void PurchaseFailedHandler(IAPProduct product)
    {
        Debug.Log("The purchase of product " + product.Name + " has failed.");
    }
}
