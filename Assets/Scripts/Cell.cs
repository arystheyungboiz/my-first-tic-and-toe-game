using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
   public GameObject Finished;
   public Sprite x;
   public Sprite o;

   public int row;
   public int column;

   private Transform canvas;

   private Button button;

   private Image image;

   private Board board;

   private void Awake()
   {
    image = GetComponent<Image>();
    button = GetComponent<Button>();
    button.onClick.AddListener(Click);
   }

   private void Start()
   {
    board = FindObjectOfType<Board>();
    canvas = FindObjectOfType<Canvas>().transform;
   }

   public void Change(string a)
   {
    if (a == "x")
    {
       image.sprite = x;
    }
    else 
    {
        image.sprite = o;
    }
   }
   public void Click()
   {
    Change(board.Turn);
    if(board.Check(row, column))
    {
        GameObject window = Instantiate(Finished, canvas);
        window.GetComponent<Finished>().SetName(board.Turn);
    }

    if (board.Turn == "x")
    {
        board.Turn = "o";
    }
    else
    {
        board.Turn = "x";
    }
   }
   
}
