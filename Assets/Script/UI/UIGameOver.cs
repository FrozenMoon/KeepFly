using UnityEngine;
using System.Collections;
using GamePlay;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UI 
{
    public class UIGameOver : UIBase 
    {
        private Transform textScore;
        private Transform textBestScore;
        private Transform imgMedal;
        private Transform imgNew;

	    protected override void OnInit()
        {
            AddBtnClick(transform, "BtnPlay", OnBtnPlay);
            textScore = transform.Find("ImgScore/TextScore");
            textBestScore = transform.Find("ImgScore/TextBest");
            imgMedal = transform.Find("ImgScore/ImgMedal");
            imgNew = transform.Find("ImgScore/ImgNew");
        }

        protected override void OnOpen(object[] args)
        {
            // show text score
            int score = GamePlayManager.Instance.gameScore;
            textScore.gameObject.GetComponent<Text>().text = score.ToString();

            // show bese score
            int bestScore = GamePlayManager.Instance.gameBestScore;
            textBestScore.gameObject.GetComponent<Text>().text = bestScore.ToString();

            // is best ?
            if (score > bestScore)
            {
                imgNew.gameObject.SetActive(true);
            }
            else
            {
                imgNew.gameObject.SetActive(false);
            }
            

            Sprite medal = new Sprite();
            if (score < 10) 
            {
                medal = Resources.Load("Sprites/UI/medals_0", typeof(Sprite)) as Sprite;
            }
            else if (score < 20) 
            {
                medal = Resources.Load("Sprites/UI/medals_1", typeof(Sprite)) as Sprite;
            }
            else if (score < 50) 
            {
                medal = Resources.Load("Sprites/UI/medals_2", typeof(Sprite)) as Sprite;
            }
            else if (score < 100) 
            {
                medal = Resources.Load<Sprite>("Sprites/UI/medals_3");
            }

            imgMedal.gameObject.GetComponent<Image>().sprite = medal;
        }

        protected override void OnClose()
        {
            
        }

        private void OnBtnPlay() 
        {
            SceneManager.LoadScene("Main");
        }
    }
}

