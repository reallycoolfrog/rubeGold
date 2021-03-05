using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour

{
    public float speed;
    public float jumpHeight;
    public float gravityMultiplier;
    public float jumpMultiplier;

    float moveDir = 1;

    Rigidbody2D myBody;
    BoxCollider2D myCollider;
    SpriteRenderer myRenderer;

    public Sprite jumpSprite;
    public Sprite walkSprite;

    bool onFloor = true;
    public static bool faceRight = true;


    // Start is called before the first frame update
    void Start()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
        myCollider = gameObject.GetComponent<BoxCollider2D>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if(onFloor && myBody.velocity.y > 0){
            onFloor = false;
        }
        CheckKeys();
        HandleMovement();
        JumpPhysics();
    }

    void CheckKeys() {
        if(Input.GetKey(KeyCode.D)){
            moveDir = 1;
            faceRight = true;
            myRenderer.flipX = false;
        } else if(Input.GetKey(KeyCode.A)){
            moveDir = -1;
            faceRight = false;
            myRenderer.flipX = true;
        } else {
            moveDir = 0;
        }
        if(Input.GetKey(KeyCode.W) && onFloor){ //Starting jump
            myBody.velocity = new Vector3(myBody.velocity.x, jumpHeight);
            myRenderer.sprite = jumpSprite;
        } else if (!Input.GetKey(KeyCode.W) && myBody.velocity.y > 0){
            //not pressing w. & moving upwards in jump
            myBody.velocity += Vector2.up * Physics.gravity.y * (jumpMultiplier - 1f) * Time.deltaTime;
            //Add a boost
        }
    }

    void JumpPhysics(){
        if(myBody.velocity.y < 0) { //descending from jump
            myBody.velocity += Vector2.up * Physics.gravity.y * (gravityMultiplier - 1f) * Time.deltaTime;
        }
    }

    void HandleMovement() {
        myBody.velocity = new Vector3(moveDir * speed, myBody.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D collisionInfo){
        if(collisionInfo.gameObject.tag == "Floor"){
            onFloor = true;
            myRenderer.sprite = walkSprite;
        }
    }
}
