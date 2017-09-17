using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;

namespace UIFrameWork
{
    public class MarkContext : BaseContext
    {
        public MarkContext() : base(UIType.Mark)
        {
        }
    }


    public class MarkView : BaseView
    {
        public Text InitText;

        //public Image[] ImageAL = new Image[6];
        //public Text[] ImageText = new Text[6];
        //private int i = 0;

        //public Text []NewsFrom = new Text[5];
        //public Text[] News = new Text[5];
        //public Image[] NewsPicture = new Image[5];
        //private int ii = 0;

        public override void Init()
        {
            base.Init();
    }
        public override void OnEnter(BaseContext context)
        {
            base.OnEnter(context);
            UIManager.Instance.isQuit = false;
        }
        public override void OnExit(BaseContext context)
        {
            base.OnExit(context);
        }
        public override void OnPause(BaseContext context)
        {
            base.OnPause(context);
        }
        public override void OnResume(BaseContext context)
        {
            base.OnResume(context);
            UIManager.Instance.isQuit = false;
        }
        public override void Excute()
        {
            base.Excute();
        }

        //进入书签树并清空之前的状态
        public void AccessToMarkMenu()
        {
            UIManager.Instance.StartAndResetUILine(UIManager.UILine.MarkMenu);
            UIManager.Instance.Push(new MarkContext());
        }

    //    //收藏模型
    //    public void AddMark()
    //    {
    //        if (i <= 5)
    //        {
    //            InitText.gameObject.SetActive(false);
    //            ImageAL[i].sprite = Resources.Load("Model/" + VRView.ObjName) as Sprite;
    //            Debug.Log(VRView.ObjName+"1");
    //            ImageText[i].text = VRView.ObjName;
    //            ImageAL[i].gameObject.SetActive(true);
    //            i++;
    //        }
    //        else
    //            return;
    //    }

    //    //收藏资讯1
    //    public void AddMarkOne()
    //    {
    //        if (ii <= 1)
    //        {
    //            NewsFrom[ii] = NewsFrom[2];
    //            News[ii] = News[2];
    //            NewsPicture[ii] = NewsPicture[2];                
    //            NewsFrom[ii].gameObject.SetActive(true);
    //            News[ii].gameObject.SetActive(true);
    //            NewsPicture[ii].gameObject.SetActive(true);

    //            ii++;
    //        }

    //    }

    //    //收藏资讯2
    //    public void AddMarkTwo()
    //    {
    //        if (ii <= 1)
    //        {
    //            InitText.gameObject.SetActive(false);
    //            NewsFrom[ii] = NewsFrom[3];
    //            News[ii] = News[3];
    //            NewsPicture[ii] = NewsPicture[3];
    //            NewsFrom[ii].gameObject.SetActive(true);
    //            News[ii].gameObject.SetActive(true);
    //            NewsPicture[ii].gameObject.SetActive(true);
    //            ii++;
    //        }
    //    }

    //    public void AddMarkThree()
    //    {
    //        if (ii <= 1)
    //        {
    //            InitText.gameObject.SetActive(false);
    //            NewsFrom[ii] = NewsFrom[4];
    //            News[ii] = News[4];
    //            NewsPicture[ii] = NewsPicture[4];
    //            NewsFrom[ii].gameObject.SetActive(true);
    //            News[ii].gameObject.SetActive(true);
    //            NewsPicture[ii].gameObject.SetActive(true);
    //            ii++;
    //        }
    //    }
    }
}
