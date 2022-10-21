using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPreview : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 dragStartpoint;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0f;
        lineRenderer.endWidth = 0f;
    }

    public void ShowPreview() {
        lineRenderer.endWidth = 0.05f;
    }

    public void HidePreview() {
        lineRenderer.endWidth = 0f;
    }
    public void SetStartPoint(Vector3 worldPosition) {
        dragStartpoint = worldPosition;
        lineRenderer.SetPosition(0,dragStartpoint);
    }

    public void SetEndPoint(Vector3 worldPosition) {
        Vector3 offset = worldPosition - dragStartpoint;
        Vector3 endPoint = transform.position + 2.5f*offset;

        lineRenderer.SetPosition(1, endPoint);
    }
}
