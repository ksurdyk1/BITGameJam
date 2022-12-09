using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
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
        Debug.Log("Spawned");
        yield return new WaitForSeconds(1f);
        StartCoroutine(SpawnEnemy());

    }}
