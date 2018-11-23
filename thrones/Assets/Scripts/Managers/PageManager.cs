﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thrones.Managers
{
    public class PageManager : MonoBehaviour
    {
        // 現在表示中のページ
        private static GameObject currentPage;

        // 該当ページの初期ポジション
        private Vector3 originalVector;

        // 現在表示中のページを取得
        public static GameObject getCurrentPage()
        {
            if(PageManager.currentPage)
            {
                return PageManager.currentPage;
            }

            return GameObject.Find("HomePage");
        }

        void Start()
        {
            this.originalVector = gameObject.transform.localPosition;

            Debug.Log($"Start {gameObject.name} x:{this.originalVector.x}, y:{this.originalVector.y}");
        }


        public void Show()
        {
            Debug.Log($"Show {gameObject.name}");
            gameObject.transform.localPosition = new Vector3(0, 0, 0);

            PageManager.currentPage = gameObject;
        }


        public void Hide()
        {
            Debug.Log($"Hide {gameObject.name}");
            gameObject.transform.localPosition = this.originalVector;
        }

    }

}