using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPlayer : MonoBehaviour
{
    public int allPlayerInitHealth = 3;
    public int allPlayerInitBomb = 1;
    public int allPlayerInitPower = 2;
    public int mode = 1;
    public int[] health;
    public int[] power;
    public int[] maxBomb;
    private int[] nowPlacedBomb = { 0, 0, 0, 0 };
    private float[] LastAjustHealthTime = { 0, 0, 0, 0 };
    Transform statusP1, statusP2, statusNpc1,statusNpc2;
    public Transform Canvas;
    public GameObject EndUI, win, lose;
    GameObject[] player;
    bool isEnd = false;
    //another status can add here;
    public void Start()
    {
        health = new int[4];
        maxBomb = new int[4];
        power = new int[4];
        player = new GameObject[4];
        health[0] = health[1] = health[2] = health[3] = allPlayerInitHealth;
        maxBomb[0] = maxBomb[1] = maxBomb[2] = maxBomb[3] = allPlayerInitBomb;
        power[0] = power[1] = power[2] = power[3] = allPlayerInitPower;
        statusP1 = GameObject.Find("StatusP1").transform;
        statusP2 = GameObject.Find("StatusP2").transform;
        player[0] = GameObject.Find("Player1");
        player[1] = GameObject.Find("Player2");
        
        if(mode == 2)
        {
            statusNpc1 = GameObject.Find("StatusNpc1").transform;
            statusNpc2 = GameObject.Find("StatusNpc2").transform;
            player[2] = GameObject.Find("Npc1");
            player[3] = GameObject.Find("Npc2");
        }
    }
    public void throwsData(int player)
    {
        switch (player)
        {
            case 0:
                statusP1.SendMessage("fetchData");
                break;
            case 1:
                statusP2.SendMessage("fetchData");
                break;
            case 2:
                statusNpc1.SendMessage("fetchData");
                break;
            case 3:
                statusNpc2.SendMessage("fetchData");
                break;
        }
    }
    public void AdjustHealth(int player, int value) 
    {
        if(Time.time - LastAjustHealthTime[player] < 0.5f)
        {
            return;
        }
        LastAjustHealthTime[player] = Time.time;
        health[player] += value;
        throwsData(player);
        if(mode == 1)//only pvp
        {
            if(health[player] == 0 && !isEnd)
            {
                isEnd = true;
                Destroy(this.player[player]);
                GameObject tp = Instantiate(EndUI, Canvas.transform);
                Instantiate(statusP1, new Vector3(100, 500, 0), Quaternion.Euler(0, 0, 0), tp.transform);
                if(player == 1)
                {
                    Instantiate(lose, new Vector3(300, 300, 0), Quaternion.Euler(0, 0, 0), tp.transform);
                    Instantiate(win, new Vector3(300, 500, 0), Quaternion.Euler(0, 0, 0), tp.transform);
                }
                else
                {
                    Instantiate(lose, new Vector3(300, 500, 0), Quaternion.Euler(0, 0, 0), tp.transform);
                    Instantiate(win, new Vector3(300, 300, 0), Quaternion.Euler(0, 0, 0), tp.transform);
                }
                Instantiate(statusP2, new Vector3(100, 300, 0), Quaternion.Euler(0, 0, 0), tp.transform);
            }
        }
        else
        {

        }
    }
    public void AdjustMaxBomb(int player,int value)
    {
        maxBomb[player] += value;
        throwsData(player);
    }
    public void AdjustPower(int player, int value)
    {
        power[player] += value;
        throwsData(player);
    }
    public void PutBomb(int player)
    {
        nowPlacedBomb[player]++;
    }
    public void BlowUp(int player)
    {
        nowPlacedBomb[player]--;
    }
    public bool CanPutBomb(int player)
    {
        if (nowPlacedBomb[player] < maxBomb[player]) return true;
        else return false;
    }
}
