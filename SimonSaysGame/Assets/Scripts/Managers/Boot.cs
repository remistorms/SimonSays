using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{

    public static Boot instance = null;
    
    [SerializeField] Manager_Event manager_Event_ref;
    [SerializeField] Manager_Sound manager_Sound_ref;
   // [SerializeField] Manager_UI manager_UI_ref;
    [SerializeField] Manager_Game manager_Game_ref;

    private void Awake()
    {
        /*
        //Prevents this from being destroyed at load
        DontDestroyOnLoad(this.gameObject);
        //Check if there are no other instances of this BootScript, if there are... destroy this one

        //Check if instance already exists, if not, assign it, if it does, destroy this GO
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        } */
    }

    void Start()
    {
        StartCoroutine(_Boot());
    }


    private IEnumerator _Boot()
    {
        //Initializes managers in order to avoid errors later
        manager_Event_ref.Initialize();
        manager_Sound_ref.Initialize();
        manager_UI_ref.Initialize();
        manager_Game_ref.Initialize();
<<<<<<< HEAD
        //yield return null;
        //SceneManager.LoadScene (1, LoadSceneMode.Additive);
       // SceneManager.LoadScene(1, LoadSceneMode.Additive);
=======
        yield return null;
        SceneManager.LoadScene (1, LoadSceneMode.Additive);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
>>>>>>> parent of ad25d2e... WORKS after some tweaks
        yield return null;
        //SceneManager.LoadScene(3, LoadSceneMode.Additive);
        //Manager_Game_ref.initialize();
        GLOBAL.instance.M_ui.ShowScreen(UI_Screen.Enum_Screen.MainMenu);

    }

}