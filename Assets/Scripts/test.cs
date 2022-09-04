using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    double val1;
        double val2;
    Stack<double> stack = new Stack<double>();
    void Start()
    {
        stack.Push(2.5);
        stack.Push(5);
         val1 = stack.Pop();
        Debug.Log("val1: " + val1);
         val2 = stack.Pop();
        stack.Push(val2 + val1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
