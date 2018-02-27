using System;
using UnityEngine;
using UnityEngine.Purchasing;

public class InAppPurchaser : MonoBehaviour, IStoreListener
{

    public static InAppPurchaser Purchaser = null;

    bool bStartUp = false;

    private static IStoreController storeController;
    private static IExtensionProvider extensionProvider;

    #region 상품ID
    // 상품ID 와 구글개발자 콘솔에 등록한 상품ID 가 동일해야함.
    public const string productId1 = "gem1";
    public const string productId2 = "gem2";
    public const string productId3 = "gem3";
    public const string productId4 = "gem4";
    #endregion

    public static void Init()
    {
        if (Purchaser == null)
        {
            Purchaser = FindObjectOfType(typeof(InAppPurchaser)) as InAppPurchaser;

            if (Purchaser == null)
            {
                GameObject obj = new GameObject("InAppPurchaser");
                Purchaser = obj.AddComponent(typeof(InAppPurchaser)) as InAppPurchaser;
            }
            Purchaser.StartUp();
        }
    }

    public void StartUp()
    {
        if (!bStartUp)
        {
            bStartUp = true;
            InitializePurchasing();
        }
    }

    bool isInitialized()
    {
        return (storeController != null && extensionProvider != null);
    }

    public void InitializePurchasing()
    {
        if (isInitialized())
            return;

        var module = StandardPurchasingModule.Instance();

        ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);

        builder.AddProduct(productId1, ProductType.Consumable, new IDs
        {
            {productId1, AppleAppStore.Name},
            {productId1, GooglePlay.Name},
        });

        builder.AddProduct(productId2, ProductType.Consumable, new IDs
        {
            {productId2, AppleAppStore.Name},
            {productId2, GooglePlay.Name},
        });

        builder.AddProduct(productId3, ProductType.Consumable, new IDs
        {
            {productId3, AppleAppStore.Name},
            {productId3, GooglePlay.Name},
        });

        builder.AddProduct(productId4, ProductType.Consumable, new IDs
        {
            {productId4, AppleAppStore.Name},
            {productId4, GooglePlay.Name},
        });

        UnityPurchasing.Initialize(this, builder);
    }

    public void BuyProductID(string _productId)
    {
        try
        {
            if (isInitialized())
            {
                Product p = storeController.products.WithID(_productId);

                if (p != null && p.availableToPurchase)
                {
                    Debug.Log(string.Format("Purchasing product asychronously: '{0}'", p.definition.id));
                    storeController.InitiatePurchase(p);
                }
                else
                {
                    Debug.Log("BuyProductID : Fail. Not purchasing product, either is not found or is not available for purchase");
                }
            }
            else
            {
                Debug.Log("BuyProductID Fail. Not initialized.");
            }
        }
        catch (Exception e)
        {
            Debug.Log("BuyProductID: Fail. Exception during puchase." + e);
        }
    }

    public void RestorePurchase()
    {
        if (!isInitialized())
        {
            Debug.Log("RestorePuchase Fail. Not initialized.");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = extensionProvider.GetExtension<IAppleExtensions>();

            apple.RestoreTransactions
            (
                // 람다연산자.. 왼쪽의 입력 변수를 오른쪽의 람다 본문과 구분하는데 사용
                // 람다식.. (입력 파라미터) => {문장블럭};
                (result) => { Debug.Log("RestorePurchases continuing : " + result + ". If no further messages, no purchases available to restore."); }
            );
        }
        else
        {
            Debug.Log("RestorePurchases Fail. Not supported on this platform. Current = " + Application.platform);
        }
    }

    public void OnInitialized(IStoreController sc, IExtensionProvider ep)
    {
        Debug.Log("OnInitialized : PASS");

        storeController = sc;
        extensionProvider = ep;
    }

    public void OnInitializeFailed(InitializationFailureReason reason)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason: " + reason);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));

        switch (args.purchasedProduct.definition.id)
        {
            case productId1:
                break;

            case productId2:
                break;

            case productId3:
                break;

            case productId4:
                break;
        }

        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: Fail. Product: '{0}', PurchaseFailureReason: '{1}'", product.definition.storeSpecificId, failureReason));
    }
}
