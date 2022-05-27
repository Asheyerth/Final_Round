using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideplayers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    public void onClick()
    {
        

        if (this.name.Contains("1"))
        {
            foreach (var item in elements.blue)
            {
                item.obj.SetActive(false);
            }  

        }

        if (this.name.Contains("2"))
        {
            foreach (var item in elements.red)
            {
                item.obj.SetActive(false);
            }
        }
    }
}
