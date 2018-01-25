using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    UISlider MySlider;
    bool bStart = false;

    // 제일 먼저 실행 됨..
    void Reset()
    {

    }

    // 한번 만 실행되는 함수

    // 생성자 전에 호출되는 이니셜라이즈 비슷
    void Awake() 
    {
        // Start() 보다 먼저.
        // 객체 온 되어 있지 않아도 실행
    }


    // 객제가 온 되어 있어야 호출되는 함수
    	// Use this for initialization
	void Start () 
    {
		// Awake() 보다 나중
        // 객체가 온 되어 있어야 실행

        MySlider = GetComponent<UISlider>();

        //Debug.Log("Start 들어옴 : " + MySlider.value);
	}
	
    // 여러 번 호출되는 함수

    // Update() 보다 자주 호출될 수 있음
    void FixedUpdate()
    {
        // 프레임 당이 아닌 안전한 타이밍에 호출
        // 프레임 당 여러 번 초
    }
    
	// Update is called once per frame
	void Update () 
    {
	    if(!bStart)
        {
            MySlider.value += 0.01f;

            if (MySlider.value >= 1)
            {
                bStart = true;
                MySlider.value = 1;

                //Debug.Log("Update value 1 : " + MySlider.value);
            }

           // Debug.Log("Update value 1 보다 작음 : " + MySlider.value);
        }
        else
        {
            MySlider.value -= 0.01f;

            if(MySlider.value <= 0)
            {
                bStart = false;
                MySlider.value = 0;
            }
        }

	}

    void LateUpdate()
    {

    }
}
