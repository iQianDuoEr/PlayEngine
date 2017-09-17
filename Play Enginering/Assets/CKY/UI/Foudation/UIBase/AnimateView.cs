using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Base Animate View
 * 
 * 
 */

namespace UIFrameWork
{
    public abstract class AnimateView : BaseView
    {
        [SerializeField]
        protected Animator _animator;

        public override void OnEnter(BaseContext context)
        {
            base.OnEnter(context);
            _animator.SetTrigger("OnEnter");
        }

        public override void OnExit(BaseContext context)
        {
            base.OnExit(context);
            _animator.SetTrigger("OnExit");
        }

        public override void OnPause(BaseContext context)
        {
            base.OnPause(context);
            _animator.SetTrigger("OnPause");
        }

        public override void OnResume(BaseContext context)
        {
            base.OnResume(context);
            _animator.SetTrigger("OnResume");
        }
    }
}