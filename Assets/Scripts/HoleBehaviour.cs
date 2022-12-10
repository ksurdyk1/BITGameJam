using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public enum HoleState
{
    Hole,
    Drilled,
    Filled,
    Healthy
}
public class HoleBehaviour : MonoBehaviour
{
    private HoleState holeState;
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

    [SerializeField] private List<Sprite> holeType;

    public void setHoleState(HoleState newState)
    {
        holeState = newState;
    }

    public HoleState getHoleState()
    {
        return holeState;
    }
    private void Awake()
    {
        cooldown = Random.Range(2, 6);
        GetComponent<SpriteRenderer>().sprite = holeType[Random.Range(0, holeType.Count)];
    }

    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(cooldown);

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
        cooldown = Random.Range(2, 6);

        StartCoroutine(SpawnEnemy());

    }}
