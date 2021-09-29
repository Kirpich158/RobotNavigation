using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public RobotRay go;
    public Button but;
    

    public void Again()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Go()
    {
        go.speed = 1f;
        but.gameObject.SetActive(false);
    }
}
