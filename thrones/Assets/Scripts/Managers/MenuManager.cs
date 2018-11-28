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
        };



        private void Start()
        {
            Button button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(OnClick);

        }


        public void OnClick()
        {
            if(this.page == "menu")
            {
                GameObject.Find("MenuPage").GetComponent<PageManager>().Toggle();

                return;
            }

            Debug.Log($" - Click {gameObject.name} button .");

            // 現在表示中のを隠す
            PageManager.getCurrentPage().GetComponent<PageManager>().Hide();

            this.ShowPage();
        }


        // ページの表示
        public void ShowPage()
        {
            this.GetPageGameObject().GetComponent<PageManager>().Show();
        }


        private GameObject GetPageGameObject()
        {
            Debug.Log($"page : {this.page}");

            string page_name = "HomePage";

            foreach (KeyValuePair<string, string> pair in MenuManager.PageList)
            {
                if (pair.Key == this.page)
                {
                    page_name = pair.Value;
                    break;
                }
            }

            Debug.Log($"panel name: {page_name}");

            return GameObject.Find(page_name);
        }
    }
}