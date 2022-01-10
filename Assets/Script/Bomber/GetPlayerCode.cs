using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerCode : MonoBehaviour
{
    public static int GetCode(string name)
    {
        if (name.Equals("Player1"))
        {
            return 0;
        }
        else if (name.Equals("Player2"))
        {
            return 1;
        }
        else if (name.Equals("Npc1"))
        {
            return 2;
        }
        else if (name.Equals("Npc2"))
        {
            return 3;
        }
        return -1;
    }
}
