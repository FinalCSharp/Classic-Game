using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDropItem : MonoBehaviour
{
    public GameObject[] randomItem;
    public int prob;
    static System.Random rdm = new System.Random();
    public void DestroyIt()
    {
        if (rdm.Next() % 101 <= prob)
        {
            Instantiate(randomItem[rdm.Next() % randomItem.Length], transform.localPosition, Quaternion.Euler(0, 0, 0), transform.parent);
        }
        Destroy(transform.gameObject);
    }
}
