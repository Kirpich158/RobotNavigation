using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotRay : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (Physics.Raycast(transform.position, transform.forward, 0.6f))
        {
            transform.Translate(Vector3.zero);
            // Dead end scenario
            if (Physics.Raycast(transform.position, -transform.right, 0.6f) 
                && Physics.Raycast(transform.position, transform.right, 0.8f))
            {
                StartCoroutine(Rotation(180f));
            }
            // Blocked from right side scenario
            if (Physics.Raycast(transform.position, -transform.right, 0.6f))
            {
                StartCoroutine(Rotation(90f));
            }
            // Blocked from left side scenario
            if (Physics.Raycast(transform.position, transform.right, 0.6f))
            {
                StartCoroutine(Rotation(-90f));
            }
            if(!Physics.Raycast(transform.position, -transform.right, 0.6f) 
                && !Physics.Raycast(transform.position, transform.right, 0.6f))
            {
                StartCoroutine(Rotation(90f));
            }
        }
    }

    IEnumerator Rotation(float y)
    {
        transform.Rotate(0f, y, 0f);
        yield return new WaitForSecondsRealtime(1f);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}