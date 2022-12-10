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

    public override void UseItem(UsingItem isStartingToUse)
    {

            if (isStartingToUse == UsingItem.OnBegin)
            {
                SoundManager.Instance.FillSFX.Play(); 
                triggerArea.gameObject.SetActive(true);
            }
            else if (isStartingToUse == UsingItem.InProgress)
            {
                Debug.Log("Nie mam itemu filler");

                if(currentHole != null)
                {
                    Debug.Log("Mam filler");

                    if (currentHole.holeState == HoleState.Drilled)
                    {
                        Debug.Log("Filluje");
                        currentHole.HoleFill();


                    }
                }
            }
            else if (isStartingToUse == UsingItem.OnEnd)
            {
                SoundManager.Instance.FillSFX.Stop();
                triggerArea.gameObject.SetActive(false);
            }
        
       
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<HoleBehaviour>() != null)
        {
            // Debug.Log("Entered " + col.name);
            Debug.Log("Mam dziure");

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
