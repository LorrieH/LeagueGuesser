using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionChecker : MonoBehaviour 
{
    private QuestionGenerator questionGenerator;
    [SerializeField]private InputField inputAnswer;
    [SerializeField]private GameObject victoryScreen;
    [SerializeField]private GameObject defeatScreen;

	void Start () 
    {
        questionGenerator = GetComponent<QuestionGenerator>();
	}

    public void CheckQuestion()
    {
        string tempAnswer = inputAnswer.text;
        string answer = tempAnswer.ToLower();
        Debug.Log(answer);
        int pos = System.Array.IndexOf(questionGenerator.currentQuestion.questionAnswers, answer);
        if (pos > -1)
        {
            Debug.Log("Correct!");
            StartCoroutine(Victory());
        }
        else
        {
            Debug.Log("Fout!");
            StartCoroutine(Defeat());
        }
    }

    IEnumerator Victory()
    {
        inputAnswer.text = "";
        victoryScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        victoryScreen.SetActive(false);
        questionGenerator.NextQuestion();
    }

    IEnumerator Defeat()
    {
        inputAnswer.text = "";
        defeatScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        defeatScreen.SetActive(false);
        questionGenerator.NextQuestion();
    }

}
