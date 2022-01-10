using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_products : MonoBehaviour
{
    public int minItem = 1;
    public int maxItem = 4;
    public GameObject[] products = new GameObject[4];
    int x = -290;
    static System.Random rdm = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        int itemNum = rdm.Next(0, maxItem);
        for(int i = 0; i< itemNum + 1; i++)
        {
            Instantiate(products[rdm.Next()%products.Length], transform.position + new Vector3(x, -65, 0), new Quaternion(0, 0, 0, 0), transform);
            x += 140;
        }   
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
