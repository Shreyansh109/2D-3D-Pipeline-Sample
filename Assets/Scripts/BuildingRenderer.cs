using UnityEngine;
using UnityEngine.InputSystem;

public class BuildingRenderer : MonoBehaviour
{
    GameObject player;
    PlayerMovement playerMovement;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    public void DimensionChanger()
    {
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
