using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckerBehaviour : PickableBehaviour
{
     
    public override void Interact()
    {
        Debug.Log("Sucking");
    }

    public override void UseItem(bool isStartingToUse)
    {
        if (isStartingToUse)
        {
            SoundManager.Instance.SuckerSFX.loop = true;
            SoundManager.Instance.SuckerSFX.Play();
        }
        else
        {
            SoundManager.Instance.SuckerSFX.Stop();
        }
        
    }
}
