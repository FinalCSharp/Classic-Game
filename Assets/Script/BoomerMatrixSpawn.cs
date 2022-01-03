using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerMatrixSpawn : MonoBehaviour
{
    static int Width = 10, Height = 15;
    public int[,] Matrix = new int[Width, Height];
    static int Space = 0, Unbreak = -2, Breakable = -1;
    // 0: space
    // 0, 14 line can be Destory
    // Start is called before the first frame update
    void Start()
    {
        SpawnMatrix();
    }
    // Update is called once per frame
    void Update() { }
    public void SpawnMatrix()
    {
        for (int i = 0; i < Width; i++)
        {
            int Item = Random.Range(0, 1);
            if (Item == 0) Matrix[i, 0] = Space;
            else Matrix[i, 0] = Breakable;
        }
        for (int i = 1; i < Width - 1; i++)
        {
            for (int j = 1; j < Height - 1; j++)
            {
                int Item = Random.Range(0, 2);
                if (Item == 0) Matrix[i, j] = Space;
                else if (Item == 1) Matrix[i, j] = Unbreak;
                else Matrix[i, j] = Breakable;
            }
        }
        Matrix[0, 0] = Matrix[1, 0] = Matrix[0, 1] =
        Matrix[Width - 1, Height - 1] = Matrix[Width - 2, Height - 1] = Matrix[Width - 1, Height - 2] =
        Matrix[0, Height - 1] = Matrix[1, Height - 1] = Matrix[0, Height - 2] =
        Matrix[Width - 1, 0] = Matrix[Width - 1, 1] = Matrix[Width - 2, 0] = Space;
    }
}
