using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampUVBehaviour : PickableBehaviour
{
   public override void Interact()
   {
      Debug.Log("UVing");
   }

   public override void UseItem(bool isStartingToUse)
   {
      if (isStartingToUse)
      {
         SoundManager.Instance.UVLampSFX.Play();
      }
      else
      {
         SoundManager.Instance.UVLampSFX.Stop();
      }
   }
}
