using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player :MonoBehaviour
{

    public  List<elements> objetos;
    public  int money;
    public int numplayer;
    public static player instance;
    public GameObject playernum;

    public static List<player> playersinplay = new List<player>();


    public  player(int numplayer, List<elements> components, int money)
    {
        this.numplayer = numplayer;
        this.objetos = components;
        this.money = money;
    }

    private void Awake()
    {
        instance = this;
    }

    public int prices(GameObject objeto, int price)
    {
        if (objeto.tag=="tower")
        {
            if (objeto.name.Contains("1"))
            {
                return price = 30;
            }else if (objeto.name.Contains("2"))
            {
                return price = 50;
            }
        }
        if (objeto.tag=="barrier")
        {
            if (objeto.name.Contains("1"))
            {
                return price = 20;
            }
            else if (objeto.name.Contains("2"))
            {
                return price = 25;
            }
        }
        if (objeto.tag=="corecrystal")
        {
            return price = 0;
        }
        if (objeto.tag=="soldier")
        {
            if (objeto.name.Contains("1"))
            {
                return price = 5;
            }
            else if (objeto.name.Contains("2"))
            {
                return price = 10;
            }
            else if (objeto.name.Contains("3"))
            {
                return price = 15;
            }

        }

        return 0;
    } public int lifepoints(GameObject objeto, int lifepnts)
    {
        if (objeto.tag=="tower")
        {
            if (objeto.name.Contains("1"))
            {
                return lifepnts = 30;
            }else if (objeto.name.Contains("2"))
            {
                return lifepnts = 50;
            }
        }
        if (objeto.tag=="barrier")
        {
            if (objeto.name.Contains("1"))
            {
                return lifepnts = 20;
            }
            else if (objeto.name.Contains("2"))
            {
                return lifepnts = 25;
            }
        }
        if (objeto.tag=="corecrystal")
        {
            return lifepnts = 0;
        }
        if (objeto.tag=="soldier")
        {
            if (objeto.name.Contains("1"))
            {
                return lifepnts = 5;
            }
            else if (objeto.name.Contains("2"))
            {
                return lifepnts = 10;
            }
            else if (objeto.name.Contains("3"))
            {
                return lifepnts = 15;
            }

        }

        return 0;
    }
    
}
