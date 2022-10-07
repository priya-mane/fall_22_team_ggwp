using UnityEngine;

public class Ball : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    private float speed = 300f;
    private Vector3 initialPosition;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private LaunchPreview launchPreview;
    private Vector3 ballPosition;
    private bool mouseFlag=false;

    private void Awake() {
        this.rigidbody = GetComponent<Rigidbody2D>();
        this.launchPreview = GetComponent<LaunchPreview>();
        this.initialPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    private void Start() {
        // Invoke(nameof(SetRandomTrajectory), 1f);
    }

    private void OnMouseOver() {
        if(this.rigidbody.velocity == Vector2.zero){
            mouseFlag = true;
        }
    }

    private void Update() {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.back*-10;
        this.ballPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            if(mouseFlag){
                if(Input.GetMouseButtonDown(0)) {
                    StartDrag(worldPosition);
                }
                if(Input.GetMouseButton(0)) {
                    ContinueDrag(worldPosition);
                }
                if(Input.GetMouseButtonUp(0)) {
                    EndDrag(worldPosition);
                    mouseFlag = false;
                }
            }
    }

    private void StartDrag(Vector3 worldPosition) {
        startPosition = worldPosition;
        launchPreview.ShowPreview();
        launchPreview.SetStartPoint(transform.position);
    }

    private void ContinueDrag(Vector3 worldPosition) {
        endPosition = worldPosition;
        Vector3 direction = endPosition - startPosition;
        launchPreview.SetEndPoint(transform.position - direction);
    }

    private void EndDrag(Vector3 worldPosition) {
        Vector3 direction = endPosition - startPosition;
        direction.Normalize();
        launchPreview.HidePreview();
        AnalyticsManager.instance.Send2(GameManager.level);
        this.rigidbody.AddForce(-1*direction*this.speed);
    }

    public void ResetBall() {
        AnalyticsManager.instance.ballReset++;
        Color white_color = new Color(1f, 1f, 1f, 1f);
        this.rigidbody.velocity = Vector2.zero;
        this.rigidbody.angularVelocity = 0f;
        gameObject.transform.position = initialPosition;
        gameObject.GetComponent<SpriteRenderer>().color = white_color;
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = new Vector2();
        force.x = Random.Range(-1f, 1f);
        force.y = 1f;

        this.rigidbody.AddForce(force.normalized * speed);
    }
}