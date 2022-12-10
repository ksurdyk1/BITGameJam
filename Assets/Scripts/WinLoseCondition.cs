using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseCondition : MonoBehaviour
{
    [SerializeField] private int hp = 2;
    private EnemyLimitBehaviour enemyCounter;

    [SerializeField] private SpriteRenderer fade;

    public void LosePoint()
    {
        hp--;
        Debug.Log("Missed");

        if (hp < 1)
        {
            enemyCounter = null;
            Debug.Log("GameOver");
            
            
            fade.gameObject.SetActive(true);
            fade.DOFade(1, 3f).OnComplete(() =>
            {
                SceneManager.LoadScene(2);
            });
        }
    }
    
    
}
