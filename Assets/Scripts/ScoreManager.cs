using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
   public GameObject player;
   [SerializeField] private Text _textscore;
   public int intscore;

   private void FixedUpdate()
   {
      intscore = Convert.ToInt32(player.transform.position.z);
      _textscore.text = intscore.ToString();
   }
}
