using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onlineDerector : MonoBehaviour
{
    public GameObject gameobject; //メインスクリプト
    public GameObject inputField; //IPアドレスの入力欄
    public GameObject toggle;     //サーバーのチェックボックス
    public void OnClick()
    {
        //IPアドレスの取得
        string ip = inputField.GetComponent<InputField>().text;
        //サーバーのチェック
        bool server = toggle.GetComponent<Toggle>().isOn;
        //ログイン処理を呼び出す
        gameobject.GetComponent<multiController>().Login(ip, server);
        //親オブジェクトを非表示(Panelを非表示)
        transform.parent.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        ////IPアドレスの取得
        //string ip = inputField.GetComponent<InputField>().text;
        ////サーバーのチェック
        //bool server = toggle.GetComponent<Toggle>().isOn;
        ////ログイン処理を呼び出す
        //gameobject.GetComponent<multiController>().Login(ip, server);
        ////親オブジェクトを非表示(Panelを非表示)
        //transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
