using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerC : MonoBehaviour
{
    //カウントダウン
    public float countdown = 6.0f;

    //Rigidbody rigid;

   



    // Start is called before the first frame update
    void Start()
    {
        //rigid = GameObject.Find("player").GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        //速度に関係
        {
            //時間をカウントダウンする
            countdown -= Time.deltaTime;

            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("q");
                transform.Translate(1f, 0f, 0f);
                if (countdown >= 4)
                {
                    Debug.Log("qq");
                    transform.Translate(1.5f, 0f, 0f);
                    if (countdown <= 2)
                    {
                        Debug.Log("qqq");
                        transform.Translate(2f, 0f, 0f);
                        if (countdown <= 0)
                        {
                            Debug.Log("qqqq");
                            transform.Translate(2.5f, 0f, 0f);

                        }
                    }
                }
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-1f, 0f, 0f);

            }
        }

        {
            //speed = rigid.velocity.magnitude;


        }





    }
}