using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionGenerator : MonoBehaviour {

    public Question[] questions;
    public Question currentQuestion;

    private FadeImage fadeScript;
    [SerializeField]private Text questionText;
    [SerializeField]private Image questionImage;

    void Start()
    {
        fadeScript = GameObject.FindWithTag("QuestionImage").GetComponent<FadeImage>();
        NextQuestion();
    }

	public void NextQuestion()
    {
        currentQuestion = GenerateQuestion();
        questionText.text = currentQuestion.questionString;
        questionImage.sprite = currentQuestion.questionImage;
        fadeScript.ResetAlpha();
	}

    private Question GenerateQuestion()
    {
        int index = Random.Range(0,questions.Length);
        return questions[index];
    }

}
