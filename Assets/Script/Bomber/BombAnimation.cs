using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombAnimation : MonoBehaviour
{
    //Control the Bomb Blow up (count down) & Judge if the temp or Player Been Attack;
    public float BlowUpTime = 3.0f, MinSize_X, MaxSize_X, MinSize_Y, MaxSize_Y, AnimationPeriod;
    float Timer = 0f, t;
    private bool EnLarge = true;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        Timer = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if ((Time.time - Timer) >= BlowUpTime) BlowUp();
        else
        {
            //Animation (Zoom);
            //I haven't check the Maxsize and Minsize dta;
            Vector3 Scale = this.transform.localScale;
            if (EnLarge)
            {
                Scale.x = Mathf.Lerp(MinSize_X, MaxSize_X, t/ AnimationPeriod);
                Scale.y = Mathf.Lerp(MinSize_Y, MaxSize_Y, t/ AnimationPeriod);
            }
            else
            {
                Scale.x = Mathf.Lerp(MaxSize_X, MinSize_X, t/ AnimationPeriod);
                Scale.y = Mathf.Lerp(MaxSize_Y, MinSize_Y, t/ AnimationPeriod);
            }
            if (Scale.x == MaxSize_X || Scale.x == MinSize_X) EnLarge = !EnLarge;
            transform.localScale = Scale;
        }
    }
    private void BlowUp()
    {
        try
        {
            parent.SendMessage("Show");
        }
        catch (System.Exception) { }
        Destroy(transform.gameObject);
        //Judge Matrix & Destroy Bomb;
    }
}
