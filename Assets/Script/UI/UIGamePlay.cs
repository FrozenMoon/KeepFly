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

        protected override void OnInit()
        {
            textScore = transform.Find("TextScore");
            textDebug = transform.Find("TextDebug");

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
    }
}

