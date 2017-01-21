using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMaterial : MonoBehaviour {

    public Material normalMaterial;
    public Material switchMaterial;

    private bool hasSwitch = false;

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    public void Switch()
    {
        if ( !hasSwitch )
        {
            GetComponent<Renderer>().material = switchMaterial;
            hasSwitch = true;
        }
    }

    void OnTriggerEnter( Collider collision )
    {
        SphereTrigger trigger = collision.gameObject.GetComponent<SphereTrigger>();
        if ( trigger != null )
        {
            Switch();
        }
    }
}
