using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    public InputAction interact;
    public InputAction dropItem;

    private IPickable heldItem;

    private List<GameObject> overlappedObjects;
    void Start()
    {
        interact.Enable();
        dropItem.Enable();
        overlappedObjects = new List<GameObject>();
        
    }

    void Interact()
    {
        if (heldItem != null)
        {
            heldItem.Interact();
            return;
        }

        foreach (var item in overlappedObjects)
        {
            if(item.TryGetComponent(out IPickable pickable) && !pickable.isPicked)
            {
                pickable.PickUp(transform);
                heldItem = pickable;
                return;
            }
        }
    }

    void DropItem()
    {
        if (heldItem != null)
        {
            heldItem.PickDown();
            heldItem = null;
        }
    }
    private void Update()
    {
        if (interact.triggered)
        {
            Interact();
        }

        if (dropItem.triggered)
        {
            DropItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        overlappedObjects.Add(col.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        overlappedObjects.Remove(other.gameObject);
    }
}
