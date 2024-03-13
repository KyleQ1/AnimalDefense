using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class CopTargetSetter : MonoBehaviour
{
    AIDestinationSetter destinationSetter;
    void Start()
    {
        destinationSetter = GetComponent<AIDestinationSetter>();
        destinationSetter.target = GameObject.Find("racecar").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
