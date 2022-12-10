using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillerBehaviour : PickableBehaviour
{
    public override void Interact()
    {
        Debug.Log("Filling");
    }

    public override void UseItem(bool isStartingToUse)
    {
        if (isStartingToUse)
        {
            SoundManager.Instance.FillSFX.Play(); 
        }
        else
        {
            SoundManager.Instance.FillSFX.Stop();
        }
    }
}
