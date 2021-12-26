using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook : MonoBehaviour
{
    //fix:1. the rotation should be around a point.
    //fix:2. the object mass?
    //fix:3. the y direction is wrong.
    private bool MOVE = false;
    private bool R_direction = true;
    // Start is called before the first frame update
    void Start()
    {
        //start rortate
        rotaing();
        //set the start point.
        this.gameObject.transform.position = new Vector3(0.033f, 3.734f, 0);
        this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 64.199f));
    }
    // Update is called once per frame
    void Update()
    {
        //if isnt moving, keep rotating.
        if (Input.GetKey(KeyCode.DownArrow) && !MOVE)
        {
            Down();
            MOVE = true;
        }
        else if (!MOVE) rotaing();
        else Down();
    }
    void Down() {
        //moving toward the angel chosen.
        transform.Translate(0, -0.03f, 0);
    }
    void Back(float weight) {
        //if hook fin. set MOVE to false;
        transform.Translate(0, 0.1f*weight, 0);
        if (gameObject.transform.position == new Vector3(0, 0, 0))
            MOVE = false;
    }
    void rotaing()
    {
        //every sec, rotate(if co. boundary ,change the direc.)
        float z = gameObject.transform.eulerAngles.z;
        if (z > 180) z -= 360;
        if (z >= 154.199f && R_direction)
            R_direction = false;
        else if (z <= -25.801f && !R_direction)
            R_direction = true;
        if (R_direction) transform.Rotate(0, 0, 0.25f);
        else transform.Rotate(0, 0 , -0.25f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.tag == "Bgold") {
            //Back();//Q: game object mass?
        }
        */
    }
}
