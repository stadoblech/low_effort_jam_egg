using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class OnPlayerEventsScriptable : ScriptableObject
{
    public System.Action OnPlayerKilled;
    public System.Action OnPlayerFinishedLevel;
}
