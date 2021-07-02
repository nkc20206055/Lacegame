using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

//using System.Collections.Generic;

public class PlayerController : MonoBehaviourPunCallbacks /*MonoBehaviour*/,IPunObservable
{
    public float Speed = 5;
    public int GateCount, GoalCount;
    public string Ptext;
    public float speed;
    GameObject textM,Maincamera,PlayerUi;
    Transform lapText, goalText;//PlayerUIの子オブジェクト取得
    Text T;
    TextMesh TM;
    Vector3 Plpos,Camerapos,mixpos;
    Rigidbody rigidbody;
    Vector3 GatePos;
    bool IPswitht;
    private Vector3 offset;//中心座標
    void PCamera(float x)
    {
        //カメラ追従
        // まずはカメラ位置をプレイヤーに追従させて...
        Maincamera.transform.position = transform.position + offset;
        // プレイヤーを中心にカメラを回すと、プレイヤーとカメラの相対位置が
        // 変化するはずなので、RotateAroundの後でoffsetを更新する
        if (x >= 1)
        {
            Maincamera.transform.RotateAround(transform.position, Vector3.up, 60.0f*Time.deltaTime);
            // transform.RotateAround(Vector3.zero,Vector3.up,-2.0f);
            offset = Maincamera.transform.position - transform.position;
        }
        if (x <= -1)
        {
            Maincamera.transform.RotateAround(transform.position, Vector3.up, -60.0f * Time.deltaTime);
            // transform.RotateAround(Vector3.zero,Vector3.up,-2.0f);
            offset = Maincamera.transform.position - transform.position;
        }
    }

    void IPp()
    {
        if (photonView.IsMine)
        {
            if (IPswitht == true)
            {
                PhotonView PV = gameObject.GetComponent<PhotonView>();
                if (PV.ViewID == 1001|| PV.ViewID == 1002)
                {
                    Ptext = "Player1";
                    TM.text = Ptext;
                }
                else if (PV.ViewID == 2001)
                {
                    Ptext = "Player2";
                    TM.text = Ptext;
                }
                else if (PV.ViewID == 3001)
                {
                    Ptext = "Player3";
                    TM.text = Ptext;
                }
                else if (PV.ViewID == 4001)
                {
                    Ptext = "Player4";
                    TM.text = Ptext;
                }
                IPswitht = false;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            Vector3 plpos = transform.position;
            Maincamera = GameObject.Find("Main Camera");
            Maincamera.transform.parent = transform;
            Camerapos = new Vector3(0, 2.95f, -5.14f);
            Camerapos = new Vector3(plpos.x, plpos.y + 2.5f, plpos.z + -6f);
            Maincamera.transform.position = Camerapos;//Main CameraをAppleに映るように配置
        }


        //rigidbody = gameObject.GetComponent<Rigidbody>();
        if (photonView.IsMine)
        {
            PlayerUi = GameObject.Find("PlayerText");
            // PlayerUiの子オブジェクトの中からアクティブなオブジェクトを探す
            lapText = PlayerUi.transform.Find("LapText");
            Debug.Log("target2(transform) = " + lapText);
            Debug.Log("target2(gameObject) = " + lapText.gameObject);
            T = lapText.gameObject.GetComponent<Text>();

            // PlayerUiの子オブジェクトの中から非アクティブなオブジェクトを探す
            goalText = PlayerUi.transform.Find("GoalText");
            Debug.Log("target3(transform) = " + goalText);
            Debug.Log("target3(gameObject) = " + goalText.gameObject);

            {
                //Maincamera = GameObject.Find("Main Camera");
                ////offset = transform.position - Maincamera.transform.position;
                ////Camerapos = new Vector3(0,1.95f,-5.14f);
                //Camerapos = new Vector3(0, -1.95f, 5f);
                //Maincamera.transform.position = Camerapos;//Main CameraをAppleに映るように配置
                //offset = transform.position - Maincamera.transform.position;
                //Debug.Log(offset);
                ////Debug.Log(Maincamera);
            }
            textM = transform.GetChild(0).gameObject;//Apple内にある子オブジェクトのtextObを取得する
            TM = textM.GetComponent<TextMesh>();
            //Debug.Log(TM);
            TM.text = Ptext;

            Vector3 pPos = transform.position;
            GatePos = new Vector3(pPos.x, pPos.y + 1, pPos.z);
            IPswitht = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        {
            //自分のオブジェクトだけ移動する
            //if (photonView.IsMine)
            //{
            //    float x = Input.GetAxis("Horizontal");
            //    float y = Input.GetAxis("Vertical");
            //    transform.Translate(new Vector3(x, y, 0) * Time.deltaTime * Speed);
            //}

            //float x = Input.GetAxis("Horizontal");
            //float y = Input.GetAxis("Vertical");
            //PCamera(x);]

            //transform.Rotate(0, x, 0);
            //rigidbody.AddForce(new Vector3(0, 0, y) * 5);

            //transform.Rotate(0, x, 0);
            //rigidbody.velocity = new Vector3(0, 0, y) * 10;

            //transform.Translate(new Vector3(0, 0, y) * Time.deltaTime * Speed);
            //transform.Rotate(0, x, 0);

            ////カメラ追従
            //// まずはカメラ位置をプレイヤーに追従させて...
            //Maincamera.transform.position = transform.position + offset;
            //// プレイヤーを中心にカメラを回すと、プレイヤーとカメラの相対位置が
            //// 変化するはずなので、RotateAroundの後でoffsetを更新する
            //if (x>=1)
            //{
            //    Maincamera.transform.RotateAround(transform.position, Vector3.up, 1.0f);
            //    // transform.RotateAround(Vector3.zero,Vector3.up,-2.0f);
            //    offset = Maincamera.transform.position - transform.position;
            //}
            //if (x <= -1)
            //{
            //    Maincamera.transform.RotateAround(transform.position, Vector3.up, -1.0f);
            //    // transform.RotateAround(Vector3.zero,Vector3.up,-2.0f);
            //    offset = Maincamera.transform.position - transform.position;
            //}
        }//関係ない
        IPp();

        if (photonView.IsMine)
        {
            if (transform.position.y <= -5)//落ちた時の処理
            {
                Debug.Log("落ちた");
                transform.position = GatePos;
            }
        }

        if (photonView.IsMine)//移動
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            transform.Rotate(0, x, 0);

            if (y != 0 && Speed >= speed)
            {
                speed = speed + 0.2f;
            }
            else
            {
                speed = speed * 0.98f;
            }
            transform.Translate(new Vector3(0, 0, y) * Time.deltaTime * speed);
        }
        else
        {
            //移動速度を指定する
            GetComponent<Rigidbody>().velocity = velo;
            //回転速度を指定する
            GetComponent<Rigidbody>().angularVelocity = angul;
        }
    }

    void FixedUpdate()
    {
        //if (photonView.IsMine)//移動
        //{
        //    float x = Input.GetAxis("Horizontal");
        //    float y = Input.GetAxis("Vertical");
        //    transform.Rotate(0, x, 0);

        //    if (y != 0 && Speed >= speed)
        //    {
        //        speed = speed + 0.2f;
        //    }
        //    else
        //    {
        //        speed = speed * 0.98f;
        //    }
        //    transform.Translate(new Vector3(0, 0, y) * Time.deltaTime * speed);
        //}
        //else
        //{
        //    //移動速度を指定する
        //    GetComponent<Rigidbody>().velocity = velo;
        //    //回転速度を指定する
        //    GetComponent<Rigidbody>().angularVelocity = angul;
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        if (photonView.IsMine)
        {
            if (other.gameObject.tag == "Goal" && GateCount >= 6)
            {
                int G;
                //Debug.Log("ゴール");
                GoalCount++;
                if (GoalCount >= 3)
                {
                    Debug.Log("ゴール");
                    goalText.gameObject.SetActive(true);
                }
                else
                { 
                    G = GoalCount + 1;
                //T = GameObject.Find("LapText").GetComponent<Text>();
                T.text = " Lap " + G + "/3";
                GateCount = 0;
                }
            }
            if (other.gameObject.tag == "Gate")
            {
                if (GoalCount<3) {
                    Vector3 Gpos = other.transform.position;
                   GatePos = new Vector3(Gpos.x,Gpos.y+1,Gpos.z);
                   GateCount++;
                   Debug.Log("gatepoint " + GateCount);
                }
            }
        }
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

        {
            //if (stream.IsWriting) //自分のオブジェクトの時
            //{
            //    string msg = transform.position + ";"                   //表示座標
            //               + transform.localEulerAngles + ";"           //回転角度
            //               + GetComponent<Rigidbody>().velocity + ";"   //移動速度
            //               + GetComponent<Rigidbody>().angularVelocity; //回転速度
            //    stream.SendNext(msg);                                   //メッセージ出力
            //}
            //else                //他人のオブジェクトの時
            //{
            //    string msg = stream.ReceiveNext().ToString();           //メッセージ入力
            //    string[] p = msg.Split(';');                            //「;」で区切る
            //    transform.position = Str2vec3(p[0]);                    //表示座標修正
            //    transform.localEulerAngles = Str2vec3(p[1]);            //回転角度修正
            //    velo = Str2vec3(p[2]);                                  //移動速度保存
            //    angul = Str2vec3(p[3]);                                 //回転速度保存
            //}
        }
    }

        //文字列をVector3に変換
    Vector3 Str2vec3(string str){
        string[] xyz = str.Trim('(', ')').Split(',');   //カッコを削除してカンマで分割
        return(new Vector3(float.Parse(xyz[0]), float.Parse(xyz[1]), float.Parse(xyz[2])));
    }
}
