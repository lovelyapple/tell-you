using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BeatMoveState
{
    Start,
    Ready,
    Touched,
    DeleteRequest,
}
public enum BeatScoreState
{
    None,
    NormalHigh,
    Perfact,
    NormalLow,
}
public enum BeatType
{
    SingleTap,
}