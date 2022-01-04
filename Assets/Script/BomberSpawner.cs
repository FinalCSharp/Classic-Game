using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BombGenerator;
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
    public void PlaceBomb() {
        if (!Cd)
        {
            Vector2 Location = transform.parent.position;
            int x = (int)(Location.x + 0.5f);
            int y = (int)(Location.y + 0.5f);
            BombControl(x, y);
            //Start CoolDown Timer
            Cd = true;
            CdTimer();
        }
    }
    public void BombControl(int x, int y) {
        //BombGeneretor's location should be fixed?
    }
    IEnumerator CdTimer()
    {
        yield return new WaitForSeconds(CoolDownTime);
        Cd = false;
    }
}