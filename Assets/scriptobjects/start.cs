using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void onClick()
    {
        PlayerPrefs.SetInt("playernum", 1);
        SceneManager.LoadScene("new");
    }
}
