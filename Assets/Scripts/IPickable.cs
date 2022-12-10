using UnityEngine;

public interface IPickable
{
    bool isPicked { get; set; }
    void PickUp(Transform parent);
    void PickDown();
    void Interact();
    void UseItem();

}
