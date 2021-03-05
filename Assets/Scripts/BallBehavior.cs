using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{

    SpriteRenderer myRenderer;
    public Color floorColor;
    public Color gateColor;

    Rigidbody2D myBody;

    public float power;
    public GameObject freakyfloor;
    public GameObject freakierfloor;
    public GameObject freakiest;
    public GameObject ALLBALLS;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        myBody = gameObject.GetComponent<Rigidbody2D>();
        freakyfloor = GameObject.Find("freakyfloor");
        freakierfloor = GameObject.Find("freakierfloor");
        freakiest = GameObject.Find("freakiest");
        ALLBALLS = GameObject.Find("ALLBALLS");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            //Add force to the ball to the upper right when space is pressed
            myBody.AddForce((Vector3.right + Vector3.up) * power);
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.name == "Floor"){
            Debug.Log("Hit Floor");
            myRenderer.color = floorColor;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == "Gate"){
            myRenderer.color = gateColor;
            Destroy(freakyfloor);
        } else if(other.gameObject.name == "gate2"){
            Destroy(freakierfloor);
        } else if (other.gameObject.name == "gate3"){
            Destroy(freakiest);
        } else if (other.gameObject.name == "gate4"){
            Destroy(ALLBALLS);
        }
    }
}
