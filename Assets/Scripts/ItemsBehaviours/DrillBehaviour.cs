using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DrillBehaviour : PickableBehaviour
{
    [SerializeField]
    private Transform triggerArea;

    private EnemyBehaviour currentEnemy;

    private Quaternion startRotation;
    void Start()
    {
        startRotation = transform.rotation;
    }
    public override void Interact()
    {
    }

    public override void UseItem(UsingItem isStartingToUse)
    {

            if (isStartingToUse == UsingItem.OnBegin)
            {
                transform.DORotate(Vector3.forward * 30, 1f).Rewind();
                SoundManager.Instance.drillSFX.loop = true;
                triggerArea.gameObject.SetActive(true);
                SoundManager.Instance.drillSFX.Play();

                transform.rotation = startRotation;

            }
            else if (isStartingToUse == UsingItem.InProgress)
            {
                transform.Rotate(0,0,Random.Range(-1f,1f));
                if(currentHole != null)
                {
                    Debug.Log("Do drill");
                    if( currentHole.holeState == HoleState.Hole)
                        currentHole.HoleDrill();
                }
                else if (currentEnemy != null)
                {
                   currentEnemy.StartSlashing(this);
                }
            }
            else if (isStartingToUse == UsingItem.OnEnd)
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
          // Debug.Log("Entered " + col.name);

            currentHole = col.GetComponent<HoleBehaviour>();
        }
        else if (col.GetComponent<EnemyBehaviour>() != null)
        {
            Debug.Log("Entered " + col.name);

            currentEnemy = col.GetComponent<EnemyBehaviour>();
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
