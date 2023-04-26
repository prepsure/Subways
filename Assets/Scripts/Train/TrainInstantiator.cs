using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Scripts.UI;

public class TrainInstantiator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectsOfType<TrainController>()
            .ToList()
            .ForEach(t => {
                GameObject train = t.MakeTrain();

                train.GetComponent<TrainColor>().ColorRender.materials[1].color = t.GetComponent<PlayerController>().PlayerColor;

                train.GetComponent<DisplayTrainPassengerCount>().PlayerNum = t.GetComponent<PlayerController>().PlayerNumber;

                train.GetComponent<TrainMovement>().StartCurve = ListUtils.PickRandom(FindObjectsOfType<BezierSpline>().ToList()).gameObject;
                train.GetComponent<TrainMovement>().StartChuggin();

                t.GetComponent<PlayerController>().enabled = false;
            });
    }
}
