using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionGenerator : MonoBehaviour {

    public Question[] questions;
    public Question currentQuestion;

    private ImageEffects effectScript;
    [SerializeField]private Text questionText;
    [SerializeField]private Image questionImage;

    void Start()
    {
        effectScript = GameObject.FindWithTag("QuestionImage").GetComponent<ImageEffects>();
        NextQuestion();
    }

	public void NextQuestion()
    {
        currentQuestion = GenerateQuestion();
        questionText.text = currentQuestion.questionString;
        questionImage.sprite = currentQuestion.questionImage;
        effectScript.ResetTimer();
        effectScript.ResetScale();
	}

    private Question GenerateQuestion()
    {
        int index = Random.Range(0,questions.Length);
        return questions[index];
    }

}
