using UnityEngine;

public class MainMenuTriggers : MonoBehaviour
{
    public enum TriggerType{NewGame,ContinueGame,Level}
    public TriggerType type;

    public int levelIndex;
    
    //Checks the type of trigger and calls the appropriate method
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            if(type == TriggerType.NewGame)
            {
                SceneLoader.Instance.NewGame();
            }
            else if(type == TriggerType.ContinueGame)
            {
                SceneLoader.Instance.ContinueGame();
            }
            else if(type == TriggerType.Level)
            {
                SceneLoader.Instance.LoadLevel(levelIndex);
            }
        }
    }   
}
