using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public int[] itemTable;
    int scoreNow = 0;
    Text txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
    }
    public void pickedItem(int itemCode)// qPack item first ,later is bgold,mgold,sgold and so on 
    {
        if (itemCode == -1) return;
        scoreNow += itemTable[itemCode];
        txt.text = System.Convert.ToString(scoreNow);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
