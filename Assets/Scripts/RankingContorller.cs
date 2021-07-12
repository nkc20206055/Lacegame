using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;//Photonを使うために書く

public class RankingContorller : MonoBehaviourPunCallbacks
{
    GameObject P1T, P2T, P3T, P4T;
    multiController mC;
    Text[] Ptexts = new Text[4];
    public GameObject[] PtestGS = new GameObject[4];//UIのPlayerTextの保存
    public Vector3[] TextPosS = new Vector3[4];//UIのPlayerTextの位置を保存
    public int[,] PlayerGoolCout = new int[4,3];//二次元配列
    public bool RankingSwithc;
    string St,Sg;
    int Thiert,oTest;
    // Start is called before the first frame update
    void Start()
    {
        mC = GameObject.Find("MultiObject").GetComponent<multiController>();
        int oP = 1;
        for (int i = 0; i < 4; i++)
        {
            St = "Player" + oP + "Text";
            St = St.ToString();//一行にまとめる
            //switch (i)
            //{
            //    case 0:
            //        P1T = GameObject.Find(St);
            //        TextPosS[0] = P1T.transform.position;
            //        Ptexts[0]=P1T.GetComponent<Text>();
            //        break;
            //    case 1:
            //        P2T = GameObject.Find(St);
            //        TextPosS[1] = P2T.transform.position;
            //        Ptexts[1] = P2T.GetComponent<Text>();
            //        break;
            //    case 2:
            //        P3T = GameObject.Find(St);
            //        TextPosS[2] = P3T.transform.position;
            //        Ptexts[2] = P3T.GetComponent<Text>();
            //        break;
            //    case 3:
            //        P4T = GameObject.Find(St);
            //        TextPosS[3] = P4T.transform.position;
            //        Ptexts[3] = P4T.GetComponent<Text>();
            //        break;
            //}

            PtestGS[i] = GameObject.Find(St);
            TextPosS[i] = PtestGS[i].transform.position;
            Ptexts[i] = GameObject.Find(St).GetComponent<Text>();//Stで保存した文字列と同じ名前のTextを持ってくる

            PlayerGoolCout[i, 2] = oP;
            //Ptexts[i].text = oP.ToString();
            //Debug.Log(Ptexts[i]);
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
        if (mC.ServerFlg == true)
        {
            if (RankingSwithc == true)
            {
                for (int t = 0; t < 4; t++)//二次元配列確認
                {
                        //PlayerGoolCout[t, o] = o;
                        Debug.Log(t + " " + PlayerGoolCout[t, 0]+" "+ PlayerGoolCout[t, 1]);
                }
                RankingSwithc = false;
            }
        }


        //if (Input.GetKeyDown(KeyCode.T))//お試し
        //{
        //    //Debug.Log("動いた");
        //    RankingSwithc = true;
        //    if (RankingSwithc == true)
        //    {
        //        for (int t = 0; t < 4; t++)//二次元配列確認※何列目か
        //        {
        //            for (int o = 0; o < 2; o++)//t列目内の0に何回ラップメか、1に何回透明ゲートを通ったかを保存
        //            {
        //                //PlayerGoolCout[t, o] = o;
        //                Thiert = Random.Range(0, 3);
        //                oTest = Random.Range(1, 7);
        //                if (o==0) {
        //                    PlayerGoolCout[t, 0] = Thiert;
        //                } else if (o==1) {
        //                    PlayerGoolCout[t, 1] = oTest;
        //                }
        //                //Debug.Log(t + " " + PlayerGoolCout[t, o]);
        //            }
        //            Debug.Log(t + " " + PlayerGoolCout[t, 0]+" "+ PlayerGoolCout[t, 1]+" "+ PlayerGoolCout[t, 2]);
        //        }

        //        //順位を入れ替え
        //        int i = Random.Range(0, 4);
        //        {
        //            //for(int h = 3; h >= 0; h--)
        //            //{
        //            //    if (i!=h)//違う列なら調べられる
        //            //    {
        //            //        for (int r=0;r<2;r++)
        //            //        {
        //            //            if (PlayerGoolCout[i,0]> PlayerGoolCout[h, 0]|| PlayerGoolCout[i, 0]==PlayerGoolCout[h, 0])
        //            //            {
        //            //                if (PlayerGoolCout[i, 1] > PlayerGoolCout[h, 1])
        //            //                {
        //            //                    PtestGS[i].transform.position = TextPosS[h];
        //            //                    PtestGS[h].transform.position = TextPosS[i];
        //            //                    //break;
        //            //                    //Debug.Log(PlayerGoolCout[i, 2] + "と" + PlayerGoolCout[h, 2] + "を入れ替え");
        //            //                }
        //            //                //else
        //            //                //{
        //            //                //    PtestGS[i].transform.position = TextPosS[h];
        //            //                //    PtestGS[h].transform.position = TextPosS[i];
        //            //                //    break;
        //            //                //}

        //            //            }

        //            //        }
        //            //    }
        //            //}
        //        }


        //        RankingSwithc = false;
        //    }
        //}
    }
}
