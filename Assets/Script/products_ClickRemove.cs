using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class products_ClickRemove : MonoBehaviour , IPointerClickHandler
{
    GameObject button;

    public void OnPointerClick(PointerEventData eventData)
    {
            Destroy(button);
    }

    // Start is called before the first frame update
    void Start()
    {
        button = transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
