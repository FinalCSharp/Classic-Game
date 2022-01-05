using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombAnimation : MonoBehaviour
{
    //Control the Bomb Blow up (count down) & Judge if the temp or Player Been Attack;
    private float Timer = 0f, BlowUpTime = 3.0f, MinSize_X, MaxSize_X, MinSize_Y, MaxSize_Y, t;
    private bool EnLarge = true;
    // Start is called before the first frame update
    void Start()
    {
        Timer = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if ((Time.time - Timer) == BlowUpTime) BlowUp();
        else
        {
            //Animation (Zoom);
            //I haven't check the Maxsize and Minsize dta;
            Vector3 Scale = this.transform.localScale;
            if (EnLarge)
            {
                Scale.x = Mathf.Lerp(MinSize_X, MaxSize_X, t);
                Scale.y = Mathf.Lerp(MinSize_Y, MaxSize_Y, t);
            }
            else
            {
                Scale.x = Mathf.Lerp(MaxSize_X, MinSize_X, t);
                Scale.y = Mathf.Lerp(MaxSize_Y, MinSize_Y, t);
            }
            if (Scale.x == MaxSize_X || Scale.x == MinSize_X) EnLarge = !EnLarge;
            transform.localScale = Scale;
        }
    }
    private void BlowUp()
    {
        //Judge Matrix & Destroy Bomb;
    }
}
