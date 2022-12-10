using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillerBehaviour : PickableBehaviour
{
    public override void Interact()
    {
        SoundManager.Instance.FillSFX.Play();

        Debug.Log("Filling");
    }
}
