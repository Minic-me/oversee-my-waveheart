using Oversee.Scripts.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public bool isMoving = false;

    private Vector3 _lastPosition;

    public GameObject playerAttached;

    // Use this for initialization
    void Start()
    {
        _lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        isMoving = _lastPosition != transform.position;

        _lastPosition = transform.position;

        if ( isMoving && playerAttached != null )
        {
            playerAttached.transform.position = _lastPosition + new Vector3(0,1.3f,0);
            playerAttached.GetComponent<FirstPersonController>().isImmobilized = true;
        } else if( playerAttached != null )
        {
            playerAttached.GetComponent<FirstPersonController>().isImmobilized = false;
        }
    }

    void OnTriggerEnter( Collider other )
    {
        SphereTrigger sphereTrigger = other.gameObject.GetComponent<SphereTrigger>();

        if ( sphereTrigger != null && !isMoving )
        {
            isMoving = true;
            Vector3 movement = ( transform.position - other.transform.position ) * sphereTrigger.Force;
            GetComponent<Rigidbody>().AddForce( movement );
        }
    }
}
