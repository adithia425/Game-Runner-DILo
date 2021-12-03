using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeRun : MonoBehaviour
{
    public GameObject ground1;
    public GameObject ground2;

    public bool modeRunActive;

    void Update()
    {
        if (modeRunActive)
        {
            ModeRunActive();
        }
    }
    void ModeRunActive()
    {
        if (ground1.transform.position.x == -57.5f)
        {
            ground1.transform.position = new Vector2(57.5f, 8);
            ground2.transform.position = new Vector2(0, 8);
        }
        else if (ground2.transform.position.x == -57.5f)
        {
            ground2.transform.position = new Vector2(57.5f, 8);
            ground1.transform.position = new Vector2(0, 8);
        }
    }

    public void ModeRunOn()
    {
        modeRunActive = true;
        ground1.GetComponent<MoveGround>().modeRunActive = true;
        ground2.GetComponent<MoveGround>().modeRunActive = true;
    }
    public void ModeRunOff()
    {
        modeRunActive = false;
        ground1.GetComponent<MoveGround>().modeRunActive = false;
        ground2.GetComponent<MoveGround>().modeRunActive = false;
    }

}
