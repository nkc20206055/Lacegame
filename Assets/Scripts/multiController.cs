using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class multiController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject ProText;
    GameDerector GD;//GameDerectorスクリプト取得用変数
    otamesiRPC orpc;
    public Text tm;
    string s;
    public int Maxroom, Countrooms;//ルームの人数は最大4人まで
    public byte otame;
    public bool ServerFlg; //サーバーフラグ
    int otamesI;
    bool MainGameSwithc,SaveSwithc;
    public void Login(string ip, bool sf)
    {
        //サーバーフラグの設定
        ServerFlg = sf;
        //IPアドレスの設定
        PhotonNetwork.PhotonServerSettings.AppSettings.Server = ip;
        //ポート番号の設定
        PhotonNetwork.PhotonServerSettings.AppSettings.Port = 5055;
        //ネットワークへの接続
        PhotonNetwork.ConnectUsingSettings();

        //送信回数の設定
        //PhotonNetwork.SerializationRate = 1;  //１秒に１回だけ通信する
        PhotonNetwork.SerializationRate = 10;  //お試し
    }
    // Start is called before the first frame update
    void Start()
    {
        ////IPアドレスの設定
        //PhotonNetwork.PhotonServerSettings.AppSettings.Server = "172.18.86.111";
        ////ポート番号の設定
        //PhotonNetwork.PhotonServerSettings.AppSettings.Port = 5055;
        ////ネットワークへの接続
        //PhotonNetwork.ConnectUsingSettings();

        MainGameSwithc = true;
        SaveSwithc = true;
        GD = GameObject.Find("GameDerector").GetComponent<GameDerector>();
        Maxroom = 4;
    }

    // サーバーへの接続が成功した時
    public override void OnConnectedToMaster()
    {
        //PhotonNetwork.LocalPlayer();

        //ルームが無ければ作成してからルーム参加する
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);

        //PhotonNetwork.JoinLobby();
    }
    // ロビーに入った時
    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
    }

    // ルームに入ったとき時(部屋の入室に成功したときに呼ばれる)
    public override void OnJoinedRoom()
    {
        ProText.SetActive(true);
        //int i = 1;
        //otame = (byte)i;
        if (ServerFlg == false)
        {
            //orpc = GameObject.Find("Otamesirpc").GetComponent<otamesiRPC>();
            //otame = orpc.saveC;
            //otamesI = Countrooms;
        }
        {
            //if (ServerFlg == true)
            //{
            //    PhotonNetwork.Instantiate("prototypeGround 1", new Vector3(-50, -21, 0), Quaternion.identity);
            //    //PhotonNetwork.JoinOrCreateRoom();
            //}
            ////ランダムな位置にネットワークオブジェクトを生成する
            //var v = new Vector3(-5f, 1, 0);
            //GameObject go = PhotonNetwork.Instantiate("Apple", v, Quaternion.identity);
            ////サーバーなら赤、クライアントなら青にする
            //if (ServerFlg)
            //{
            //    go.GetComponent<PlayerController>().Ptext = "Player1";
            //}
            //else
            //{
            //    go.GetComponent<PlayerController>().Ptext = "Player2";
            //}
        }

        {
            //PhotonNetwork.OnRoomPropertiesUpdate();
            //PhotonNetwork.room.SetCustomProperties();

            //if (ServerFlg == true)
            //{
            //    //Countrooms++;
            //    //RPC(遠隔手続き呼び出し)
            //    //photonView.RPC("TargetHit", RpcTarget.All, Countrooms);

            //    Debug.Log(Countrooms);
            //}
            //else if (ServerFlg == false)
            //{
            //    //Countrooms++;
            //    //RPC(遠隔手続き呼び出し)
            //    //photonView.RPC("TargetHit", RpcTarget.All, Countrooms);

            //    Debug.Log(Countrooms);
            //}

            //if (ServerFlg == true && Countrooms <= Maxroom)
            //{
            //    Countrooms++;
            //    Debug.Log(Countrooms);
            //    s = Countrooms.ToString("000");
            //    tm.text = s;
            //}
            //else if (ServerFlg == false && Countrooms <= Maxroom)
            //{
            //    Countrooms++;
            //    Debug.Log(Countrooms);
            //    s = Countrooms.ToString("000");
            //    tm.text = s;
            //}
            //else
            //{
            //    Debug.Log("満員");
            //}
        }

        {

            //PhotonNetwork.Instantiate("prototypeGround 1"/*GD.playername*/, new Vector3(-50,-21,0), Quaternion.identity);

            ////ランダムな位置にネットワークオブジェクトを生成する
            //var v = new Vector3(/*Random.Range(-3f, 1f)*/-5f, /*Random.Range(1, 3f)*/1, 0);
            //GameObject go = PhotonNetwork.Instantiate("Apple"/*GD.playername*/, v, Quaternion.identity);
            ////サーバーなら赤、クライアントなら青にする
            //if (ServerFlg)
            //{
            //    //go.GetComponent<Renderer>().material.color = Color.red;
            //    go.GetComponent<PlayerController>().Ptext = "Player1";
            //}
            //else
            //{
            //    go.GetComponent<PlayerController>().Ptext = "Player2";
            //}
        }
    }

    //ルームに入れなかったとき
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        ProText.SetActive(true);
        tm.text = "入れなかった";
    }

    void t()
    {


        //int a;
        //string b;

        //void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        //{
        //    if (stream.isWriting)
        //    {
        //        //データの送信
        //        stream.SendNext(a);
        //        stream.SendNext(b);
        //    }
        //    else
        //    {
        //        //データの受信
        //        a = (int)stream.ReceiveNext();
        //        b = (string)stream.ReceiveNext();
        //    }
        //}

        //他の誰か（プレイヤー）が部屋に来た時に呼ばれる
        //public override void OnPlayerEnteredRoom(Player newPlayer)
        //{
        //    Countrooms++;
        //    Debug.Log(Countrooms);
        //    s = Countrooms.ToString("000");
        //    tm.text = s;
        //}
    }//関係ない

    // ルームリストに更新があった時
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        //Countrooms += 1;
        Debug.Log("OnRoomListUpdate");
    }

    //PhotonNetwork.CurrentRoom.IsOpen = false;が動いたときにルームプロパティが変更されたので動く
    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        //※この場合ServerFlgがtrueのオブジェクト以外にこの処理が動く
        //Countrooms += 1;
        Debug.Log("OnRoomPropertiesUpdate");
        //if (ServerFlg == true)
        //{
        //    PhotonNetwork.Instantiate("prototypeGround 1", new Vector3(-50, -21, 0), Quaternion.identity);
        //    //PhotonNetwork.JoinOrCreateRoom();
        //}
            if (ServerFlg == false)
            {
                //ランダムな位置にネットワークオブジェクトを生成する
                orpc = GameObject.Find("Otamesirpc").GetComponent<otamesiRPC>();
                //switch (PV.ViewID)
                //{
                //    case:
                //}
                var v = new Vector3(-5f, 1, 0);
                GameObject go = PhotonNetwork.Instantiate("Apple", v, Quaternion.identity);
                PhotonView PV = go.GetComponent<PhotonView>();
            //サーバーなら赤、クライアントなら青にする
            //if (ServerFlg==false)
            //{
            
                if (PV.ViewID == 2001)
                {
                    //go.GetComponent<PlayerController>().Ptext = "Player2"/* +*/ /*orpc.SaveCount*//*PV.ViewID*/;
                    go.transform.position = new Vector3(-4f, 1, 0);
                }
                else if (PV.ViewID == 3001)
                {
                    //go.GetComponent<PlayerController>().Ptext = "Player3";
                    go.transform.position = new Vector3(4f, 1, -5);
                }
                else if (PV.ViewID == 4001)
                {
                    //go.GetComponent<PlayerController>().Ptext = "Player4";
                    go.transform.position = new Vector3(-4f, 1, -10);
                }
            }
    }

    //
    int status = 0;
    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.NetworkClientState.ToString() == "ConnectingToMasterserver" && status == 0)
        {
            status = 1;
            Debug.Log("サーバーに接続中･･･");
        }
        if (PhotonNetwork.NetworkClientState.ToString() == "Authenticating" && status == 1)
        {
            status = 2;
            Debug.Log("認証中･･･");
        }
        if (PhotonNetwork.NetworkClientState.ToString() == "Joining" && status == 2)
        {
            status = 3;
            Debug.Log("ルームに参加中");
        }

        if (SaveSwithc==true)
        {
            otamesI = Countrooms;
            SaveSwithc = false;
        }

        if (Countrooms>= Maxroom && MainGameSwithc==true)
        {
            //Countrooms = 999;
            if (ServerFlg == true)
            {
                PhotonNetwork.Instantiate("prototypeGround 1", new Vector3(-42, -21, -20), Quaternion.identity);
                //PhotonNetwork.JoinOrCreateRoom();

            }
            if (ServerFlg)
            {
                //ランダムな位置にネットワークオブジェクトを生成する
                var v = new Vector3(4f, 1, 5);
            GameObject go = PhotonNetwork.Instantiate("Apple", v, Quaternion.identity);
            //サーバーなら赤、クライアントなら青にする
            //if (ServerFlg)
            //{
                //go.GetComponent<PlayerController>().Ptext = "Player1";
            }
            //if (Countrooms >= Maxroom)
            //{
            PhotonNetwork.CurrentRoom.IsOpen = false;//この処理が動くとこれ以降他の人がルームに入れない
            //}
            //if (ServerFlg == true) {
            //    PhotonNetwork.Instantiate("prototypeGround 1", new Vector3(-50, -21, 0), Quaternion.identity);
            //    //PhotonNetwork.JoinOrCreateRoom();
            //}
            ////ランダムな位置にネットワークオブジェクトを生成する
            //var v = new Vector3(-5f,1, 0);
            //GameObject go = PhotonNetwork.Instantiate("Apple", v, Quaternion.identity);
            ////サーバーなら赤、クライアントなら青にする
            //if (ServerFlg)
            //{
            //    go.GetComponent<PlayerController>().Ptext = "Player1";
            //}
            //else
            //{
            //    go.GetComponent<PlayerController>().Ptext = "Player2";
            //}
            MainGameSwithc = false;
        }
        //else if (MainGameSwithc == true)
        //{

            //}

    }
    //すべての端末で実行される
    //[PunRPC]
    //private void TargetHit(int t)
    //{
    //    s = t.ToString("000");
    //    tm.text = s;
    //}
}
