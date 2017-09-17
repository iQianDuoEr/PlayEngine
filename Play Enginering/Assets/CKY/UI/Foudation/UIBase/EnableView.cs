using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UIFrameWork
{
    public abstract class EnableView : BaseView
    {
        private CanvasGroup _canvasGroup;
        public override void Init()
        {
            base.Init();
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        public override void OnEnter(BaseContext context)
        {
            base.OnEnter(context);
            gameObject.SetActive(true);
        }
        public override void OnExit(BaseContext context)
        {
            base.OnExit(context);
            gameObject.SetActive(false);
        }
        public override void OnPause(BaseContext context)
        {
            base.OnPause(context);
            _canvasGroup.blocksRaycasts = false;
        }
        public override void OnResume(BaseContext context)
        {
            base.OnResume(context);
            _canvasGroup.blocksRaycasts = true;
        }
    }
}