using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LayerUility
{
    static LayerMask? beatLayerMask;
    public static LayerMask BeatLayerMask
    {
        get
        {
            if(!beatLayerMask.HasValue)
            {
                beatLayerMask = LayerMask.GetMask("Beat");
            }

            return beatLayerMask.Value;
        }
    }
}
