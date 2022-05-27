using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plasma : MonoBehaviour
{
  public static void Create(Vector3 spawnerPosition,  Vector3 targetp, Transform father)
    {
        Transform plasmaptrans= Instantiate(dragmovedrop.instance.pfplasma, spawnerPosition, Quaternion.identity, father);
        
        plasma projectileplasma = plasmaptrans.GetComponent<plasma>();
        projectileplasma.Setup(targetp);
    }

    private Vector3 targetps;

    private void Setup(Vector3 targetps)
    {
        this.targetps = targetps;
    }

    private void Update()
    {
        Vector3 movedir = (targetps - transform.position).normalized;
        float speed = 10f;
        transform.position += movedir * speed * Time.deltaTime;

        float destroy_dst = 1f;
        if (Vector3.Distance(transform.position, targetps)<destroy_dst)
        {
            Destroy(gameObject);
        }
    }
}
