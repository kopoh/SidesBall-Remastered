using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int Speed = 140;
    public float sensitivity = 40f;
    public TMP_Text TMPscore;
    public Text _textscore;
    public Text _texthighscore;
    public Text _pausetexthighscore;

    public UnityEvent LoseEvent;
    private Rigidbody player;
    private float CurrentSencitivity; //блет ну можно было же назвать CurSence;
    private SafeInt intscore;
    private SafeInt highscore;
    private void Start()
    {
        if (LoseEvent == null)
            LoseEvent = new UnityEvent();

        player = gameObject.GetComponent<Rigidbody>();
        
        sensitivity = PlayerPrefsSafe.GetFloat("sensitivity", 40);
        intscore = PlayerPrefsSafe.GetInt("points", 0);
        highscore = PlayerPrefsSafe.GetInt("highscorepoints", 0);
        _textscore.text = intscore.ToString();
    }

    private void Update()
    {
        player.AddForce(Input.acceleration.x * sensitivity, 0, Time.deltaTime * Speed, ForceMode.Force);
        intscore = Convert.ToInt32(player.transform.position.z);
        TMPscore.text = _textscore.text = intscore.ToString();
        _pausetexthighscore.text = _texthighscore.text = highscore.ToString();
        
        if (player.position.x >= 3.50f || player.position.y <= -2f || player.position.x <= -3.50f) //проверяем игрока на вылет из игровой зоны по координама, по идее можно было через простые тригеры, но кодом надежнее
        {    //бля костыль бесит, но ничего лучше я не придумал (я про весь этот код)
            player.transform.position = new Vector3(0, 0, player.position.z);
        }
        
        if (intscore >= highscore) //переопределяем очки
        {
            highscore = intscore;
            PlayerPrefsSafe.SetInt("highscorepoints", highscore);
        }
        
        PlayerPrefsSafe.SetInt("points", intscore);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && LoseEvent != null)
        {
            PlayerPrefsSafe.SetInt("highscorepoints", highscore);
            player.isKinematic = true;
            if (intscore >= highscore)
            {
                highscore = intscore;
                PlayerPrefsSafe.SetInt("highscorepoints", highscore);
                Social.ReportScore(highscore, "CgkIjqSPppUVEAIQAg", success => { });
                //AddScoreToLeaderboard("CgkIjqSPppUVEAIQAg", highscore);
            }

            if (highscore >= 1000) //first 1000 achievment
            {
                UnlockAchievement("CgkIjqSPppUVEAIQAQ");
            }
            
            if (highscore >= 2000) //first 2000 achievment
            {
                UnlockAchievement("CgkIjqSPppUVEAIQBA");
            }
            
            if (highscore >= 5000) //first 5000 achievment
            {
                UnlockAchievement("CgkIjqSPppUVEAIQBQ");
            }
            LoseEvent.Invoke();
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
