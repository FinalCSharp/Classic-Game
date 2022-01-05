using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    //Every Player Have a Bomb Generator.
    // Start is called before the first frame update
    public GameObject Bomb;
    private bool Cd = false;
    private int CoolDownTime = 3;
    private float Timer = 0;
    BombIntIndex bombIntIndex;
    void Start() {
        bombIntIndex = GameObject.Find("ContextApi").GetComponent<BombIntIndex>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Cd && (Time.time - Timer) >= CoolDownTime) Cd = false;
    }
    public void PlaceBomb()
    {
        if (!Cd)
        {
            int[] position = bombIntIndex.getIndex(transform.localPosition);
            //Haven't test the spawn location (XMax & Ymax). by Otuslettia.
            //btw maybe the Location of Bomb will Follow the Player, Consider make the location fixed if it happens ;)
            Instantiate(Bomb, new Vector3(position[0] - 7, position[1] - 4.5f, 0), Quaternion.Euler(0, 0, 0));
            //Start CoolDown Timer
            Timer = Time.time;
            Cd = true;
        }
    }

}