using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public int[] itemTable;
    int scoreNow = 0;
    Text txt;
    int buff;
    public void resetBuff()
    {
        buff = 1;
    }
    public void setBuff(int value)
    {
        buff += value;
    }
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
    }
    public void setScore(int value)
    {
        scoreNow += value;
        refreshScore();
    }
    void refreshScore()
    {
        txt.text = System.Convert.ToString(scoreNow);
    }
    public bool IsLegalBuy(int value)
    {
        if (scoreNow >= value)
        {
            return true;
        }
        else
            return false;
    }
    public void pickedItem(int itemCode)// qPack item first ,later is bgold,mgold,sgold and so on 
    {
        if (itemCode == -1) return;
        scoreNow += itemTable[itemCode];
        if(itemCode == itemTable.Length -1 && buff >= 1)
        {
            scoreNow += 100 * buff;
        }
        refreshScore();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
