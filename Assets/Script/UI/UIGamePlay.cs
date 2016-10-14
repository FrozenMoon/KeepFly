using UnityEngine;
using System.Collections;
using GamePlay;
using UnityEngine.UI;
using Common;
using UnityEngine.Events;

namespace UI 
{
    public class UIGamePlay : UIBase 
    {
	    private Transform textScore;
        private Transform textDebug;
        private Transform btnPlay;

        protected override void OnInit()
        {
            textScore = transform.Find("TextScore");
            textDebug = transform.Find("TextDebug");
            btnPlay   = transform.Find("BtnPlay");

            AddBtnClick(transform, "BtnPause", OnBtnPause);
            AddBtnClick(transform, "BtnPlay", OnBtnPlay);

            EventManger.Instance.AddListener<GameEvent>(UpdateScore);
        }

        protected override void OnOpen(object[] args)
        {
            
        }

        protected override void OnClose()
        {
            EventManger.Instance.RemoveListener<GameEvent>(UpdateScore);
        }

        void UpdateScore(GameEvent e)
        {
            textScore.GetComponent<Text>().text = e.nParam.ToString();
        }
        private void OnBtnPause() 
        {
            GAME_STATE gs = GamePlayManager.Instance.gameState;
            if (gs == GAME_STATE.GAME_STATE_PLAY) 
            {
                GamePlayManager.Instance.SetGameState(GAME_STATE.GAME_STATE_RESUME);
                btnPlay.gameObject.SetActive(true);
            }
        }

        private void OnBtnPlay() 
        {
            GAME_STATE gs = GamePlayManager.Instance.gameState;
            if (gs == GAME_STATE.GAME_STATE_RESUME) 
            {
                GamePlayManager.Instance.SetGameState(GAME_STATE.GAME_STATE_GOON);
                btnPlay.gameObject.SetActive(false);
            }
        }
    }
}

