using UnityEngine;
using UnityEngine.InputSystem;

public class BuildingRenderer : MonoBehaviour
{
    GameObject player;
    PlayerMovement playerMovement;
    void Start()
    {
        // The player provides the current scene dimension used by the visibility check.
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    public void DimensionChanger()
    {
        // Hide buildings behind the player when the scene is in its 2D dimension.
        if (!playerMovement.sceneData.GetSceneDimensions() && 
            (player.gameObject.transform.position.x - gameObject.transform.position.x) < 0)
        {
            gameObject.SetActive(false);
            print(gameObject.name + " is inactive");
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
    
}
