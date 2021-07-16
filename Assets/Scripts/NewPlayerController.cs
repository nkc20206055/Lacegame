using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class NewPlayerController : /*MonoBehaviour*/MonoBehaviourPunCallbacks, IPunObservable
{
    GameObject textM,Maincamera, PlayerUi, ProtoUI;
    Vector3 Camerapos, GatePos, Savemuki;
    Transform lapText, goalText, StartText;//PlayerUIの子オブジェクト取得
    Text T, startT,rankignText;
    RankingContorller RC;
    public int GateCount, GoalCount, SaveID;
    int PlayerNmber, Pts,MainRanking;
    float stratTime, SaveTime;
    bool StartSwicht, countStart, StartPlayer;
    void RnkignTextChenze()
    {
        if (photonView.IsMine) {
            if (RC.PlayerRT == true)
            {
                PhotonView PV = /*textM.*/GetComponent<PhotonView>();
                if (PV.ViewID == 1001 || PV.ViewID == 1002)
                {
                    MainRanking = RC.PlayerGoolCout[0, 2];
                    rankignText.text = MainRanking.ToString();
                }
                else if (PV.ViewID == 2001)
                {
                    MainRanking = RC.PlayerGoolCout[1, 2];
                    rankignText.text = MainRanking.ToString();
                }
                else if (PV.ViewID == 3001)
                {
                    MainRanking = RC.PlayerGoolCout[2, 2];
                    rankignText.text = MainRanking.ToString();
                }
                else if (PV.ViewID == 4001)
                {
                    MainRanking = RC.PlayerGoolCout[3, 2];
                    rankignText.text = MainRanking.ToString();
                }

                RC.PlayerRT = false;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        RC = GameObject.Find("PlayerRankingTexts").GetComponent<RankingContorller>();

        //カメラが追従するように設定
        if (photonView.IsMine)
        {
            Vector3 plpos = transform.position;
        Maincamera = GameObject.Find("Main Camera");
        Maincamera.transform.parent = transform;
        Camerapos = new Vector3(0, 2.95f, -5.14f);
        Camerapos = new Vector3(plpos.x, plpos.y + 2.5f, plpos.z + -6f);
        Maincamera.transform.position = Camerapos;//Main CameraをAppleに映るように配置

        Savemuki = transform.eulerAngles;
        Vector3 pPos = transform.position;
        GatePos = new Vector3(pPos.x, pPos.y + 1, pPos.z);
        }
        //
        if (photonView.IsMine)
        {
            PlayerUi = GameObject.Find("PlayerText");
            ProtoUI = GameObject.Find("ProtoText");
            rankignText = GameObject.Find("RankText").GetComponent<Text>();
            // PlayerUiの子オブジェクトの中からアクティブなオブジェクトを探す
            lapText = PlayerUi.transform.Find("LapText");
            StartText = ProtoUI.transform.Find("Text");
            //Debug.Log("target2(transform) = " + lapText);
            //Debug.Log("target2(gameObject) = " + lapText.gameObject);
            T = lapText.gameObject.GetComponent<Text>();
            startT = StartText.gameObject.GetComponent<Text>();

            // PlayerUiの子オブジェクトの中から非アクティブなオブジェクトを探す
            goalText = PlayerUi.transform.Find("GoalText");
            //Debug.Log("target3(transform) = " + goalText);
            //Debug.Log("target3(gameObject) = " + goalText.gameObject);

            Vector3 pPos = transform.position;
            GatePos = new Vector3(pPos.x, pPos.y + 1, pPos.z);
            //IPswitht = true;
            countStart = true;
            StartSwicht = true;
            StartPlayer = false;
            stratTime = 0;
        }

        textM = transform.GetChild(0).gameObject;//Apple内にある子オブジェクトのtextObを取得する
        PhotonView PV = /*textM.*/GetComponent<PhotonView>();
        if (PV.ViewID == 1001 || PV.ViewID == 1002)
        {
            textM.GetComponent<TextMesh>().text = "Player1";
            PlayerNmber = 0;
            if (photonView.IsMine)
            {
                rankignText.text = "1";
            }
        }
        if (PV.ViewID == 2001)
        {
            textM.GetComponent<TextMesh>().text = "Player2";
            PlayerNmber = 1;
            if (photonView.IsMine)
            {
                rankignText.text = "2";
            }
        }
        if (PV.ViewID == 3001)
        {
            textM.GetComponent<TextMesh>().text = "Player3";
            PlayerNmber = 2;
            if (photonView.IsMine)
            {
                rankignText.text = "3";
            }
        }
        if (PV.ViewID == 4001)
        {
            textM.GetComponent<TextMesh>().text = "Player4";
            PlayerNmber = 3;
            if (photonView.IsMine)
            {
                rankignText.text = "4";
            }
        }
        //if (photonView.IsMine)
        //{
            //SaveID = PV.ViewID;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (StartSwicht == true)
            {
                stratTime += 1 * Time.deltaTime;
                if (stratTime < 4)
                {
                    //stratTime += 1 * Time.deltaTime;
                    if (countStart == true)
                    {
                        if (stratTime < 3 && stratTime >= 2)
                        {
                            startT.text = "1";
                            countStart = false;
                        }
                        else if (stratTime < 2 && stratTime >= 1)
                        {
                            startT.text = "2";
                            countStart = false;
                        }
                        else if (stratTime < 1 && stratTime >= 0)
                        {
                            startT.text = "3";
                            countStart = false;
                        }
                    }
                    if (SaveTime <= stratTime && countStart == false)
                    {
                        SaveTime = 1 + SaveTime;
                        countStart = true;
                    }
                }
                else if (stratTime < 5 && stratTime >= 4)
                {
                    startT.text = "Start";
                    StartPlayer = true;
                }
                else if (stratTime >= 5)
                {
                    startT.color = new Color(1f, 0f, 0f, 0f);
                    Debug.Log("変わった");
                    StartSwicht = false;
                }
            }
        }

        if (photonView.IsMine)
        {
            if (transform.position.y <= 0f)//落ちた時の処理
            {
                Debug.Log("落ちた");
                transform.localEulerAngles=Savemuki;//向きをゲートが向いてる方に※Playerのローカル座標の角度にSavemukiの角度を代入する
                transform.position = GatePos;//通ったゲート位置に戻る
            }
        }

        RnkignTextChenze();

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
                    Savemuki = other.transform.eulerAngles;
                    G = GoalCount + 1;
                    T = GameObject.Find("LapText").GetComponent<Text>();
                    T.text = " Lap " + G + "/3";
                    GateCount = 0;
                }
            }
            if (other.gameObject.tag == "Gate")
            {
                if (GoalCount < 3)
                {
                    Vector3 Gpos = other.transform.position;
                    GatePos = new Vector3(Gpos.x, Gpos.y-1, Gpos.z);
                    Savemuki = other.transform.eulerAngles;//※ワールド座標の角度をSavemukiに代入
                    //Debug.Log(other.transform.eulerAngles); ;
                    GateCount++;
                    Debug.Log("gatepoint " + GateCount);
                }
            }
        }
        else
        {
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
                    GateCount++;
                    Debug.Log("gatepoint " + GateCount);
                }
            }

        }
        //RPC(遠隔手続き呼び出し)
        photonView.RPC("PlayerNumber", RpcTarget.All, PlayerNmber, GoalCount, GateCount);
        //Debug.Log("当たった");
    }

    //全ての端末で実行される
    [PunRPC]
    private void PlayerNumber(int HaiN, int a, int b)//透明なゲートとゴールを通った回数を渡す
    {
        for (int i = 0; i < 2; i++)
        {
            switch (i)
            {
                case 0:
                    Pts = a;
                    break;
                case 1:
                    Pts = b;
                    break;
            }
            RC.PlayerGoolCout[HaiN, i] = Pts;
            //RC.RankingSwithc = true;
        }
        RC.Pnuber = HaiN;
        RC.RankingSwithc = true;
    }
}
