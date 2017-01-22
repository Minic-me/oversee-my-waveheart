using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnd : MonoBehaviour
{
    public int _levelNumber;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        CharacterController character = other as CharacterController;
        if(character != null )
        {
            EventManager.Send( "level_complete", _levelNumber );
        }
    }
}
