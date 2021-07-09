using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;//Photonを使うために書く

public class RankingContorller : MonoBehaviourPunCallbacks
{
    multiController mC;
    Text[] Ptexts = new Text[4];
    string St;
    // Start is called before the first frame update
    void Start()
    {
        //mC = GameObject.Find("MultiObject").GetComponent<multiController>();
        int oP = 1;
        for (int i = 0; i < 4; i++)
        {
            St = "Player" + oP + "Text";
            St = St.ToString();//一行にまとめる
            Ptexts[i] = GameObject.Find(St).GetComponent<Text>();
            //Ptexts[i].text = oP.ToString();
            Debug.Log(Ptexts[i]);
            oP++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (mC.ServerFlg==true)
        //{

        //}
        if (Input.GetKeyDown(KeyCode.T))
        {

        }
    }
}
