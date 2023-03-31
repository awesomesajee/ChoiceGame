
using System.Collections;
using UnityEngine;
using TMPro;

public class DialogController : MonoBehaviour
{
    public TextMeshProUGUI barText;

    public TextMeshProUGUI speakerName;
    public SwitchCharacter switchCharacter;

    private int sentenceIndex = -1;

    private StoryScene currentScene;
    private State state = State.COMPLETED;
    
    private enum State
    {
        PLAYING,
        COMPLETED
    }

    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }

    public void PlayNextSentence()
    {
        if (!IsLastSentence())
        {
            StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
            speakerName.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
            speakerName.color = currentScene.sentences[sentenceIndex].speaker.textColor;
            switchCharacter.DisplayCharacter(currentScene.sentences[sentenceIndex].speaker.avatar);
        }
    }
    

    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED)
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if (++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }
}
