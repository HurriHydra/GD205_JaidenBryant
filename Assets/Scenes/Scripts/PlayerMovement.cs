using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w")) // works
        {


            if (transform.position.x >= 3f)
            {
                //do nothing lol
            }
            else
            {
                transform.position += new Vector3(1f, 0f, 0f);
                transform.rotation = Quaternion.AngleAxis(180, Vector3.up); //transform.Rotate(0.0f, 180.0f, 0.0f);
            }
        }

        if (Input.GetKeyDown("d"))
        {
            if (transform.position.z < -1f)
            {
                //do nothing lol
            }
            else
            {
                transform.position += new Vector3(0f, 0f, -1f);
                transform.rotation = Quaternion.AngleAxis(-90, Vector3.up); //transform.Rotate(0.0f, -90.0f, 0.0f);
            }
        }

        if (Input.GetKeyDown("a")) // this works
        {
            if (transform.position.z >= 3f)
            {
                //do nothing lol
            }
            else
            {
                transform.position += new Vector3(0f, 0f, 1f);
                transform.rotation = Quaternion.AngleAxis(90, Vector3.up); //transform.Rotate(0.0f, 90.0f, 0.0f);
            }
        }

        if (Input.GetKeyDown("s"))
        {
            if (transform.position.x < -2f)
            {
                //do nothing lol
            }
            else
            {
                transform.position += new Vector3(-1f, 0f, 0f);
                transform.rotation = Quaternion.AngleAxis(0, Vector3.up); //transform.Rotate(0.0f, 0.0f, 0.0f);
            }

        }
    }
}// Getting the character to turn the right way without messing up had to be the most annoying thing about the script :V