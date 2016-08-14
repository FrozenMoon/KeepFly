using UnityEngine;
using System.Collections;
using GamePlay;
using UnityEngine.UI;

namespace UI 
{
    public class UIGamePlay : UIBase 
    {
        private Text textScore;

	    void Update() 
        {
	        textScore.text = GamePlayManager.Instance.gameScore.ToString();
	    }

        protected override void OnInit()
        {
            textScore = transform.FindChild("TextScore").gameObject.GetComponent<Text>();
        }

        protected override void OnOpen(object[] args)
        {
           
        }

        protected override void OnClose()
        {
            
        }

    }
}

