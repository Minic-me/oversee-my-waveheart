using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoidsMonteCharge : MonoBehaviour {

    private MonteCharge _monteCharge;

	// Use this for initialization
	void Start () {
        _monteCharge = GetComponentInParent<MonteCharge>();		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter( Collider other )
    {
        SphereTrigger trigger = other.gameObject.GetComponent<SphereTrigger>();
        if ( trigger != null )
        {
            Vector3 diff;
            if ( _monteCharge.state > 50 )
            {
                diff = transform.position - other.transform.position;
            } else
            {
                diff = other.transform.position - transform.position;
            }

            if(diff.y > 0 )
            {
                _monteCharge.ChangeState( ( _monteCharge.state > 50 ? 0 : 100 ) );
            }
        }
    }
}
