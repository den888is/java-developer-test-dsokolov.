using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bulletPref;
    private float speed;
    public float offset;
    public byte health;
    public int points;
    private GameObject mCamera;
    CameraController cameraConroller;
    public Vector2 p;

    void Start()
    {
        speed = 2;
        health = 3;
        mCamera = GameObject.Find("Main Camera");
        cameraConroller = mCamera.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        { transform.Translate(Vector2.up * Time.deltaTime * speed); }
        if (Input.GetKey(KeyCode.A))
        { transform.Translate(Vector2.left * Time.deltaTime * speed); }
        if (Input.GetKey(KeyCode.D))
        { transform.Translate(Vector2.right * Time.deltaTime * speed); }
        if (Input.GetKey("escape")) { Application.Quit(); }

        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotateZ + offset);

        if (Input.GetMouseButtonUp(0)) { Shot(); }
        Border();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        if (health <= 0)
            Restart();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Border()
    {
        if (transform.position.y < cameraConroller.GetCTHeight() / 2 * (-1) || transform.position.y > cameraConroller.GetCTHeight() / 2)
        {
            p = new Vector2(transform.position.x, transform.position.y * (-1) * cameraConroller.borderStrong);
            transform.SetPositionAndRotation(p, Quaternion.identity);
        }
        if (transform.position.x < cameraConroller.GetCTWidth() / 2 * (-1) * cameraConroller.scaleX || transform.position.x > cameraConroller.GetCTWidth() / 2 * cameraConroller.scaleX)
        {
            p = new Vector2(transform.position.x * (-1) * cameraConroller.borderStrong, transform.position.y);
            transform.SetPositionAndRotation(p, Quaternion.identity);
        }
    }
    public void Shot()
    {
        Debug.Log("Shot");
        Instantiate(bulletPref);
    }
}
