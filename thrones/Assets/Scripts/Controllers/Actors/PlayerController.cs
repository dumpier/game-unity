using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Thrones.Controllers.Actors.Battle
{
    public class PlayerController : MonoBehaviour
    {
        // 速度
        public float speed = 3.0f;


        // 移動する方向とベクトル（動く力、速度）の変数（最初は初期化しておく）
        private Vector3 moveDirection = Vector3.zero;

        // 重力の強さ
        public float gravity = 20.0F;
        // ジャンプのスピード
        public float jumpPower = 6.0F;  

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            moveDirection.y = 0f;  // Y方向への速度をゼロにする
            // moveDirection = 1F * speed;  // 移動スピードを向いている方向に与える

            if (Input.GetKey(KeyCode.Space))
            {
                // スペースを押した場合
                transform.position += transform.up * jumpPower * Time.deltaTime;
            }

            if (Input.GetKey("up"))
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey("down"))
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey("right"))
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
            if (Input.GetKey("left"))
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
        }
    }
}