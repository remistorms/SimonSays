using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{

    public static Boot instance = null;
    
    [SerializeField] Manager_Event manager_Event_ref;
    //[SerializeField] Manager_Sound manager_Sound_ref;
    [SerializeField] Manager_Game manager_Game_ref;

    private void Awake()
    {
        StartCoroutine(BootRoutine());
    }

    private IEnumerator BootRoutine()
    {
        //Initializes managers in order to avoid errors later
        Debug.Log("Initializing...");
        manager_Event_ref.Initialize();
        yield return null;
       // manager_Sound_ref.Initialize();
        yield return null;
        manager_Game_ref.Initialize();
        yield return null;

    }

}