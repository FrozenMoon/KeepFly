using UnityEngine;
using System.Collections;
using GamePlay;
using UnityEngine.UI;

namespace UI 
{
    public class UIGamePlay : UIBase 
    {
	    private Transform textScore;

        protected override void OnInit()
        {
            textScore = transform.FindChild("TextScore");
        }

        void Update() 
        {
	        textScore.GetComponent<Text>().text = GamePlayManager.Instance.gameScore.ToString();
	    }

        protected override void OnOpen(object[] args)
        {
           
        }

        protected override void OnClose()
        {
            
        }
    }
}

