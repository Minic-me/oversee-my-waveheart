using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.EyeTracking;

[RequireComponent(typeof(GazeAware))]
public class Code : MonoBehaviour {

    private GazeAware _gazeAwareComponent;
    private bool _isLooked;
    private bool _isActivate = false;

    // Use this for initialization
    void Start () {
        _gazeAwareComponent = GetComponent<GazeAware>();
	}
	
	// Update is called once per frame
	void Update () {
        if (_gazeAwareComponent.HasGazeFocus && !_isLooked)
        {
            if (!_isActivate)
            {
                EventManager.Send("code_activated", this);
            }
            _isLooked = true;
        }
        else if(!_gazeAwareComponent.HasGazeFocus && _isLooked)
        {
            _isLooked = false;
        }
    }

    public void Activate()
    {
        _isActivate = true;
        GetComponent<MeshRenderer>().material.color = Color.green;
    }

    public void Disactivate()
    {
        _isActivate = false;
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
