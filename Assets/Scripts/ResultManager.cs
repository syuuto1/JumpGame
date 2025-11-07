using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public Text resultText;

    void Start()
    {
        int finalTime = Mathf.FloorToInt(GameManager.resultTime);
        resultText.text = "Time: " + finalTime;
    }
}