using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownUpController : MonoBehaviour
{
    float degree = 0, hookSpeed = 0, duplicatedHookSpeed = 0;
    float x = 0, y = 0, totalX = 0, totalY = 0;
    bool isDown = false, isUp = false;
    float originX,originY;
    GameObject hook;
    public void up(float hookSpeed)
    {
        this.hookSpeed = hookSpeed;
        y = -hookSpeed * (float)System.Math.Cos(degree / 180 * System.Math.PI);
        x = hookSpeed * (float)System.Math.Sin(degree / 180 * System.Math.PI);
        isDown = false; //break action
        isUp = true;
    }
    public void down(float[] value)
    {
        degree = value[0];
        duplicatedHookSpeed = hookSpeed = value[1];
        isDown = true;
        totalX = totalY = 0;
        y = -hookSpeed * (float)System.Math.Cos(degree / 180 * System.Math.PI);
        x = hookSpeed * (float)System.Math.Sin(degree / 180 * System.Math.PI);
    }
    // Start is called before the first frame update
    void Start()
    {
        originX = transform.localPosition.x;
        originY = transform.localPosition.y;
        hook = GameObject.Find("hook");
    }
    void Up()
    {
        transform.Translate(-x * Time.deltaTime, -y * Time.deltaTime, 0);
        if (transform.localPosition.y > originY) 
        {
            transform.localPosition = new Vector2(originX,originY);
            isUp = false;
            hook.SendMessage("hookActionDone");
        }
    }
    void Down()
    {
        transform.Translate(x * Time.deltaTime, y * Time.deltaTime, 0);
        totalX += x * Time.deltaTime;
        totalY += y * Time.deltaTime;
        if (totalX<-450 || totalX>450 || totalY < -700)
        {
            isDown = false;
            up(hookSpeed);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isDown)
        {
            Down();
        }
        if (isUp)
        {
            Up();
        }
    }
}
