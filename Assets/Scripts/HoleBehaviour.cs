using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class HoleBehaviour : MonoBehaviour
{
    [SerializeField] private EnemyBehaviour enemyPrefab;
    [Range(0, 500)]
    [SerializeField] private int forceRange = 200;
    [Range(50, 500)]
    [SerializeField] private int forceRangeY = 320;
    [Range(0, 100)]
    [SerializeField] private int forceRangeDownX = 50;
    [Range(50, 500)]
    [SerializeField] private int minForceDownY = 50;
    [SerializeField] private bool isDown = false;
    [SerializeField] private float cooldown = 3f;

    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        var enemy = Instantiate(enemyPrefab, transform.position, quaternion.identity);
        enemy.transform.SetParent(transform);
        int rand = Random.Range(-forceRange, forceRange);
        int randY = 0;
        if (isDown)
        {
            rand = Random.Range(-forceRangeDownX, forceRangeDownX);
            randY = Random.Range(minForceDownY, forceRangeY);
        }
        
        enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(rand,randY));
        yield return new WaitForSeconds(cooldown);
        StartCoroutine(SpawnEnemy());

    }}
