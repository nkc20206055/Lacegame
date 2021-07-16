using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class playerC2 :/* MonoBehaviour*/MonoBehaviourPunCallbacks,IPunObservable
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
        if (photonView.IsMine)
        {
            Speed = 1;
            rb = GetComponent<Rigidbody>();
        }


    }

    void FixedUpdate()
    {
        if (photonView.IsMine)/*※送信受信のため追加*/
        {
            //速さの計算
            if (Input.GetButton("Jump"))
        {
            Speed += AccelPerSecond * Time.deltaTime;
            if (Speed > MaxSpeed) Speed = MaxSpeed;
            //Debug.Log("J");

            }
            else
            {
            Speed -= AccelPerSecond * Time.deltaTime / 2;
            if (Speed < 0) Speed = 1;
            //Debug.Log("a");

            }

            rb.velocity = transform.forward * Speed;


            //旋回する角度の計算
            float Handle = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, TurnPerSecond * Handle * Time.deltaTime);



             rb.velocity = transform.forward * Speed;
        }
        else
        {
            //移動速度を指定する
            GetComponent<Rigidbody>().velocity = velo;
            //回転速度を指定する
            GetComponent<Rigidbody>().angularVelocity = angul;
        }

    }

    // データの送受信※送信受信のため追加
    Vector3 velo;    //受信した移動速度
    Vector3 angul;   //受信した回転速度
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) //自分のオブジェクトの時
        {
            stream.SendNext(transform.position);                        //表示座標送信
            stream.SendNext(transform.localEulerAngles);                //回転角度送信
            stream.SendNext(GetComponent<Rigidbody>().velocity);        //移動速度送信
            stream.SendNext(GetComponent<Rigidbody>().angularVelocity); //回転速度送信
        }
        else   //他人のオブジェクトの時
        {
            transform.position = (Vector3)stream.ReceiveNext();         //表示座標受信
            transform.localEulerAngles = (Vector3)stream.ReceiveNext(); //回転角度受信
            velo = (Vector3)stream.ReceiveNext();                       //移動速度受信
            angul = (Vector3)stream.ReceiveNext();                      //回転速度受信
        }

    }


    //rigid = GameObject.Find("player").GetComponent<Rigidbody>();




    // Update is called once per frame
    void Update()
    {






    }
}