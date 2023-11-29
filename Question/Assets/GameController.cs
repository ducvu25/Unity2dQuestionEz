using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Sprite[] sprites;
    [SerializeField] Button[] btn;
    [SerializeField] GameObject endGame;

    [SerializeField] TextMeshProUGUI[] txtAnswers;
    [SerializeField] TextMeshProUGUI txtQuestion;

    [SerializeField] Question[] questions;
    AudioController audioController;
    int n = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioController = GetComponent<AudioController>();
        NewQuestion();
        endGame.SetActive(false);
    }

    void NewQuestion()
    {
        panel.GetComponent<Image>().sprite = sprites[n];
        for(int i = 0; i<txtAnswers.Length; i++)
        {
            txtAnswers[i].text = questions[n].answers[i];
        }
        txtQuestion.text = questions[n].question;
        if (n == 2)
        {
            btn[0].GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        }
        else
        {
            btn[0].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
    public void Choose(int value)
    {
        //Debug.Log(value);
        if(value == questions[n].key)
        {
            n++;
            if(n == questions.Length)
            {
                audioController.PlaySound(3);
                btn[0].transform.GetChild(0).gameObject.SetActive(false);
                btn[0].transform.GetChild(1).gameObject.SetActive(false);
                btn[1].gameObject.SetActive(false);
                btn[2].gameObject.SetActive(false);
                panel.GetComponent<Image>().sprite = sprites[n];
                endGame.SetActive(true);
            }
            else
            {
                audioController.PlaySound(1);
                Invoke("NewQuestion", 2);
            }
        }
        else
        {
            audioController.PlaySound(0);
            n = 0;
            Invoke("NewQuestion", 2);
        }
        //Debug.Log(n);
    }
    public void Click()
    {
        audioController.PlaySound(2);
    }
}

[System.Serializable]
public class Question
{
    public string question;
    public string[] answers;
    public int key;
}
