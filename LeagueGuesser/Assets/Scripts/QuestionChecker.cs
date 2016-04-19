using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionChecker : MonoBehaviour 
{
    private QuestionGenerator questionGenerator;
    [SerializeField]private InputField inputAnswer;

	void Start () 
    {
        questionGenerator = GetComponent<QuestionGenerator>();
	}
	
    public void CheckQuestion()
    {
        if(inputAnswer.text == questionGenerator.currentQuestion.questionAnswers[0])
        {
            Debug.Log("AYY je hebt het goed man");
            questionGenerator.NextQuestion();
            inputAnswer.text = "";
        }
        else
        {
            Debug.Log("Never lucky man");
        }
    }

}
