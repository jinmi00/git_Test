using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour {


    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void ShowPopup()
    {
        this.gameObject.SetActive(true);
    }

    public void ClosePopup()
    {
        this.gameObject.SetActive(false);
    }
}
