using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NewPlayerController : /*MonoBehaviour*/MonoBehaviourPunCallbacks, IPunObservable
{
    GameObject Maincamera;
    Vector3 Camerapos, GatePos, Savemuki;
    //Transform Savemuki,Pmuki;
    public int GateCount, GoalCount;
    // Start is called before the first frame update
    void Start()
    {
        //if (photonView.IsMine)
        //{
            Vector3 plpos = transform.position;
        Maincamera = GameObject.Find("Main Camera");
        Maincamera.transform.parent = transform;
        Camerapos = new Vector3(0, 2.95f, -5.14f);
        Camerapos = new Vector3(plpos.x, plpos.y + 2.5f, plpos.z + -6f);
        Maincamera.transform.position = Camerapos;//Main CameraをAppleに映るように配置

        Savemuki = transform.eulerAngles;
        Vector3 pPos = transform.position;
        GatePos = new Vector3(pPos.x, pPos.y + 1, pPos.z);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //if (photonView.IsMine)
        //{
            if (transform.position.y <= 0f)//落ちた時の処理
            {
                Debug.Log("落ちた");
                transform.eulerAngles=Savemuki;//向きをゲートが向いてる方に
                transform.position = GatePos;//通ったゲート位置に戻る
            }
        //}

        //他プレイヤーにデータを送信
        //if (photonView.IsMine)
        //{

        //}
        //else
        //{
        //    //移動速度を指定する
        //    GetComponent<Rigidbody>().velocity = velo;
        //    //回転速度を指定する
        //    GetComponent<Rigidbody>().angularVelocity = angul;
        //}
    }

    // データの送受信
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
    void OnTriggerEnter(Collider other)
    {
        //if (photonView.IsMine)
        //{
            if (other.gameObject.tag == "Goal" && GateCount >= 6)
            {
                int G;
                //Debug.Log("ゴール");
                GoalCount++;
                if (GoalCount >= 3)
                {
                    Debug.Log("ゴール");
                    //goalText.gameObject.SetActive(true);
                }
                else
                {
                    G = GoalCount + 1;
                    //T = GameObject.Find("LapText").GetComponent<Text>();
                    //T.text = " Lap " + G + "/3";
                    GateCount = 0;
                }
            }
            if (other.gameObject.tag == "Gate")
            {
                if (GoalCount < 3)
                {
                    Vector3 Gpos = other.transform.position;
                    GatePos = new Vector3(Gpos.x, Gpos.y + 1, Gpos.z);
                    Savemuki = other.transform.eulerAngles;
                    //Debug.Log(other.transform.eulerAngles); ;
                    GateCount++;
                    Debug.Log("gatepoint " + GateCount);
                }
            }
        //}else
        //{
        //    if (other.gameObject.tag == "Goal" && GateCount >= 6)
        //    {
        //        int G;
        //        //Debug.Log("ゴール");
        //        GoalCount++;
        //        if (GoalCount >= 3)
        //        {
        //            Debug.Log("ゴール");
        //            //goalText.gameObject.SetActive(true);
        //        }
        //        else
        //        {
        //            G = GoalCount + 1;
        //            //T = GameObject.Find("LapText").GetComponent<Text>();
        //            //T.text = " Lap " + G + "/3";
        //            GateCount = 0;
        //        }
        //    }
        //    if (other.gameObject.tag == "Gate")
        //    {
        //        if (GoalCount < 3)
        //        {
        //            Vector3 Gpos = other.transform.position;
        //            GatePos = new Vector3(Gpos.x, Gpos.y + 1, Gpos.z);
        //            GateCount++;
        //            Debug.Log("gatepoint " + GateCount);
        //        }
        //    }

        //}
        //Debug.Log("当たった");
    }
}
