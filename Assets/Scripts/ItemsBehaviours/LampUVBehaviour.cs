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

   public override void UseItem(UsingItem isStartingToUse)
   {
 
         if (isStartingToUse == UsingItem.OnBegin)
         {
            SoundManager.Instance.UVLampSFX.Play();
            triggerArea.gameObject.SetActive(true);
         }
         else if (isStartingToUse == UsingItem.InProgress)
         {
            if(currentHole != null)
            {
               if( currentHole.holeState == HoleState.Filled)
                  currentHole.HoleUving();
            }
         }
         else if (isStartingToUse == UsingItem.OnEnd)
         {
            SoundManager.Instance.UVLampSFX.Stop();
            triggerArea.gameObject.SetActive(false);
         }
      
   
   }
   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.GetComponent<HoleBehaviour>() != null)
      {
         // Debug.Log("Entered " + col.name);

         currentHole = col.GetComponent<HoleBehaviour>();
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {

      if (other.GetComponent<HoleBehaviour>() != null)
      {
         currentHole = null;

      }
   }
}
