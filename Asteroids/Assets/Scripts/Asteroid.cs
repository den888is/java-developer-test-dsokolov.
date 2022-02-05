using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Vector2 v;
    private GameObject mCamera;
    CameraController cameraConroller;
    public Vector2 p;
    GameObject astGener, score;
    void Start()
    {
        mCamera = GameObject.Find("Main Camera");
        cameraConroller = mCamera.GetComponent<CameraController>();
        astGener = GameObject.Find("AsteroidGenerator");
        score = GameObject.Find("Score");
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(v * Time.deltaTime);
        //ПРОверка на выход за границу
        Border();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("BOOM Aster");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        score.GetComponent<Score>().ScorePlus();
        Destroy(collision.gameObject);
        astGener.GetComponent<AsteroidGenerator>().CreateAsteroid();
        Destroy(gameObject);
    }
    //создание копии объекта
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
}
