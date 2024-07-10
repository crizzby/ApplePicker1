using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;

    // Start is called before the first frame update
    void Start()
    {
        //work in progress
        GameObject scoreGo = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGo.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        //Current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;                                   //a

        //The Camera's z postion sets how far to push the mouse into 3D
        //If this line causes a NullReferenceException, select the Main Camera
        //in the Hierachy and set its tag to MainCamera in the Inspector.
        mousePos2D.z = -Camera.main.transform.position.z;                            //b

        //Convert the point from 2D screen space innto 3D game world space 
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);            //c

        //Move hthe x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

        
    }

    void OnCollisionEnter(Collision coll)
        {
            //Find out what hit this basket
            GameObject collideWith = coll.gameObject;
            if(collideWith.CompareTag("Apple"))
            {
                Destroy(collideWith);
                //Increasing the score
                scoreCounter.score += 100;
                HighScore.TRY_SET_HIGHSCORE(scoreCounter.score);
            }
        }
}
