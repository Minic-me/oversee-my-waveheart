using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        CharacterController player = other as CharacterController;
        if(player != null)
        {
            EventManager.Send("die_player");
        }
    }
}
