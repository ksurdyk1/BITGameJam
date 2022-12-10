using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillBehaviour : PickableBehaviour
{
    public override void Interact()
    {
        SoundManager.Instance.drillSFX.Play();
        Debug.Log("Borowanie");
    }
}
