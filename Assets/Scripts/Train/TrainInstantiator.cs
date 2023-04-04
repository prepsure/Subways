using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TrainInstantiator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectsOfType<TrainController>()
            .ToList()
            .ForEach(t => {
                GameObject train = t.MakeTrain();
                train.GetComponent<TrainMovement>().StartCurve = ListUtils.PickRandom(FindObjectsOfType<BezierSpline>().ToList()).gameObject;
                train.GetComponent<TrainMovement>().StartChuggin();
            });
    }
}
