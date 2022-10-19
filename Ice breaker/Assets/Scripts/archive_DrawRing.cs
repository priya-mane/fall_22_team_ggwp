using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRing : MonoBehaviour
{
	public LineRenderer oldLineComponent;
	/*
    public GameObject linePrefab;
    public GameObject currentLine;

    public LineRenderer lineRenderer;

    public EdgeCollider2D edgeCollider1;
	public EdgeCollider2D edgeCollider2;
	*/
    
    // Start is called before the first frame update
    void Start()
    {
		/*
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider1 = currentLine.GetComponent<EdgeCollider2D>();
		edgeCollider2 = currentLine.GetComponent<EdgeCollider2D>();
        DrawCircle(50, 3);
		*/
        
    }
/*
	Vector2 rotatePoint()
	{
		result.Y = (int)Math.Round( centerPoint.Y + distance * Math.Sin( angle ) );
		result.X = (int)Math.Round( centerPoint.X + distance * Math.Cos( angle ) );
		
	}
*/	
/*
	public static Vector3 Rotated( Vector3 vector, Vector3 rotation, Vector3 pivot) 
	{
    	return Rotated(vector, Quaternion.Euler(rotation), pivot);
	}
*/

    // Update is called once per frame
    void Update()
    {
		Vector3 rotationToAdd = new Vector3(0, 0, 20);
		Vector3 centre = new Vector3(10f, -2.0f, 0);
		
        oldLineComponent.transform.Rotate(0, 0, 6.0f*10.0f*Time.deltaTime, Space.World);
		
		/*
		
		oldLineComponent = this.GetComponent<LineRenderer>();
		Vector3[] newPos = new Vector3[oldLineComponent.positionCount];
		oldLineComponent.GetPositions(newPos);
		List<Vector3> positions = new List<Vector3>();

		for(int i=0;i<oldLineComponent.positionCount; i++)
		{	
			Vector3 dir_Vector = newPos[i] - centre;
			Vector3 new_vector = Rotated(dir_Vector, rotationToAdd, centre) + centre; 
			oldLineComponent.SetPosition(i, new_vector);
		}
		*/
		
    }

	Vector3 rotatePointAroundAxis(Vector3 point, float angle, Vector3 axis)
	{
		Quaternion q = Quaternion.AngleAxis(angle, axis);
		return q * point; //Note: q must be first (point * q wouldn't compile)
	}

	/*
	void getcirclePoints(int steps, float radius)
	{
		float x_centre = 10f;
        float y_centre = -2.0f;
		List<Vector2> positions1 = new List<Vector2>();
		List<Vector2> positions2 = new List<Vector2>();

		for (int currentStep = 0; currentStep < steps; currentStep++)
        {
            float circumferenceprogess = (float)currentStep / steps;
            float currentRadian = circumferenceprogess * 2 * Mathf.PI;
            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);
            float x = xScaled * (radius-0.25f);
            float y = yScaled * (radius-0.25f);
			if (currentStep < steps/2)
			{
				positions1.Add(new Vector2(x+x_centre, y+y_centre));
			}
			else
			{
				positions2.Add(new Vector2(x+x_centre, y+y_centre));
			}
        }

		for (int currentStep = 0; currentStep < steps; currentStep++)
        {
            float circumferenceprogess = (float)currentStep / steps;
            float currentRadian = circumferenceprogess * 2 * Mathf.PI;
            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);
            float x = xScaled * (radius+0.25f);
            float y = yScaled * (radius+0.25f);

            if (currentStep < steps/2)
			{
				positions1.Add(new Vector2(x+x_centre, y+y_centre));
			}
			else
			{
				positions2.Add(new Vector2(x+x_centre, y+y_centre));
			}
        }

		edgeCollider1.SetPoints(positions1);
		edgeCollider2.SetPoints(positions2);
	}

    void DrawCircle(int steps, float radius)
    {
        float x_centre = 10f;
        float y_centre = -2.0f;
        lineRenderer.positionCount = steps;
        List<Vector2> positions = new List<Vector2>();
        
        for (int currentStep = 0; currentStep < steps; currentStep++)
        {
            float circumferenceprogess = (float)currentStep / steps;
            float currentRadian = circumferenceprogess * 2 * Mathf.PI;
            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);
            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currentPosition = new Vector3(x+x_centre, y+y_centre, 0);

            lineRenderer.SetPosition(currentStep, currentPosition);
        }

		getcirclePoints(steps, radius);
    }
	*/
}
