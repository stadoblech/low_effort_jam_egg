using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCheckForImpact : MonoBehaviour
{
    [SerializeField]
    OnPlayerEventsScriptable playerEvents;

    [SerializeField]
    float brakeMagnitude;




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude >= brakeMagnitude || collision.transform.tag == "Deadly")
        {
            playerEvents.OnPlayerKilled?.Invoke();
        }
    }
}
