using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimation : MonoBehaviour
{
    public GameObject[] Explosion;
    public float animateDuration = 1.5f;
    ExplosionCalculate explosionCalculate;
    BombIntIndex bombIntIndex;
    Transform []explosing;
    bool isAnimate = false;
    SpriteRenderer[]clr;
    Color defaultColor;
    public void Show()
    {
        Vector3 tp = transform.position;
        int[] bombIndex = bombIntIndex.getIndex(tp);
        int[] position = explosionCalculate.GetArea(bombIndex[0], bombIndex[1]);

        explosing[0] = Instantiate(Explosion[0], transform.localPosition - new Vector3(0, (bombIndex[1] - position[0])/2.0f, 0), Quaternion.Euler(0, 0, 0), transform).transform;
        explosing[1] = Instantiate(Explosion[0], transform.localPosition - new Vector3(0, (bombIndex[1] - position[1])/2.0f, 0), Quaternion.Euler(0, 0, 0), transform).transform;
        explosing[2] = Instantiate(Explosion[1], transform.localPosition - new Vector3((bombIndex[0] - position[2])/2.0f, 0, 0), Quaternion.Euler(0, 0, 0), transform).transform;
        explosing[3] = Instantiate(Explosion[1], transform.localPosition - new Vector3((bombIndex[0] - position[3])/2.0f, 0, 0), Quaternion.Euler(0, 0, 0), transform).transform;
        
        explosing[0].localScale = new Vector3(1, position[0] - bombIndex[1] + 1, 1);
        explosing[1].localScale = new Vector3(1, bombIndex[1] - position[1] + 1, 1);
        explosing[2].localScale = new Vector3(bombIndex[0] - position[2] + 1, 1, 1);
        explosing[3].localScale = new Vector3(position[3] - bombIndex[0] + 1, 1, 1);
        isAnimate = true;
        clr[0] = explosing[0].GetComponent<SpriteRenderer>();
        clr[1] = explosing[1].GetComponent<SpriteRenderer>();
        clr[2] = explosing[2].GetComponent<SpriteRenderer>();
        clr[3] = explosing[3].GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        explosing = new Transform[4];
        clr = new SpriteRenderer[4];
        bombIntIndex = GameObject.Find("ContextApi").GetComponent<BombIntIndex>();
        explosionCalculate = transform.GetComponent<ExplosionCalculate>();
    }
    float nowAlpha = 1;
    // Update is called once per frame
    void Update()
    {
        if (isAnimate)
        {
            nowAlpha -= 1 / animateDuration * Time.deltaTime;
            if(nowAlpha<= 0)
            {
                isAnimate = false;
                Destroy(transform.gameObject);
            }
            defaultColor = new Color(clr[0].color.r, clr[0].color.g, clr[0].color.b, nowAlpha);
            clr[0].color = clr[1].color = clr[2].color = clr[3].color = defaultColor;
        }
    }
}
