using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ExplosionCalculate : MonoBehaviour
{
    private int getVTop(int xPosition, int yPosition)
    {
        if (yPosition > 9) return 9;
        if (TransformMatrix.matrix[xPosition, yPosition] == null)
            return getVTop(xPosition, yPosition + 1);
        if (TransformMatrix.matrix[xPosition, yPosition].name.Equals("Deletable(Clone)"))
        {
            return yPosition - 1;
        }else if(TransformMatrix.matrix[xPosition, yPosition].name.Equals("Undeletable(Clone)"))
        {
            return yPosition;
        }
        return getVTop(xPosition, yPosition + 1);
    }
    private int getVBottom(int xPosition, int yPosition)
    {
        if (yPosition < 0) return 0;
        if (TransformMatrix.matrix[xPosition, yPosition] == null)
            return getVBottom(xPosition, yPosition - 1);
        if (TransformMatrix.matrix[xPosition, yPosition].name.Equals("Deletable(Clone)"))
        {
            return yPosition + 1;
        }else if(TransformMatrix.matrix[xPosition, yPosition].name.Equals("Undeletable(Clone)")) 
        {
            return yPosition;
        }
        return getVBottom(xPosition, yPosition - 1);
    }
    private int getHLeft(int xPosition, int yPosition)
    {
        if (xPosition < 0) return 0;
        if (TransformMatrix.matrix[xPosition, yPosition] == null)
            return getHLeft(xPosition - 1, yPosition);
        if (TransformMatrix.matrix[xPosition, yPosition].name.Equals("Deletable(Clone)"))
        {
            return xPosition + 1;
        }else if (TransformMatrix.matrix[xPosition, yPosition].name.Equals("Undeletable(Clone)"))
        {
            return xPosition;
        }
        return getHLeft(xPosition - 1, yPosition);
    }
    private int getHRight(int xPosition, int yPosition)
    {
        if (xPosition > 14) return 14;
        if (TransformMatrix.matrix[xPosition, yPosition] == null)
            return getHRight(xPosition + 1, yPosition);
        if (TransformMatrix.matrix[xPosition, yPosition].name.Equals("Deletable(Clone)"))
        {
            return xPosition - 1;
        }else if (TransformMatrix.matrix[xPosition, yPosition].name.Equals("Undeletable(Clone)"))
        {
            return xPosition;
        }
        return getHRight(xPosition + 1, yPosition);
    }
    public int[] GetArea(int xPosition,int yPosition) //return x1,y1,x2,y2 in array
    {
        int[] temp = new int[4];
        temp[0] = getVTop(xPosition, yPosition);
        temp[1] = getVBottom(xPosition, yPosition);
        temp[2] = getHLeft(xPosition, yPosition);
        temp[3] = getHRight(xPosition, yPosition);
        return temp;
    }
}
