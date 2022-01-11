using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookAction : MonoBehaviour
{
    private bool MOVE = false, shouldUp = false;
    private bool R_direction = true, isPending = false;
    public float ableRationDegree = 70, hookSpeed = 150, rotateSpeed = 200;
    float duplicatedHookSpeed;
    float originX, originY;
    float totalX, totalY, xSpeed, ySpeed;
    bool isCathed = false, isQpack = false;
    public float[] qPackSpeedTable;
    public float[] speedTable;
    Transform soundPlayer, score, Hook;
    // Start is called before the first frame update
    void Start()
    {
        soundPlayer = GameObject.Find("SoundPlayer").transform;
        Hook = transform.parent.parent; // its parent
        score = GameObject.Find("Score").transform;
        duplicatedHookSpeed = hookSpeed;
        totalX = totalY = 0; // init
        originX = transform.localPosition.x;
        originY = transform.localPosition.y;
        //start rortate
        rotating();
        //set the start point.
    }
    public void hookActionDone()
    {
        MOVE = shouldUp = false;
        //do some condition to break this line
        score.SendMessage("pickedItem", getItemCode());
        hookSpeed = duplicatedHookSpeed;//restore speed
        transform.localPosition = new Vector3(0, 0, 0);
        freeHook();
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
            isQpack = isCathed = false;
            xSpeed = hookSpeed * (float)System.Math.Cos(zR);
            ySpeed = hookSpeed * (float)System.Math.Sin(zR);
        }
        else if (!MOVE) rotating();
    }
    int getItemCode()
    {
        int i; // counter
        if (isQpack)
        {
            for (i = 0; i < qPackSpeedTable.Length; i++)
                if (qPackSpeedTable[i] == hookSpeed)
                    return i + speedTable.Length;
        }
        else
        {
            for (i = 0; i < speedTable.Length; i++)
                if (speedTable[i] == hookSpeed)
                    return i;
        }
        return -1;//error
    }
    void Up()
    {
        Hook.SendMessage("up", hookSpeed);
    }
    void Down()
    {
        Hook.SendMessage("down", new float[] { zR, hookSpeed });
    }
    float zR = 0;
    void rotating()
    {
        //every sec, rotate(if co. boundary ,change the direc.)
        if (zR >= ableRationDegree)
        {
            R_direction = false;
        }
        else if (zR <= -ableRationDegree)
        {
            R_direction = true;
        }
        if (R_direction)
        {
            zR += rotateSpeed * Time.deltaTime;
        }
        else
        {
            zR -= rotateSpeed * Time.deltaTime;
        }
        transform.localRotation = Quaternion.Euler(0, 0, zR);
    }
    void freeHook()
    {
        if (transform.childCount > 0) Destroy(transform.GetChild(0).gameObject);
        //sound effect here
        //soundPlayer.SendMessage("playSoundEffect")
    }
    void revertHookSpeed()
    {
        hookSpeed = duplicatedHookSpeed;
    }
    System.Random rdm = new System.Random();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Transform clsn = collision.gameObject.transform;
        if (isCathed) return;
        clsn.parent = transform;
        clsn.localPosition = new Vector2(0, 0);
        shouldUp = true;
        isCathed = true;
        switch (collision.gameObject.name)
        {
            //sound effect here
            case "CQpack(Clone)": // 問號包
                isQpack = true;
                hookSpeed = qPackSpeedTable[rdm.Next() % (qPackSpeedTable.Length)];
                break;
            case "CBgold(Clone)": // big gold
                hookSpeed = speedTable[0];
                break;
            case "CMgold(Clone)": // medium gold
                hookSpeed = speedTable[1];
                break;
            case "CSgold(Clone)": // small gold
                hookSpeed = speedTable[2];
                break;
            case "CBstone2(Clone)": // big stone
                hookSpeed = speedTable[3];
                break;
            case "CMstone2(Clone)": // medium stone
                hookSpeed = speedTable[4];
                break;
            case "CSstone2(Clone)": // small stone
                hookSpeed = speedTable[5];
                break;
        }
        Up();
    }
}