using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResourceCountDown : MonoBehaviour
{
    public float timeLimit;
    float currentTimeLeft, startingTime;
    public TextMeshProUGUI timerText;
    public string losingSceneName;
    // Start is called before the first frame update
    void OnEnable()
    {
        currentTimeLeft = timeLimit;
        startingTime = Time.time;
        timerText.text = currentTimeLeft.ToString("00.0");
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeLeft = timeLimit - (Time.time - startingTime);
        if(currentTimeLeft<=0){
            SceneManager.LoadScene(losingSceneName);
        }
        timerText.text = currentTimeLeft.ToString("00.0");
    }
}
