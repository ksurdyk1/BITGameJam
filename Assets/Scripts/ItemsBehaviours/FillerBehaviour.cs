using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillerBehaviour : PickableBehaviour
{
    [SerializeField]
    private Transform triggerArea;
    public override void Interact()
    {
        Debug.Log("Filling");
    }

    public override void UseItem(bool isStartingToUse)
    {
        if (isStartingToUse)
        {
            SoundManager.Instance.FillSFX.Play(); 
            triggerArea.gameObject.SetActive(true);
        }
        else
        {
            SoundManager.Instance.FillSFX.Stop();
            triggerArea.gameObject.SetActive(false);
        }
    }
}
