using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionChecker : MonoBehaviour 
{
    private QuestionGenerator questionGenerator;
    private ImageEffects victoryEffectScript;
    private ImageEffects defeatEffectScript;
    [SerializeField]private InputField inputAnswer;
    [SerializeField]private GameObject victoryScreen;
    [SerializeField]private GameObject defeatScreen;

	void Start () 
    {
        questionGenerator = GetComponent<QuestionGenerator>();
        victoryEffectScript = victoryScreen.GetComponentInChildren<ImageEffects>();
        defeatEffectScript = defeatScreen.GetComponentInChildren<ImageEffects>();
    }

    public void CheckQuestion()
    {
        string tempAnswer = inputAnswer.text;
        string answer = tempAnswer.ToLower();
        int pos = System.Array.IndexOf(questionGenerator.currentQuestion.questionAnswers, answer);
        if (pos > -1)
        {
            StartCoroutine(Victory());
        }
        else
        {
            StartCoroutine(Defeat());
        }
    }

    IEnumerator Victory()
    {
        victoryEffectScript.ResetTimer();
        inputAnswer.text = "";
        victoryScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        victoryScreen.SetActive(false);
        questionGenerator.NextQuestion();
    }

    IEnumerator Defeat()
    {
        defeatEffectScript.ResetTimer();
        inputAnswer.text = "";
        defeatScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        defeatScreen.SetActive(false);
        questionGenerator.NextQuestion();
    }

}
