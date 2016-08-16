using UnityEngine;
using System.Collections;
using Common;

namespace GamePlay 
{

    public class Land : MonoBehaviour 
    {
        private float bornX = 3.35f;
        private float deathX = -3.1f;
        private Vector3 direction;

        // Use this for initialization
        void Start() 
        {
            direction = new Vector3(-1, 0, 0);
        }

        // Update is called once per frame
        void Update() 
        {
            if (GamePlayManager.Instance.gameState <= GAME_STATE.GAME_STATE_PLAY) 
            {
                this.transform.Translate(direction * Time.deltaTime * GamePlayManager.Instance.speed);

                if (IsDeath()) 
                {
                    ReBorn();
                }
            }
        }

        private bool IsDeath() 
        {
            return this.transform.position.x <= deathX;
        }

        private void ReBorn() 
        {
            this.transform.position = new Vector3(bornX, this.transform.position.y, this.transform.position.z);
        }

        public void OnCollisionEnter2D(Collision2D co) 
        {
            if (GamePlayManager.Instance.gameState == GAME_STATE.GAME_STATE_PLAY) 
            {
                if (co.gameObject.tag == GameSetting.Instance.tagBird)
                {
                    AudioManager.Instance.Play(AudioManager.audioHit);
                    EffectManager.Instance.Create(EffectManager.effectHit, co.transform.position);
                    GamePlayManager.Instance.SetGameState(GAME_STATE.GAME_STATE_OVER);
                }
            }
        }
    }
}
