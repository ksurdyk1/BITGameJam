using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private List<Sprite> enemyType;
    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = enemyType[Random.Range(0, enemyType.Count)];
    }

    
    private void Start()
    {
        var range = 100;
        var x = new Vector2(Random.Range(-range, range), Random.Range(-range, range));

        var difV = transform.position - Vector3.left * Random.Range(0.1f,0.5f);
        GetComponent<Rigidbody2D>().AddForceAtPosition(Vector2.up* Random.Range(1.5f,2.5f), difV );
    }
}
