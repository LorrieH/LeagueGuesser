using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionChecker : MonoBehaviour 
{
    private QuestionGenerator questionGenerator;
    private ImageEffects victoryEffectScript;
    private ImageEffects defeatEffectScript;
    private AnimationHandler animations;
    [SerializeField]private InputField inputAnswer;
    [SerializeField]private GameObject victoryScreen;
    [SerializeField]private GameObject defeatScreen;

	void Start () 
    {
        animations = GetComponent<AnimationHandler>();
        questionGenerator = GetComponent<QuestionGenerator>();
        victoryEffectScript = victoryScreen.GetComponentInChildren<ImageEffects>();
        defeatEffectScript = defeatScreen.GetComponentInChildren<ImageEffects>();
    }

    public void CheckQuestion()
    {
        string tempAnswer = inputAnswer.text;
        string answer = tempAnswer.ToLower();
        int pos = System.Array.IndexOf(questionGenerator.currentQuestion.questionAnswers, answer);
        animations.PlayAnimation("TextAnimator", 2);
        animations.PlayAnimation("TextBackgroundAnimator", 2);
        animations.PlayAnimation("ImageAnimator", 2);
        animations.PlayAnimation("ImageBackgroundAnimator", 2);
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

    void PlayAnimations()
    {

    }

}
