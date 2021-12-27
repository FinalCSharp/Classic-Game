using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDown : MonoBehaviour
{
    int initTime = 0;
    float timeNow;
    bool isStarted = false;
    Text txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
    }
    public void start()
    {
        timeNow = Time.time;
        isStarted = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isStarted && (int)(Time.time - timeNow) != initTime)
        {
            initTime = (int)(Time.time - timeNow);
            txt.text = System.Convert.ToString(60 - initTime);
        }
    }
}
