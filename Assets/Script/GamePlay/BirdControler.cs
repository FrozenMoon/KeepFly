using UnityEngine;
using System.Collections;

namespace GamePlay {
    public class BirdControler : MonoBehaviour 
    {
        public float jumpY = 3.5f;
        public float jumpX = 0;

        private float rangY = 0.2f;
        private Vector3 direction;
        private Vector3 orgPosition;

        // Use this for initialization
        void Start() 
        {
            direction = new Vector3(0, 1, 0);
            orgPosition = transform.position;
        }

        // Update is called once per frame
        void Update() 
        {
            GAME_STATE gs = GamePlayManager.Instance.gameState;
            if (gs == GAME_STATE.GAME_STATE_READY)
            {
                MoveY();
            }
            else if (gs == GAME_STATE.GAME_STATE_PLAY) 
            {
                if (Input.GetButtonDown(GameSetting.Instance.inputJump)) 
                {
                   Jump();
                }
            }
            else if (gs == GAME_STATE.GAME_STATE_OVER)
            {
                // 速度为0后进入结算得分状态
                Vector3 vel = GetComponent<Rigidbody2D>().velocity;
                if (vel.x == 0 && vel.y == 0) 
                {
                    GamePlayManager.Instance.SetGameState(GAME_STATE.GAME_STATE_SCORE);
                }
            }
        }

        public void OnGamePlay() 
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Animator>().Play("Jump");
            Jump();
        }

        public void OnGameOver() 
        {
            GetComponent<Animator>().Stop();
        }

        public void Jump() 
        {
            // 重新播放跳跃动画
            GetComponent<Animator>().SetTrigger("Jump");

            Vector3 vel = GetComponent<Rigidbody2D>().velocity;
             // Y轴的速度
            GetComponent<Rigidbody2D>().velocity = new Vector3(vel.x, jumpY, vel.z);
        }

        private void MoveY() 
        {
            transform.Translate(direction * Time.deltaTime);
            if (transform.position.y >= orgPosition.y + rangY) 
            {
                direction.y = -1;
            }
            else if (transform.position.y <= orgPosition.y - rangY) 
            {
                direction.y = 1;
            }
        }
    }
}
