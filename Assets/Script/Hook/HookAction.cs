using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookAction : MonoBehaviour
{
    //fix:1. the rotation should be around a point.
    //fix:2. the object mass?
    //fix:3. the y direction is wrong.
    private bool MOVE = false, shouldUp = false;
    private bool R_direction = true;
    public float originRotationPoint = 64.199f, ableRationDegree = 70, hookSpeed = 150,rotateSpeed = 200;
    float originX, originY;
    float totalX, totalY, x;
    // Start is called before the first frame update
    void Start()
    {
        totalX = totalY = 0; // init
        originX = transform.localPosition.x;
        originY = transform.localPosition.y;
        //start rortate
        rotating();
        //set the start point.
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, originRotationPoint));
    }
    // Update is called once per frame
    void Update()
    {
        //if isnt moving, keep rotating.
        if (shouldUp)
        {
            Up();
        }
        else if (Input.GetKey(KeyCode.DownArrow) && !MOVE)
        {
            totalX = totalY = 0;
            Down();
            MOVE = true;
        }
        else if (!MOVE) rotating();
        else Down();
    }
    void Up()
    {
        transform.Translate(-x, hookSpeed * Time.deltaTime , 0);
        totalX -= x;
        totalY += hookSpeed * Time.deltaTime;
        if (totalY >= 0) {
            transform.localPosition = new Vector2(originX, originY);
            shouldUp = false;
            MOVE = false;
        }
    }
    void Down() {
        //moving toward the angel chosen.
        float degree = originRotationPoint - transform.rotation.z;
        //follow the degree to fly ~~~
        x = -hookSpeed / (float)System.Math.Cos(degree) * Time.deltaTime;
        transform.Translate(x, -hookSpeed * Time.deltaTime, 0);
        totalY -= hookSpeed * Time.deltaTime;
        totalX = totalY / (float)System.Math.Cos(degree);

        if (totalX > 700 || totalX < -700
            ||totalY < -700)
        {
            shouldUp = true;
        }
    }
    void rotating()
    {
        //every sec, rotate(if co. boundary ,change the direc.)
        float z = gameObject.transform.eulerAngles.z;
        if (z > 180) z -= 360;
        if (z >= originRotationPoint + ableRationDegree && R_direction)
            R_direction = false;
        else if (z <= originRotationPoint - ableRationDegree && !R_direction)
            R_direction = true;
        if (R_direction) transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        else transform.Rotate(0, 0 , -rotateSpeed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.tag == "Bgold") {
            //Back();//Q: game object mass?
        }
        */
        Debug.Log(collision.gameObject.name);
    }
}
