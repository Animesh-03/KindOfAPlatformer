using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlayer : MonoBehaviour
{
    public static GhostPlayer Instance;

    public SpriteRenderer ghostSprite;
    public SpriteRenderer ghostHammerHandleSprite;
    public SpriteRenderer ghostHammerHeadSprite;

    public GhostRepeater ghostPlayerRepeater;
    public GhostRepeater ghostHammerRepeater;
    
    void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
        ToggleVisibility(false);
    }

    //Makes the player ghost visible or invisible
    private void ToggleVisibility(bool visible)
    {
        ghostSprite.enabled = visible;
        ghostHammerHandleSprite.enabled = visible;
        ghostHammerHeadSprite.enabled = visible;
    }

    //Plays the ghost which follows the previous actions
    public void PlayGhost(bool loop)
    {
        //Enable movement of player and hammer
        ghostPlayerRepeater.repeat = true;
        ghostHammerRepeater.repeat = true;

        ghostPlayerRepeater.loop = loop;
        ghostHammerRepeater.loop = loop;

        //Restarts the ghost to play from the beginning
        ghostPlayerRepeater.RestartGhost();
        ghostHammerRepeater.RestartGhost();

        ToggleVisibility(true);
    }

    //Stops the ghost and sets it to invisbles
    public void StopGhost()
    {
        ghostPlayerRepeater.repeat = false;
        ghostHammerRepeater.repeat = false;

        ToggleVisibility(false);

    }
}
