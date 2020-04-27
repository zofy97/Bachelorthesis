using System;
using UnityEngine;
using Object = System.Object;
using Random = System.Random;

public class MathCalculation : MonoBehaviour
{
    private int firstNumber;
    private int secondNumber;
    private MathOperations mathOperation;

    private object[] CreateMathTask(MathOperations mathOperator)
    {
        var numbers = GenerateRandomNumbers();

        var a = numbers[0];
        var b = numbers[1];
        
        var result = 0;
        switch (mathOperator)
        {
            case MathOperations.Addition:
                result = a + b;
                break;
            case MathOperations.Subtraction:
                result = a - b;
                break;
            case MathOperations.Multiplication:
                result = a * b;
                break;
            case MathOperations.Division:
                result = a / b;
                break;
        }
        
        var extraAnswers = new int[3];
        var random = new Random();

        extraAnswers[0] = result + random.Next(1, 5);
        extraAnswers[1] = result - random.Next(3, 6);
        extraAnswers[2] = result * random.Next(0, 2);
        
        var task = new Object[] {a, b, mathOperator, result};

        return task;
    }

    private int[] GenerateRandomNumbers()
    {
        Random r = new Random();
        firstNumber = r.Next(1, 10);
        secondNumber = r.Next(1, 10);
        
        return new[] {firstNumber, secondNumber};
    }

    public void SelectAdditionSubtraction()
    {
        var taskSet = new Object[9];
        for (var i = 1; i < taskSet.Length; i++)
        {
            taskSet[i-1] = CreateMathTask(MathOperations.Addition);
            taskSet[i] = CreateMathTask(MathOperations.Subtraction);
            i++;
        }
    }

    public void SelectMultiplicationDivision()
    {
        CreateMathTask(MathOperations.Multiplication);
        CreateMathTask(MathOperations.Division);
    }
}

public enum MathOperations
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}