using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Thrones.Managers
{
    public class MenuManager : MonoBehaviour
    {
        public string page = "";

        // ページ一覧の定義
        public static readonly Dictionary<string, string> PageList = new Dictionary<string, string>()
        {
            { "home",   "HomePage" },
            { "menu",   "MenuPage" },
            { "quest",  "QuestPage" },
            { "deck",   "DeckPage" },
            { "gacha",      "GachaPage" },
            { "mission",    "MissionPage" },
            { "character",  "CharacterPage" },
        };


        private void Start()
        {
            Button button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }


        public void OnClick()
        {
            if(this.page.Equals("menu"))
            {
                this.ShowMenuPage();
                return;
            }

            // 現在表示中のを隠す
            PageManager.getCurrentPage().GetComponent<PageManager>().Hide();

            // 指定ページの表示
            this.GetPageGameObject().GetComponent<PageManager>().Show();
        }


        // メニュー一覧の表示
        private void ShowMenuPage()
        {
            // 現在表示中のページがMenu一覧でない場合隠す
            if (! PageManager.getCurrentPage().name.Equals("MenuPage"))
            {
                PageManager.getCurrentPage().GetComponent<PageManager>().Hide();
            }

            GameObject.Find("MenuPage").GetComponent<PageManager>().Toggle();
        }


        // ページオブジェクトの取得
        private GameObject GetPageGameObject()
        {
            string page_name = "HomePage";

            MenuManager.PageList.TryGetValue(this.page, out page_name);

            return GameObject.Find(page_name);
        }
    }
}