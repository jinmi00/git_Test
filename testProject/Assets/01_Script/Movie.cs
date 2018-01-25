using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movie : MonoBehaviour {

    public MediaPlayerCtrl MyMovieCtrl;

    bool bClick = false;

	void Start () {
        
	}

    public void OnPlayBtn()
    {
        MyMovieCtrl.Play();
        Debug.Log("들어옴");
    }

    public void OnStopBtn()
    {
        MyMovieCtrl.Stop();
    }

    public void OnPauseBtn()
    {
        MyMovieCtrl.Pause();
    }

    public void OnPauseToch()
    {
        if (!bClick)
        {
            OnPauseBtn();
            bClick = true;
        }
        else
        {
            OnPlayBtn();
            bClick = false;
        }
    }
}
