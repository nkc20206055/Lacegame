using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerC2 : MonoBehaviour
{
    //カウントダウン
    //public float countdown = 3.0f;

    //Rigidbody rigid;





    // Start is called before the first frame update

    public float MaxSpeed;//最高速を決める変数(km/h)
    public float AccelPerSecond;//加速力を決める変数(km/h*s)
    public float TurnPerSecond;//旋回力を決める変数(deg/s)
    private float Speed;
    private Rigidbody rb;

    void Start()
    {
        Speed = 1;
        rb = GetComponent<Rigidbody>();


    }

    void FixedUpdate()
    {
        //速さの計算
        if (Input.GetButton("Jump"))
        {
            Speed += AccelPerSecond * Time.deltaTime;
            if (Speed > MaxSpeed) Speed = MaxSpeed;
            Debug.Log("J");

        }
        else
        {
            Speed -= AccelPerSecond * Time.deltaTime / 2;
            if (Speed < 0) Speed = 1;
            Debug.Log("a");

        }

        rb.velocity = transform.forward * Speed;


        //旋回する角度の計算
        float Handle = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, TurnPerSecond * Handle * Time.deltaTime);



        rb.velocity = transform.forward * Speed;

        
    }



    //rigid = GameObject.Find("player").GetComponent<Rigidbody>();




    // Update is called once per frame
    void Update()
    {






    }
}