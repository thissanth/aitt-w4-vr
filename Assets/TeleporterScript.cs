using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TeleporterScript : MonoBehaviour
{
    public GameObject player;
    public GameObject leftHand;
    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Input.GetStateDown("OffRoadTeleport", SteamVR_Input_Sources.LeftHand))
        {
            print("Fire out the teleport line");
            Ray raycast = new Ray(leftHand.transform.position, leftHand.transform.forward);
            RaycastHit hit;

            bool bHit = Physics.Raycast(raycast, out hit);
            destination = hit.point;
            if (bHit)
            {
                print(hit.point);
                player.transform.position = destination;
            }
            else
            {
                print("Didn't hit");
            }
        }

        if (SteamVR_Input.GetStateUp("OffRoadTeleport", SteamVR_Input_Sources.LeftHand))
        {
            print("Teleport to the intersection point");
        }
    }
}
