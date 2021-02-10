using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurveScript : MonoBehaviour
{

    public int CurrentAge = 18;
    public int AddedAge = 1;
    // Start is called before the first frame update
    void Start()
    {
        ComputeAge();
    }

   /// <summary>
   /// Computes a modified age integer
   /// </summary>
    void ComputeAge()
    {
        Debug.Log(CurrentAge + AddedAge);
    }
}
