using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public static new CameraControl camera;
    Animator anim;

    private void Awake()
    {
        camera = this;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ZoomIn()
    {
        anim.Play("CameraZoomIn");
    }
    public void ZoomOut()
    {
        anim.Play("CameraZoomOut");
    }
}
