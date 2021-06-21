using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaolandUIController : MonoBehaviour
{
    public int GoalCount,GateCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Goal"&& GateCount>=6)
        {
            Debug.Log("ゴール");
            GoalCount++;
            GateCount = 0;
        }
        if (other.gameObject.tag == "Gate")
        {
            Debug.Log("gatepoint");
            GateCount++;
        }
    }
}
