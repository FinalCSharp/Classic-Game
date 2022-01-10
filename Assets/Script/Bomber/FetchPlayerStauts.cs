using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FetchPlayerStauts : MonoBehaviour
{
    StatusPlayer statusPlayer;
    public int thisPlayerLabel;
    Text power, bombN, health;
    string parseToString(int num)
    {
        return System.Convert.ToString(num);
    }
    public void fetchData()
    {
        power.text = parseToString(statusPlayer.power[thisPlayerLabel]);
        bombN.text = parseToString(statusPlayer.maxBomb[thisPlayerLabel]);
        health.text = parseToString(statusPlayer.health[thisPlayerLabel]);
    }
    private void Start()
    {
        power = transform.Find("PowerData").GetComponent<Text>();
        bombN = transform.Find("BombData").GetComponent<Text>();
        health = transform.Find("HealthData").GetComponent<Text>();
        statusPlayer = GameObject.Find("ContextApi").GetComponent<StatusPlayer>();
    }
}
