using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    int Min = -3;
    int Max = 4;
    int Movement = 1;
    int EnemySpeed = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0f, 0f, Movement * EnemySpeed * Time.deltaTime);

        if (transform.position.z < Min) 
        {
            Movement = 1;
        }

        if (transform.position.z >= Max)
        {
            Movement = -1;
        }
      
    }
} 