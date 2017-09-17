using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIFrameWork
{
    public class UIType
    {
        public string Path { get; private set; }
        public string Name { get; private set; }

        public UIType(string path)
        {
            Path = path;
            Name = path.Substring(path.LastIndexOf("/")+1);
        }

        public override string ToString()
        {
            return string.Format("path:{0} name{1}",Path,Name);
        }

        public static readonly UIType Tour = new UIType("View/TourView");
        public static readonly UIType A = new UIType("View/AView");
        public static readonly UIType Quit = new UIType("View/QuitView");

        public static readonly UIType Home = new UIType("View/HomeView");
        public static readonly UIType Mark = new UIType("View/MarkView");
        public static readonly UIType Person = new UIType("View/PersonView");

        public static readonly UIType Search = new UIType("View/SearchView");
        public static readonly UIType Book = new UIType("View/BookView");

        public static readonly UIType Button = new UIType("View/ButtonView");
        
        public static readonly UIType Find = new UIType("View/FindView");
        public static readonly UIType Model = new UIType("View/ModelView");
        public static readonly UIType VR = new UIType("View/VRView");
        public static readonly UIType Sign = new UIType("View/SignView");
        public static readonly UIType Login = new UIType("View/LoginView");
        public static readonly UIType Chat = new UIType("View/ChatView");
        public static readonly UIType Work = new UIType("View/WorkView");
        public static readonly UIType NewOne = new UIType("View/NewViewOne");
        public static readonly UIType NewTwo = new UIType("View/NewViewTwo");
        public static readonly UIType NewThree = new UIType("View/NewViewThree");
    }
}