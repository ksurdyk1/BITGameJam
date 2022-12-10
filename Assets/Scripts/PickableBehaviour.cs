using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PickableBehaviour : MonoBehaviour, IPickable
{
    private Vector3 startPos;
    private Transform player;
    public bool isPicked { get; set; }

    protected HoleBehaviour currentHole;

    
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

    public virtual void Interact()
    {
        Debug.Log("interact item");
    }

    public virtual void UseItem(bool isStartingToUse)
    {
        Debug.Log("using item");
    }

    private void Update()
    {
        if (isPicked)
        {
            transform.position = player.position;
        }
    }
    
    
}
