using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static SoundManager _instance;
    [SerializeField] GameObject seRootObj;
    [SerializeField] GameObject bgmRootObj;

    [SerializeField] AudioSource CurrentBGMSpource;
    void Awake()
    {
        _instance = this;

        if (seRootObj == null)
        {
            seRootObj = new GameObject("SERoot");
            seRootObj.transform.parent = this.transform;
        }

        if (bgmRootObj == null)
        {
            bgmRootObj = new GameObject("BGMRoot");
            bgmRootObj.transform.parent = this.transform;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    public static SoundManager GetInstance()
    {
        return _instance;
    }
    public static void PlayBGMImmediatly(string id)
    {
        SoundManager.GetInstance().PlayBGM(id);
    }
    public void PlayBGM(string id, bool immediatly = true)
    {
        if (CurrentBGMSpource != null)
        {
            CurrentBGMSpource.Stop();
        }

        CurrentBGMSpource = null;

        ResourceManager.GetInstance().LoadBgm(id, (s) =>
        {
            s.transform.parent = bgmRootObj.transform;
            s.Play();
            CurrentBGMSpource = s;
        });
    }
}
