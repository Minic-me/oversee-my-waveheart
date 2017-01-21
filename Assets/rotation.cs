using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.eulerAngles += new Vector3(0, 15*Time.deltaTime, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Time.timeScale = 1;
        }

	}
}
