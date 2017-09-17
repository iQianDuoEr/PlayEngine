using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Assets;

namespace UIFrameWork
{
    public class SignContext : BaseContext
    {
        public SignContext() : base(UIType.Sign)
        {
        }
    }


    public class SignView : EnableView
    {
        public InputField Email;
        public InputField Telphone;
        public InputField Name;
        public InputField Password;
        public GameObject DebugText;
        public Text InfoText;
        //public Image[] PsdImge;
        //public Sprite PsdCur;

        private string email;
        private string telphone;
        private string name;
        private string password;

        private string patternTel;
        private string patternEmail;
        //private string patternSimplePassword;
        //private string patternMidPassword;
        //private string patternComplexPassword;


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

        //进入注册模块
        public void SignCallBack()
        {
            if (!GameManager.Instance.CanOperate())
                return;
            UIManager.Instance.Push(new SignContext());
            UIManager.Instance.isQuit = true;
        }

        //点击注册按钮
        public void SignIn()
        {
            //正则表达式判断输入的格式是否正确
            email = Email.text;
            telphone = Telphone.text;
            name = Name.text;
            password = Password.text;
            
            patternTel = "^((13[0-9])|(14[5|7])|(15([0-3]|[5-9]))|(18[0,5-9]))\\d{8}$";
            patternEmail = "^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$";

            //正则表达式判断密码的复杂程度
        //    patternSimplePassword = @"^([a-zA-Z]|[\d{8,15}]|[!@#$%^&*.]){8,15}$";
        //    patternMidPassword = @"^(?![a-zA-Z]{8,15}$)(?![\d{8,15}])(?![!@#$%^&*.]{8,15}$)([a-zA-Z\d]|[a-zA-Z!@#$%^&*.]|[\d!@#$%^&*.]){8,15}$";
        //    patternComplexPassword = @"^(?![a-zA-Z]{8,15}$)(?![\d{8,15}])(?![!@#$%^&*.]{8,15}$)(?![a-zA-Z\d]{8,15}$)(?![a-zA-Z!@#$%^&*.]{8,15})(?![\d!@#$%^&*.]{8,15}$)
        //([a-zA-Z\d!@#$%^&*.]{8,15}&)";

            Regex rTel = new Regex(patternTel);
            Regex rEmail = new Regex(patternEmail);
            //Regex rSpassword = new Regex(patternSimplePassword);
            //Regex rMpassword = new Regex(patternMidPassword);
            //Regex rCpassword = new Regex(patternComplexPassword);

            if (!rTel.IsMatch(telphone) || !rEmail.IsMatch(email))
            {
                DebugText.SetActive(true);
                Debug.Log("123");
                return;
            }

            //显示密码的复杂程度
            //if (rSpassword.IsMatch(password))
            //{ PsdImge[1].sprite =PsdCur; }
            //else if (rMpassword.IsMatch(password))
            //{ PsdImge[2].sprite =PsdCur; }
            //else if (rCpassword.IsMatch(password))
            //{ PsdImge[3].sprite =PsdCur; }

            string[] col = { "Name", "Password", "Telphone", "Email" };
            string[] values = { name, password, telphone, email };
            Debug.Log("456");
            SqlAccess sql = new SqlAccess();
            sql.InsertInto("Players", col, values);

            //进入个人树并清空之前的状态
            UIManager.Instance.StartAndResetUILine(UIManager.UILine.PersonMenu);
            UIManager.Instance.Push(new PersonContext());
            InfoText.GetComponent<Text>().text = name;
        }
    }
}
