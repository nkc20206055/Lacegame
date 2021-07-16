using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;//Photonを使うために書く

public class RankingContorller : MonoBehaviourPunCallbacks
{
    GameObject P1T, P2T, P3T, P4T,PlayerID;
    PhotonView PV;
    multiController mC;
    int[] PrankingSave = new int[4];
    Text[] Ptexts = new Text[4];
    public GameObject[] PtestGS = new GameObject[5];//UIのPlayerTextの保存
    public Vector3[] TextPosS = new Vector3[5];//UIのPlayerTextの位置を保存
    public int[,] PlayerGoolCout = new int[4,3];//二次元配列
    public int Pnuber;//ランキングを入れ替えるときに使用
    public bool RankingSwithc;
    string St,Sg;
    int Thiert,oTest;
    // Start is called before the first frame update
    void Start()
    {
        Pnuber = 0;
        mC = GameObject.Find("MultiObject").GetComponent<multiController>();
        int oP = 1;
        for (int i = 0; i < 4; i++)
        {
            St = "Player" + oP + "Text";
            St = St.ToString();//一行にまとめる
            PtestGS[i] = GameObject.Find(St);
            TextPosS[i] = PtestGS[i].transform.position;
            Ptexts[i] = GameObject.Find(St).GetComponent<Text>();//Stで保存した文字列と同じ名前のTextを持ってくる

            //お試し
            //PtestGS[oP] = GameObject.Find(St);
            //TextPosS[oP] = PtestGS[oP].transform.position;
            //Ptexts[i] = GameObject.Find(St).GetComponent<Text>();//Stで保存した文字列と同じ名前のTextを持ってくる

            PlayerGoolCout[i, 2] = oP;
            //Ptexts[i].text = oP.ToString();
            //Debug.Log(Ptexts[i]);

            PrankingSave[i] = i;
            oP++;
        }

        
        //for (int t = 0; t < 4; t++)//二次元配列確認
        //{
        //    for (int o = 0; o < 2; o++)
        //    {
        //        PlayerGoolCout[t, o] = o;
        //        Debug.Log(t + " " + PlayerGoolCout[t, o]);
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
        if (RankingSwithc == true)
        {

            //if (mC.ServerFlg == true)
            //{
                //for (int t = 0; t < 4; t++)//二次元配列確認
                //{
                //    //PlayerGoolCout[t, o] = o;
                //    Debug.Log(t + " " + PlayerGoolCout[t, 0] + " " + PlayerGoolCout[t, 1]
                //                + " " + PlayerGoolCout[t, 2] + "位" + "  " + Ptexts[t]);
                //    //Debug.Log(PrankingSave[t]);
                //    //PrankingSave[t] =t;
                //}

                for (int i = 3; i >= 0; i--)
                {
                    if (PrankingSave[i] != Pnuber && PlayerGoolCout[Pnuber, 2] > PlayerGoolCout[PrankingSave[i], 2])//自分のは処理しない
                    {
                        if (PlayerGoolCout[Pnuber, 0] == PlayerGoolCout[PrankingSave[i], 0])
                        {
                            if (PlayerGoolCout[Pnuber, 1] > PlayerGoolCout[PrankingSave[i], 1])
                            {
                                int s = 0;
                                s = PlayerGoolCout[PrankingSave[i], 2];
                                PlayerGoolCout[PrankingSave[i], 2] = PlayerGoolCout[Pnuber, 2];
                                PlayerGoolCout[Pnuber, 2] = s;
                                s = PrankingSave[i];
                                PrankingSave[i] = PrankingSave[Pnuber];
                                PrankingSave[Pnuber] = s;
                                //Ptexts[PlayerGoolCout[Pnuber, 2]].transform.position = TextPosS[PlayerGoolCout[PrankingSave[i], 2]];
                                //Ptexts[PlayerGoolCout[PrankingSave[i], 2]].transform.position = TextPosS[PlayerGoolCout[Pnuber, 2]];
                            }

                        }
                        else if (PlayerGoolCout[Pnuber, 0] > PlayerGoolCout[PrankingSave[i], 0])
                        {
                            int s = 0;
                            s = PlayerGoolCout[PrankingSave[i], 2];
                            PlayerGoolCout[PrankingSave[i], 2] = PlayerGoolCout[Pnuber, 2];
                            PlayerGoolCout[Pnuber, 2] = s;
                            s = PrankingSave[i];
                            PrankingSave[i] = PrankingSave[Pnuber];
                            PrankingSave[Pnuber] = s;
                            //Ptexts[PlayerGoolCout[Pnuber, 2]].transform.position = TextPosS[PlayerGoolCout[PrankingSave[i], 2]];
                            //Ptexts[PlayerGoolCout[PrankingSave[i], 2]].transform.position = TextPosS[PlayerGoolCout[Pnuber, 2]];
                        }
                    }
                }
            //}
            
                

                //RPC(遠隔手続き呼び出し）
                photonView.RPC("RnkingT", RpcTarget.All);

                for (int t = 0; t < 4; t++)//二次元配列確認
                {
                    //Ptexts[t].transform.position = TextPosS[PlayerGoolCout[t, 2] - 1];
                    Debug.Log(t + " " + PlayerGoolCout[t, 0] + " " + PlayerGoolCout[t, 1] 
                                + " " + PlayerGoolCout[t, 2] + "位"+"  "+ Ptexts[t]);
                }
                RankingSwithc = false;
        }
        


    }
    [PunRPC]
    private void RnkingT()
    {
        for (int t = 0; t < 4; t++)//二次元配列確認
        {
            Ptexts[t].transform.position = TextPosS[PlayerGoolCout[t, 2] - 1];
        }
        //if (photonView.IsMine)
        //{

        //}
    }
}
