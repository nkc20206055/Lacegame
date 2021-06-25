using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class otamesiRPC : /*MonoBehaviour*/MonoBehaviourPunCallbacks
{
    //[SerializeField] GameObject text;
    multiController oD;
    public Text oText;
    string s;
    public int SaveCount;
    public byte saveC;
    private bool tt;
    // Start is called before the first frame update
    void Start()
    {
        oD = GameObject.Find("MultiObject").GetComponent<multiController>();
        tt = true;
    }

    public override void OnJoinedRoom()
    {
        if (oD.ServerFlg == true)
        {
            oD.Countrooms++;
            SaveCount = oD.Countrooms;

            //SaveCount++;

            //RPC(遠隔手続き呼び出し)
            photonView.RPC("TargetHit", RpcTarget.All, oD.Countrooms/*SaveCount*/);
        }
    }

    //他の誰か（プレイヤー）が部屋に来た時に呼ばれる
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (oD.ServerFlg == true)
        {
            oD.Countrooms++;
            //SaveCount++;
            saveC++;
        }
    }

    // 他のプレイヤーが退室した時
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (oD.ServerFlg == true)
        {
            oD.Countrooms--;
            //SaveCount--;
            saveC--;
        }
    }

    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        Debug.Log("OnRoomPropertiesUpdate");
    }
    // Update is called once per frame
    void Update()
    {
        //if (oD.ServerFlg == true)
        //{
            if (/*oD.ServerFlg == true*/SaveCount != oD.Countrooms && SaveCount <= 4)
            {
                photonView.RPC("TargetHit", RpcTarget.All, oD.Countrooms/*SaveCount*/);
            SaveCount = oD.Countrooms;

            }
            else if (tt == true && SaveCount >= 4)
            {
                photonView.RPC("TargetHit", RpcTarget.All, oD.Countrooms/*SaveCount*/);
            SaveCount = oD.Countrooms;
            tt = false;
            }
            //photonView.RPC("PlayerON", RpcTarget.All,tt);
        //}
    }
    //すべての端末で実行される
    [PunRPC]
    private void TargetHit(int t)
    {
        //s = t.ToString("000");
        //oText.text = s;
        oText.text = t.ToString(/*"000"*/);
        //oD.Countrooms = t;
        //SaveCount = oD.Countrooms;
    }
    //[PunRPC]
    //public void PlayerON(bool o)
    //{
    //    Debug.Log("動いた");
    //}
}
