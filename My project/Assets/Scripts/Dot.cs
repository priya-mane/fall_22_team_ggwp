using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public int row;
    public int column;

    public int targetX;
    public int targetY;

    // public bool isMatch = false;

    private Board board;
    private GameObject otherDot;
    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;
    private Vector2 tempPostion; 
    public float swipeAngle =0;

    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectsOfType<Board>()[1];
        Debug.Log("start " + board.allDots.Length);
        targetX = (int) transform.position.x;
        targetY = (int) transform.position.y;
        row = targetY;
        column = targetX;
    }

    // Update is called once per frame
    void Update()
    {
        // FindMatches();
        // if(isMatch){

        //     SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
        //     mySprite.color = new Color(0f,0f,0f,.2f);
        // }
        
        targetX = column;
        targetY = row;


        if( Mathf.Abs(targetY - transform.position.y)> .1){
            tempPostion = new Vector2(transform.position.x, targetY); 
            transform.position = Vector2.Lerp(transform.position, tempPostion, .4f);
        }else{
            tempPostion = new Vector2(transform.position.x, targetY); 
            transform.position = tempPostion;
            Debug.Log(board.GetHashCode());
            board.allDots[column, row] = this.gameObject; 
        }

        if( Mathf.Abs(targetX - transform.position.x)> .1){
            tempPostion = new Vector2(targetX, transform.position.y); 
            transform.position = Vector2.Lerp(transform.position, tempPostion, .4f);
        }else{
            tempPostion = new Vector2(targetX, transform.position.y); 
            transform.position = tempPostion;
            board.allDots[column, row] = this.gameObject; 
        }

        
    }
    
    void OnMouseDown(){
        firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(firstTouchPosition);
    }

    void OnMouseUp(){
        finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CalculateAngle();
    }

    void CalculateAngle(){
        swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x)*180/Mathf.PI;
        // Debug.Log(swipeAngle);
        MovePieces();
    }

    void MovePieces(){
        if(swipeAngle> -45 && swipeAngle<= 45 && column < board.width){
            //right swipe
            otherDot = board.allDots[column +1, row];
            otherDot.GetComponent<Dot>().column -=1;
            column+=1;

        }else if(swipeAngle> 45 && swipeAngle<= 135 && row < board.height)
        {
            //up swipe
            otherDot = board.allDots[column, row+1];
            otherDot.GetComponent<Dot>().row -=1;
            row+=1;
        }else if((swipeAngle> 135 ||  swipeAngle <= -135) && column>0)
        {
            //Left swipe
            otherDot = board.allDots[column - 1, row];
            otherDot.GetComponent<Dot>().column +=1;
            column-=1;   
        }
        else if(swipeAngle < -45 && swipeAngle >= -135 && row > 0)
        {
            // Down swipe
            otherDot = board.allDots[column, row-1];
            otherDot.GetComponent<Dot>().row +=1;
            row-=1;   
        } 
    }

    // void FindMatches(){
    //     if(column >0 && column <board.width -1){
    //         GameObject leftDot1 = board.allDots[column -1, row];
    //         GameObject rightDot1 = board.allDots[column+1, row];
    //         if(leftDot1.tag == this.gameObject.tag && rightDot1.tag == this.gameObject.tag){
    //             leftDot1.GetComponent<Dot>().isMatch = true;
    //             rightDot1.GetComponent<Dot>().isMatch = true;
    //             isMatch = true; 
    //         }
    //     }
    // }
}
