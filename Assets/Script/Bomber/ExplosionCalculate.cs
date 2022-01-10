using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ExplosionCalculate : MonoBehaviour
{
    private int getVTop(int xPosition, int yPosition,int power , int now) 
    {
        if (now > power) return yPosition;
        if (yPosition > 9) return 9;
        if (TransformMatrix.matrix[xPosition, yPosition] == null)
            return getVTop(xPosition, yPosition + 1, power, ++now);
        if (TransformMatrix.matrix[xPosition, yPosition].name.Equals("Deletable(Clone)"))
        {
            return yPosition;
        }else if(TransformMatrix.matrix[xPosition, yPosition].name.Equals("Undeletable(Clone)"))
        {
            return yPosition - 1;
        }
        return getVTop(xPosition, yPosition + 1, power, ++now);
    }
    private int getVBottom(int xPosition, int yPosition, int power,int now)
    {
        if (now > power) return yPosition;
        if (yPosition < 0) return 0;
        if (TransformMatrix.matrix[xPosition, yPosition] == null)
            return getVBottom(xPosition, yPosition - 1, power, ++now);
        if (TransformMatrix.matrix[xPosition, yPosition].name.Equals("Deletable(Clone)"))
        {
            return yPosition;
        }else if(TransformMatrix.matrix[xPosition, yPosition].name.Equals("Undeletable(Clone)")) 
        {
            return yPosition + 1;
        }
        return getVBottom(xPosition, yPosition - 1, power, ++now);
    }
    private int getHLeft(int xPosition, int yPosition, int power,int now)
    {
        if (now > power) return xPosition;
        if (xPosition < 0) return 0;
        if (TransformMatrix.matrix[xPosition, yPosition] == null)
            return getHLeft(xPosition - 1, yPosition, power, ++now);
        if (TransformMatrix.matrix[xPosition, yPosition].name.Equals("Deletable(Clone)"))
        {
            return xPosition;
        }else if (TransformMatrix.matrix[xPosition, yPosition].name.Equals("Undeletable(Clone)"))
        {
            return xPosition + 1;
        }
        return getHLeft(xPosition - 1, yPosition, power, ++now);
    }
    private int getHRight(int xPosition, int yPosition, int power,int now)
    {
        if (now > power) return xPosition;
        if (xPosition > 14) return 14;
        if (TransformMatrix.matrix[xPosition, yPosition] == null)
            return getHRight(xPosition + 1, yPosition, power, ++now);
        if (TransformMatrix.matrix[xPosition, yPosition].name.Equals("Deletable(Clone)"))
        {
            return xPosition;
        }else if (TransformMatrix.matrix[xPosition, yPosition].name.Equals("Undeletable(Clone)"))
        {
            return xPosition - 1;
        }
        return getHRight(xPosition + 1, yPosition, power, ++now);
    }
    public int[] GetArea(int xPosition,int yPosition,int power) //return x1,y1,x2,y2 in array
    {
        int[] temp = new int[4];
        temp[0] = getVTop(xPosition, yPosition, power, 1);
        temp[1] = getVBottom(xPosition, yPosition, power, 1);
        temp[2] = getHLeft(xPosition, yPosition, power, 1);
        temp[3] = getHRight(xPosition, yPosition, power, 1);
        return temp;
    }
}
