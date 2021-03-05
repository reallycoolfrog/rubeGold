using UnityEngine;

public class CameraFollow : MonoBehaviour{

    public Transform followTransform;

    public BoxCollider2D worldBounds; //define world bounds that camera cant leave

    Camera mainCam;

    Vector3 smoothPos;

    public float smoothRate; //speed of smoothing

//hold positions of world bounds
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    float camX;
    float camY;

    float camWidth;
    float camSize;

    void Start ()
    {
        xMin = worldBounds.bounds.min.x;
        xMax = worldBounds.bounds.max.x;
        yMin = worldBounds.bounds.min.y;
        yMax = worldBounds.bounds.max.y;

        mainCam = gameObject.GetComponent<Camera>();
        camWidth = mainCam.aspect*camSize;
    }

    void FixedUpdate ()
    {
        camY = Mathf.Clamp(followTransform.position.y, yMin + camSize, yMax - camSize);
        camX = Mathf.Clamp(followTransform.position.x, xMin + camWidth, xMax - camWidth);

        smoothPos = Vector3.Lerp(gameObject.transform.position, new Vector3(camX, camY, gameObject.transform.position.z), smoothRate);
        gameObject.transform.position = smoothPos;
    }

}
