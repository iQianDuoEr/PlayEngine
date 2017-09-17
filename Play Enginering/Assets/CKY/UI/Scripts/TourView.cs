using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace UIFrameWork
{
    public class TourContext : BaseContext
    {
        public TourContext():base(UIType.Tour)
        {
        }
    }

    public class TourView : EnableView
    {
        public Animator _animator;
        private int _Pageposition = 1;

        public void Update()
        {
            #region AndroidPlayer
            if (Input.touchCount > 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                if (touchDeltaPosition.x > 10)
                {
                    _animator.SetBool("Forward",true);
                    _animator.SetBool("Back",false);
                    _animator.SetFloat("Position", ++_Pageposition);
                }
                if (touchDeltaPosition.x < -10)
                {
                    _animator.SetBool("Forward",false);
                    _animator.SetBool("Back",true);
                    _animator.SetFloat("Position", _Pageposition--);
                }
            }
            #endregion

            #region WindowsPlayer
            if (Input.GetMouseButtonDown(0))
            {
                _animator.SetBool("Forward",true);
                _animator.SetBool("Back",false);
                _animator.SetFloat("Position",++_Pageposition);
            }
            if (Input.GetMouseButtonDown(1))
            {
                _animator.SetBool("Forward",false);
                _animator.SetBool("Back",true);
                _animator.SetFloat("Position",_Pageposition--);
            }
            #endregion
        }

        public override void Init()
        {
            base.Init();
        }
        public override void OnEnter(BaseContext context)
        {
            base.OnEnter(context);
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
        public override void PopCallBack()
        {
            base.PopCallBack();
        }

        //立即体验切入UI界面
        public void AccessToHomeMenu()
        {
            UIManager.Instance.StartAndResetUILine(UIManager.UILine.HomeMenu);
            UIManager.Instance.Push(new HomeContext());
            UIManager.Instance.GetSingleUI(UIType.A);
        }
    }
}