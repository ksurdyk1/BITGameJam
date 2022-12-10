using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampUVBehaviour : PickableBehaviour
{
   [SerializeField]
   private Transform triggerArea;
   public override void Interact()
   {
      Debug.Log("UVing");
   }

   public override void UseItem(bool isStartingToUse)
   {
      if (isStartingToUse)
      {
         SoundManager.Instance.UVLampSFX.Play();
         triggerArea.gameObject.SetActive(true);
      }
      else
      {
         SoundManager.Instance.UVLampSFX.Stop();
         triggerArea.gameObject.SetActive(false);
      }
   }
}
