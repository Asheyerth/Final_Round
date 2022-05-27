using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class soldier : MonoBehaviour
{


    [SerializeField] public float speed = 2f;
    private CornerPoints cpoints;
    private int cpointscount;
    private int cpointscount1;
    private bool canmove = true;
    
    
    private void Start()
    {
        
        cpoints = GameObject.FindGameObjectWithTag("corners").GetComponent<CornerPoints>();
        cpointscount1 = cpoints.cornerpoints.Length;
        cpointscount = 1;

    }

    private List<Vector2> visited = new List<Vector2>();
    private List<Vector2> visited1 = new List<Vector2>();

    private void FixedUpdate()
    {
        if (canmove)
        {
            if (canmove && cpointscount < cpoints.cornerpoints.Length - 1 && this.gameObject.name.Contains("red"))
            {
                move();

                if (Vector2.Distance(this.transform.position, cpoints.cornerpoints[cpointscount].position) < 0.1f && !visited.Contains(cpoints.cornerpoints[cpointscount].position))
                {
                    visited.Add(cpoints.cornerpoints[cpointscount].position);
                    cpointscount++;

                }

            }
            if (canmove && cpointscount1 - 1 > 0 && this.gameObject.name.Contains("blue"))
            {
                move();

                if (Vector2.Distance(this.transform.position, cpoints.cornerpoints[cpointscount1 - 1].position) < 0.1f && !visited1.Contains(cpoints.cornerpoints[cpointscount1 - 1].position))
                {
                    visited1.Add(cpoints.cornerpoints[cpointscount - 1].position);
                    cpointscount--;

                }
            }
        }        
        else
        {

            canmove = true;
        }

    }

    private void move()
    {             
            transform.position = Vector2.MoveTowards(this.transform.position, cpoints.cornerpoints[cpointscount].position, speed * Time.deltaTime);      
    }




}
