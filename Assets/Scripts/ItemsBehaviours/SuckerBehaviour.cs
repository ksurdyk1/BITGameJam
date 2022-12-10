using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckerBehaviour : PickableBehaviour
{
     
    public override void Interact()
    {
        SoundManager.Instance.SuckerSFX.Play();
        Debug.Log("Sucking");
    }
}
