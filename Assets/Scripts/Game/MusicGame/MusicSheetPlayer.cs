using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TellYou.Game.Music
{
    public class BeatRecord
    {
        public uint index;
        public BeatType beatType;
        public float spawnTime;
        public float offset;
    }

    public class MusicSheetPlayer : MonoBehaviour
    {
        float overHeadTimeLeft = 5f;
        float timePassed = 0f;
        uint currentBeatIndex = 0;
        List<BeatRecord> records;
        public void BeginRecord()
        {
            currentBeatIndex = 0;
            timePassed = 0f;
            records = new List<BeatRecord>();
        }
        public void OnPlay()
        {
            if (overHeadTimeLeft > 0)
            {
                overHeadTimeLeft -= Time.deltaTime;

                if (overHeadTimeLeft <= 0)
                {
                    SoundManager.GetInstance().PlayBGM("toiminatonoyakei");
                }

                return;
            }
        }
 

        public void OnCreateNewBeat(float offset, float timePassed, BeatType beatType)
        {
            var newRecord = new BeatRecord();
            newRecord.index = currentBeatIndex;
            newRecord.beatType = beatType;
            newRecord.spawnTime = timePassed;
            newRecord.offset = offset;

            records.Add(newRecord);
        }
    }
}