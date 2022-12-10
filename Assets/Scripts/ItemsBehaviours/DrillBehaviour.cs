using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DrillBehaviour : PickableBehaviour
{
    public override void Interact()
    {
    }

    public override void UseItem(bool isStartingToUse)
    {
        Debug.Log("Borowanie");
        if (isStartingToUse)
        {
            SoundManager.Instance.drillSFX.Play();
        }
        else
        {
            SoundManager.Instance.drillSFX.Stop();
        }
        Camera.current.DOShakePosition(1f, new Vector3(0.1f, 0.1f, 0.1f), 10, 90f);
    }
}
