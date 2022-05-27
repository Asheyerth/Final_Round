using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{

    private Camera _camara;
    public static DragDrop instance;
    private Vector3 _dragOffset;
    private Vector2 _originalPosition;
    //private GameObject _object;

    [SerializeField] private float speed = 20;
    private void Awake()
    {
        _camara = Camera.main;
        instance = this;
    }

    //public DragDrop(GameObject _object)
    //{
    //    this._object = _object;
    //}

    void OnMouseDrag()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, speed * Time.deltaTime);
    }

    Vector3 GetMousePos()
    {
        var mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = 0;
        return mousepos;
    }

    private void OnMouseDown()
    {
        _originalPosition = transform.position;
        Debug.Log("ORIGINAL" + _originalPosition);
        _dragOffset = transform.position - GetMousePos();

    }


    private void OnMouseUp()
    {
        Vector3 h = Vector3.zero;

        if (this.gameObject.tag=="tower")
        {
            h = mapManager.instance.gridtowerpos(this.transform.position, this.gameObject);
        }
        else if(this.gameObject.tag=="barrier"){
            h = mapManager.instance.gridroadpos(this.transform.position, this.gameObject);
        }
        else if (this.gameObject.tag=="corecrystal")
        {
            h = mapManager.instance.gridcorepos(this.transform.position, this.gameObject);
        }
        

        if (h == Vector3.zero)
        {
            transform.position = _originalPosition;
            Debug.Log(_originalPosition);
        }
        else
        {
            transform.position = h;
            Debug.Log("nueva posición " + h);
        }
    }


  
}
