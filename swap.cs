using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swap : MonoBehaviour
{

    //--------------------------VARIABLES--------------------------------------------------------------------
    public Image slot11;
    public Image slot12;
    public Image slot13;
    public Image slot21;
    public Image slot22;
    public Image slot23;
    public Image slot31;
    public Image slot32;
    public Image slot33;
    public Image slot41;
    public Image slot42;
    public Image slot43;
    public Image slot51;
    public Image slot52;
    public Image slot53;

    public Sprite pyro;
    public Sprite hydro;
    public Sprite geo;
    public Sprite anemo;
    public Sprite electro;
    public Sprite cryo;
    public Sprite dendro;
    public Sprite fatui;
    public Sprite hilichurl;
    public Sprite slimes;

    public Button button;
    public Text Points;

    [SerializeField]
    private incrementBet bet;

    private int index;
    public int totalPoints;
    public int pointsAwarded;


    private Image[] panels;
    private Image[,] panels_t = new Image[3, 5];
    public int[,] intArray = new int[3, 5];

    //--------------------ON-CLICK-----------------------------------------------------------------
    public void ButtonClicked()
    {

        int index = 0;                          //index for the 1d to 2d conversion

        //convert panels to a 2d array because we cannot populate a 2d array in unity editor
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                panels_t[i, j] = panels[index];
                index++;
            }
        }

        //populating int array on click
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                intArray[i, j] = Random.Range(1, 100);
            }
        }

        //--------------------------ODDS--------------------------------------------------------------------
        //conversion from odds to integers
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (intArray[i, j] <= 11)                             //odds of pyro 11%
                {
                    intArray[i, j] = 1;
                }

                else if (intArray[i, j] > 11 & intArray[i, j] <= 22) //odds of hydro 11%
                {
                    intArray[i, j] = 2;
                }

                else if (intArray[i, j] > 22 & intArray[i, j] <= 33) //odds of geo 11%
                {
                    intArray[i, j] = 3;
                }

                else if (intArray[i, j] > 33 & intArray[i, j] <= 44) //odds of anemo 11%
                {
                    intArray[i, j] = 4;
                }

                else if (intArray[i, j] > 44 & intArray[i, j] <= 55) //odds of electro 11%
                {
                    intArray[i, j] = 5;
                }

                else if (intArray[i, j] > 55 & intArray[i, j] <= 66) //odds of cryo 11%
                {
                    intArray[i, j] = 6;
                }

                else if (intArray[i, j] > 66 & intArray[i, j] <= 77) //odds of dendro 11%
                {
                    intArray[i, j] = 7;
                }

                else if (intArray[i, j] > 77 & intArray[i, j] <= 87) //odds of fatui 10%
                {
                    intArray[i, j] = 8;
                }

                else if (intArray[i, j] > 87 & intArray[i, j] <= 90) //odds of hilichurl 3%
                {
                    intArray[i, j] = 9;
                }

                else if (intArray[i, j] > 90 & intArray[i, j] <= 100) //odds of slimes 10%
                {
                    intArray[i, j] = 10;
                }

            }
        }
        //--------------------------------------------------------------------------------------------------

        //feed in all nums in array
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                //use switch to convert nums to images and set
                switch (intArray[i, j])
                {
                    case 1:
                        panels_t[i, j].sprite = pyro;
                        break;
                    case 2:
                        panels_t[i, j].sprite = hydro;
                        break;
                    case 3:
                        panels_t[i, j].sprite = geo;
                        break;
                    case 4:
                        panels_t[i, j].sprite = anemo;
                        break;
                    case 5:
                        panels_t[i, j].sprite = electro;
                        break;
                    case 6:
                        panels_t[i, j].sprite = cryo;
                        break;
                    case 7:
                        panels_t[i, j].sprite = dendro;
                        break;
                    case 8:
                        panels_t[i, j].sprite = fatui;
                        break;
                    case 9:
                        panels_t[i, j].sprite = hilichurl;
                        break;
                    case 10:
                        panels_t[i, j].sprite = slimes;
                        break;
                }
            }
        }

        checkWins(intArray);

    } //end main

    public void checkWins(int[,] intArray)
    {

        int pointsAwarded = 0;
        //--------------------------WIN_SETS--------------------------------------------------------------------
        //check for horozontal matches        
        for (int i = 0; i < 3; i++)
        {
            int j = 0;
            if (intArray[i, j] == intArray[i, j + 1] &&         //5 match
                intArray[i, j + 1] == intArray[i, j + 2] &&
                intArray[i, j + 2] == intArray[i, j + 3] &&
                intArray[i, j + 3] == intArray[i, j + 4])
            {
                pointsAwarded = pointsAwarded + 5;
            }

            else if (intArray[i, j] == intArray[i, j + 1] &&         //4 match
                    intArray[i, j + 1] == intArray[i, j + 2] &&
                    intArray[i, j + 2] == intArray[i, j + 3] ||
                    intArray[i, j + 1] == intArray[i, j + 2] &&
                    intArray[i, j + 2] == intArray[i, j + 3] &&
                    intArray[i, j + 3] == intArray[i, j + 4])
            {
                pointsAwarded = pointsAwarded + 2;
            }

            else if (intArray[i, j] == intArray[i, j + 1] &&         //3 match
                    intArray[i, j + 1] == intArray[i, j + 2] ||
                    intArray[i, j + 1] == intArray[i, j + 2] &&
                    intArray[i, j + 2] == intArray[i, j + 3] ||
                    intArray[i, j + 2] == intArray[i, j + 3] &&
                    intArray[i, j + 3] == intArray[i, j + 4])
            {
                pointsAwarded = pointsAwarded + 1;
            }
        }

        //check for top w match        
        if (intArray[0, 0] == intArray[1, 1] &&         //5 match
            intArray[1, 1] == intArray[0, 2] &&
            intArray[0, 2] == intArray[1, 3] &&
            intArray[1, 3] == intArray[0, 4])
        {
            pointsAwarded = pointsAwarded + 5;
        }

        else if (intArray[0, 0] == intArray[1, 1] &&         //4 match
                intArray[1, 1] == intArray[0, 2] &&
                intArray[0, 2] == intArray[1, 3] ||
                intArray[1, 1] == intArray[0, 2] &&
                intArray[0, 2] == intArray[1, 3] &&
                intArray[1, 3] == intArray[0, 4])
        {
            pointsAwarded = pointsAwarded + 2;
        }

        else if (intArray[0, 0] == intArray[1, 1] &&         //3 match
                intArray[1, 1] == intArray[0, 2] ||
                intArray[1, 1] == intArray[0, 2] &&
                intArray[0, 2] == intArray[1, 3] ||
                intArray[0, 2] == intArray[1, 3] &&
                intArray[1, 3] == intArray[0, 4])
        {
            pointsAwarded = pointsAwarded + 1;
        }

        //check for a pyramid match        
        if (intArray[2, 0] == intArray[1, 1] &&         //5 match
            intArray[1, 1] == intArray[0, 2] &&
            intArray[0, 2] == intArray[1, 3] &&
            intArray[1, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 5;
        }

        else if (intArray[2, 0] == intArray[1, 1] &&         //4 match
                intArray[1, 1] == intArray[0, 2] &&
                intArray[0, 2] == intArray[1, 3] ||
                intArray[1, 1] == intArray[0, 2] &&
                intArray[0, 2] == intArray[1, 3] &&
                intArray[1, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 2;
        }

        else if (intArray[2, 0] == intArray[1, 1] &&         //3 match
                intArray[1, 1] == intArray[0, 2] ||
                intArray[1, 1] == intArray[0, 2] &&
                intArray[0, 2] == intArray[1, 3] ||
                intArray[0, 2] == intArray[1, 3] &&
                intArray[1, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 1;
        }

        //check for slide match
        if (intArray[0, 0] == intArray[1, 1] &&         //5 match
            intArray[1, 1] == intArray[1, 2] &&
            intArray[1, 2] == intArray[1, 3] &&
            intArray[1, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 5;
        }

        else if (intArray[0, 0] == intArray[1, 1] &&         //4 match
                intArray[1, 1] == intArray[1, 2] &&
                intArray[1, 2] == intArray[1, 3] ||
                intArray[1, 1] == intArray[1, 2] &&
                intArray[1, 2] == intArray[1, 3] &&
                intArray[1, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 2;
        }

        else if (intArray[0, 0] == intArray[1, 1] &&         //3 match
                intArray[1, 1] == intArray[1, 2] ||
                intArray[1, 1] == intArray[1, 2] &&
                intArray[1, 2] == intArray[1, 3] ||
                intArray[1, 2] == intArray[1, 3] &&
                intArray[1, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 1;
        }

        //check for big W match
        if (intArray[0, 0] == intArray[2, 1] &&         //5 match
            intArray[2, 1] == intArray[0, 2] &&
            intArray[0, 2] == intArray[2, 3] &&
            intArray[2, 3] == intArray[0, 4])
        {
            pointsAwarded = pointsAwarded + 5;
        }

        else if (intArray[0, 0] == intArray[2, 1] &&         //4 match
                intArray[2, 1] == intArray[0, 2] &&
                intArray[0, 2] == intArray[2, 3] ||
                intArray[2, 1] == intArray[0, 2] &&
                intArray[0, 2] == intArray[2, 3] &&
                intArray[2, 3] == intArray[0, 4])
        {
            pointsAwarded = pointsAwarded + 2;
        }

        else if (intArray[0, 0] == intArray[2, 1] &&         //3 match
                intArray[2, 1] == intArray[0, 2] ||
                intArray[2, 1] == intArray[0, 2] &&
                intArray[0, 2] == intArray[2, 3] ||
                intArray[0, 2] == intArray[2, 3] &&
                intArray[2, 3] == intArray[0, 4])
        {
            pointsAwarded = pointsAwarded + 1;
        }

        //check for left slide match
        if (intArray[2, 0] == intArray[1, 1] &&         //5 match
            intArray[1, 1] == intArray[1, 2] &&
            intArray[1, 2] == intArray[1, 3] &&
            intArray[1, 3] == intArray[0, 4])
        {
            pointsAwarded = pointsAwarded + 5;
        }

        else if (intArray[2, 0] == intArray[1, 1] &&         //4 match
                intArray[1, 1] == intArray[1, 2] &&
                intArray[1, 2] == intArray[1, 3] ||
                intArray[1, 1] == intArray[1, 2] &&
                intArray[1, 2] == intArray[1, 3] &&
                intArray[1, 3] == intArray[0, 4])
        {
            pointsAwarded = pointsAwarded + 2;
        }

        else if (intArray[2, 0] == intArray[1, 1] &&         //3 match
                intArray[1, 1] == intArray[1, 2] ||
                intArray[1, 1] == intArray[1, 2] &&
                intArray[1, 2] == intArray[1, 3] ||
                intArray[1, 2] == intArray[1, 3] &&
                intArray[1, 3] == intArray[0, 4])
        {
            pointsAwarded = pointsAwarded + 1;
        }

        //check for tower match
        if (intArray[2, 0] == intArray[2, 1] &&         //5 match
            intArray[2, 1] == intArray[0, 2] &&
            intArray[0, 2] == intArray[2, 3] &&
            intArray[2, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 5;
        }

        else if (intArray[2, 0] == intArray[2, 1] &&         //4 match
                intArray[2, 1] == intArray[0, 2] &&
                intArray[0, 2] == intArray[2, 3] ||
                intArray[2, 1] == intArray[0, 2] &&
                intArray[0, 2] == intArray[2, 3] &&
                intArray[2, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 2;
        }

        else if (intArray[2, 0] == intArray[2, 1] &&         //3 match
                intArray[2, 1] == intArray[0, 2] ||
                intArray[2, 1] == intArray[0, 2] &&
                intArray[0, 2] == intArray[2, 3] ||
                intArray[0, 2] == intArray[2, 3] &&
                intArray[2, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 1;
        }

        //check for scatter match
        if (intArray[1, 0] == intArray[2, 1] &&         //5 match
            intArray[2, 1] == intArray[0, 2] &&
            intArray[0, 2] == intArray[2, 3] &&
            intArray[2, 3] == intArray[1, 4])
        {
            pointsAwarded = pointsAwarded + 5;
        }

        else if (intArray[1, 0] == intArray[2, 1] &&         //4 match
                intArray[2, 1] == intArray[0, 2] &&
                intArray[0, 2] == intArray[2, 3] ||
                intArray[2, 1] == intArray[0, 2] &&
                intArray[0, 2] == intArray[2, 3] &&
                intArray[2, 3] == intArray[1, 4])
        {
            pointsAwarded = pointsAwarded + 2;
        }

        else if (intArray[1, 0] == intArray[2, 1] &&         //3 match
                intArray[2, 1] == intArray[0, 2] ||
                intArray[2, 1] == intArray[0, 2] &&
                intArray[0, 2] == intArray[2, 3] ||
                intArray[0, 2] == intArray[2, 3] &&
                intArray[2, 3] == intArray[1, 4])
        {
            pointsAwarded = pointsAwarded + 1;
        }

        //check for smile match
        if (intArray[0, 0] == intArray[2, 1] &&         //5 match
            intArray[2, 1] == intArray[2, 2] &&
            intArray[2, 2] == intArray[2, 3] &&
            intArray[2, 3] == intArray[0, 4])
        {
            pointsAwarded = pointsAwarded + 5;
        }

        else if (intArray[0, 0] == intArray[2, 1] &&         //4 match
                intArray[2, 1] == intArray[2, 2] &&
                intArray[2, 2] == intArray[2, 3] ||
                intArray[2, 1] == intArray[2, 2] &&
                intArray[2, 2] == intArray[2, 3] &&
                intArray[2, 3] == intArray[0, 4])
        {
            pointsAwarded = pointsAwarded + 2;
        }

        else if (intArray[0, 0] == intArray[2, 1] &&         //3 match
                intArray[2, 1] == intArray[2, 2] ||
                intArray[2, 1] == intArray[2, 2] &&
                intArray[2, 2] == intArray[2, 3] ||
                intArray[2, 2] == intArray[2, 3] &&
                intArray[2, 3] == intArray[0, 4])
        {
            pointsAwarded = pointsAwarded + 1;
        }

        //check for mountain match        
        if (intArray[0, 0] == intArray[1, 1] &&         //5 match
            intArray[1, 1] == intArray[0, 2] &&
            intArray[0, 2] == intArray[1, 3] &&
            intArray[1, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 5;
        }

        else if (intArray[0, 0] == intArray[1, 1] &&         //4 match
                intArray[1, 1] == intArray[0, 2] &&
                intArray[0, 2] == intArray[1, 3] ||
                intArray[1, 1] == intArray[0, 2] &&
                intArray[0, 2] == intArray[1, 3] &&
                intArray[1, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 2;
        }

        else if (intArray[0, 0] == intArray[1, 1] &&         //3 match
                intArray[1, 1] == intArray[0, 2] ||
                intArray[1, 1] == intArray[0, 2] &&
                intArray[0, 2] == intArray[1, 3] ||
                intArray[0, 2] == intArray[1, 3] &&
                intArray[1, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 1;
        }

        //check for M match        
        if (intArray[2, 0] == intArray[0, 1] &&         //5 match
            intArray[0, 1] == intArray[2, 2] &&
            intArray[2, 2] == intArray[0, 3] &&
            intArray[0, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 5;
        }

        else if (intArray[2, 0] == intArray[0, 1] &&         //4 match
                intArray[0, 1] == intArray[2, 2] &&
                intArray[2, 2] == intArray[0, 3] ||
                intArray[0, 1] == intArray[2, 2] &&
                intArray[2, 2] == intArray[0, 3] &&
                intArray[0, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 2;
        }

        else if (intArray[2, 0] == intArray[0, 1] &&         //3 match
                intArray[0, 1] == intArray[2, 2] ||
                intArray[0, 1] == intArray[2, 2] &&
                intArray[2, 2] == intArray[0, 3] ||
                intArray[2, 2] == intArray[0, 3] &&
                intArray[0, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 1;
        }


        //check for hill match
        if (intArray[2, 0] == intArray[1, 1] &&         //5 match
            intArray[1, 1] == intArray[1, 2] &&
            intArray[1, 2] == intArray[1, 3] &&
            intArray[1, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 5;
        }

        else if (intArray[2, 0] == intArray[1, 1] &&         //4 match
                intArray[1, 1] == intArray[1, 2] &&
                intArray[1, 2] == intArray[1, 3] ||
                intArray[1, 1] == intArray[1, 2] &&
                intArray[1, 2] == intArray[1, 3] &&
                intArray[1, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 2;
        }

        else if (intArray[2, 0] == intArray[1, 1] &&         //3 match
                intArray[1, 1] == intArray[1, 2] ||
                intArray[1, 1] == intArray[1, 2] &&
                intArray[1, 2] == intArray[1, 3] ||
                intArray[1, 2] == intArray[1, 3] &&
                intArray[1, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 1;
        }

        //check for snake match1s
        if (intArray[0, 0] == intArray[2, 1] &&         //5 match
            intArray[2, 1] == intArray[1, 2] &&
            intArray[1, 2] == intArray[2, 3] &&
            intArray[2, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 5;
        }

        else if (intArray[0, 0] == intArray[2, 1] &&         //4 match
                intArray[2, 1] == intArray[1, 2] &&
                intArray[1, 2] == intArray[2, 3] ||
                intArray[2, 1] == intArray[1, 2] &&
                intArray[1, 2] == intArray[2, 3] &&
                intArray[2, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 2;
        }

        else if (intArray[0, 0] == intArray[2, 1] &&         //3 match
                intArray[2, 1] == intArray[1, 2] ||
                intArray[2, 1] == intArray[1, 2] &&
                intArray[1, 2] == intArray[2, 3] ||
                intArray[1, 2] == intArray[2, 3] &&
                intArray[2, 3] == intArray[2, 4])
        {
            pointsAwarded = pointsAwarded + 1;
        }

        //------------------------check for special wins---------------------------------------

        //pointsAwarded = checkScatterWins(intArray);
        //scatter wins
        int counter = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (intArray[i, j] == 9)
                {
                    counter++;
                }
            }
        }

        if (counter >= 3)
        {
            pointsAwarded = pointsAwarded + 5 * (counter - 2);
        }

        //bonus wins
        counter = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (intArray[i, j] == 8)
                {
                    counter++;
                }
            }
        }

        pointsAwarded = pointsAwarded + (1 * counter);


        //wild wins

        /*public int checkWildWins(int[,] intArray)
        {
            return pointsAwarded;
        }*/


        //-------------------output-----------------------------------------
        totalPoints += pointsAwarded * bet.betInt;
        Points.text = totalPoints.ToString();

    }
}