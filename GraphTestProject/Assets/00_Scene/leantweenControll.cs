using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leantweenControll : MonoBehaviour {

    public Transform MyTrans;

	// Update is called once per frame
	void Update () {
        //LeanTween.scaleX(this.gameObject, 10f, 3f).setEase(LeanTweenType.easeInElastic);

        //LeanTween.scaleY(this.gameObject, 10f, 3f).setEase(LeanTweenType.easeInExpo);

        LeanTween.move(this.gameObject, MyTrans, 1f).setEase(LeanTweenType.easeOutQuart);
	}
}
