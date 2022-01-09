using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToggle : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("Deletable(Clone)")) return;
        boxCollider2D.isTrigger = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name.Equals("Deletable(Clone)")) return;
        boxCollider2D.isTrigger = true;
    }
}
