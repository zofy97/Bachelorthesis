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
    private string answerOperationSign;

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

    // declare MathCalculation instance if not already done
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // call method once scene is opened
    private void Start()
    {
        GetOperation();
    }

    // get selected Operation from PlayerPrefs
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

    /*
     * deactivate startDialog and activate gameElements to start the game
     * math task with the selected math operation is created
     */
    public void StartMathTask()
    {
        if (startDialog.active)
        {
            startDialog.SetActive(false);
            gameElements.SetActive(true);
        }

        CreateMathTask(mathOperation);
    }

    /*
     * check whether answer is correct or not
     * player gets 10 coins if answer was correct
     * leaderboard gets updated and new task gets created
     */
    public void CheckAnswer()
    {
        if (EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text == answer.ToString() || EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text == answerOperationSign)
        {
            Debug.Log("Correct");
            coinsCounter.SaveCoinsIntern(coinsCounter.GetCoinsIntern() + 10);
            coinsCounter.UpdateCounterText();
            
            var coins = coinsCounter.GetCoinsIntern();
            coinsCounter.UpdateCoinsCounter(coins);
            
            leaderboardManager.SendLeaderboardInfos(coins);
            
            StartMathTask();
        }
        else
        {
            Debug.Log("false");
            StartMathTask();
        }
    }

    /*
     * create math task with alternating math operations
     * generate random extra answers and select random location for the correct answer button
     */
    private void CreateMathTask(MathOperations mathOperator)
    {
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
                if (counter % 4 == 0)
                    Multiplication();
                else if (counter % 3 == 0)
                    Division();
                else if (counter % 2 == 0)
                    Addition();
                else 
                    Subtraction();
                break;
        }

        
        var random = new Random();
        if (mathOperator != MathOperations.SmallerOrBigger)
        {
            var extraAnswers = new int[4];

            extraAnswers[0] = (int) answer + random.Next(3, 11);
            extraAnswers[1] = (int) answer - random.Next(7, 10);
            extraAnswers[2] = (int) answer * random.Next(2, 4);
            extraAnswers[3] = (int) answer - random.Next(4, 7);

            for (var i = 0; i < answerButtons.Length; i++)
            {
                if (extraAnswers[i] == answer)
                    extraAnswers[i]++;
                if (i != answerLocation)
                    answerButtons[i].text = extraAnswers[i].ToString();
            }

            answerLocation = random.Next(0, 3);
            answerButtons[answerLocation].text = answer.ToString();
        }
        else
        {
            Debug.Log("small or bigger");

            answerButtons[0].text = "<";
            answerButtons[1].text = "=";
            answerButtons[2].text = ">";
            answerButtons[3].text = "";
        }
    }

    // generate random numbers for math tasks between min and max number
    private int[] GenerateRandomNumbers(int min, int max)
    {
        var r = new Random();
        firstNumber = r.Next(min, max);
        secondNumber = r.Next(min, max);

        return new[] {firstNumber, secondNumber};
    }

    // generate addition math tasks
    private void Addition()
    {
        var numbers = GenerateRandomNumbers(1, 15);
        a = numbers[0];
        b = numbers[1];

        answer = a + b;

        valueA.text = a.ToString();
        valueB.text = b.ToString();
        operationSign.text = "+";

        counter++;
    }

    
    // generate subtraction math tasks
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

        counter++;
    }

    
    // generate multiplication math tasks
    private void Multiplication()
    {
        var numbers = GenerateRandomNumbers(1, 10);
        a = numbers[0];
        b = numbers[1];

        answer = a * b;

        valueA.text = a.ToString();
        valueB.text = b.ToString();
        operationSign.text = "*";
        
        counter++;
    }
    
    // generate division math tasks
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
        
        counter++;
    }

    // generation smaller or bigger task
    private void SmallerOrBigger()
    {
        var numbers = GenerateRandomNumbers(1, 99);
        a = numbers[0];
        b = numbers[1];

        valueA.text = a.ToString();
        valueB.text = b.ToString();

        operationSign.text = "?";

        if (a < b)
            answerOperationSign = "<";
        else if (a > b)
            answerOperationSign = ">";
        else
            answerOperationSign = "=";
    }
}

// four different math operation modes
public enum MathOperations
{
    LineCalculation,
    PointCalculation,
    SmallerOrBigger,
    Mixed
}