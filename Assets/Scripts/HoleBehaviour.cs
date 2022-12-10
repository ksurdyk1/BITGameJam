using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class HoleBehaviour : MonoBehaviour
{
    [SerializeField] private EnemyBehaviour enemyPrefab;
    [Range(0, 500)]
    public int forceRange = 200;

    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator SpawnEnemy()
    {
        var enemy = Instantiate(enemyPrefab, transform.position, quaternion.identity);

        var rand = Random.Range(-forceRange, forceRange);
        enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(rand,0));
        yield return new WaitForSeconds(3f);
        StartCoroutine(SpawnEnemy());

    }}
