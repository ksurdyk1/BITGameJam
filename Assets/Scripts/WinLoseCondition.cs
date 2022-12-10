using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseCondition : MonoBehaviour
{
    [SerializeField] private int hp = 2;
    private EnemyLimitBehaviour enemyCounter;

    [SerializeField] private Fader fade;

    public void LosePoint()
    {
        hp--;

        var x = Vector3.one* 0.1f;
        Camera.current.DOShakePosition(1f, x, 10, 90f);

        if (hp == 20)
        {
            Debug.Log("Zaczyna sie muza");
            SoundManager.Instance.PlayExtraMusic();
        }
        
        if (hp < 1)
        {
            enemyCounter = null;
            Debug.Log("GameOver");
            SoundManager.Instance.deathSFX.Play();
            fade.MakeFadeOut(3);
           
        }
    }
    
    
}
