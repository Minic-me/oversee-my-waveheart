using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTrigger : MonoBehaviour {
    public float Force { get; set; }

    // Use this for initialization
    void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Destroy()
    {
        Destroy( gameObject );
    }
}
