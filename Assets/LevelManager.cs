using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update


    Vector3 dziura1 = new Vector3(17, 3, -9);
    public GameObject ZOMBIE_PREFAB;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       
            if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 3)
            {
                Instantiate(ZOMBIE_PREFAB, dziura1, transform.rotation);
            }
        

       
    }
    void Spawn()
    {
        
        
    }

    /*
 * ----------------------------------------------------------------------------
 * "THE BEER-WARE LICENSE" (Revision 42):
 * https://github.com/woodymapper wrote this file. As long as you retain this notice you
 * can do whatever you want with this stuff. If we meet some day, and you think
 * this stuff is worth it, you can buy me a beer in return WoodyMapper
 * ----------------------------------------------------------------------------
 */
}
