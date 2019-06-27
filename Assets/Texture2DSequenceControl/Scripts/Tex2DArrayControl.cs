using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Tex2DArrayControl : MonoBehaviour, ITimeControl
{
    public Texture2DArray tex2dArray { get; set; }
    public float fps = 30;

    new public Renderer renderer { get { if (_r == null) _r = GetComponent<Renderer>(); return _r; } }
    Renderer _r;

    public void OnControlTimeStart()
    {
        if (tex2dArray == null)
            tex2dArray = GetComponent<Texture2DArrayGenerator>().Generate();
        if (tex2dArray != null) 
            renderer.SetTexture("_MainTex", tex2dArray);
        renderer.SetFloat("_T", 1f);
    }

    public void OnControlTimeStop()
    {
        renderer.SetFloat("_T", 0);
    }

    public void SetTime(double time)
    {
        if (tex2dArray == null)
            return;
        var frame = (int)(time * fps);
        renderer.SetFloat("_F", frame);
    }

    void Start()
    {
        renderer.SetFloat("_T", 0);
    }

}
