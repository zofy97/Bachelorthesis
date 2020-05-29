using System;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Object = System.Object;
using Random = System.Random;

public class MathCalculation : MonoBehaviour
{
    public static MathCalculation instance;
    public CoinsCounter coinsCounter;
    public LeaderboardManager leaderboardManager;

    private float a, b;
    private float answer;

    public Text valueA, valueB;
    public Text operationSign;
    public Text[] answerButtons;

    public GameObject startDialog;
    public GameObject gameElements;
    
    private int firstNumber;
    private int secondNumber;
    private MathOperations mathOperation;
    private int counter = 0;
    private int answerLocation;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        GetOperation();
    }

    private void GetOperation()
    {
        var operation = PlayerPrefs.GetString("operation");

        switch (operation)
        {
            case "lineCalculation":
                mathOperation = MathOperations.LineCalculation;
                break;
            case "pointCalculation":
                mathOperation = MathOperations.PointCalculation;
                break;
            case "smallerOrBigger":
                mathOperation = MathOperations.SmallerOrBigger;
                break;
            case "mixed":
                mathOperation = MathOperations.Mixed;
                break;
        }
    }

    public void StartMathTask()
    {
        if (startDialog.active)
        {
            startDialog.SetActive(false);
            gameElements.SetActive(true);
        }

        CreateMathTask(mathOperation);
        Debug.Log(mathOperation);
    }

    public void CheckAnswer()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        if (EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text == answer.ToString())
        {
            Debug.Log("Correct");
            coinsCounter.SaveCoinsIntern(coinsCounter.GetCoinsIntern() + 10);
            coinsCounter.UpdateCounterText();
            Debug.Log(coinsCounter.GetCoinsIntern());
            var coins = coinsCounter.GetCoinsIntern();
            UpdateCoinsCounter(coins);
            
            leaderboardManager.SendLeaderboardInfos(coins);
            StartMathTask();
        }
        else
        {
            Debug.Log("False");
            StartMathTask();
        }
    }
    
    public void UpdateCoinsCounter(int coins)
    {
        new LogEventRequest().SetEventKey("SAVE_PLAYER").SetEventAttribute("COINS", coins).Send((response) => {
            if (!response.HasErrors) {
                Debug.Log("Player Saved To GameSparks...");
            } else {
                Debug.Log("Error Saving Player Data...");
            }
        });
    }

    private object[] CreateMathTask(MathOperations mathOperator)
    {
        //var numbers = GenerateRandomNumbers();

        //var a = numbers[0];
        //var b = numbers[1];

        switch (mathOperator)
        {
            case MathOperations.LineCalculation:
                if (counter % 2 == 0)
                    Addition();
                else
                    Subtraction();
                
                break;
            case MathOperations.PointCalculation:
                if (counter % 2 == 0)
                    Multiplication();
                else
                    Division();
                break;
            case MathOperations.SmallerOrBigger:
                SmallerOrBigger();
                break;
            case MathOperations.Mixed:
                Addition();
                Subtraction();
                Multiplication();
                Division();
                counter++;
                SmallerOrBigger();
                break;
        }

        var extraAnswers = new int[4];
        var random = new Random();

        extraAnswers[0] = (int) answer + random.Next(3, 11);
        extraAnswers[1] = (int) answer - random.Next(7, 10);
        extraAnswers[2] = (int) answer * random.Next(2, 4);
        extraAnswers[3] = (int) answer - random.Next(4, 7);
        

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (extraAnswers[i] == answer)
                extraAnswers[i]++;
            if (i != answerLocation)
                answerButtons[i].text = extraAnswers[i].ToString();
        }
        //answerButtons[0].text = extraAnswers[0].ToString();
        //answerButtons[1].text = extraAnswers[1].ToString();
        //answerButtons[2].text = extraAnswers[2].ToString();

        var task = new object[] {a, b, mathOperator, answer};

        return task;
    }

    private int[] GenerateRandomNumbers(int min, int max)
    {
        var r = new Random();
        firstNumber = r.Next(min, max);
        secondNumber = r.Next(min, max);

        return new[] {firstNumber, secondNumber};
    }

    private void Addition()
    {
        var numbers = GenerateRandomNumbers(1, 15);
        a = numbers[0];
        b = numbers[1];

        answer = a + b;

        valueA.text = a.ToString();
        valueB.text = b.ToString();
        operationSign.text = "+";

        var random = new Random();
        answerLocation  = random.Next(0, 3);
        answerButtons[answerLocation].text = answer.ToString();

        counter++;
    }

    private void Subtraction()
    {
        int[] numbers = GenerateRandomNumbers(1, 15);
        while (numbers[0] < numbers[1])
            numbers = GenerateRandomNumbers(1,15);
        a = numbers[0];
        b = numbers[1];

        answer = a - b;

        valueA.text = a.ToString();
        valueB.text = b.ToString();
        operationSign.text = "-";
        
        var random = new Random();
        answerLocation  = random.Next(0, 3);
        answerButtons[answerLocation].text = answer.ToString();

        counter++;
    }

    private void Multiplication()
    {
        var numbers = GenerateRandomNumbers(1, 10);
        a = numbers[0];
        b = numbers[1];

        answer = a * b;

        valueA.text = a.ToString();
        valueB.text = b.ToString();
        operationSign.text = "*";
        
        var random = new Random();
        answerLocation  = random.Next(0, 3);
        answerButtons[answerLocation].text = answer.ToString();
    }

    private void Division()
    {
        var numbers = GenerateRandomNumbers(1, 30);
        while (numbers[0] % numbers[1] != 0)
            numbers = GenerateRandomNumbers(1, 30);
        a = numbers[0];
        b = numbers[1];

        answer = a / b;

        valueA.text = a.ToString();
        valueB.text = b.ToString();
        operationSign.text = "/";
        
        var random = new Random();
        answerLocation  = random.Next(0, 3);
        answerButtons[answerLocation].text = answer.ToString();
    }

    private void SmallerOrBigger()
    {
        var numbers = GenerateRandomNumbers(1, 99);
        a = numbers[0];
        b = numbers[1];

        valueA.text = a.ToString();
        valueB.text = b.ToString();

        if (a < b)
            operationSign.text = "<";
        else if (a > b)
            operationSign.text = ">";
        else
            operationSign.text = "=";
    }

    public object[] SelectAdditionSubtraction()
    {
        PlayerPrefs.SetString("operation", "addition");

        var taskSet = new object[9];
        for (var i = 1; i < taskSet.Length; i++)
        {
            //taskSet[i-1] = CreateMathTask(MathOperations.Addition);
            //taskSet[i] = CreateMathTask(MathOperations.Subtraction);
            i++;
        }

        return taskSet;
    }

    public object[] SelectMultiplicationDivision()
    {
        PlayerPrefs.SetString("operation", "multiplication");

        var taskSet = new object[9];
        for (var i = 1; i < taskSet.Length; i++)
        {
            //taskSet[i-1] = CreateMathTask(MathOperations.Multiplication);
            //taskSet[i] = CreateMathTask(MathOperations.Division);
            i++;
        }

        return taskSet;
    }
}

public enum MathOperations
{
    LineCalculation,
    PointCalculation,
    SmallerOrBigger,
    Mixed
}