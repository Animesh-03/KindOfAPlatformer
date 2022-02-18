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

    private void ToggleVisibility(bool visible)
    {
        ghostSprite.enabled = visible;
        ghostHammerHandleSprite.enabled = visible;
        ghostHammerHeadSprite.enabled = visible;
    }

    public void PlayGhost(bool loop)
    {
        ghostPlayerRepeater.repeat = true;
        ghostHammerRepeater.repeat = true;

        ghostPlayerRepeater.loop = loop;
        ghostHammerRepeater.loop = loop;

        ghostPlayerRepeater.RestartGhost();
        ghostHammerRepeater.RestartGhost();

        ToggleVisibility(true);
    }

    public void StopGhost()
    {
        ghostPlayerRepeater.repeat = false;
        ghostHammerRepeater.repeat = false;

        ToggleVisibility(false);

    }
}
