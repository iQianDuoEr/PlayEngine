/*
 * 
 * UI根节点
 * 
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace UIFrameWork
{
    public class UIRoot : MonoBehaviour
    {

        private GameObject View;

        public void Start()
        {
            UIManager.Create();
            if (!PlayerPrefs.HasKey("宝宝我来过啦"))
            {
                View = UIManager.Instance.GetSingleUI(UIType.Tour);
                PlayerPrefs.SetInt("宝宝我来过啦", 10);
            }
            else
            {
                UIManager.Instance.StartAndResetUILine(UIManager.UILine.HomeMenu);
                UIManager.Instance.Push(new HomeContext());
                UIManager.Instance.GetSingleUI(UIType.A);
            }
        }

        public void Update()
        {
            Cursor.visible = false;
            UIManager.Instance.Update();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!UIManager.Instance.isQuit)
                    UIManager.Instance.Push(new QuitContext());
                else
                    UIManager.Instance.Pop();
            }
        }
    }
}
