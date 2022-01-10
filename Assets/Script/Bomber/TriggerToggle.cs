using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToggle : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    bool[] inBomb = { false, false, false, false };
    bool isChange = false;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (isChange)
        {
            for(int i = 0; i < 4; i++)
            {
                if (inBomb[i])
                {
                    return;
                }
            }
            boxCollider2D.isTrigger = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("Player1"))
        {
            inBomb[0] = false;
        }
        if (collision.name.Equals("Player2"))
        {
            inBomb[1] = false;
        }

        if (collision.name.Equals("Npc1"))
        {
            inBomb[2] = false;
        }

        if (collision.name.Equals("Npc2"))
        {
            inBomb[3] = false;
        }
        isChange = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        isChange = true;
        if (collision.name.Equals("Player1")) {
            inBomb[0] = true;
        }
        if (collision.name.Equals("Player2"))
        {
            inBomb[1] = true;
        }

        if (collision.name.Equals("Npc1"))
        {
            inBomb[2] = true;
        }

        if (collision.name.Equals("Npc2"))
        {
            inBomb[3] = true;
        }
    }
}
