using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    
	void Start ()
    {
        EventManager.Send("in_tampon");
    }
}
