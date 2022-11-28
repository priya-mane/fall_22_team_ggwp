using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    [SerializeField] FlashImage _flashImage = null;
    public new Rigidbody2D rigidbody { get; private set; }
    private float speed = 300f;
    private Vector3 initialPosition;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private LaunchPreview launchPreview;
    private Vector3 ballPosition;
    private bool mouseFlag=false;
    public bool withPaddle = false;
    private bool withPendulum = false;
    public GameObject currentPaddle;
	//public GameObject door;
    //public GameObject dynamic_lvl_pivot;
	//public GameObject support;
    
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    
    [SerializeField] private CameraController cam;
    
    private RotatingPaddle rotatingPaddle;
    private Vector3 velocitywithPaddle;
    public GameObject[] stars;

    private void Awake() 
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
        this.launchPreview = GetComponent<LaunchPreview>();
        this.initialPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    private void Start() 
    {
        // Invoke(nameof(SetRandomTrajectory), 1f);
    }

    private void OnMouseOver() {
  
    }
    void OnMouseDown(){
        if(this.rigidbody.velocity == Vector2.zero){
            mouseFlag = true;
        }
    }
    private void Update() 
    {
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
        if (withPendulum && Input.GetKeyDown(KeyCode.P))
        {
            withPaddle = false;
            withPendulum = false;
            Rigidbody2D pendulum = this.currentPaddle.transform.parent.GetComponent<Rigidbody2D>();
            float ballSpeed = this.currentPaddle.GetComponent<TangentRedirect>().GetPendulumBallSpeed();
            this.rigidbody.velocity = ballSpeed*pendulum.velocity;
            this.rigidbody.angularVelocity = pendulum.angularVelocity;
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

    public void setPendulum(TangentRedirect pendulum){
        this.withPaddle = true;
        this.withPendulum = true;
        this.rigidbody.velocity = Vector2.zero;
        this.rigidbody.angularVelocity = 0f;
        this.currentPaddle = pendulum.gameObject;
    }
    public void positionWithPaddle(){
        if(this.currentPaddle.tag == "TopPaddle" || this.currentPaddle.tag == "Pendulum"){
            Debug.Log("upon stick this is being called 3");
            this.gameObject.transform.position = this.currentPaddle.transform.position + Vector3.down;
        }
        else if(this.currentPaddle.tag == "RotatingPaddle") {
            if(this.currentPaddle.transform.eulerAngles.z >= 315.0f){
                this.rotatingPaddle.Rotate();
            }
            // float angle = (3.14159265f / 180f) * this.gameObject.transform.eulerAngles.z;
            this.gameObject.transform.position = Vector3.up + this.rotatingPaddle.transform.position;
            Vector3 forceToBeApplied = this.rotatingPaddle.RedirectBall(this.velocitywithPaddle);
            this.rigidbody.AddForce(forceToBeApplied * speed*1.2f);
            withPaddle = false;
            this.rotatingPaddle = null;
            this.currentPaddle = null;
        }
        else{
            Debug.Log("upon stick this is being called 3");
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
        // AnalyticsManager.instance.ballReset++;
        _flashImage.startFalsh(.50f,  .3f, Color.red);
        Color white_color = new Color(1f, 1f, 1f, 1f);
        this.rigidbody.velocity = Vector2.zero;
        this.rigidbody.angularVelocity = 0f;
        this.rigidbody.gravityScale = 0;
        this.rigidbody.drag = 0;
		gameObject.transform.position = initialPosition;
		if (cam != null)
		{
			cam.transform.position = new Vector3(0.0f, 0.0f ,-10.0f);
		}
		
		
        /*
        if (dynamic_lvl_pivot != null && !(support.GetComponent<Renderer>().isVisible) )
        {
            // reset to connecting sticky paddle
            gameObject.transform.position = dynamic_lvl_pivot.transform.position;
            Vector3 temp = new Vector3(0.0f, -0.5f ,0.0f);
            gameObject.transform.position = transform.position + temp;
        }
        else
        {
            // reset to support
            gameObject.transform.position = initialPosition;
        }
		*/
		gameObject.transform.position = initialPosition;
        gameObject.GetComponent<SpriteRenderer>().color = white_color;
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = new Vector2();
        force.x = UnityEngine.Random.Range(-1f, 1f);
        force.y = 1f;

        this.rigidbody.AddForce(force.normalized * speed);
    }
    
    public void SetColor(Color color){
        //Debug.Log(color.ToString() + " Ball.cs");
        //gameObject.GetComponent<Renderer>().material.SetColor("_Color", color);
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("star")){
            other.gameObject.SetActive(false);
            GameManager.stars = GameManager.stars + 1;
        }
        
        if(other.gameObject.CompareTag("life")){
            other.gameObject.SetActive(false);
            GameManager.lives = GameManager.lives + 1;
        }
    }
    
}