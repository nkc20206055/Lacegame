using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceSystem : MonoBehaviour
{

    public Text timeText;
    public Text kyoriText;

    private int count;
    private bool cangoal, goalnow = false, StartGoalLine = false;//;
    private float seconds, minutes;

    public GameObject object1;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer();

            if(this.transform.position.y < 0 )
        {
            transform.position = object1.transform.position;

        }



    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CheckPoint")    //チェックポイントに阿多安宅
        {
            Destroy(other.gameObject);
            count += 1;
            Debug.Log("当たった");
        }
        if (count == 1)  //
        {
            Debug.Log("進行状況　3/2");
            kyoriText.text = "進行状況　3/2 ";// + minutes.ToString("00") + " : " + ((int)seconds).ToString("00");
        }
        if (count == 2)  
        {
            Debug.Log("進行状況　3/1");
            kyoriText.text = "進行状況　3/1 ";
        }
        if (count == 3)  
        {
            Debug.Log("進行状況　ゴールへ");
            kyoriText.text = "進行状況　達成 ";
        }


        if (other.gameObject.tag == "Line")    //スタートラインに阿多高田
        {
            if (count == 3)  //
            {
                Debug.Log("b");
                kyoriText.text = "ゴール ";
                StartGoalLine = false;
                goalnow = true;
            }
            else
            {
                StartGoalLine = true;
            }

        }


    }

    void timer()
    {
        if(StartGoalLine)
        {
            seconds += Time.deltaTime;
        }
        if(seconds >= 60)
        {
            minutes++;
            seconds -= 60;
        }
        if (!goalnow)
        {
            //ゴールしてない
            timeText.text = "Time " + minutes.ToString("00") + " : " + ((int)seconds).ToString("00");
        }
        else
        {
            //ゴールした
            timeText.text = "ゴールタイムは  " + minutes.ToString("00") + " : " + ((int)seconds).ToString("00");
        }



    }
    

}

