using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject Bgold, Mgold, Sgold, Bstone, Mstone, Sstone, Qpack;
    public int level;
    public int bgold, mgold, sgold, bstone, mstone, sstone, qPckNum;
    System.Random rdm = new System.Random();
    private GameObject newObject(int type, int size)
    {
        GameObject label;
        switch (type)
        {
            case 1:
                label = Instantiate(Bgold);
                break;
            case 2:
                label = Instantiate(Mgold);
                break;
            case 3:
                label = Instantiate(Sgold);
                break;
            case 4:
                label = Instantiate(Bstone);
                break;
            case 5:
                label = Instantiate(Mstone);
                break;
            case 6:
                label = Instantiate(Sstone);
                break;
            case 7:
                label = Instantiate(Qpack);
                break;
            default:
                label = Instantiate(Sstone);
                break;
        }
        return label;
    }
    private int MaxWidth, MaxHeight;
    private double radius = 350;
    struct pack
    {
        public int x, y, size, margin, betweenDistance, maxStone;
        public GameObject label;
    }
    private List<pack> biggoldlist = new List<pack>();
    private List<pack> goldlist = new List<pack>();
    private List<pack> buildList = new List<pack>();
    private List<pack> combinedlist = new List<pack>();
    public void setObjNum(int []value)
    {
        bgold = value[0];
        mgold = value[1];
        sgold = value[2];
        bstone = value[3];
        mstone = value[4];
        sstone = value[5];
        qPckNum = value[6];
    }
    public void reset()
    {
        biggoldlist.Clear();
        buildList.Clear();
        combinedlist.Clear();

        for (int i = 0; i < transform.childCount; i++) Destroy(transform.GetChild(i).gameObject);
    }
    public void Spawn()
    {
        spawn();//pending
        // GameObject.Find("Obj").SendMessage("spawned"); //here is use to send the message that the map has been spawn
        GameObject.Find("CountDown").SendMessage("start");
    }
    private bool isEmpty(int x, int y, int size, List<pack> ls, bool isSameItem)
    {
        bool returnValue = true;
        foreach (pack pck in ls)
        {
            bool lefttop = x >= pck.x - pck.margin && x <= pck.x + pck.margin + pck.size && y >= pck.y - pck.margin && y <= pck.y + pck.margin + pck.size;
            bool righttop = x + size >= pck.x - pck.margin && x + size <= pck.x + pck.margin + pck.size && y >= pck.y - pck.margin && y <= pck.y + pck.margin + pck.size;
            bool rightbottom = x + size >= pck.x - pck.margin && x + size <= pck.x + pck.margin + pck.size && y + size >= pck.y - pck.margin && y + size <= pck.y + pck.margin + pck.size;
            bool leftbottom = x >= pck.x - pck.margin && x <= pck.x + pck.margin + pck.size && y + size >= pck.y - pck.margin && y + size <= pck.y + pck.margin + pck.size;
            bool distance = System.Math.Sqrt(System.Math.Pow(System.Math.Abs(x - pck.x), 2) + System.Math.Pow(System.Math.Abs(y - pck.y), 2)) >= pck.betweenDistance;
            if ((lefttop || rightbottom || righttop || leftbottom) || (!distance && isSameItem))
            {
                returnValue = false;
                break;
            }
        }
        return returnValue;
    }
    
    private double getAbs(double x, double MaxHeight)
    {
        double tp = 0;
        if (x == MaxHeight)
            tp = 1;
        else if (x < MaxHeight)
        {
            tp = 1 - (MaxHeight - x) / MaxHeight;
        }
        else
        {
            tp = 1 - (x - MaxHeight) / MaxHeight;
        }
        return tp;
    }
    private void buildGold(int tp, int type, bool isBigBig, int size, int margin, double distance)
    {
        List<pack> ls;
        if (isBigBig)
            ls = biggoldlist;
        else
            ls = goldlist;
        ls.Clear();
        int tx = 0, ty = 0;
        while (tp > 0)
        {
            int counter = 0;
            bool isLegal = true;
            do
            {
                if (isBigBig)
                {
                    tx = rdm.Next(0, MaxWidth - 50 + 1);
                    int min = System.Convert.ToInt32(radius * getAbs(tx, MaxWidth / 2));

                    ty = rdm.Next((min + level * 2 > MaxHeight-50 ) ? 550 : min + level * 2, MaxHeight + 1);
                }
                else
                {
                    tx = rdm.Next(0, MaxWidth - 50 + 1);
                    ty = rdm.Next(0, MaxHeight - 50 + 1);
                }
                counter++;
                if (counter >= 1000)
                {
                    isLegal = false;
                    break;
                }
            }
            while (!isEmpty(tx, ty, 100, biggoldlist, false) || !isEmpty(tx, ty, 100, combinedlist, false) || !isEmpty(tx, ty, 100, ls, true));
            if (!isLegal)
                buildGold(tp, type, isBigBig, size, margin, distance);
            else
            {
                GameObject tpLabel = newObject(type, size);
                tpLabel.transform.position = new Vector2(tx, -ty);
                tpLabel.transform.parent = transform;
                pack newPack;
                newPack.x = tx;
                newPack.y = ty;
                newPack.maxStone = 3 + level * 3 / 10;
                newPack.size = size;
                newPack.margin = margin;
                newPack.betweenDistance = System.Convert.ToInt32(distance);
                newPack.label = tpLabel;
                ls.Add(newPack);
                tp--;
            }
        }
    }
    private void build(int tp, int type, int size, int margin, double distance)
    {
        buildList.Clear();
        int tx, ty;
        int round_count = 0;
        bool restart = false;
        while (tp > 0)
        {
            int counter = 0;
            bool isLegal = true;

            int yAxis = rdm.Next(level / 10, 101);
            if (yAxis >= 50)
            {
                if (biggoldlist.Count <= 0) continue;
                int index = rdm.Next(0, biggoldlist.Count);
                while (biggoldlist[index].maxStone <= 0)
                {
                    index = rdm.Next(0, biggoldlist.Count);
                }
                do
                {
                    tx = rdm.Next((biggoldlist[index].x - 50 - counter < 0) ? 0 : biggoldlist[index].x - 50 - counter, (biggoldlist[index].x + biggoldlist[index].size + 50 + counter > MaxWidth) ? MaxWidth : biggoldlist[index].x + biggoldlist[index].size + 50 + counter);
                    int min = System.Convert.ToInt32((biggoldlist[index].margin + biggoldlist[index].size) * (1 - getAbs(tx, biggoldlist[index].x + biggoldlist[index].size / 2)));
                    counter++;
                    ty = rdm.Next(biggoldlist[index].y - min, biggoldlist[index].y + biggoldlist[index].size * 75 / 100);
                    if (counter >= 1000)
                    {
                        isLegal = false;
                        break;
                    }
                    round_count++;
                    if (round_count >= 2000)
                    {
                        restart = true;
                        break;
                    }
                } while (ty < 50||!isEmpty(tx, ty, 15, combinedlist, false) || !isEmpty(tx, ty, 15, biggoldlist, false) || !isEmpty(tx, ty, 15, buildList, true));
            }
            else
            {
                do
                {
                    tx = rdm.Next(0, MaxWidth - 50 + 1);

                    ty = rdm.Next(0, 550 + 1);
                    counter++;
                    if (counter >= 1000)
                    {
                        isLegal = false;
                        break;
                    }
                    round_count++;
                    if (round_count >= 2000)
                    {
                        restart = true;
                        break;
                    }
                }
                while (!isEmpty(tx, ty, 15, combinedlist, false) || !isEmpty(tx, ty, 15, biggoldlist, false) || (!isEmpty(tx, ty, 15, buildList, true)));
            }
            if (!isLegal)
                build(tp, type, size, margin, distance);
            else
            {
                GameObject tpLabel = newObject(type, size);
                tpLabel.transform.position = new Vector2(tx, -ty);
                tpLabel.transform.parent = transform;
                pack newPack;
                newPack.x = tx;
                newPack.y = ty;
                newPack.maxStone = 0;
                newPack.size = size;
                newPack.margin = margin;
                newPack.betweenDistance = System.Convert.ToInt32(distance);
                newPack.label = tpLabel;
                buildList.Add(newPack);
                tp--;
            }
        }
        if (restart)
            spawn();
    }
    
    private void combine(List<pack> targetList, List<pack> list, bool isFree)
    {
        foreach (pack tp in list) targetList.Add(tp);
        if (isFree)
            list.Clear();
    }
    private void spawn()
    {
        reset();
        int QpackNum = rdm.Next() % (qPckNum + 1);
        build(QpackNum, 7, 35, 80, MaxWidth * 0.45);//build Qpack
        combine(combinedlist, buildList, true);
        buildGold(bgold, 1, true, 100, 50, MaxWidth * 0.45);//biggoldlist should not be combied XD...
        buildGold(mgold, 2, false, 35, 50, MaxWidth * 0.05);
        combine(combinedlist, goldlist, true);
        buildGold(sgold, 3, false, 25, 50, MaxWidth * 0.05);
        combine(combinedlist, goldlist, true);
        build(bstone, 4, 45, 80, MaxWidth * 0.1);//big stone
        combine(combinedlist, buildList, true);
        build(mstone, 5, 35, 60, MaxWidth * 0.05);
        combine(combinedlist, buildList, true);
        build(sstone, 6, 25, 60, MaxWidth * 0.05);
        combine(combinedlist, buildList, true);
    }
    // Start is called before the first frame update
    void Start()
    {
        MaxWidth = 900; MaxHeight = 550;
        bgold = Random.Range(1, 2);
        mgold = Random.Range(1, 3);
        sgold = Random.Range(1, 6);
        bstone = Random.Range(1, 2);
        mstone = Random.Range(1, 3);
        sstone = Random.Range(1, 6);
        qPckNum = 1;
        spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
