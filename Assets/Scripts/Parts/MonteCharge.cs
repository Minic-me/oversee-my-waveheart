using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonteCharge : MonoBehaviour {

    [Range(0f, 100f)]
    public float state = 0f;

    public Transform poids;
    public Transform plateforme;
    public Transform cable;

    public Vector3 plateformeMax;
    public Vector3 plateformeMin;

    public Vector3 poidsMax;
    public Vector3 poidsMin;

    public Vector3 cableMax;
    public Vector3 cableMin;

	// Use this for initialization
	void Start () {
        ChangeState(100f);		
	}
	
	// Update is called once per frame
	void Update () {
        plateforme.position = new Vector3(
            (plateformeMax.x - plateformeMin.x) * ( state / 100 ) + plateformeMin.x,
            (plateformeMax.y - plateformeMin.y) * ( state / 100 ) + plateformeMin.y,
            (plateformeMax.z - plateformeMin.z) * ( state / 100 ) + plateformeMin.z
        );

        poids.position = new Vector3(
            ( poidsMax.x - poidsMin.x ) * ( state / 100 ) + poidsMin.x,
            ( poidsMax.y - poidsMin.y ) * ( state / 100 ) + poidsMin.y,
            ( poidsMax.z - poidsMin.z ) * ( state / 100 ) + poidsMin.z
        );

        cable.localScale = new Vector3(
            ( cableMax.x - cableMin.x ) * ( state / 100 ) + cableMin.x,
            ( cableMax.y - cableMin.y ) * ( state / 100 ) + cableMin.y,
            ( cableMax.z - cableMin.z ) * ( state / 100 ) + cableMin.z
        );
    }

    public void ChangeState(float newState)
    {
        iTween.ValueTo( gameObject, iTween.Hash(
            "from", state,
            "to", newState,
            "time", 3f,
            "onupdate", "ChangingState",
            "onupdatetarget", gameObject
        ) );
    }

    private void ChangingState(float v)
    {
        state = v;
    }
}
