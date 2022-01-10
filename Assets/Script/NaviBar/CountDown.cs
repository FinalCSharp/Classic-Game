using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class CountDown : MonoBehaviour
{
    public GameObject Shop, Continue, End;
    int initTime = 0;
    float timeNow;
    bool isStarted = false;
    public Transform hook;
    public Transform score, targetScore;
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
    public void reset()
    {
        timeNow = Time.time;
        initTime = 0;
    }
    int toNum(string str)
    {
        return int.Parse(str);
    }
    // Update is called once per frame
    void Update()
    {
        if (isStarted && (int)(Time.time - timeNow) != initTime)
        {
            initTime = (int)(Time.time - timeNow);
            txt.text = System.Convert.ToString(60 - initTime);
            if (initTime == 60)
            {
                //should endgame here and check next level condition is satisfied or not
                Debug.Log(toNum(score.GetComponent<Text>().text));
                Debug.Log(toNum(targetScore.GetComponent<Text>().text));
                if (toNum(score.GetComponent<Text>().text) >= toNum(targetScore.GetComponent<Text>().text))
                {
                    score.SendMessage("resetBuff");
                    hook.SendMessage("resetBuff");
                    Instantiate(Shop);
                }
                else
                {
                    SceneManager.LoadScene(1);
                }
            }
        }
    }
}
