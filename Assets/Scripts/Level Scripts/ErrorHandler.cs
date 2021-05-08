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

    IEnumerator ShowError(int seconds)
    {
        errorFade.FadeIn();
        yield return new WaitForSeconds(seconds);
        errorFade.FadeOut();
    }

    public void RaiseError(string errorText)
    {
        errorMessage.text = errorText;
        StartCoroutine(ShowError(1));
    }
}
