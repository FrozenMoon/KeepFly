using UnityEngine;
using System.Collections;
using Common;

namespace GamePlay 
{

    public class PipeChild : MonoBehaviour 
    {
        public bool overChangeTrigger = false;
        public void OnCollisionEnter2D(Collision2D co) 
        {
            if (GamePlayManager.Instance.gameState == GAME_STATE.GAME_STATE_PLAY) 
            {
                if (co.gameObject.tag == GameSetting.Instance.tagBird)
                {
                    AudioManager.Instance.Play(AudioManager.audioHit);
                    AudioManager.Instance.Play(AudioManager.audioDie);
                    EffectManager.Instance.Create(EffectManager.effectHit, (Vector3)co.contacts[0].point);
                    transform.parent.FindChild("pipe_down").GetComponent<BoxCollider2D>().isTrigger = true;
                    GamePlayManager.Instance.SetGameState(GAME_STATE.GAME_STATE_OVER);
                }
            }
        }
    }
}