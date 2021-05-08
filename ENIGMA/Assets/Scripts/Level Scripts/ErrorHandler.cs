using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ErrorHandler : MonoBehaviour
{
    TextMeshProUGUI errorMessage;
    FadeScript errorFade;
    // Start is called before the first frame update
    void Start()
    {
        errorMessage = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        errorFade = GetComponent<FadeScript>();
    }

    IEnumerator showError(int seconds)
    {
        errorFade.FadeIn();
        yield return new WaitForSeconds(seconds);
        errorFade.FadeOut();
    }

    public void raiseError(string errorText)
    {
        errorMessage.text = errorText;
        StartCoroutine(showError(1));
    }
}
