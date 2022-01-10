using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class products_ClickRemove : MonoBehaviour , IPointerClickHandler
{
    GameObject button;
    public int itemcode = -1;
    private int cost;
    GameObject hook;
    Score score;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (score.IsLegalBuy(cost))
        {
            Destroy(button);
            if(itemcode == 1)
            {
                score.SendMessage("setBuff", 1);
            }
            else
            {
                hook.SendMessage("setBuff",0.35);
            }
            score.setScore(-cost);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        hook = GameObject.Find("Hook");
        cost = Random.Range(50, 151);
        transform.Find("cashFlow").GetComponent<Text>().text = "$" + System.Convert.ToString(cost);
        score = GameObject.Find("Score").GetComponent<Score>();
        button = transform.gameObject;
    }
}
