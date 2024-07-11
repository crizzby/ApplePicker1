using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static private Text _UI_Text;
    static private int _Score = 1000;

    private Text txtCom;

    void Awake()
    {
        _UI_Text = GetComponent<Text>();
    } 
    static public int SCORE
    {
        get{return _Score;}
        private set
        {
            _Score = value;
            if(_UI_Text != null)
            {
                _UI_Text.text = "High Score: " + value.ToString("#,0");
            }
        }
    }
    static public void TRY_SET_HIGHSCORE(int scoreToTry)
    {
        if(scoreToTry <= SCORE) return;
        SCORE = scoreToTry;
    }

    [Tooltip("Check this box to reset the HighScore in Playerprefs")]
    public bool resetHighScore = false;

    void OnDrawGizmos()
    { 
    	if(resetHighScore)
        {
            resetHighScore = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs HighScore reset ot 1.000.");
        }
    }
    // Start is called before the first frame update

}
