using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    bool isPicked { get; set; }
    void PickUp(Transform parent);
    void PickDown();

}
