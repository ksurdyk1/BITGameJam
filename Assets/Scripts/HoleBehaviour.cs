using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class HoleBehaviour : MonoBehaviour
{
    [SerializeField] private EnemyBehaviour enemyPrefab;
    [Range(0, 500)]
    public int forceRange = 200;

    [SerializeField] private float cooldown = 3f;

    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        var enemy = Instantiate(enemyPrefab, transform.position, quaternion.identity);
        var rand = Random.Range(-forceRange, forceRange);
        enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(rand,0));
        yield return new WaitForSeconds(cooldown);
        StartCoroutine(SpawnEnemy());

    }}
