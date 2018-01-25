using System;
using UnityEngine;
using UnityEngine.Purchasing;

public class Test_Billing : MonoBehaviour, IStoreListener {

    private static IStoreController storeController;
    private static IExtensionProvider extensionProvider;

    #region 상품ID
    // 상품 ID
    public const string productID1 = "gem1";
    public const string productID2 = "gem2";
    public const string productID3 = "gem3";
    public const string productID4 = "gem4";
    public const string productID5 = "gem5";
    #endregion

    // Use this for initialization
	void Start () {
        InitializePurchasing();
	}
	
    private bool IsInitialized()
    {
        return (storeController != null && extensionProvider != null);
    }

    public void InitializePurchasing()
    {
        if(IsInitialized())
        {
            return; 
        }

        var module = StandardPurchasingModule.Instance();

        ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);

        builder.AddProduct(productID1, ProductType.Consumable, new IDs
        {
            { productID1, AppleAppStore.Name },
            { productID1, GooglePlay.Name },
        });

        builder.AddProduct(productID2, ProductType.Consumable, new IDs
        {
            { productID2, AppleAppStore.Name },
            { productID2, GooglePlay.Name },
        });

        builder.AddProduct(productID3, ProductType.Consumable, new IDs
        {
            { productID3, AppleAppStore.Name },
            { productID3, GooglePlay.Name },
        });

        builder.AddProduct(productID4, ProductType.Consumable, new IDs
        {
            { productID4, AppleAppStore.Name },
            { productID4, GooglePlay.Name },
        });

        builder.AddProduct(productID5, ProductType.Consumable, new IDs
        {
            { productID5, AppleAppStore.Name },
            { productID5, GooglePlay.Name },
        });

        UnityPurchasing.Initialize(this, builder);
    }

    public void BuyProductID(string productID)
    {
        try 
        {
            if (IsInitialized())
            {
                Product p = storeController.products.WithID(productID);

                if (p != null && p.availableToPurchase)
                {
                    Debug.Log(string.Format("구매완료. '{0}'", p.definition.id));
                    storeController.InitiatePurchase(p);
                }
                else
                {
                    Debug.Log("Fail. 구매 안됨. 아이템 없음.");
                }
            }
            else
            {
                Debug.Log("실패. 초기화되지 않음.");
            }
        }
        catch(Exception e)
        {
            Debug.Log("구매 실패. 구매 동안 예외 발생" + e);
        }
    }

    public void RestorePurchase()
    {
        if(!IsInitialized())
        {
            Debug.Log("구매복원 실패. 초기화되지 않음");
            return;
        }

        if(Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("구매복원 시작..");

            var apple = extensionProvider.GetExtension<IAppleExtensions>();

            apple.RestoreTransactions
                (
                    (result) => { Debug.Log("구매복원 시도중" + result + "만약 아무런 메시지가 없다면, 구매복원 유효하지 않음"); }
                );
        }
        else
        {
            Debug.Log("구매복원 실패. 이 플랫폼에서는 지원하지 않음. " + Application.platform);
        }
    }

    public void OnInitialized(IStoreController sc, IExtensionProvider ep)
    {
        Debug.Log("온. 초기화 : 성공");

        storeController = sc;
        extensionProvider = ep;
    }

    public void OnInitializeFailed(InitializationFailureReason reason)
    {
        Debug.Log("온 초기화 실패 이유 : " + reason);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        Debug.Log(string.Format("구매 성공. product : '{0}'", args.purchasedProduct.definition.id));

        switch(args.purchasedProduct.definition.id)
        {
            case productID1:
                break;

            case productID2:
                break;

            case productID3:
                break;

            case productID4:
                break;

            case productID5:
                break;
        }

        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("온 구매실패 함수 실패. Product '{0}', 구매실패 이유: {1}", product.definition.storeSpecificId, failureReason));
    }
}
