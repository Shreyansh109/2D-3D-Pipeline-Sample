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
        print("Dimension Change Pressed");
        if (!playerMovement.sceneData.GetSceneDimensions())
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    
}
