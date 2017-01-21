using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookTrigger : MonoBehaviour {

    private Camera _camera;

	// Use this for initialization
	void Start () {
        _camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = _camera.ViewportPointToRay( new Vector3( 0.5f, 0.5f, 0 ) );
        RaycastHit hit;

        if ( Physics.Raycast( ray, out hit ) )
        {
            SphereLauncher sphereLauncher = hit.collider.gameObject.GetComponent<SphereLauncher>();
            if ( sphereLauncher != null)
            {
                sphereLauncher.Trigger();
            }
            Debug.Log( hit.transform.name );
            Debug.DrawLine( transform.position, hit.transform.position, Color.red );
        }
    }
}
