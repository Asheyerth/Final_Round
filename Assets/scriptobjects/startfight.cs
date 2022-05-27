using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startfight : MonoBehaviour
{
    [SerializeField] private GameObject blue_soldier1;
    [SerializeField] private GameObject blue_soldier2;
    [SerializeField] private GameObject blue_soldier3;

    [SerializeField] private GameObject red_soldier1;
    [SerializeField] private GameObject red_soldier2;
    [SerializeField] private GameObject red_soldier3;

    private float bfloat1 = 1f;
    private float bfloat2 = 2f;
    private float bfloat3 = 3f;

    private CornerPoints cpoints;
    private GameObject father;
    // Start is called before the first frame update

    
    private void Start()
    {

        cpoints = GameObject.FindGameObjectWithTag("corners").GetComponent<CornerPoints>();



    }

    private IEnumerator spawnplayers(float interval, GameObject player)
    {
        yield return new WaitForSeconds(interval);
        if (player.name.Contains("blue"))
        {
            GameObject new_blue = Instantiate(player, cpoints.cornerpoints[cpoints.cornerpoints.Length-1].position, Quaternion.identity);
        }
        if (player.name.Contains("red"))
        {
            GameObject new_red = Instantiate(player, cpoints.cornerpoints[0].position, Quaternion.identity);
        }
      
     
    }

    public void Onclick()
    {
        foreach (var item in elements.blue)
        {
            if (item.obj.name.Contains("soldier"))
            {
                if (item.obj.name.Contains("1"))
                {
                    StartCoroutine(spawnplayers(bfloat1, blue_soldier1));
                }
                if (item.obj.name.Contains("2"))
                {
                    StartCoroutine(spawnplayers(bfloat2, blue_soldier2));
                }
                if (item.obj.name.Contains("3"))
                {
                    StartCoroutine(spawnplayers(bfloat3, blue_soldier3));
                }

            }
        }
          foreach (var item in elements.red)
        {
            if (item.obj.name.Contains("soldier"))
            {
                if (item.obj.name.Contains("1"))
                {
                    StartCoroutine(spawnplayers(bfloat1, red_soldier1));
                }
                if (item.obj.name.Contains("2"))
                {
                    StartCoroutine(spawnplayers(bfloat2, red_soldier2));
                }
                if (item.obj.name.Contains("3"))
                {
                    StartCoroutine(spawnplayers(bfloat3, red_soldier3));
                }

            }
        }

    }

  
}
