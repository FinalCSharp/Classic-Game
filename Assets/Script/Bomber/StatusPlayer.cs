using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPlayer : MonoBehaviour
{
    public int allPlayerInitHealth = 3;
    public int allPlayerInitBomb = 1;
    private int[] health;
    private int[] maxBomb;
    private int[] nowPlacedBomb = { 0, 0, 0, 0 };
    //another status can add here;
    public void Start()
    {
        health = new int[4];
        maxBomb = new int[4];
        health[0] = health[1] = health[2] = health[3] = allPlayerInitHealth;
        maxBomb[0] = maxBomb[1] = maxBomb[2] = maxBomb[3] = allPlayerInitBomb;
    }
    public void AdjustHealth(int player, int value) 
    {
        health[player] += value;
        if(health[player] == 0)
        {
            //this player die need destroy from map
        }
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
