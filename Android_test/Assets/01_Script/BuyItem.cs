using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour {

    int iCount = 0;

    public bool IsInitialized;
    public static GPConnectionState State;

    void Awake()
    {
        InAppPurchaser.Init();
    }

    void Start()
    {
        GooglePlayConnection.ActionConnectionResultReceived += ActionConnectionResultReceived;
        GooglePlayConnection.Instance.Connect();

        if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED)
        {
            // Player is Connected..

            //GooglePlayManager.ActionOAuthTokenLoaded += ActionOAuthTokenLoaded;
            //GooglePlayManager.Instance.LoadToken();
            GooglePlayManager.Instance.LoadToken(GooglePlayManager.Instance.currentAccount, "oauth2:https://www.googleapis.com/auth/games");
        }
    }

    void Destroy()
    {
        GooglePlayConnection.Instance.Disconnect();
    }


    public void OnBtn_Buy()
    {
        ++iCount;

        InAppPurchaser.Purchaser.BuyProductID("gem1");

        GameObject.Find("Count").GetComponent<UILabel>().text = iCount.ToString();

    }

    private void ActionConnectionResultReceived(GooglePlayConnectionResult result)
    {
        if(result.IsSuccess)
        {
            Debug.Log("Connected!");
        }
        else
        {
            Debug.Log("Connection failed with code: " + result.code.ToString());
        }

//CANCELED = 13,
//DATE_INVALID = 12,
//DEVELOPER_ERROR = 10,
//DRIVE_EXTERNAL_STORAGE_REQUIRED = 1500,
//INTERNAL_ERROR = 8,
//INTERRUPTED = 15,
//INVALID_ACCOUNT = 5,
//LICENSE_CHECK_FAILED = 11,
//NETWORK_ERROR = 7,
//RESOLUTION_REQUIRED = 6,
//SERVICE_DISABLED = 3,
//SERVICE_INVALID = 9,
//SERVICE_MISSING = 1,
//SERVICE_VERSION_UPDATE_REQUIRED = 2,
//SIGN_IN_REQUIRED = 4,
//SUCCESS = 0,
//TIMEOUT = 14
    }
}
