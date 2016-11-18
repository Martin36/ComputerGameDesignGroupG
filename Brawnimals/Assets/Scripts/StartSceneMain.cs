using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartSceneMain : MonoBehaviour {

    private Button game1;
    private Button game2;
    private Button exit;

	// Use this for initialization
	void Start () {
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach(Button button in buttons)
        {
            if (button.tag.Equals("game1"))
            {
                game1 = button;
                game1.gameObject.GetComponentInChildren<Text>().text = "Play Game 1";
                game1.onClick.AddListener(StartGame1);
            }
            if (button.tag.Equals("game2"))
            {
                game2 = button;
                game2.gameObject.GetComponentInChildren<Text>().text = "Play Game 2";
                game2.onClick.AddListener(StartGame2);
            }
            if (button.tag.Equals("exit"))
            {
                exit = button;
                exit.gameObject.GetComponentInChildren<Text>().text = "Exit";
                exit.onClick.AddListener(Exit);
            }
        }
    }
    
    void StartGame1()
    {
        //Code for starting game1

    }

    void StartGame2()
    {
        //Code for starting game2
    }

    void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
