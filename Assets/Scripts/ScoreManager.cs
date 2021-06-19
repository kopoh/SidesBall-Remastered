using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
   public TMP_Text Text1;
   public GameObject player;
   [SerializeField] private Text _textscore;
   public int intscore;

   private void FixedUpdate()
   {
      intscore = Convert.ToInt32(player.transform.position.z);
      Text1.text = _textscore.text = intscore.ToString();
   }
}
