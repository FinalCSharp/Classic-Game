using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombIntIndex : MonoBehaviour
{
    public int[] getIndex(Vector3 vector)
    {
        int[] temp = new int[2];
        temp[0] = (int)System.Math.Round(vector.x + 7, 0);
        temp[1] = (int)System.Math.Round(vector.y + 4.5f, 0);
        return temp;
    }
}
