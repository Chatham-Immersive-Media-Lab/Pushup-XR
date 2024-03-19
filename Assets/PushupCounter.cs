using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushupCounter : MonoBehaviour
{
    private int pushups;
    private Collider previousCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other != previousCollider)
        {
            pushups++;
            previousCollider = other;
            Debug.Log(pushups);
        }
    }
}