using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draw_circle : MonoBehaviour
{
    public LineRenderer CircleRenderer;
    public EdgeCollider2D edgeCollider;
    void Start()
    {
        DrawCircle(100, 3.5f);
    }

    void Update()
    {
    }

    void DrawCircle(int steps, float radius)
    {
        float x_centre = 10f;
        float y_centre = -2.0f;
        CircleRenderer.positionCount = steps;
        List<Vector2> positions = new List<Vector2>();
        
        for (int currentStep = 0; currentStep < steps-50; currentStep++)
        {
            float circumferenceprogess = (float)currentStep / steps;
            float currentRadian = circumferenceprogess * 2 * Mathf.PI;
            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);
            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currentPosition = new Vector3(x+x_centre, y+y_centre, 0);

            CircleRenderer.SetPosition(currentStep, currentPosition);
            positions.Add(new Vector2(x+x_centre, y+y_centre));

        }

        edgeCollider.points = positions.ToArray();
    }
    
}
