using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ThreeSecondSwitchScene : MonoBehaviour
{
    public int target = 1;
    int time = 3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Three", 1, 1);
    }
    void Three()
    {
        time -= 1;
        if(time == -1)
        {
            SceneManager.LoadScene(target);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
