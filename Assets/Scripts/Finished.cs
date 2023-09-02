using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Finished : MonoBehaviour
{
   public Text winnername;
   public Button restart;

   private void Start()
   {
    restart.onClick.AddListener(Click);
   }

   public void SetName(string a)
   {
    winnername.text = a;
   }

   public void Click()
   {
    SceneManager.LoadScene("SampleScene");
   }
}
