using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject canvas;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("InputManager").GetComponent<InputManager>().enabled = false;
            for (int i = 0; i < canvas.transform.childCount; i++)
            {
                Transform tmp = canvas.transform.GetChild(i);
                if (tmp.tag == "FinishUI")
                    tmp.gameObject.SetActive(true);
            }
            //Time.timeScale = 0;

            other.GetComponent<Movement>().enabled = false;
            other.GetComponent<Animator>().enabled = false;
        }
    }
}
