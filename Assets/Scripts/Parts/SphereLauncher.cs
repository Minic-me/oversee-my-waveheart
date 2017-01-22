using System;
using System.Collections;
using System.Collections.Generic;
using Tobii.EyeTracking;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(GazeAware))]
public class SphereLauncher : MonoBehaviour {

    public GameObject sphereZone;

    public Transform scaleTo;

    public float scaleTime = 2f;

    public iTween.EaseType scaleEaseType = iTween.EaseType.linear;

    private bool _hasDrawn = false;

    public bool soundPlayer = false;

    private AudioSource _audioSource;

    public float sphereForce = 10f;

    private GazeAware _gaze;
    private bool _focusCoroutineStarted;
    public float durationFocusToTrigger;
    public Image fill;

	// Use this for initialization
	void Start () {
        _audioSource = GetComponent<AudioSource>();
        _gaze = GetComponent<GazeAware>();
        _focusCoroutineStarted = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(_gaze.HasGazeFocus && !_focusCoroutineStarted)
        {
            StartCoroutine(Focus());
            _focusCoroutineStarted = true;
        }
        if(!_gaze.HasGazeFocus)
        {
            StopCoroutine(Focus());
            _focusCoroutineStarted = false;
        }
	}

    private IEnumerator Focus()
    {
        float timer = 0f;
        while(timer < durationFocusToTrigger)
        {
            fill.fillAmount = timer / durationFocusToTrigger;
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Trigger();
    }

    public void Trigger()
    {
        if ( sphereZone != null && !_hasDrawn)
        {
            if(_audioSource != null && soundPlayer)
            {
                _audioSource.Play();
            }

            GameObject sphere = Instantiate( sphereZone );
            sphere.transform.position = transform.position;
            sphere.transform.parent = transform;
            sphere.GetComponent<SphereTrigger>().Force = sphereForce;

            iTween.ScaleTo(sphere, iTween.Hash(
                "scale", scaleTo,
                "time", scaleTime,
                "easetype", scaleEaseType,
                "oncomplete", "Destroy",
                "oncompletetarget", sphere
            ));

            iTween.ColorTo( sphere, iTween.Hash(
                "a", 0,
                "time", scaleTime,
                "easetype", scaleEaseType
            ) );

            _hasDrawn = true;
        }
    }
}
