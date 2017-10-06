﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

public class QuestionManagerController : MonoBehaviour {

    [SerializeField]
    GameObject QuestionText;
    [SerializeField]
    GameObject kid;
    [SerializeField]
    int hardness;
    [HideInInspector]
    public int SymbolType;
    [HideInInspector]
    public int SymbolType2;

    int b = 0;
    int a = 0;
    int c = 0;
    //More readability
    enum Difficulty
    {
        easy = 0, normal, hard
    }
   public enum Equation
    {
        Addition = 0, Subtraction,AddAndSubtract,Comparisson,MultipleEq
    }
    //This is for addition
    int[] Easy = new int[20];
    int[] Normal = new int[50];
    int[] Hard = new int[100];

    //The answer to the generated question
    int answer = 0;
    
    void Start()
    {
        //Fill in the 3 Arrays
        int index = 0;
        for (int i = 0; i < 100; i++)
        {
            if (i < 50)
            {
                if (i % 2 == 0 && index < 10)
                {
                    Easy[index] = index+1;
                    index++;
                }

                Normal[i] = i;
            }

            Hard[i] = i;
           
        }

        GenerateQuestion();
    }

    private void OnEnable()
    {
        GameManager.QuestionTime += GenerateQuestion;
    }

    private void OnDisable()
    {
        GameManager.QuestionTime -= GenerateQuestion;
    }
    int type;
    public void GenerateQuestion()
    {
        int difficulty = 0;
        int Equationtype = (int)InfoManager.instance.ID;

        switch (difficulty)
        {
            case (int)Difficulty.easy:
                 a = Easy[(int)Random.Range(0, 10)];
                 b = Easy[(int)Random.Range(0, 5)];
                c = Easy[(int)Random.Range(0, 5)];
                break;
            case (int)Difficulty.normal:
                a = Normal[(int)Random.Range(0, 49)];
                b = Normal[(int)Random.Range(0, 49)];
                c = Easy[(int)Random.Range(0, 49)]; 
                break;
            case (int)Difficulty.hard:
                a = Hard[(int)Random.Range(0, 99)];
                b = Hard[(int)Random.Range(0, 99)];
                c = Easy[(int)Random.Range(0, 99)];
                break;
        }

        type = 0;
        switch (Equationtype)
        {
            
            case (int)Equation.Addition:
                SymbolType = 0;
                if (a >= b)
                    QuestionText.GetComponent<Text>().text = a.ToString() + "\n+" + b.ToString() + "\n----";
                else
                    QuestionText.GetComponent<Text>().text = b.ToString() + "\n+" + a.ToString() + "\n----";
                answer = a + b;
                break;
/////////////////
            case (int)Equation.Subtraction:
                SymbolType = 1;
                if (a >= b || a == b)
                {
                    QuestionText.GetComponent<Text>().text = (a+1).ToString() + "\n-" + b.ToString() + "\n----";
                    a++;
                    answer = a - b;
                }
                else
                {
                    int temp = a;
                    a = b;
                    b = temp;

                    QuestionText.GetComponent<Text>().text = a.ToString() + "\n-" + b.ToString() + "\n----";
                    answer = a - b;
                }
                break;

/////////////////
            case (int)Equation.AddAndSubtract:
                type+= Random.Range(0,2);
                if (type % 2 == 0)
                {
                    SymbolType = 0;
                    if (a >= b)
                        QuestionText.GetComponent<Text>().text = a.ToString() + "\n+" + b.ToString() + "\n----";
                    else
                    {
                        int temp = a;
                        a = b;
                        b = temp;
                        QuestionText.GetComponent<Text>().text = a.ToString() + "\n+" + b.ToString() + "\n----";
                    }
                    answer = a + b;
                }
                else
                {
                    SymbolType = 1;
                    if (a >= b || a == b)
                    {
                        QuestionText.GetComponent<Text>().text = (a + 1).ToString() + "\n-" + b.ToString() + "\n----";
                        a++;
                        answer =a - b;
                    }
                    else
                    {
                        int temp = a;
                        a = b;
                        b = temp;
                        QuestionText.GetComponent<Text>().text = a.ToString() + "\n-" + b.ToString() + "\n----";
                        answer = a - b;
                    }
                }
                break;

/////////////////
            case (int)Equation.Comparisson:
                if (a > b)
                   answer = SymbolType = 3;   
                
                else if (b > a)
                    answer = SymbolType = 4;

                else
                    answer = SymbolType = 2;       
                break;
            /////////////////

            case (int)Equation.MultipleEq:
                type = Random.Range(0, 2);
                QuestionText.GetComponent<Text>().text = a.ToString() + "\n+" + b.ToString() + "\n-" + c.ToString()+ "\n----";
                SymbolType = 0;
                SymbolType2 = 1;
                answer = a + b - c;
                break;

            /////////////////
            case 5:
                SymbolType = 0;
                if (a >= b)
                    QuestionText.GetComponent<Text>().text = a.ToString() + "\n+" + b.ToString() + "\n----";
                else
                    QuestionText.GetComponent<Text>().text = b.ToString() + "\n+" + a.ToString() + "\n----";
                answer = a + b;
                break;

/////////////////
            case 6:
                SymbolType = 1;
                if (a >= b || a == b)
                {
                    QuestionText.GetComponent<Text>().text = (a + 1).ToString() + "\n-" + b.ToString() + "\n----";
                    a++;
                    answer = a - b;
                }
                else
                {
                    int temp = a;
                    a = b;
                    b = temp;

                    QuestionText.GetComponent<Text>().text = a.ToString() + "\n-" + b.ToString() + "\n----";
                    answer = a - b;
                }
                break;

/////////////////
            case 7:
                type += Random.Range(0, 2);
                if (type % 2 == 0)
                {
                    SymbolType = 0;
                    if (a >= b)
                        QuestionText.GetComponent<Text>().text = a.ToString() + "\n+" + b.ToString() + "\n----";
                    else
                    {
                        int temp = a;
                        a = b;
                        b = temp;
                        QuestionText.GetComponent<Text>().text = a.ToString() + "\n+" + b.ToString() + "\n----";
                    }
                    answer = a + b;
                }
                else
                {
                    SymbolType = 1;
                    if (a >= b || a == b)
                    {
                        QuestionText.GetComponent<Text>().text = (a + 1).ToString() + "\n-" + b.ToString() + "\n----";
                        a++;
                        answer = a - b;
                    }
                    else
                    {
                        int temp = a;
                        a = b;
                        b = temp;
                        QuestionText.GetComponent<Text>().text = a.ToString() + "\n-" + b.ToString() + "\n----";
                        answer = a - b;
                    }
                }
                break;

/////////////////
            case 8:
                if (a > b)
                    answer = SymbolType = 3;

                else if (b > a)
                    answer = SymbolType = 4;

                else
                    answer = SymbolType = 2;
                break;
/////////////////
          //  case 9:
          //      break;
            default:
                SymbolType = 0;
                if (a >= b)
                    QuestionText.GetComponent<Text>().text = a.ToString() + "\n+" + b.ToString() + "\n----";
                else
                    QuestionText.GetComponent<Text>().text = b.ToString() + "\n+" + a.ToString() + "\n----";
                answer = a + b;
                break;

        }
        GameManager.instance.a = a;
        GameManager.instance.b = b;
        GameManager.instance.c  = c;
        GameManager.instance.answer = answer;
        
    }

    

    public void CompareResults(int userSub)
    {
        if (userSub == answer)
            GameManager.instance.CorrectAnswer();
        else
            GameManager.instance.WrongAnswer();// GenerateQuestion();



    }
    
}
