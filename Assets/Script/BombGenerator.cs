using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    //Every Player Have a Bomb Generator.
    // Start is called before the first frame update
    public int XMax, YMax;
    public GameObject Bomb;
    private bool Cd = false;
    private int CoolDownTime = 3;
    private float Timer = 0;
    void Start() { }
    // Update is called once per frame
    void Update()
    {
        if (Cd && (Time.time - Timer) == CoolDownTime) Cd = false;
    }
    public void PlaceBomb()
    {
        if (!Cd)
        {
            Vector2 Location = transform.parent.position;
            int x = (int)((Location.x / XMax) + 0.5f);
            int y = (int)((Location.y / YMax) + 0.5f);
            //Haven't test the spawn location (XMax & Ymax). by Otuslettia.
            //btw maybe the Location of Bomb will Follow the Player, Consider make the location fixed if it happens ;)
            Instantiate(Bomb, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0), transform);
            //Start CoolDown Timer
            Timer = Time.time;
            Cd = true;
        }
    }

}