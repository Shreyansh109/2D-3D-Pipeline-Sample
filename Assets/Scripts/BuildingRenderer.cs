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
        DimensionChanger();
    }

    public void DimensionChanger()
    {
        if (!playerMovement.sceneData.GetSceneDimensions() && 
            (player.gameObject.transform.position.x - gameObject.transform.position.x) < 0)
        {
            gameObject.SetActive(false);
            print("Dimension Change Pressed");
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
    
}
