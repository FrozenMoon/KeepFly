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
            int nScore = GamePlayManager.Instance.gameScore;
            textScore.gameObject.GetComponent<Text>().text = nScore.ToString();

            // show bese score
            textBestScore.gameObject.GetComponent<Text>().text = nScore.ToString();

            // is best ?
            imgNew.gameObject.SetActive(false);

            Sprite medal = new Sprite();
            if (nScore < 10) 
            {
                medal = Resources.Load("Sprites/UI/medals_0", typeof(Sprite)) as Sprite;
            }
            else if (nScore < 20) 
            {
                medal = Resources.Load("Sprites/UI/medals_1", typeof(Sprite)) as Sprite;
            }
            else if (nScore < 50) 
            {
                medal = Resources.Load("Sprites/UI/medals_2", typeof(Sprite)) as Sprite;
            }
            else if (nScore < 100) 
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

