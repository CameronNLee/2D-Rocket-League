using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySpawner : MonoBehaviour
{
    public GameObject PrefabSmall;
    public GameObject PrefabMedium;
    public GameObject PrefabLarge;

    private int MAXNUM = 6;
    public static int count = 0;
    private float elapsedTime = 0;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        
        if(elapsedTime > 5 && count < MAXNUM)
        {

            float x = Random.Range(-21,22);
            float y = Random.Range(-13,14);
            Vector3 position = new Vector3(x, y, -1);
            var choice = Random.Range(1, 101);
            if(choice <= 50)
            {
                Instantiate(PrefabSmall, position, Quaternion.identity);
            }
            else if(choice > 80)
            {
                Instantiate(PrefabLarge, position, Quaternion.identity);
            }
            else
            {
                Instantiate(PrefabMedium, position, Quaternion.identity);

            }
           
            elapsedTime = 0f;
            count += 1;
        } 
        
    }
}
