using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DrillBehaviour : PickableBehaviour
{
    public override void Interact()
    {
    }

    public override void UseItem()
    {
        Debug.Log("Borowanie");

        SoundManager.Instance.drillSFX.Play();
        Camera.current.DOShakePosition(1f, new Vector3(0.1f, 0.1f, 0.1f), 10, 90f);
    }
}
