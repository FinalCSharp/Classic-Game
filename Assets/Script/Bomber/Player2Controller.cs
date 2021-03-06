using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float runSpeed = 50;
    Rigidbody2D rb;
    BombGenerator bombGenerator;

    public void setRunSpeed(float value)
    {
        runSpeed += value;
    }
    // Start is called before the first frame update
    void Start()
    {
        bombGenerator = transform.GetComponent<BombGenerator>();
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.MovePosition(transform.localPosition + new Vector3(-runSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.MovePosition(transform.localPosition + new Vector3(runSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.MovePosition(transform.localPosition + new Vector3(0, runSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.MovePosition(transform.localPosition + new Vector3(0, -runSpeed * Time.deltaTime, 0));
        }
        int[] playerPosition = BombIntIndex.getIndex(transform.localPosition);
        if (Input.GetKey(KeyCode.KeypadEnter) && !TransformMatrix.matrix[playerPosition[0], playerPosition[1]])
        {
            bombGenerator.PlaceBomb();
        }
    }
}
