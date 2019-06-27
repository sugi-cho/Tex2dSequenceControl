using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RendererExtentions
{
    static MaterialPropertyBlock mpb { get { if (_mpb == null) _mpb = new MaterialPropertyBlock(); return _mpb; } }
    static MaterialPropertyBlock _mpb;
    public static void SetFloat(this Renderer r, string prop, float val)
    {
        r.GetPropertyBlock(mpb);
        mpb.SetFloat(prop, val);
        r.SetPropertyBlock(mpb);
    }
    public static void SetTexture(this Renderer r, string prop, Texture val)
    {
        r.GetPropertyBlock(mpb);
        mpb.SetTexture(prop, val);
        r.SetPropertyBlock(mpb);
    }
}
