using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBomb : MonoBehaviour
{
    StatusPlayer statusPlayer;
    private void Start()
    {
        statusPlayer = GameObject.Find("ContextApi").GetComponent<StatusPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        statusPlayer.AdjustMaxBomb(GetPlayerCode.GetCode(collision.name), 1);
        Destroy(transform.gameObject);
    }
}
