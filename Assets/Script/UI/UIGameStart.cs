using UnityEngine;
using System.Collections;
using GamePlay;
using UnityEngine.UI;

namespace UI 
{
    public class UIGameStart : UIBase 
    {
        protected override void OnInit()
        {
            AddBtnClick(transform, "BtnPlay", OnBtnPlay);
        }

        protected override void OnOpen(object[] args)
        {
           
        }

        protected override void OnClose()
        {
            
        }
        private void OnBtnPlay() 
        {
            GamePlayManager.Instance.SetGameState(GAME_STATE.GAME_STATE_READY);
        }
    }
}

