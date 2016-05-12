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
    private Profile profile;

	void Start () 
    {
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
        yield return new WaitForSeconds(.3f);
        victoryEffectScript.ResetTimer();
        inputAnswer.text = "";
        victoryScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        victoryScreen.SetActive(false);
        profile.SetElo(Random.Range(16,24));
        questionGenerator.NextQuestion();
    }

    IEnumerator Defeat()
    {
        yield return new WaitForSeconds(.5f);
        defeatEffectScript.ResetTimer();
        inputAnswer.text = "";
        defeatScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        defeatScreen.SetActive(false);
        profile.SetElo(Random.Range(-16, -24));
        questionGenerator.NextQuestion();
    }
}
