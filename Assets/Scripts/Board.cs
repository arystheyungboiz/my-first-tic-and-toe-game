using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
   public Transform board;
   public GridLayoutGroup grid;
   public GameObject cellpf;
   public string Turn = "x";

   public int BoardSize;

   private string[,] matrix;


   public void Start()
   {
      grid.constraintCount = BoardSize;
      matrix = new string[BoardSize +1, BoardSize +1];
      BoardCreate();
   }
   
   private void BoardCreate()
   {
      for (int i = 1; i <= BoardSize; i++)
      {
         for (int j = 1; j <= BoardSize; j++)
         {
            GameObject cellTrans = Instantiate(cellpf, board);
            Cell cell = cellTrans.GetComponent<Cell>();
            cell.row = i;
            cell.column = j;
            matrix[i,j] = "";
         }
      }
   }
   public bool Check(int row, int column)
   {
      matrix[row, column] = Turn;
      bool result = false;
   // Check row - cột
   int count = 0;

   // top - trên
   for (int i = row - 1; i >= 1; i--)
   {
      if (matrix[i,column] == Turn)
      {
         count++;
      }
      else
      {
         break;
      }
   } 

   // bottom - dưới
   for (int i = row + 1; i <= BoardSize; i++)
   {
      if (matrix[i,column] == Turn)
      {
         count++;
      }
      else
      {
         break;
      }
   } 
   if (count +1 >= 5)
   {
      result = true;
   }

   // Check column - hàng
   count = 0;

   // left - trái
   for (int i = column - 1; i >= 1; i--)
   {
      if (matrix[row,i] == Turn)
      {
         count++;
      }
      else
      {
         break;
      }
   } 

   // right - phải
   for (int i = column + 1; i <= BoardSize; i++)
   {
      if (matrix[row,i] == Turn)
      {
         count++;
      }
      else
      {
         break;
      }
   } 
   if (count +1 >= 5)
   {
      result = true;
   }


   // Check row v2 - cột v2
   count = 0;

   // top left - chéo trên trái
   for (int i = column - 1; i >= 1; i--)
   {
      if (matrix[row - (column-i),i] == Turn)
      {
         count++;
      }
      else
      {
         break;
      }
   } 

   // bottom right - chéo dưới phải
   for (int i = column + 1; i <= BoardSize; i++)
   {
      if (matrix[row + (column-i),i] == Turn)
      {
         count++;
      }
      else
      {
         break;
      }
   } 
   if (count +1 >= 5)
   {
      result = true;
   }

   // Check column v2 - hàng v2
   count = 0;

   // top left - chéo trên phải
   for (int i = column + 1; i <= BoardSize; i++)
   {
      if (matrix[row - (column-i),i] == Turn)
      {
         count++;
      }
      else
      {
         break;
      }
   } 

   // bottom right - chéo dưới trái
   for (int i = column - 1; i >= 1; i-- )
   {
      if (matrix[row + (column-i),i] == Turn)
      {
         count++;
      }
      else
      {
         break;
      }
   } 
   if (count +1 >= 5)
   {
      result = true;
   }

   return result;
   }   
}
