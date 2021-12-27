using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookAction : MonoBehaviour
{
    private bool MOVE = false, shouldUp = false;
    private bool R_direction = true;
    public float originRotationPoint = 64.199f, ableRationDegree = 70, hookSpeed = 150,rotateSpeed = 200;
    float duplicatedHookSpeed;
    float originX, originY;
    float totalX, totalY, degree;
    bool isCathed = false, isQpack = false;
    public float[] qPackSpeedTable;
    public float[] speedTable;
    GameObject soundPlayer;
    // Start is called before the first frame update
    void Start()
    {
        soundPlayer = GameObject.Find("SoundPlayer");
        duplicatedHookSpeed = hookSpeed;
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
            isQpack = isCathed = false;
        }
        else if (!MOVE) rotating();
        else Down();
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
        float x = -hookSpeed / (float)System.Math.Cos(degree) * Time.deltaTime;
        transform.Translate(-x, hookSpeed * Time.deltaTime , 0);
        if (transform.localPosition.y >= originY) {
            transform.localPosition = new Vector2(originX, originY);
            shouldUp = false;
            MOVE = false;
            int code = getItemCode();
            GameObject.Find("Score").SendMessage("pickedItem", code);
            if(code != -1)
                freeHook();
            revertHookSpeed();
        }
    }
    void Down() {
        //moving toward the angel chosen.
        degree = originRotationPoint - transform.rotation.z;
        //follow the degree to fly ~~~
        float x = -hookSpeed / (float)System.Math.Cos(degree) * Time.deltaTime;
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
    void freeHook()
    {
        Destroy(transform.GetChild(0).gameObject);
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
    }
}
