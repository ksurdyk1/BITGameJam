using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    public InputAction interact;
    public InputAction dropItem;
    public InputAction useItem;
    private IPickable heldItem;

    private List<GameObject> overlappedObjects =new List<GameObject>();
    void Start()
    {
        interact.Enable();
        dropItem.Enable();
        useItem.Enable();
    }

    void Interact()
    {
        foreach (var item in overlappedObjects)
        {
            if(item.TryGetComponent(out IPickable pickable) && !pickable.isPicked && heldItem == null)
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

    void UseItem(UsingItem isStarting)
    {
        if (heldItem != null)
        {
            heldItem.UseItem(isStarting);
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

        if (useItem.WasPressedThisFrame()) 
        {
            UseItem(UsingItem.OnBegin);
        }
        if (useItem.IsPressed()) 
        {
            UseItem(UsingItem.InProgress);
        }
        
        if (useItem.WasReleasedThisFrame()) 
        {
            UseItem(UsingItem.OnEnd);
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
