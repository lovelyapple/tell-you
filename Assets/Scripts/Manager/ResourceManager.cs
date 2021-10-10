using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ResourceManager : NormalSingletoneBase<ResourceManager>
{
    public void LoadBgm(string id, Action<AudioSource> onLoad)
    {
        if (onLoad == null)
        {
            Debug.LogError("on load action is null");
        }
        
        var asset = Resources.Load<AudioSource>("BgmInGame/" + id);
        var newInstance = GameObject.Instantiate<AudioSource>(asset);

        if (onLoad != null)
        {
            onLoad(newInstance);
        }
    }
}
