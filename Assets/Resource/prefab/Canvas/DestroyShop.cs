using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DestroyShop : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    public void OnPointerClick(PointerEventData e)
    {
        Destroy(transform.parent.gameObject);
        GameObject.Find("spawner").SendMessage("reset");
        GameObject.Find("CountDown").SendMessage("reset");
        //set another level target && other config
        GameObject.Find("spawner").SendMessage("Spawn");
        GameObject.Find("TopBar").SendMessage("NextLevel");
    }
}
