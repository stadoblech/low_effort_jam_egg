using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZoneController : MonoBehaviour
{
    [SerializeField]
    OnPlayerEventsScriptable playerEvents;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerEvents.OnPlayerKilled?.Invoke();
        }
    }

}
