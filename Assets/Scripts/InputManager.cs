using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public TextMeshProUGUI screen;

    public string screenText;
    public List<string> textList = new List<string>();

    void Update()
    {
        SetInput();
    }

    private void SetInput()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.TryGetComponent(out ButtonBase buttonBase))
                {
                    buttonBase.Operation(textList);
                    buttonBase.Move();
                }
            }
        }
    }
}


