using Assets;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UIFrameWork
{
    public class LoginContext : BaseContext
    {
        public LoginContext() : base(UIType.Login)
        {
        }
    }


    public class LoginView : EnableView
    {
        public InputField Name;
        public InputField Password;
        public GameObject DebugText;
        public Text InfoText;

        private string name;
        private string password;

        private string patternTel;
        private string patternEmail;

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

        //进入登录模块
        public void LoginCallBack()
        {
            if (!GameManager.Instance.CanOperate())
                return;
            UIManager.Instance.Push(new LoginContext());
            UIManager.Instance.isQuit = true;
        }

        //点击登录按钮
        public void LoginIn()
        {
            name = Name.text;
            password = Password.text;

            string patternTel = "^((13[0-9])|(14[5|7])|(15([0-3]|[5-9]))|(18[0,5-9]))\\d{8}$";
            string patternEmail = "^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$";
            Regex rTel = new Regex(patternTel);
            Regex rEmail = new Regex(patternEmail);

            if (!rTel.IsMatch(name) && !rEmail.IsMatch(name))
            {
                DebugText.SetActive(true);
                return;
            }

            string[] items = { "Password" };
            string[] whereColName = { "Name" };
            string[] operation = { "=" };
            string[] value = { name };

            SqlAccess sql = new SqlAccess();
            if ((sql.Select("Players", items, whereColName, operation, value)) != null)
            {
                UIManager.Instance.StartAndResetUILine(UIManager.UILine.PersonMenu);
                UIManager.Instance.Push(new PersonContext());
                InfoText.text = name;
                Debug.Log(name);
            }
        }
    }
}
