using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    private GameObject ball; 
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.4f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("ball"))
                {
                    ball = hit.collider.gameObject;
                    lineRenderer.enabled = true;
                    lineRenderer.SetPosition(0, ball.transform.position);
                    lineRenderer.SetPosition(1, ball.transform.position);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.enabled = false;
        }

        if (Input.GetMouseButton(0) && ball != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            lineRenderer.SetPosition(1, ray.GetPoint(10f));
        }
    }
}