using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LayerExtensions
{
    public static int ToLayer(this LayerMask layerMask)
    {
        int layerNumber = 0;
        int layer = layerMask.value;
        while (layer > 0)
        {
            layer = layer >> 1;
            layerNumber++;
        }
        return layerNumber - 1;
    }

    public static LayerMask ToLayerMask(this int indexLayer)
    {
        return 1 << indexLayer;
    }

    public static LayerMask GetPhysicsLayerMask(this int currentLayer)
    {
        int finalMask = 0;
        for (int i = 0; i < 32; i++)
        {
            if (!Physics.GetIgnoreLayerCollision(currentLayer, i))
            {
                finalMask = finalMask | (1 << i);
            }
        }
        return finalMask;
    }

    public static bool Contains(this LayerMask layerMask, int layer)
    {
        return layerMask == (layerMask | (1 << layer));
    }
}
