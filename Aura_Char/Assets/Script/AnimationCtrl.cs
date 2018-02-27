using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCtrl : MonoBehaviour {

    Animator Anim;

	// Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		// Space 로 Sad 로 바꿔보자.
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Anim.SetBool("bSad", true);
            Debug.Log("Sad 들어옴");
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Anim.SetBool("bSad", false);
        }

        // A 로 Joy 로 바꿔보자.
        if(Input.GetKeyDown(KeyCode.A))
        {
            Anim.SetBool("bJoy", true);
            Debug.Log("joy 들어옴");
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            Anim.SetBool("bJoy", false);
        }

        // B 로 Normal 로 바꿔보자
        if(Input.GetKeyDown(KeyCode.B))
        {
            Anim.SetBool("bNormal", true);
            Debug.Log("Normal 들어옴");
        }
        else if(Input.GetKeyUp(KeyCode.B))
        {
            Anim.SetBool("bNormal", false);
        }

	}
}
