using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Texture2DArrayGenerator : MonoBehaviour
{
    public string tex2dsPath;
    public Texture2DArray tex2dArray;

    [Header("set tex to renderer")]
    public Renderer[] targetRenderers;
    public string propName = "_MainTex";

    public Texture2DArrayEvent onCreate;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    public Texture2DArray Generate()
    {
        var tex2ds = Resources.LoadAll<Texture2D>(tex2dsPath);
        var w = tex2ds[0].width;
        var h = tex2ds[0].height;
        var d = tex2ds.Length;
        var format = tex2ds[0].format;
        tex2dArray = new Texture2DArray(w, h, d, format, 1 < tex2ds[0].mipmapCount);

        tex2ds = tex2ds.OrderBy(tex => tex.name).ToArray();
        for (var i = 0; i < d; i++)
            Graphics.CopyTexture(tex2ds[i], 0, tex2dArray, i);

        var mpb = new MaterialPropertyBlock();
        foreach (var r in targetRenderers)
        {
            r.GetPropertyBlock(mpb);
            mpb.SetTexture(propName, tex2dArray);
            r.SetPropertyBlock(mpb);
        }

        onCreate.Invoke(tex2dArray);
        return tex2dArray;
    }

    private void OnDestroy()
    {
        Destroy(tex2dArray);
    }

    [System.Serializable]
    public class Texture2DArrayEvent : UnityEvent<Texture2DArray> { }
}