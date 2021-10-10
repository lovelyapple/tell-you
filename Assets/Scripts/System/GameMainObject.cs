using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TellYou.System
{
    public class GameMainObject : MonoBehaviour
    {
        private static GameMainObject _instance;
        public void Awake()
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);

            InitializeManager();
        }

        public GameMainObject GetInstance()
        {
            return _instance;
        }

        void InitializeManager()
        {
            //monobehavior
            TellYou.Game.Music.MusicFieldManager.SetInstance();

            //normal
            ResourceManager.SetInstance(new ResourceManager());
        }
    }
}