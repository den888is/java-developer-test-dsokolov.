using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject ship;
    public float speed;
    private GameObject mCamera;
    CameraController cameraConroller;
    void Start()
    {
        speed = 4;
        ship = GameObject.Find("Player");
        transform.position = new Vector2(ship.transform.position.x, ship.transform.position.y);
        transform.rotation = ship.transform.rotation;
        mCamera = GameObject.Find("Main Camera");
        cameraConroller = mCamera.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        Border();
    }
    public void Border()
    {
        if (transform.position.y < cameraConroller.GetCTHeight() / 2 * (-1) || transform.position.y > cameraConroller.GetCTHeight() / 2)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < cameraConroller.GetCTWidth() / 2 * (-1) * cameraConroller.scaleX || transform.position.x > cameraConroller.GetCTWidth() / 2 * cameraConroller.scaleX)
        {
            Destroy(gameObject);
        }
    }
}
