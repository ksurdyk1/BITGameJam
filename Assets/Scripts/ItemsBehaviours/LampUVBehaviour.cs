using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampUVBehaviour : PickableBehaviour
{
   public override void Interact()
   {
      Debug.Log("UVing");
   }

   public override void UseItem()
   {
      SoundManager.Instance.UVLampSFX.Play();
   }
}
