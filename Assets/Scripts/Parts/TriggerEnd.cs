using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnd : MonoBehaviour
{
    public int _levelNumber;

    void OnTriggerEnter(Collider other)
    {
        EventManager.Send("level_complete", _levelNumber);
    }
}
