using DG.Tweening;
using UnityEngine;

public class PickableBehaviour : MonoBehaviour, IPickable
{
    private Vector3 startPos;
    private Transform player;
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

    public virtual void Interact()
    {
        Debug.Log("interact item");
    }

    private void Update()
    {
        if (isPicked)
        {
            transform.position = player.position;
        }
    }
}
