using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeManager : MonoBehaviour
{
    public Rigidbody2D hookEnd;
    // Start is called before the first frame update
    void Start()
    {
     hookEnd.AddForce(Vector2.left*2f);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
