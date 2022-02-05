using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    void Start()
    {
        transform.GetComponent<Text>().text = score.ToString();
    }
    public void ScorePlus()
    {
        score++;
        transform.GetComponent<Text>().text = score.ToString();
    }
}
