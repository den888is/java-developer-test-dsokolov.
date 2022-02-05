using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float pixelPerUnit = 256f;

    public float cTwidth, cTHeight;
    public float tileMaptWidth, tileMapHeight;
    public float standartAspect;

    public float windowAspect;//наше и щелевое отношение
    public float scaleHeght;
    GameObject gr;
    public float scaleX;
    public float borderStrong;
    private void Awake()//т.к. получаю 0
    {
        cTwidth = 20f;
        cTHeight = 10f;
    }
    void Start()
    {
        borderStrong = 0.99f;
        gr = GameObject.Find("Grid");

        tileMaptWidth = cTwidth * pixelPerUnit;
        tileMapHeight = cTHeight * pixelPerUnit;
        standartAspect = tileMaptWidth / tileMapHeight;//отношение сторон тайлов по умолчанию 1
        windowAspect = (float)Screen.width / (float)Screen.height;//ширина к высоте экрана 2
        scaleHeght = standartAspect / windowAspect;
        if (scaleHeght != 1.0f)
        {
            scaleX = gr.GetComponent<Grid>().transform.localScale.x / scaleHeght;
            gr.GetComponent<Grid>().transform.localScale = new Vector2(scaleX, gr.GetComponent<Grid>().transform.localScale.y);
        }
    }
    public float GetCTWidth() { return cTwidth; }
    public float GetCTHeight() { return cTHeight; }
}
