using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class multiController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject ProText;

    GameDerector GD;//GameDerectorスクリプト取得用変数
    int Maxroom,Countrooms;//ルームの人数は最大4人まで
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
        //ルームが無ければ作成してからルーム参加する
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }

    // ルームに入ったとき時
    public override void OnJoinedRoom()
    {
        //ProText.SetActive(true);
        //if (ServerFlg==true&&Countrooms<=Maxroom)
        //{
        //    Countrooms++;
        //    Debug.Log(Countrooms);
        //}else if (ServerFlg == false && Countrooms <= Maxroom)
        //{
        //    Countrooms++;
        //    Debug.Log(Countrooms);
        //}
        //else
        //{
        //    Debug.Log("満員");
        //}



        {

            PhotonNetwork.Instantiate("prototypeGround 1"/*GD.playername*/, new Vector3(-50,-21,0), Quaternion.identity);

            //ランダムな位置にネットワークオブジェクトを生成する
            var v = new Vector3(/*Random.Range(-3f, 1f)*/-5f, /*Random.Range(1, 3f)*/1, 0);
            GameObject go = PhotonNetwork.Instantiate("Apple"/*GD.playername*/, v, Quaternion.identity);
            //サーバーなら赤、クライアントなら青にする
            if (ServerFlg)
            {
                //go.GetComponent<Renderer>().material.color = Color.red;
                go.GetComponent<PlayerController>().Ptext = "Player1";
            }
            else
            {
                go.GetComponent<PlayerController>().Ptext = "Player2";
            }
        }
    }

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
    }
}
