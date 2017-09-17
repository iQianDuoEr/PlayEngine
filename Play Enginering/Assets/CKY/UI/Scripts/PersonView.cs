using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace UIFrameWork
{
    public class PersonContext : BaseContext
    {
        public PersonContext() : base(UIType.Person)
        {
        }
    }


    public class PersonView : BaseView
    {

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

        //进入个人树并清空之前的状态
        public void AccessToPersonMenu()
        {
            UIManager.Instance.StartAndResetUILine(UIManager.UILine.PersonMenu);
            UIManager.Instance.Push(new PersonContext());
        }
    }
}
