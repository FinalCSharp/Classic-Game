using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerMatrixSpawn : MonoBehaviour
{
    public int[,] Matrix = new int[Width, Height];
    private static int Width = 15, Height = 10;
    private static int Space = 0, Breakable = -1, Unbreakable = -2;
    private static int[] P_x = { 0, 0, Width - 1, Width - 1 }, P_y = {0,Height-1,0,Height-1 };
    // 0, 14 line can be Destory
    // Start is called before the first frame update
    void Start()
    {
        Random.seed = System.Guid.NewGuid().GetHashCode();
        SpawnMatrix();
    }
    // Update is called once per frame
    //void Update() { }
    //
    public void DestroyBlock(int x, int y)
    {//Distroy Blocks:(int location(x, y))//Just Use Trigger to Do It? Anyway.
        if (Matrix[x, y] == Breakable)
        {
            Matrix[x, y] = Space;
            //call the function in DisplayScript to update the map;
        }
    }
    public void SpawnMatrix()
    {
        for (int i = 0; i < Width; i++) {
            for (int j = 0; j < Height; j++) {
                int Item = Random.Range(0, 3);
                Matrix[i, j] = -Item;
            }
        }
        //Make Sure the Way to Other Player Exist.
        for (int i = 0; i < Width; i++) {
            if (Matrix[i, 0] == Unbreakable) Matrix[i, 0] = Breakable;
            if (Matrix[i, Height - 1] == Unbreakable) Matrix[i, Height-1] = Breakable;
        }
        for (int i = 0; i < Height; i++)
        {
            if (Matrix[0, i] == Unbreakable) Matrix[0, i] = Breakable;
            if (Matrix[Width - 1, i] == Unbreakable) Matrix[Width-1, i] = Breakable;
        }
        //Setting Player Start Point.
        for (int i = 0; i < 4; i++)
        {
            Matrix[P_x[i], P_y[i]] = Space;
            if (P_x[i] == 0) Matrix[P_x[i] + 1, P_y[i]] = Space;
            else Matrix[P_x[i] - 1, P_y[i]] = Space;
            if (P_y[i] == 0) Matrix[P_x[i], P_y[i] + 1] = Space;
            else Matrix[P_x[i], P_y[i] - 1] = Space;
        }
    }
}
