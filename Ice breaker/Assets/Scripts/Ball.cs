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
    public bool withPaddle = false;
    public GameObject currentPaddle;
    private RotatingPaddle rotatingPaddle;
    private Vector3 velocitywithPaddle;

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
                withPaddle = false;
                mouseFlag = false;
            }
        }
        if(withPaddle){
            // Debug.Log("position with paddle is getting called");
            positionWithPaddle();
        }
    }

    public void setPaddle(GameObject paddle){
        this.currentPaddle = paddle;
        this.withPaddle = true;
        this.rigidbody.velocity = Vector2.zero;
        this.rigidbody.angularVelocity = 0f;
    }

    public void setRotatingPaddle(RotatingPaddle paddle) {
        this.rotatingPaddle = paddle;
        this.currentPaddle = paddle.gameObject;
        this.withPaddle = true;
        this.velocitywithPaddle = this.rigidbody.velocity;
        this.rigidbody.velocity = Vector2.zero;
        this.rigidbody.angularVelocity = 0f;
    }

    public void positionWithPaddle(){
        if(this.currentPaddle.tag == "TopPaddle"){
            this.gameObject.transform.position = this.currentPaddle.transform.position + Vector3.down;
        }
        else if(this.currentPaddle.tag == "RotatingPaddle") {
            if(this.currentPaddle.transform.eulerAngles.z >= 315.0f){
                this.rotatingPaddle.Rotate();
            }
            // float angle = (3.14159265f / 180f) * this.gameObject.transform.eulerAngles.z;
            this.gameObject.transform.position = Vector3.up + this.rotatingPaddle.transform.position;
            Vector2 forceToBeApplied = this.rotatingPaddle.RedirectBall(this.velocitywithPaddle);
            this.rigidbody.AddForce(forceToBeApplied * speed*1.2f);
            withPaddle = false;
            this.rotatingPaddle = null;
            this.currentPaddle = null;
        }
        else{
            this.gameObject.transform.position = this.currentPaddle.transform.position + Vector3.up;
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
 //       AnalyticsManager.instance.Send2(GameManager.level);
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