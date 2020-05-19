using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f,10f)][SerializeField] float timeScale;
    [SerializeField] int pointsToAdd;
    [SerializeField] int currentPoints = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called before the first frame update

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1 )
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        timeScale = 1f;
        pointsToAdd = 1;
        scoreText.text = currentPoints.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public void addPointsToScore()
    {
        currentPoints += pointsToAdd;
        scoreText.text = currentPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;   
    }
}
