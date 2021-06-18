﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPunCallbacks /*MonoBehaviour*/
{
    public int Speed = 5;
    public string Ptext;
    GameObject textM,Maincamera;
    TextMesh TM;
    Vector3 Plpos,Camerapos,mixpos;
    private Vector3 offset;//中心座標
    void PCamera(float x)
    {
        //カメラ追従
        // まずはカメラ位置をプレイヤーに追従させて...
        Maincamera.transform.position = transform.position + offset;
        // プレイヤーを中心にカメラを回すと、プレイヤーとカメラの相対位置が
        // 変化するはずなので、RotateAroundの後でoffsetを更新する
        if (x >= 1)
        {
            Maincamera.transform.RotateAround(transform.position, Vector3.up, 60.0f*Time.deltaTime);
            // transform.RotateAround(Vector3.zero,Vector3.up,-2.0f);
            offset = Maincamera.transform.position - transform.position;
        }
        if (x <= -1)
        {
            Maincamera.transform.RotateAround(transform.position, Vector3.up, -60.0f * Time.deltaTime);
            // transform.RotateAround(Vector3.zero,Vector3.up,-2.0f);
            offset = Maincamera.transform.position - transform.position;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Maincamera = GameObject.Find("Main Camera");
        ////offset = transform.position - Maincamera.transform.position;
        ////Camerapos = new Vector3(0,1.95f,-5.14f);
        //Camerapos = new Vector3(0, -1.95f, 5f);
        //Maincamera.transform.position = Camerapos;//Main CameraをAppleに映るように配置
        //offset = transform.position - Maincamera.transform.position;
        //Debug.Log(offset);
        ////Debug.Log(Maincamera);

        textM = transform.GetChild(0).gameObject;//Apple内にある子オブジェクトのtextObを取得する
        TM = textM.GetComponent<TextMesh>();
        //Debug.Log(TM);
        TM.text = Ptext;
    }

    // Update is called once per frame
    void Update()
    {
        //自分のオブジェクトだけ移動する
        if (photonView.IsMine)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(x, y, 0) * Time.deltaTime * Speed);
        }

        //float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");
        //PCamera(x);
        //transform.Translate(new Vector3(0, 0, y) * Time.deltaTime * Speed);
        //transform.Rotate(0,x,0);

        ////カメラ追従
        //// まずはカメラ位置をプレイヤーに追従させて...
        //Maincamera.transform.position = transform.position + offset;
        //// プレイヤーを中心にカメラを回すと、プレイヤーとカメラの相対位置が
        //// 変化するはずなので、RotateAroundの後でoffsetを更新する
        //if (x>=1)
        //{
        //    Maincamera.transform.RotateAround(transform.position, Vector3.up, 1.0f);
        //    // transform.RotateAround(Vector3.zero,Vector3.up,-2.0f);
        //    offset = Maincamera.transform.position - transform.position;
        //}
        //if (x <= -1)
        //{
        //    Maincamera.transform.RotateAround(transform.position, Vector3.up, -1.0f);
        //    // transform.RotateAround(Vector3.zero,Vector3.up,-2.0f);
        //    offset = Maincamera.transform.position - transform.position;
        //}
    }
}
