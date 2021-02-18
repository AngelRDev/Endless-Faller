using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary> Manages the state of the level </summary>
public class LevelManager : MonoBehaviour
{
    public int Score { get; private set; }

    [SerializeField] private Text scoreText;

    private MainCharacter _player;
    private MovingPlatform[] _movingPlatforms;

    void Start()
    {
        // Get MainCharacter (to reset level)
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<MainCharacter>();
        
        // Get list of platforms (to reset level)
        GameObject []tempPlatforms = GameObject.FindGameObjectsWithTag("MovingPlatform");
        _movingPlatforms = new MovingPlatform[tempPlatforms.Length];
        for (int i = 0; i < tempPlatforms.Length; i++) _movingPlatforms[i] = tempPlatforms[i].GetComponent<MovingPlatform>();
    }

    public void IncrementScore()
    {
        Score++;
        scoreText.text = "Score: " + Score.ToString();
    } 

    public void Reset()
    {
        Score = 0;
        scoreText.text = "Score: " + Score.ToString();
        _player.Reset();
        for (int i = 0; i < _movingPlatforms.Length; i++) _movingPlatforms[i].Init();
    }
}
