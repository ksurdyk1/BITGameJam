using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemyLimitBehaviour : MonoBehaviour
{
    [SerializeField] private WinLoseCondition loseCondition;
   


    private void OnCollisionEnter2D(Collision2D col)
    {
        loseCondition.LosePoint();
        Destroy(col.gameObject);
    }

    
}
