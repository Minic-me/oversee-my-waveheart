using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour {

    private Platform _platform;

	// Use this for initialization
	void Start () {
        _platform = GetComponentInParent<Platform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        CharacterController character = collider as CharacterController;
        if ( character != null )
        {
            _platform.playerAttached = collider.gameObject;
            collider.transform.parent = transform.parent;
        }
    }

    void OnTriggerExit( Collider other )
    {
        CharacterController character = other as CharacterController;
        if ( character != null )
        {
            _platform.playerAttached = null;
            other.transform.parent = null;
        }
    }
}
