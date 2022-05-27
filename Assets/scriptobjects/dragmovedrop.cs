using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CreateDragDrop
public class dragmovedrop : MonoBehaviour
{
    
    private Vector3 _dragOffset;
    private Vector2 _originalPosition;
    private Vector3 shootfromposition;

    private GameObject _objtc;
    //public List<elements> _listobjects=new List<elements>();


    public int price=0;//precio
    public int lifepoint=0;//lifepoint
    public bool isdead=false;//está muerto


    [SerializeField] public Transform plasmaspawner;
    [SerializeField] public Transform pfplasma;


    public elements elem;
    
    private float speed = 20;

    public static dragmovedrop instance;

    
    private void Awake()
    {
        this._objtc = this.gameObject;
        instance = this;


        ////shootfromposition = transform.position;//transform.Find("towershot").position;
        //if (transform.Find("towershot"))
        //{
        //    shootfromposition = transform.Find("towershot").position;
        //}
        

    }



    //Update
    //if (Input.GetMouseButtonDown(0))
    //{
    //    Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    plasma.Create(shootfromposition,mousepos);
    //}

    //private void Update()
    //{

    //    if (Input.GetMouseButtonDown(1))
    //    {

    //        shootfromposition = transform.Find("towershow").position;
    //        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        plasma.Create(shootfromposition, mousepos, _objtc.transform);


    //    }

    //}






    private void OnMouseDown()
    {

        mousedwn();
       
      
    }

    public void mousedwn()
    {
        
        if (Input.GetMouseButton(0)&& !this.gameObject.name.Contains("(Clone)"))
        {
            if (this.gameObject.name.Contains("soldier"))
            {
                ifsoldier(this.gameObject);
            }
          
                
          
            _objtc = Instantiate(this.gameObject, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            
            _dragOffset = transform.position - GetMousePos();

         
        }
        else if (Input.GetMouseButtonDown(0)&& this.gameObject.name.Contains("(Clone)"))
        {
            if (this.gameObject.name.Contains("blue"))
            {
                foreach (var item in elements.blue)
                {
                    if (item.obj == _objtc)
                    {
                       
                        Destroy(item.obj);
                        elements.blue.Remove(item);

                        elements.blue.RemoveAll(items => items == null);
                        
                        break;
                    }
                }
            }
             if (this.gameObject.name.Contains("red"))
            {
                foreach (var item in elements.red)
                {
                    if (item.obj == _objtc)
                    {
                       
                        Destroy(item.obj);
                        elements.red.Remove(item);

                        elements.red.RemoveAll(items => items == null);
                        break;
                    }
                }
            }

            

        }

    }

    public void ifsoldier(GameObject obj)
    {
        if (obj.name.Contains("soldier"))
        {
                elem = new elements(obj.gameObject, player.instance.prices(obj.gameObject, price), player.instance.lifepoints(obj.gameObject, lifepoint), isdead);
                Debug.Log(elem.obj.name + elem.cost);
                addelement(elem);
            
        }
    }

    public void addelement(elements ele)
    {
        if (ele != null)
        {
            if (ele.obj.name.Contains("blue"))
            {
                int temp = mapManager.blue.money;
                temp -= ele.cost;
                mapManager.blue.money = temp;
                Debug.Log("BLUEMOEY: "+mapManager.blue.money);
                elements.blue.Add(ele);
            }
            if (ele.obj.name.Contains("red"))
            {
                int temp = mapManager.red.money;
                temp -= ele.cost;
                mapManager.red.money =temp;
                Debug.Log("REDMONEY: " + mapManager.red.money);
                elements.red.Add(ele);
            }
            
        }

    }

    private void OnMouseDrag()
    {
     
      _objtc.transform.position = Vector3.MoveTowards(_objtc.transform.position, GetMousePos() + _dragOffset, speed * Time.deltaTime);
    }

    private void OnMouseUp()
    {
        Vector3 h = Vector3.zero;
        
        if (_objtc.tag == "tower")
        {

            h = mapManager.instance.gridtowerpos(_objtc.transform.position, _objtc);
        }
        else if (_objtc.tag == "barrier")
        {
            h = mapManager.instance.gridroadpos(_objtc.transform.position, _objtc);
        }
        else if (_objtc.tag == "corecrystal")
        {
            h = mapManager.instance.gridcorepos(_objtc.transform.position, _objtc);
        }
        

        if (h == Vector3.zero)
        {
            
            Destroy(_objtc);
            Debug.Log("No se puede colocar");
        }
        else
        {
            _objtc.transform.position = h;
            
             elem=new elements(_objtc, player.instance.prices(_objtc, price), player.instance.lifepoints(_objtc, lifepoint), isdead );

            addelement(elem);

            elem.pritn(elem.getblueelements());
            elem.pritn(elem.getredelements());

          
        }
    }

    Vector3 GetMousePos()
    {
        var mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = 0;
        return mousepos;
    }

   
   
}
