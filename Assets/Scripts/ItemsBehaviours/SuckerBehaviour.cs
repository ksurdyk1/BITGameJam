using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckerBehaviour : PickableBehaviour
{
    [SerializeField]
    private Transform triggerArea;
     
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
            triggerArea.gameObject.SetActive(true);
        }
        else
        {
            SoundManager.Instance.SuckerSFX.Stop();
            triggerArea.gameObject.SetActive(false);
        }
        
    }
}
