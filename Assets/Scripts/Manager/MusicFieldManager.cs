using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TellYou.Game.Music
{
    public enum PlayStatus
    {
        StandBy,
        Record,
        Play,
    }
    public class MusicFieldManager : MonoSingletoneBase<MusicFieldManager>
    {
        [SerializeField] GameObject startRoot;
        [SerializeField] GameObject perfaceRoot;
        [SerializeField] GameObject endRoot;
        [SerializeField] Transform beatRootTransform;
        [SerializeField] float beatScale;
        [SerializeField] BeatObject beatPrefab;
        [SerializeField] PlayStatus currentPlayStatus;
        const float updateInterver = 0.2f;
        [SerializeField] float updateTimeLeft = 0f;
        [SerializeField] float currentTimePassed = 0f;

        Ray endRootRay;
        const float defaultTime = 5f;

        MusicSheetPlayer sheetRecorder = null;
        void Awake()
        {
            endRootRay = new Ray();
            endRootRay.origin = endRoot.transform.right;
            endRootRay.direction = (endRoot.transform.position - endRootRay.origin).normalized;

            sheetRecorder = new MusicSheetPlayer();
        }
        public void CreateBeat()
        {
            var beat = GameObject.Instantiate<BeatObject>(beatPrefab, beatRootTransform);
            var distance = DistanceToLine(endRootRay, beat.transform.position);
            beat.Setup(distance / defaultTime);
        }
        public void Update()
        {
            switch (currentPlayStatus)
            {
                case PlayStatus.StandBy:
                    break;
                case PlayStatus.Play:
                    break;
                case PlayStatus.Record:
                    sheetRecorder.OnPlay();

                    if (updateTimeLeft > 0)
                    {
                        updateTimeLeft -= Time.deltaTime;

                        if (updateTimeLeft <= 0)
                        {
                            updateTimeLeft = updateInterver;
                            currentTimePassed += updateInterver;
                        }

                        if (Input.GetMouseButtonDown(0))
                        {
                            CreateBeat();
                            
                        }
                    }
                    break;
            }

            return;
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, LayerUility.BeatLayerMask))
                {
                    var beat = hit.transform.gameObject.GetComponent<BeatObject>();

                    if (beat != null)
                    {
                        beat.OnClick();
                    }
                }
            }
        }
        public void StartRecord()
        {

        }
        public static float DistanceToLine(Ray ray, Vector3 point)
        {
            return Vector3.Cross(ray.direction, point - ray.origin).magnitude;
        }
    }
}