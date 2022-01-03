using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class products_ClickRemove : MonoBehaviour
{
    GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        button = transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Destroy(button);
        }
    }
}
