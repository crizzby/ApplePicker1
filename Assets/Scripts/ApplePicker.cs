using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for(int i=0; i <numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos =Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }    
    }

    public void AppleMissed()
    {
        //Destroy all of the falling apples
        GameObject[] appleArray=GameObject.FindGameObjectsWithTag("Apple"); //b
        foreach (GameObject  tempGo in appleArray)
        {
            Destroy(tempGo);
        }
        //Destroy one of the Baskets
        //Get the index of the last Basket in basketList
        int basketIndex = basketList.Count -1;
        
        //Get a reference to that Basket GameObject
        GameObject basketGO = basketList[basketIndex];
        
        //remove the Basket from the List and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        //if there is no Baskets left the game restarts
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
