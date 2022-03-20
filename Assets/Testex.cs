using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Testex : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        int width = 32;
        Texture2D srcTexture = new Texture2D(width, width);
        Cubemap cubemap = new Cubemap(width, TextureFormat.ARGB32, false);
        if (Camera.main.RenderToCubemap(cubemap)) {
            for (int j = 0; j < 6; j++) {

                Color[] cmmcolors= cubemap.GetPixels((CubemapFace)j);
                Color[] ReCmmcolors = new Color[cmmcolors.Length];
                for (int i = 1; i < width + 1; i++) Array.Copy(cmmcolors, width * (width - i), ReCmmcolors, width * (i - 1), width);
                srcTexture.SetPixels(ReCmmcolors);
                srcTexture.Apply();
                byte[] b = srcTexture.EncodeToPNG();
                File.WriteAllBytes(j.ToString() + "cube.png", b);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
