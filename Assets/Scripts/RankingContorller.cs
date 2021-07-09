using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;//Photonを使うために書く

public class RankingContorller : MonoBehaviourPunCallbacks
{
    multiController mC;
    Text[] Ptexts = new Text[4];
    public int[,] PlayerGoolCout = new int[4,2];//二次元配列
    public bool RankingSwithc;
    string St;
    // Start is called before the first frame update
    void Start()
    {
        mC = GameObject.Find("MultiObject").GetComponent<multiController>();
        int oP = 1;
        for (int i = 0; i < 4; i++)
        {
            St = "Player" + oP + "Text";
            St = St.ToString();//一行にまとめる
            Ptexts[i] = GameObject.Find(St).GetComponent<Text>();//Stで保存した文字列と同じ名前のTextを持ってくる
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
                    for (int o = 0; o < 2; o++)
                    {
                        //PlayerGoolCout[t, o] = o;
                        Debug.Log(t + " " + PlayerGoolCout[t, o]);
                    }
                }
                RankingSwithc = false;
            }
        }
        //if (Input.GetKeyDown(KeyCode.T))
        //{

        //}
    }
}
