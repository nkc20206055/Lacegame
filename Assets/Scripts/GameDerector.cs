using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDerector : MonoBehaviour
{
    public string fruitname;//選択した果物の名前保存用
    private string[] fruitsames = { "Apple", "Mikan", "Melon", "Nasi", "Coconut" };

    public void OnClickApple()
    {
        fruitname = fruitsames[0];
        Debug.Log(fruitname);
    }
    public void OnClickMikan()
    {
        fruitname = fruitsames[1];
        Debug.Log(fruitname);
    }
    public void OnClickMelon()
    {
        fruitname = fruitsames[2];
        Debug.Log(fruitname);
    }
    public void OnClickNasi()
    {
        fruitname = fruitsames[3];
        Debug.Log(fruitname);
    }
    public void OnClickCoconut()
    {
        fruitname = fruitsames[4];
        Debug.Log(fruitname);
    }

    public void OnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        //fruitname =fruitsames[0];
        //Debug.Log(fruitname);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
