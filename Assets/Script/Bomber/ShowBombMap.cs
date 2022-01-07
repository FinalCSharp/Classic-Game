using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBombMap : MonoBehaviour
{
    public GameObject[] obj; // can delete,can't delete
    public GameObject[] player;//player 1 ,player 2,player 3(npc),player 4(npc);
    private void Start()
    {
    }
    // Start is called before the first frame update
    public void Show(int [,]matrix)
    {
        Instantiate(player[0], new Vector3(-7, 4.5f, 0), Quaternion.Euler(0, 0, 0), transform);
        Instantiate(player[1], new Vector3(7, 4.5f, 0), Quaternion.Euler(0, 0, 0), transform);
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (matrix[i, j] == 0)
                {
                    TransformMatrix.SetMatrix(i, j, null);
                    continue;
                }
                TransformMatrix.SetMatrix(i, j, Instantiate(obj[matrix[i, j] - 1], new Vector3(i - 7, j - 4.5f, 0), Quaternion.Euler(0, 0, 0), transform).transform);
            }
        }
        for (int i = 0; i < 10; i++)
        {
            for (int j = 14; j >= 0 ; j--)
            {
                Debug.Log(TransformMatrix.matrix[j, i]);
            }
            Debug.Log("nextLine");
        }

    }
}
