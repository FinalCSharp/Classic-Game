using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookLineRender : MonoBehaviour
{
    LineRenderer lineRenderer;
    public float originX = 425, originY = 150;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 10f;
    }
    // Update is called once per frame
    void Update()
    {
        UpdataLine();
    }
    public void UpdataLine()
    {
        lineRenderer.SetPosition(0, new Vector2(originX, originY));
        lineRenderer.SetPosition(1, new Vector2(transform.position.x, transform.position.y + 10));//设置线条2点的位置
    }
}