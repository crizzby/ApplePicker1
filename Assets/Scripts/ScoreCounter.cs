using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                                       //a

public class ScoreCounter : MonoBehaviour

{
    [Header("Dynamic")]                                     //b
    public int score = 0;                               
    private Text uiText;                                    //c
    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>();                      //d
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = score.ToString("#,0");                //e
    }
}
