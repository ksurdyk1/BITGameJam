using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PickableBehaviour : MonoBehaviour, IPickable
{
    private Vector3 startPos;
    public Transform player;
    public bool isPicked { get; set; }


    private void Start()
    {
        startPos = transform.position;
    }

    public void PickUp(Transform parent)
    {
        DOTween.KillAll();
        isPicked = true;
        player = parent;
    }

    public void PickDown()
    {
        isPicked = false;
        transform.DOMove(startPos, 1f).SetEase(Ease.InOutCubic);

    }

    private void Update()
    {
        if (isPicked)
        {
            transform.position = player.position;
        }
    }
}