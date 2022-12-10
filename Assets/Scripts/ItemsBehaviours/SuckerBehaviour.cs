using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckerBehaviour : PickableBehaviour
{
    [SerializeField]
    private Transform triggerArea;

    private EnemyBehaviour currentEnemy;
    public override void Interact()
    {
        Debug.Log("Sucking");
    }

    public override void UseItem(UsingItem isStartingToUse)
    {
        if (isStartingToUse == UsingItem.OnBegin)
        {
            SoundManager.Instance.SuckerSFX.loop = true;
            SoundManager.Instance.SuckerSFX.Play();
            triggerArea.gameObject.SetActive(true);
        }
        else if (isStartingToUse == UsingItem.InProgress)
        {
            if (currentEnemy != null)
            {
                currentEnemy.StartSucking(this);
            }
        }
        else if (isStartingToUse == UsingItem.OnEnd)
        {
            SoundManager.Instance.SuckerSFX.Stop();
            triggerArea.gameObject.SetActive(false);
        }
     
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<EnemyBehaviour>() != null)
        {
             Debug.Log("Entered " + col.name);

            currentEnemy = col.GetComponent<EnemyBehaviour>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.GetComponent<EnemyBehaviour>() != null)
        {
            currentEnemy = null;

        }
    }
}
