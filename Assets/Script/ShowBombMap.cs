using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBombMap : MonoBehaviour
{
    public GameObject[] obj; // can delete,can't delete,player 1 ,player 2,player 3(npc),player 4(npc);
    // Start is called before the first frame update
    public void Show(int [,]matrix)
    {
        for(int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (matrix[i, j] == 0) continue;
                Instantiate(obj[matrix[i, j] - 1], new Vector3(j - 7, i - 3.5f, 0), Quaternion.Euler(0, 0, 0), transform);
            }
        }
    }
}
