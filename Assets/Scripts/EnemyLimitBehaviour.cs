using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyLimitBehaviour : MonoBehaviour
{
    public UnityEvent eventLost = new UnityEvent();


    private void Start()
    {
        eventLost.AddListener(LosePoint);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
    }

    void LosePoint()
    {
        
    }
}
