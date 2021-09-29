using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotRay : MonoBehaviour
{
    public float speed = 0f;
    RaycastHit hit;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (Physics.Raycast(ray, out hit, 0.6f))
        {
            transform.Translate(Vector3.zero);
            if (hit.collider.gameObject.GetComponent<EndScript>())
            {
                hit.collider.gameObject.GetComponent<EndScript>().End();
            }
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