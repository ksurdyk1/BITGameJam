using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveMouth : MonoBehaviour
{
    public float powerOffset = 0.1f;
    public float powerScale = 0.1f;

    void Start()
    {
        transform.DOLocalMove(new Vector3(0, powerOffset, 0), 1f).SetLoops(-1, LoopType.Yoyo);
       // transform.DOScale(new Vector3(0, 0.9397472f + powerScale, 0), 1f).SetLoops(-1, LoopType.Yoyo);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
