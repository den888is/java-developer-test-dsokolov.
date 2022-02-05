using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class AsteroidGenerator : MonoBehaviour
{
    [SerializeField] private GameObject asterPref;
    public const byte asterCount = 7;
    GameObject asterX, cam;
    Sprite spriteX;
    public Sprite[] asterSpriteArr = new Sprite[asterCount];
    int iX;
    double dX, dY;
    bool bX;
    System.Random r;
    public int h, w, h2, w2;

    void Start()
    {
        r = new System.Random();
        cam = GameObject.Find("Main Camera");
        //создание копии префаба астероида
        CreateStartAsteroids();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CreateStartAsteroids()
    {
        for (int i = 0; i < asterCount; i++)
        {
            CreateAsteroid();
        }
    }
    public void CreateAsteroid()
    {
        asterX = Instantiate(asterPref);
        //назначение случайной картинки
        asterX.GetComponent<SpriteRenderer>().sprite = RandomSprite();
        //назначение случайного движения
        asterX.GetComponent<Asteroid>().v = RandomV2();
        //назначение случайного положения
        asterX.transform.SetPositionAndRotation(RandomPosition(), Quaternion.identity);
        //наложение коллайдера
        asterX.AddComponent<PolygonCollider2D>();
    }
    public Sprite RandomSprite()
    {
        iX = r.Next(0, asterSpriteArr.Length);
        spriteX = asterSpriteArr[iX];
        return spriteX;
    }
    public Vector2 RandomV2()
    {
        dX = r.NextDouble();
        dY = r.NextDouble();
        //минусы
        return new Vector2((float)RandomMinus(dX), (float)RandomMinus(dY));
    }
    public double RandomMinus(double d)
    {
        if (r.Next(2) == 0)
        {
            d *= -1;
        }
        return d;
    }
    public Vector2 RandomPosition()
    {
        h2 = (int)cam.GetComponent<CameraController>().GetCTHeight();
        h = (h2 / 2);
        h = r.Next(h * (-1) + 1, h);
        w2 = (int)cam.GetComponent<CameraController>().GetCTWidth();
        w = (w2 / 2);
        w = r.Next(w * (-1) + 1, w);
        return new Vector2(w, h);
    }
}
