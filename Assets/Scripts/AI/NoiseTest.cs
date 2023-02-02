using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseTest : MonoBehaviour
{

    [SerializeField] private MoveAI player;
    [SerializeField] private int anim;
    [SerializeField] private bool activateInterupt;
    [SerializeField] private bool interuptContinue;
    [SerializeField] private bool AddAfter;
    [SerializeField] private bool addNext;

    private void Update()
    {
        if (activateInterupt)
        {
            activateInterupt = false;
            player.AddDestinationInterrupt(DestinationPoint.AddNew(transform.position, duration: 5, animMode: anim, name: "Interupt Leave"), false);
        }
        if (interuptContinue)
        {
            interuptContinue = false;
            player.AddDestinationInterrupt(DestinationPoint.AddNew(transform.position, duration: 5, animMode: anim, name: "Interupt Back"));
        }
        if (AddAfter)
        {
            AddAfter = false;
            player.AddNewDestination(DestinationPoint.AddNew(transform.position, duration: 5, animMode: anim, name: "Check Last"));
        }
        if (addNext)
        {
            addNext = false;
            player.AddDestinationAfterCurrent(DestinationPoint.AddNew(transform.position, duration: 5, animMode: anim, name: "Check Next"));
        }
    }
}
