using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMatrix : MonoBehaviour
{
    public static Transform[,] matrix = new Transform[15, 10];
    public static void SetMatrix(int i, int j, Transform transform) 
    {
        matrix[i, j] = transform;
    }
}
