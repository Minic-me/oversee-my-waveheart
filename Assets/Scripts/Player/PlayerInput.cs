using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    [SerializeField] private Transform Head;

    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.position += new Vector3(MoveSpeed * Head.forward.x, 0, MoveSpeed * Head.forward.z);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.position -= new Vector3(MoveSpeed * Head.right.x, 0, MoveSpeed * Head.right.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(MoveSpeed * Head.forward.x, 0, MoveSpeed * Head.forward.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(MoveSpeed * Head.right.x, 0, MoveSpeed * Head.right.z);
        }
    }
}
