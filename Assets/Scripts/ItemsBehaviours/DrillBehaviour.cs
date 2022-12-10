using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DrillBehaviour : PickableBehaviour
{
    public override void Interact()
    {
        Debug.Log("Borowanie");
    }

    public override void UseItem()
    {
        SoundManager.Instance.drillSFX.Play();
        Camera.current.DOShakePosition(1f, new Vector3(0.1f, 0.1f, 0.1f), 10, 90f);
    }
}
