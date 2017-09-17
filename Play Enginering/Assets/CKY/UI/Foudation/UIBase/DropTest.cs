using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropTest : MonoBehaviour {

    public string[] showText;
    public Sprite[] sprite;
    Dropdown dropDownItem;
    List<string> temoNames;
    List<Sprite> sprite_list;
    public Image other_img;//任意的img，用作被赋值替换
    void Start()
    {
        dropDownItem = this.GetComponent<Dropdown>();
        temoNames = new List<string>();
        sprite_list = new List<Sprite>();

        AddNames();
        //UpdateDropDownItem(temoNames);

    }


    void UpdateDropDownItem(List<string> showNames)
    {
        dropDownItem.options.Clear();
        Dropdown.OptionData temoData;
        for (int i = 0; i < showNames.Count; i++)
        {
            //给每一个option选项赋值
            temoData = new Dropdown.OptionData();
            temoData.text = showNames[i];
            temoData.image = sprite_list[i];
            dropDownItem.options.Add(temoData);
        }
        //初始选项的显示
        dropDownItem.captionText.text = showNames[0];
        other_img.sprite = sprite_list[0];
        dropDownItem.captionImage = other_img;

    }
    //void Update()
    //{
    //    if (dropDownItem.value == 0)
    //    {
    //        Debug.Log("11111111");
    //    }
    //    if (dropDownItem.value == 1)
    //    {
    //        Debug.Log("22222222");
    //    }
    //    if (dropDownItem.value == 2)
    //    {
    //        Debug.Log("33333333");
    //    }


    //    this.GetComponent<Image>().sprite = other_img.sprite;
    //}
    void AddNames()
    {
        for (int i = 0; i < showText.Length; i++)
        {
            temoNames.Add(showText[i]);
        }
        for (int i = 0; i < sprite.Length; i++)
        {
            sprite_list.Add(sprite[i]);
        }
    }

}
