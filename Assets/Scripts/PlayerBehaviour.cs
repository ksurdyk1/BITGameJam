using System;
using System.Collections;
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
            return;
        
        
        foreach (var item in overlappedObjects)
        {
            if(item.TryGetComponent(out IPickable pickable))
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
            Debug.Log("TRIGGERRRR");
            Interact();
        }

        if (dropItem.triggered)
        {
            DropItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("added " +col.gameObject.name);
        overlappedObjects.Add(col.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("removed " + other.gameObject.name);

        overlappedObjects.Remove(other.gameObject);
    }
}
