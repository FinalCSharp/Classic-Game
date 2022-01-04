using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Generate_Position;
    public GameObject Bomb;
    private bool Cd = false;
    private int CoolDownTime = 3;
    void Start()
    {
        /*
        GameObject player1 = GameObject.Find("Player1");
        GameObject player2 = GameObject.Find("Player2");
        GameObject NPC1 = GameObject.Find("NPC1");
        GameObject NPC2 = GameObject.Find("NPC2");
        */
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void GenerateBomb()
    {
        if (!Cd)
        {
            Vector2 Location = transform.parent.position;
            //Use Round to Get the Matrix[i, j] through Location.x / y
            Cd = true;
            Timer();
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(CoolDownTime);
        Cd = false;
    }
}