using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_products : MonoBehaviour
{
    public GameObject[] products = new GameObject[4];
    Vector2 pos1 = new Vector2(440, 220);
    Vector2 pos2 = new Vector2(280, 220);
    // Start is called before the first frame update
    void Start()
    {

        int obj1, obj2;
        while (true)
        {
            obj1 = UnityEngine.Random.Range(0,4);
            obj2 = UnityEngine.Random.Range(0,4);
            if (obj1 != obj2) break;
        }
        GameObject ob1 = products[obj1];
        GameObject ob2 = products[obj2];
        Instantiate(ob1,new Vector3(100,100),new Quaternion(0,0,0,0),transform);
        Instantiate(ob2,new Vector3(200,100),new Quaternion(0,0,0,0),transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
