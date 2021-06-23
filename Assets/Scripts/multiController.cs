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
    public Text tm;
    string s;
    public int Maxroom,Countrooms;//ルームの人数は最大4人まで
    public bool ServerFlg; //サーバーフラグ
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
        if (ServerFlg == true)
        {
            //Countrooms++;
            //RPC(遠隔手続き呼び出し)
            //photonView.RPC("TargetHit", RpcTarget.All, Countrooms);

            Debug.Log(Countrooms);
        }
        else if (ServerFlg == false)
        {
            //Countrooms++;
            //RPC(遠隔手続き呼び出し)
            //photonView.RPC("TargetHit", RpcTarget.All, Countrooms);

            Debug.Log(Countrooms);
        }
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

        if (Countrooms>=4)
        {
            Countrooms = 999;
        }

    }
    //すべての端末で実行される
    //[PunRPC]
    //private void TargetHit(int t)
    //{
    //    s = t.ToString("000");
    //    tm.text = s;
    //}
}
