using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HelixController : MonoBehaviour
{

    private Vector2 lastTapPosition;
    private Vector3 startPosition;

    public Transform topTransform;
    public Transform goalTramsform;

    public GameObject helixLevelPrefab;

    public List<Stage> allStages=new List<Stage>();

    public float helixDistance;

    private List<GameObject> spawnedLevels=new List<GameObject>();

    private void Awake()
    {
        startPosition = transform.localEulerAngles;
        helixDistance = topTransform.localPosition.y -(goalTramsform.localPosition.y +0.1f);
        //LoadStage(0);

    }



    void Update()
    {

        if (Mouse.current.leftButton.isPressed)
        {
            Vector2 currentTapPosition = Mouse.current.position.ReadValue();

            if (lastTapPosition==Vector2.zero)
            {
                lastTapPosition = currentTapPosition;
            }

            float distance = lastTapPosition.x - currentTapPosition.x;
            lastTapPosition= currentTapPosition;

            transform.Rotate(Vector3.up * distance);


        }

        if (Mouse.current != null && Mouse.current.leftButton.wasReleasedThisFrame) {
            lastTapPosition = Vector2.zero;
        }
    }


    public void LoadStage(int stageNumber)
    {

    }


}
