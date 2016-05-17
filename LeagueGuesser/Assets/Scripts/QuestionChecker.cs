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
    private Profile profile;

	void Start () 
    {
        animations = GetComponent<AnimationHandler>();
        questionGenerator = GetComponent<QuestionGenerator>();
        victoryEffectScript = victoryScreen.GetComponentInChildren<ImageEffects>();
        defeatEffectScript = defeatScreen.GetComponentInChildren<ImageEffects>();
        profile = GameObject.Find("Profile").GetComponent<Profile>();
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
        yield return new WaitForSeconds(.5f);
        //victoryEffectScript.ResetTimer();
        inputAnswer.text = "";
        victoryScreen.SetActive(true);
        animations.PlayAnimation("VictoryAnimator", 1);
        yield return new WaitForSeconds(1.5f);
        animations.PlayAnimation("VictoryAnimator", 2);
        yield return new WaitForSeconds(.3f);
        victoryScreen.SetActive(false);
        //profile.SetElo(Random.Range(16,24));
        questionGenerator.NextQuestion();
    }

    IEnumerator Defeat()
    {
        yield return new WaitForSeconds(.5f);
        defeatEffectScript.ResetTimer();
        inputAnswer.text = "";
        defeatScreen.SetActive(true);
        animations.PlayAnimation("DefeatAnimator", 1);
        yield return new WaitForSeconds(1.5f);
        animations.PlayAnimation("DefeatAnimator", 2);
        yield return new WaitForSeconds(.3f);
        defeatScreen.SetActive(false);
        //profile.SetElo(Random.Range(-16, -24));
        questionGenerator.NextQuestion();
    }
}
