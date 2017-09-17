
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace UIFrameWork
{
    public class AContext : BaseContext
    {
        public AContext() : base(UIType.A)
        {

        }
    }
    public class AView :AnimateView
    {
        public override void Init()
        {
            base.Init();
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
        }
        public override void Excute()
        {
            base.Excute();
        }

        //底部三个按钮
        public void HomeMenu()
        {
            UIManager.Instance.StartAndResetUILine(UIManager.UILine.HomeMenu);
            UIManager.Instance.Push(new HomeContext());
        }
        public void MarkMenu()
        {
            UIManager.Instance.StartAndResetUILine(UIManager.UILine.MarkMenu);
            UIManager.Instance.Push(new MarkContext());
        }
        public void PersonMenu()
        {
            UIManager.Instance.StartUILine(UIManager.UILine.PersonMenu);
            UIManager.Instance.Push(new PersonContext());
        }
    }
}
