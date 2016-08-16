using UnityEngine;
using System.Collections;
using GamePlay;
using UnityEngine.UI;

namespace UI 
{
    public class UIGamePlay : UIBase 
    {
	    private Transform textScore;
        private Transform textDebug;

        protected override void OnInit()
        {
            textScore = transform.Find("TextScore");
            textDebug = transform.Find("TextDebug");
        }

        void Update() 
        {
	        textScore.GetComponent<Text>().text = GamePlayManager.Instance.gameScore.ToString();

            GameObject bird = GameObject.FindGameObjectWithTag(GameSetting.Instance.tagBird);
            if (bird) 
            {
                textDebug.GetComponent<Text>().text = string.Format("{0}, {1}, {2}", bird.transform.position.x, bird.transform.position.y, bird.transform.position.z);    
            }
            
	    }

        protected override void OnOpen(object[] args)
        {
           
        }

        protected override void OnClose()
        {
            
        }
    }
}

