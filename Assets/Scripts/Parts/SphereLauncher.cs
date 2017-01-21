using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereLauncher : MonoBehaviour {

    public GameObject sphereZone;

    public Transform scaleTo;

    public float scaleTime = 2f;

    public iTween.EaseType scaleEaseType = iTween.EaseType.linear;

    private bool _hasDrawn = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Trigger()
    {
        if ( sphereZone != null && !_hasDrawn)
        {
            GameObject sphere = Instantiate( sphereZone );
            sphere.transform.position = transform.position;
            sphere.transform.parent = transform;

            iTween.ScaleTo(sphere, iTween.Hash(
                "scale", scaleTo,
                "time", scaleTime,
                "easetype", scaleEaseType,
                "oncomplete", "Destroy",
                "oncompletetarget", sphere
            ));

            _hasDrawn = true;
        }
    }
}
