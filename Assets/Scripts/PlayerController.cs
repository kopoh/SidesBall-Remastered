using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed = 140;
    [SerializeField] private float sensitivity = 40f;
    [SerializeField] private TMP_Text tmpScore;
    [SerializeField] private Text textScore;
    [SerializeField] private Text textHighScore;
    [SerializeField] private Text pauseTextHighScore;
    [SerializeField] private GameObject howToPlayGameObject;
    [SerializeField] private int guide; //How to play
    [SerializeField] private AudioSource audioSource;
    
    [SerializeField] private UnityEvent loseEvent;
    private Rigidbody _player;
    private SafeInt _intScore;
    private SafeInt _highScore;
    private void Start()
    {
        if (loseEvent == null)
            loseEvent = new UnityEvent();
        
        audioSource.volume = PlayerPrefsSafe.GetFloat("volume", 0.5f);
        guide = PlayerPrefsSafe.GetInt("Tutorialbool", 0);
        
        if (guide == 0)
        {
            UnlockAchievement("CgkIjqSPppUVEAIQAQ");
            howToPlayGameObject.SetActive(true);
            PlayerPrefsSafe.SetInt("Tutorialbool", 1);
        }
        
        _player = gameObject.GetComponent<Rigidbody>();
        
        sensitivity = PlayerPrefsSafe.GetFloat("sensitivity", 40);
        _intScore = PlayerPrefsSafe.GetInt("points", 0);
        _highScore = PlayerPrefsSafe.GetInt("highscorepoints", 0);
        textScore.text = _intScore.ToString();
    }

    private void Update()
    {
        _player.AddForce(Input.acceleration.x * sensitivity, 0, Time.deltaTime * speed, ForceMode.Force);
        _intScore = Convert.ToInt32(_player.transform.position.z);
        tmpScore.text = textScore.text = _intScore.ToString();
        pauseTextHighScore.text = textHighScore.text = _highScore.ToString();
        
        if (_player.position.x >= 3.50f || _player.position.y <= -2f || _player.position.x <= -3.50f) //проверяем игрока на вылет из игровой зоны по координама, по идее можно было через простые тригеры, но кодом надежнее
        {    //костыль бесит, но ничего лучше я не придумал (я про весь этот код)
            _player.transform.position = new Vector3(0, 0, _player.position.z);
        }
        
        if (_intScore >= _highScore) //переопределяем очки
        {
            _highScore = _intScore;
            PlayerPrefsSafe.SetInt("highscorepoints", _highScore);
        }
        
        PlayerPrefsSafe.SetInt("points", _intScore);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && loseEvent != null)
        {
            PlayerPrefsSafe.SetInt("highscorepoints", _highScore);
            _player.isKinematic = true;
            if (_intScore >= _highScore)
            {
                _highScore = _intScore;
                PlayerPrefsSafe.SetInt("highscorepoints", _highScore);
                Social.ReportScore(_highScore, "CgkIjqSPppUVEAIQAg", success => { });
            }

            if (_highScore >= 1000) //first 1000 achievment
            {
                UnlockAchievement("CgkIjqSPppUVEAIQAQ");
            }
            
            if (_highScore >= 2000) //first 2000 achievment
            {
                UnlockAchievement("CgkIjqSPppUVEAIQBA");
            }
            
            if (_highScore >= 5000) //first 5000 achievment
            {
                UnlockAchievement("CgkIjqSPppUVEAIQBQ");
            }
            loseEvent.Invoke();
        }
    }
    
    public static void UnlockAchievement(string id)
    {
        Social.ReportProgress(id, 100, success => { });
    }
    
    public static void AddScoreToLeaderboard(string leaderboardId, long score)
    {
        Social.ReportScore(score, leaderboardId, success => { });
    }
}
