using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTarget : MonoBehaviour
{
    Text level, target;
    string toString(int num)
    {
        return System.Convert.ToString(num);
    }
    int toNum(string str)
    {
        return int.Parse(str);
    }
    private void Start()
    {
        target = transform.Find("TargetScore").GetComponent<Text>();
        level = transform.Find("Level").GetComponent<Text>();
    }
    public void NextLevel()
    {
        level.text = toString(toNum(level.text) + 1);
        target.text = toString(toNum(level.text)*500);
    }
}
