using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    //Prefab for instantiating apples
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDeley = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //dropping apples
        Invoke ("DropApple", 2f);                                       //a
    }
    
    void DropApple()                                                    //b
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);       //c
        apple.transform.position = transform.position;                  //d
        Invoke("DropApple", appleDropDeley);                            //e
    }

    // Update is called once per frame
    void Update()                                                       //f
    {
        //Basic Movement
        //Changing Direction
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }/* else if (Random.value < changeDirChance)
        {
            speed *= -1;
        }*/
        
    }
    void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }
}
