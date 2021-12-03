using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public float speed;
    public bool modeRunActive;
    void Update()
    {

        if (modeRunActive)
        {
            Vector3 move = (new Vector3(-57.5f, 8) - transform.position).normalized;
            if (transform.position.x <= -57.5f)
                transform.position = new Vector3(-57.5f, 8);
            else
                transform.position += move * speed * Time.deltaTime;
        }
    }
}
