using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class InfixConverter : MonoBehaviour
{
    // A utility function to return
    // precedence of a given operator  5 + 6
    // Higher returned value means higher precedence
    internal static int Prec(string ch)
    {
        switch (ch)
        {
            case "+":
            case "-":
                return 1;

            case "*":
            case "/":
                return 2;
            case "log":
            case "ln":
                return 3;
        }
        return -1;
    }

    // The main method that converts given infix expression
    // to postfix expression. 
    public string[] infixToPostfix(List<string> exp)
    {
        // initializing empty String for result
        string result = "";
        string[] resultlist;

        // initializing empty stack
        Stack<string> stack = new Stack<string>();

        for (int i = 0; i < exp.Count; ++i)
        {
            string c = exp[i];

            // If the scanned character is an
            // operand, add it to output.
            if (!c.Any(c => c < '0' || c > '9') || c.Contains("."))
            {
                result += c;
            }

            // If the scanned character is an '(',
            // push it to the stack.
            else if (c == "(")
            {
                stack.Push(c);
            }

            // If the scanned character is an ')',
            // pop and output from the stack 
            // until an '(' is encountered.
            else if (c == ")")
            {
                while (stack.Count > 0 &&
                        stack.Peek() != "(")
                {
                    result += stack.Pop();
                }

                if (stack.Count > 0 && stack.Peek() != "(")
                {
                    //return "Invalid Expression"; // invalid expression
                }
                else
                {
                    stack.Pop();
                }
            }
            else // an operator is encountered
            {
                result += " ";
                while (stack.Count > 0 && Prec(c) <= Prec(stack.Peek()))
                {
                    result += stack.Pop();
                }
                result += " ";
                stack.Push(c);
            }
        }

        // pop all the operators from the stack
        while (stack.Count > 0)
        {
            result += " " + stack.Pop();
        }
  
        resultlist = result.Split(' ');
        string space = " ";
        resultlist = resultlist.Where(val => val != space).ToArray();

        //for (int i = 0; i < resultlist.Length; i++)
        //{
        //    Debug.Log("resultlist[" + i + "]" + resultlist[i]);
        //}
        //return result;
        return resultlist; 
    }   

    public double evaluatePostfix(string[] exp) //string yerine list<string> yap.
    {
        // create a stack 
        Stack<double> stack = new Stack<double>();

        // Scan all characters one by one 
        for (int i = 0; i < exp.Length; i++)
        {
            string c = exp[i];

            if (c == "")
            {
                //Debug.Log("I FOUND A null YOU F*****.");
                continue;
            }
            // If the scanned character is an  
            // operand (number here),extract 
            // the number. Push it to the stack.
            //else if (c == "log")
            //{
            //    double tmp;
            //    i++;
            //    c = exp[i];
            //    Debug.Log("log c: " + c);
            //    if (c == "")
            //    {
            //        continue;
            //    }
            //    i++;
            //    c = exp[i];
            //    //tmp = double.Parse(c, CultureInfo.InvariantCulture);
            //    tmp = Convert.ToDouble(c);
            //    double logCal = Mathf.Log10((float)tmp);
            //    //tmp = Mathf.Log10((float)tmp);
            //    stack.Push(logCal);
            //}
            else if (c.Any(char.IsDigit))
            {
                //Debug.Log("c:" + c);
                //double n = 0;

                //// extract the characters and 
                //// store it in num 
                //while (char.IsDigit(c))
                //{
                //    n = n * 10 + (double)(c - '0');
                //    Debug.Log("n: " + n);
                //    i++;
                //    c = exp[i];
                //}
                //i--;

                // push the number in stack 
                //Debug.Log("AAAAAAAAAAAAAAAAAA:" + c);
                stack.Push(double.Parse(c, CultureInfo.InvariantCulture));
            }

            // If the scanned character is 
            // an operator, pop two elements 
            // from stack apply the operator 
            else
            {
                //Debug.Log("Else C: " + c);
                double val1 = stack.Pop();
                //Debug.Log("val1: " + val1);
                double val2 = stack.Pop();
                //Debug.Log("val2: " + val2);

                switch (c)
                {
                    case "+":
                        stack.Push(val2 + val1);
                        break;

                    case "-":
                        stack.Push(val2 - val1);
                        break;

                    case "/":
                        stack.Push(val2 / val1);
                        break;

                    case "*":
                        stack.Push(val2 * val1);
                        break;

                    //case "log":
                    //    stack.Push(Mathf.Log((float)val2, (float)val1));
                    //    break;
                }
            }
        }

        return stack.Pop();
    }

}


/*
  public double evaluatePostfix(string exp)
    {
        // create a stack 
        Stack<double> stack = new Stack<double>();

        // Scan all characters one by one 
        for (int i = 0; i < exp.Length; i++)
        {
            char c = exp[i];

            if (c == ' ')
            {
                continue;
            }
 
            // If the scanned character is an  
            // operand (number here),extract 
            // the number. Push it to the stack. 
            else if (char.IsDigit(c))
            {
                double n = 0;

                // extract the characters and 
                // store it in num 
                while (char.IsDigit(c))
                {
                    n = n * 10 + (double)(c - '0');
                    i++;
                    c = exp[i];
                }
                i--;

                // push the number in stack 
                stack.Push(n);
            }

            // If the scanned character is 
            // an operator, pop two elements 
            // from stack apply the operator 
            else
            {
                double val1 = stack.Pop();
                double val2 = stack.Pop();

                switch (c)
                {
                    case '+':
                        stack.Push(val2 + val1);
                        break;

                    case '-':
                        stack.Push(val2 - val1);
                        break;

                    case '/':
                        stack.Push(val2 / val1);
                        break;

                    case '*':
                        stack.Push(val2 * val1);
                        break;
                }
            }
        }
        return stack.Pop();
    }
*/































   /*static bool isOperator(char c)
    {
        return (!(c >= '0' && c <= '9'));
    }

    static int getPriority(char C)
    {
        if (C == '-' || C == '+')
            return 1;
        else if (C == '*' || C == '/')
            return 2;
        return 0;
    }

    public string infixToPrefix(string infix) //25+36
    {
        // stack for operators.
        Stack<char> operators = new Stack<char>();

        // stack for operands.
        Stack<string> operands = new Stack<string>();

        for (int i = 0; i < infix.Length; i++)
        {
            // If current character is an
            // opening bracket, then
            // push into the operators stack.
            if (infix[i] == '(')
            {
                operators.Push(infix[i]);
            }

            // If current character is a
            // closing bracket, then pop from
            // both stacks and push result
            // in operands stack until
            // matching opening bracket is
            // not found.
            else if (infix[i] == ')')
            {
                while (operators.Count != 0 &&
                    operators.Peek() != '(')
                {

                    // operand 1
                    string op1 = operands.Peek();
                    operands.Pop();

                    // operand 2
                    string op2 = operands.Peek();
                    operands.Pop();

                    // operator
                    char op = operators.Peek();
                    operators.Pop();

                    // Add operands and operator
                    // in form operator +
                    // operand1 + operand2.
                    string tmp = op + op2 + op1;
                    operands.Push(tmp);
                }

                // Pop opening bracket
                // from stack.
                operators.Pop();
            }

            // If current character is an
            // operand then push it into
            // operands stack.
            else if (!isOperator(infix[i]))
            {
                Debug.Log("operands.push " + infix[i]);
                operands.Push(infix[i] + "");
            }

            // If current character is an
            // operator, then push it into
            // operators stack after popping
            // high priority operators from
            // operators stack and pushing
            // result in operands stack.
            else
            {
                while (operators.Count != 0 &&
                    getPriority(infix[i]) <=
                        getPriority(operators.Peek()))
                {

                    string op1 = operands.Peek();
                    operands.Pop();

                    string op2 = operands.Peek();
                    operands.Pop();

                    char op = operators.Peek();
                    operators.Pop();

                    string tmp = op + op2 + op1;
                    operands.Push(tmp);
                }
                operators.Push(infix[i]);
            }
        }

        // Pop operators from operators
        // stack until it is empty and
        // operation in add result of
        // each pop operands stack.
        while (operators.Count != 0)
        {
            string op1 = operands.Peek();
            operands.Pop();

            string op2 = operands.Peek();
            operands.Pop();

            char op = operators.Peek();
            operators.Pop();

            string tmp = op + op2 + op1;
            operands.Push(tmp);
        }

        // Final prefix expression is
        // present in operands stack.
        return operands.Peek();
    }*/
/*
    static bool isOperand(char c)
    {
        // If the character is a digit
        // then it must be an operand
        if (c >= 48 && c <= 57)
            return true;
        else
            return false;
    }

    public float evaluatePrefix(string exprsn)
    {
        Stack<float> Stack = new Stack<float>();

        for (int j = exprsn.Length - 1; j >= 0; j--)
        {

            // Push operand to Stack
            // To convert exprsn[j] to digit subtract
            // '0' from exprsn[j].
            if (isOperand(exprsn[j]))
                Stack.Push((float)(exprsn[j] - 48));

            else
            {

                // Operator encountered
                // Pop two elements from Stack
                float o1 = Stack.Peek();
                Stack.Pop();
                float o2 = Stack.Peek();
                Stack.Pop();

                // Use switch case to operate on o1
                // and o2 and perform o1 O o2.
                switch (exprsn[j])
                {
                    case '+':
                        Stack.Push(o1 + o2);
                        break;
                    case '-':
                        Stack.Push(o1 - o2);
                        break;
                    case '*':
                        Stack.Push(o1 * o2);
                        break;
                    case '/':
                        Stack.Push(o1 / o2);
                        break;
                }
            }
        }
        return Stack.Peek();
    } */

