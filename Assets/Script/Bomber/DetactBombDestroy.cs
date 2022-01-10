using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetactBombDestroy : MonoBehaviour
{
    StatusPlayer statusPlayer;
    private void Start()
    {
        statusPlayer = GameObject.Find("ContextApi").GetComponent<StatusPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("VExplosion(Clone)") || collision.name.Equals("HExplosion(Clone)")) return;
        if (collision.name.Equals("Player1"))
        {
            statusPlayer.AdjustHealth(0, -1);
        }
        if (collision.name.Equals("Player2"))
        {
            statusPlayer.AdjustHealth(1, -1);
        }
        if (collision.name.Equals("Npc1"))
        {
            statusPlayer.AdjustHealth(2, -1);
        }
        if (collision.name.Equals("Npc2"))
        {
            statusPlayer.AdjustHealth(3, -1);
        }
        if (collision.name.Equals("bomb"))
        {
            //make another bomb explos
            collision.SendMessage("BlowUp");
        }
        if (collision.name.Equals("Deletable(Clone)"))
        {
            //delete Block sendMessage to the block and let the block determine what will happens XD
            //Transform matrix will auto delete
            Destroy(collision.gameObject);
        }
    }
}
