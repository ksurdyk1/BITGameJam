using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampUVBehaviour : PickableBehaviour
{
   public override void Interact()
   {
      SoundManager.Instance.UVLampSFX.Play();

      Debug.Log("UVing");
   }
}
