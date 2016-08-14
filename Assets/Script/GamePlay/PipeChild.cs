using UnityEngine;
using System.Collections;

namespace GamePlay {

    public class PipeChild : MonoBehaviour 
    {
        // Use this for initialization
        void Start() 
        {
        }

        // Update is called once per frame
        void Update() 
        {
        }

        public void OnCollisionEnter2D(Collision2D co) {
            if (GamePlayManager.Instance.gameState == GAME_STATE.GAME_STATE_PLAY) 
            {
                if (co.gameObject.tag == TagManager.Instance.Bird)
                {
                    GamePlayManager.Instance.SetGameState(GAME_STATE.GAME_STATE_OVER);
                }
            }
        }
    }
}