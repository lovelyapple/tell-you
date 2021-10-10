using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TellYou.Game.Music
{
    public class BeatObject : MonoBehaviour
    {
        public BeatType type;
        public BeatMoveState moveState;
        public BeatScoreState scoreState;
        public float speed;
        public void Setup(float speed)
        {
            this.speed = speed;
        }
        public void Update()
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        void OnTriggerEnter(Collider ohter)
        {
            if (ohter.gameObject.name == "PerfactArea")
            {
                scoreState = BeatScoreState.Perfact;
            }
            else if (ohter.gameObject.name == "EndArea")
            {
                GameObject.Destroy(this.gameObject);
            }
        }

        public void OnClick()
        {
            Debug.Log("click ddestory");
            GameObject.Destroy(this.gameObject);
        }
    }
}