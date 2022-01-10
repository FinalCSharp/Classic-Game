using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    //Every Player Have a Bomb Generator.
    // Start is called before the first frame update
    public GameObject Bomb;
    public int thisPlayerLabel = -1;
    StatusPlayer statusPlayer;
    void Start() {
        statusPlayer = GameObject.Find("ContextApi").GetComponent<StatusPlayer>();
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void PlaceBomb()
    {
        if (statusPlayer.CanPutBomb(thisPlayerLabel))
        {
            int[] position = BombIntIndex.getIndex(transform.localPosition);
            statusPlayer.PutBomb(thisPlayerLabel);
            Transform tf = Instantiate(Bomb, new Vector3(position[0] - 7, position[1] - 4.5f, 0), Quaternion.Euler(0, 0, 0)).transform;
            TransformMatrix.SetMatrix(position[0], position[1], tf);
        }
    }

}