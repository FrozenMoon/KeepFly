using UnityEngine;
using System.Collections;
using Common;

namespace GamePlay {

    public class Pipe : MonoBehaviour 
    {
        private float bornX = 2f;
        private float deathX = -2f;
        private Vector3 direction;

        // Use this for initialization
        void Start() 
        {
            direction = new Vector3(-1, 0, 0);
            RandomMoveY();
        }

        // Update is called once per frame
        void Update() 
        {
            if (GamePlayManager.Instance.gameState == GAME_STATE.GAME_STATE_PLAY)
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
            RandomMoveY();
        }

        public void OnTriggerExit2D(Collider2D co) {
            if (GamePlayManager.Instance.gameState == GAME_STATE.GAME_STATE_PLAY) 
            {
                AudioManager.Instance.Play(AudioManager.audioScore);
                GamePlayManager.Instance.gameScore += 1;
            }
        }

        private void RandomMoveY() 
        {
            float randomY = Random.Range(-0.7f, 1.2f);
            transform.position = new Vector3(transform.position.x, randomY, transform.position.z);
        }
    }
}