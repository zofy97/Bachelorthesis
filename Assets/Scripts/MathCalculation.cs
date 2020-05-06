using System;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;
using Random = System.Random;

public class MathCalculation : MonoBehaviour
{
    public static MathCalculation instance;

    private float a, b;
    public float answer;
    
    public Text valueA , valueB;
    public Text operationSign;
    public GameObject[] answerButtons;
    
    
    private int firstNumber;
    private int secondNumber;
    private MathOperations mathOperation;

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

    private object[] CreateMathTask(MathOperations mathOperator)
    {
        var numbers = GenerateRandomNumbers();

        var a = numbers[0];
        var b = numbers[1];
        
        var result = 0;
        switch (mathOperator)
        {
            case MathOperations.LineCalculation:
                Addition();
                Subtraction();
                break;
            case MathOperations.PointCalculation:
                Multiplication();
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
                SmallerOrBigger();
                break;
        }
        
        var extraAnswers = new int[3];
        var random = new Random();

        extraAnswers[0] = result + random.Next(1, 5);
        extraAnswers[1] = result - random.Next(3, 6);
        extraAnswers[2] = result * random.Next(0, 2);
        
        var task = new object[] {a, b, mathOperator, result};

        return task;
    }
    
    private int[] GenerateRandomNumbers()
    {
        var r = new Random();
        firstNumber = r.Next(1, 10);
        secondNumber = r.Next(1, 10);
        
        return new[] {firstNumber, secondNumber};
    }

    private void Addition()
    {
        var numbers = GenerateRandomNumbers();
        a = numbers[0];
        b = numbers[1];

        answer = a + b;

        valueA.text = a.ToString();
        valueB.text = b.ToString();
        operationSign.text = "+";
    }

    private void  Subtraction()
    {
        int[] numbers = GenerateRandomNumbers();
        while (numbers[0] < numbers[1])
            numbers = GenerateRandomNumbers();
        a = numbers[0];
        b = numbers[1];

        answer = a - b;

        valueA.text = a.ToString();
        valueB.text = b.ToString();
        operationSign.text = "-";   
    }

    private void  Multiplication()
    {
        var numbers = GenerateRandomNumbers();
        a = numbers[0];
        b = numbers[1];

        answer = a * b;

        valueA.text = a.ToString();
        valueB.text = b.ToString();
        operationSign.text = "*";
    }

    private void Division()
    {
        var numbers = GenerateRandomNumbers();
        while (numbers[0] % numbers[1] != 0)
            numbers = GenerateRandomNumbers();
        a = numbers[0];
        b = numbers[1];

        answer = a - b;

        valueA.text = a.ToString();
        valueB.text = b.ToString();
        operationSign.text = "-"; 
    }

    private void SmallerOrBigger()
    {
        var numbers = GenerateRandomNumbers();
        a = numbers[0];
        b = numbers[1];

        answer = a * b;

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