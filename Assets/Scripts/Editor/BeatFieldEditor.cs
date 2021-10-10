using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TellYou.Game.Music;
public class BeatFieldEditor : EditorWindow
{
    static BeatFieldEditor instance;
    [MenuItem("Debug/BeatFieldEditor")]
    static void Open()
    {
        if (instance == null)
        {
            instance = EditorWindow.GetWindow<BeatFieldEditor>();
            instance.Show();
        }
    }

    static string bgmId = "toiminatonoyakei";
    void OnGUI()
    {
        if (!Application.isPlaying)
        {
            return;
        }

        if (GUILayout.Button("CreateBeat"))
        {
            MusicFieldManager.GetInstance().CreateBeat();
        }


        GUILayout.BeginHorizontal("box");
        {
            bgmId = EditorGUILayout.TextField("bgm id", bgmId);

            if(GUILayout.Button("Play BGM"))
            {
                SoundManager.GetInstance().PlayBGM(bgmId);
            }
        }
        GUILayout.EndHorizontal();
    }
}
