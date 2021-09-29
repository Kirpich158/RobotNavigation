using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public GameObject againBG;
    public RobotRay player;

    public void End()
    {
        player.speed = 0f;
        againBG.SetActive(true);
    }
}
