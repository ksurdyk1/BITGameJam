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

public enum UsingItem
{
    OnBegin,
    InProgress,
    OnEnd
}
public class HoleBehaviour : MonoBehaviour
{
    public HoleState holeState;
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
    [SerializeField] private Transform fillerTransform;


    private Vector2 drillProgress;
    private Vector2 fillProgress;
    private Vector2 UVProgress;

    void Awake()
    {
        drillProgress = new Vector2(0,2);
        fillProgress = new Vector2(0, 2);
        UVProgress = new Vector2(0,2);
        
        cooldown = Random.Range(2, 6);
        GetComponent<SpriteRenderer>().sprite = holeType[Random.Range(0, holeType.Count)];
    }


    public void HoleDrill()
    {
        drillProgress.x += Time.deltaTime;
        transform.localScale +=  Vector3.one* Time.deltaTime*0.1f;

        if (drillProgress.x >= drillProgress.y)
        {
            holeState = HoleState.Drilled;
            Debug.Log("Drilled");
        }
    }
    
    public void HoleFill()
    {
        fillerTransform.localScale += Vector3.one /2 * Time.deltaTime;
        fillProgress.x += Time.deltaTime;

        if (fillProgress.x >= fillProgress.y)
        {
            holeState = HoleState.Filled;
            Debug.Log("Filled");
        }
        
    }

    private float helpBlue =1;
    public void HoleUving()
    {
        helpBlue -= Time.deltaTime;
        fillerTransform.GetComponent<SpriteRenderer>().color = new Color(1, 1, helpBlue, 1);
        UVProgress.x += Time.deltaTime;
        if (UVProgress.x >= UVProgress.y)
        {
            holeState = HoleState.Healthy;
            Debug.Log("UVed");
        }
    }
    void Start()
    {

    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(cooldown);

        var enemy = Instantiate(enemyPrefab, transform.position, quaternion.identity);
        int rand = Random.Range(-forceRange, forceRange);
        int randY = 0;
        if (isDown)
        {
            rand = Random.Range(-forceRangeDownX, forceRangeDownX);
            randY = Random.Range(minForceDownY, forceRangeY);
        }
        
        enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(rand,randY));
        cooldown = Random.Range(2, 6);

        if (holeState == HoleState.Drilled || holeState == HoleState.Hole)
            BeginSpawning();

    }

    public void BeginSpawning()
    {
        StartCoroutine(SpawnEnemy());
    }
    
}
