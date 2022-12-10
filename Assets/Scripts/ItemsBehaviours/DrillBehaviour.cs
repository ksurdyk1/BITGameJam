using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DrillBehaviour : PickableBehaviour
{
    [SerializeField]
    private Transform triggerArea;

    public override void Interact()
    {
    }

    public override void UseItem(bool isStartingToUse)
    {
        Debug.Log("Borowanie");
        if (isStartingToUse)
        {
            transform.DORotate(Vector3.forward * 30, 1f).Rewind();
            SoundManager.Instance.drillSFX.loop = true;
            triggerArea.gameObject.SetActive(true);
            SoundManager.Instance.drillSFX.Play();

            if(currentHole != null)
            {
                currentHole.gameObject.SetActive(false);
            }
          
            
            
        }
        else
        {
            SoundManager.Instance.drillSFX.Stop();
            triggerArea.gameObject.SetActive(false);
        }
       // Camera.current.DOShakePosition(1f, new Vector3(0.1f, 0.1f, 0.1f), 10, 90f);
    }
    
 
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<HoleBehaviour>() != null)
        {
            Debug.Log("Entered " + col.name);

            currentHole = col.GetComponent<HoleBehaviour>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.GetComponent<HoleBehaviour>() != null)
        {
            Debug.Log("Exit " + other.name);
            currentHole = null;

        }
    }
    
}
