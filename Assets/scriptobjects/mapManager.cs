using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class mapManager : MonoBehaviour
{
    [SerializeField] private Tilemap roads;
    [SerializeField] private Tilemap cores;
    [SerializeField] private Tilemap cores2;
    [SerializeField] private Tilemap towers;
    [SerializeField] private Tilemap towers2;


    public static mapManager instance;
    [SerializeField] public List<TileData> tiledata;

    public List<Vector3> tileworldpositions;
    public Dictionary<TileBase, TileData> datafromtiles;

    

    public static player blue;
    public static player red;
    public static List<elements> players_blue = new List<elements>();
    public static List<elements> players_red = new List<elements>();
    private void Awake()
    {
        instance = this;
        datafromtiles = new Dictionary<TileBase, TileData>();
        tileworldpositions = new List<Vector3>();

        foreach (var tiled in tiledata)
        {
            foreach (var tile in tiled.tiles)
            {
                datafromtiles.Add(tile, tiled);  
            }
        }
        

       
    }
   
    public void Start()
    {
        

        blue = new player(1, elements.blue, 200);
        red = new player(2, elements.red, 200);
       
        
    }

    public void FixedUpdate()
    {
            
    }


    public Vector3 gridtowerpos(Vector3 actposition, GameObject gob)
    {
        try
        {
            if (gob.name.Contains("blue"))
            {
                Vector3Int gridpos = towers.WorldToCell(actposition);
                TileBase tile = towers.GetTile(gridpos);
                bool istower = datafromtiles[tile].istower;

                if (tile.name == "towerside" && istower)
                {

                    Vector3 pos = towers.GetCellCenterWorld(gridpos);
                    pos.y += (float)0.5;

                    return pos;
                }
            }
            else if (gob.name.Contains("red"))
            {
                Vector3Int gridpos1 = towers2.WorldToCell(actposition);
                TileBase tile1 = towers2.GetTile(gridpos1);
                bool istower1 = datafromtiles[tile1].istower;
                if (tile1.name == "towerside2" && istower1)
                {

                    Vector3 pos = towers2.GetCellCenterWorld(gridpos1);
                    pos.y += (float)0.5;

                    return pos;
                }
            }
       
            
        }
        catch (System.Exception )
        {

            return Vector3.zero;
        };
        return Vector3.zero;
   
    }

    public Vector3 gridcorepos(Vector3 actposition, GameObject tag)
    {

        try
        {
            if (tag.name.Contains("blue"))
            {
                Vector3Int gridpos = cores.WorldToCell(actposition);
                TileBase tile = cores.GetTile(gridpos);
                bool iscore = datafromtiles[tile].iscore;

                if (tile.name == "sandCores" && iscore)
                {

                    Vector3 pos = cores.GetCellCenterWorld(gridpos);
                    pos.y += (float)0.5;
                    
                    return pos;
                }
            }else if (tag.name.Contains("red"))
            {
                Vector3Int gridpos = cores2.WorldToCell(actposition);
                TileBase tile = cores2.GetTile(gridpos);
                bool iscore = datafromtiles[tile].iscore;
                if (tile.name == "snowcore" && iscore)
                {

                    Vector3 pos = cores2.GetCellCenterWorld(gridpos);
                    pos.y += (float)0.5;
                    
                    return pos;
                }
            }
           
        }
        catch (System.Exception)
        {

            return Vector3.zero;
        };
        return Vector3.zero;

    }

    public Vector3 gridroadpos(Vector3 actposition, GameObject tag)
    {
        try
        {

            Vector3Int gridpos = roads.WorldToCell(actposition);
            TileBase tile = roads.GetTile(gridpos);


            bool isroad = datafromtiles[tile].isroad;
            if (tile.name == "walkround" && isroad && tag.tag == "barrier")
            {

                Vector3 pos = roads.GetCellCenterWorld(gridpos);
                pos.y += (float)0.2;
                
                return pos;
            }
            
         
        }
        catch (System.Exception)
        {
            return Vector3.zero;
        };

        return Vector3.zero;
    }

    public Vector3 getcellroadposs(Vector3 actposition, Tilemap tail)
    {
        Vector3Int gridpos = tail.WorldToCell(actposition);
        TileBase tile = tail.GetTile(gridpos);

        Vector3 pos = tail.GetCellCenterWorld(gridpos);
        
        return pos;      

    }



}


