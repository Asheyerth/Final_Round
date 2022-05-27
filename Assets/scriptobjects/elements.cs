using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elements 
{

    public GameObject obj;
    public int cost;
    public int lifepoints;
    public bool isdead;


    public static List<elements> blue = new List<elements>();
    public static List<elements> red = new List<elements>();
    public  elements(GameObject obje, int cost, int lifepnts, bool isdead)
    {
        this.obj = obje;
        this.cost = cost;
        this.lifepoints = lifepnts;
        this.isdead = isdead;

        
    }


    public List<elements> getblueelements()
    {
       
        return blue;
    }
    public List<elements> getredelements()
    {
       
        return red;
    }

    //public void discount(player ply, List<elements> elems)
    //{
    //    int pr = ply.money;
    //    foreach (var item in elems)
    //    {
    //        pr -= item.cost;
    //    }
    //    ply.money = pr;
    //}

    public void pritn(List<elements>eles)
    {
        eles.RemoveAll(items => items == null);
        Debug.Log("ELEMENTOS -------------");
        foreach (var item in eles)
        {
            Debug.Log(item.obj.name);
        }
    }




}
