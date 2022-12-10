using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckerBehaviour : PickableBehaviour
{
     
    public override void Interact()
    {
        Debug.Log("Sucking");
    }

    public override void UseItem()
    {
        SoundManager.Instance.SuckerSFX.Play();
    }
}
