using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.

public class Deboug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var componentTypes = System.AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()).Where(type => type.IsClass && type.IsSubclassOf(typeof(Component))); foreach (var type in componentTypes)
        {
            Debug.Log(type.FullName);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
