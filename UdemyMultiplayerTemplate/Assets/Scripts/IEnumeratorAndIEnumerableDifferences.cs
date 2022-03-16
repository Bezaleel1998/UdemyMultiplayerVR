using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnumeratorAndIEnumerableDifferences : MonoBehaviour
{

    List<string> kindOfFruit;
    IEnumerable<string> ienumerable;
    IEnumerator<string> ienumerator;

    void Awake()
    {

        kindOfFruit = new List<string>();
        kindOfFruit.Add("Apple");
        kindOfFruit.Add("Banana");
        kindOfFruit.Add("Cherry");//etc

        IEnumerableObject();

        IEnumeratorObject();


    }

    void IEnumerableObject()
    {

        ienumerable = (IEnumerable<string>)kindOfFruit;
        foreach (string item in kindOfFruit)
        {

            Debug.Log(item);

        }

    }

    void IEnumeratorObject()
    {

        ienumerator = kindOfFruit.GetEnumerator();
        while (ienumerator.MoveNext())
        {


            Debug.Log((string)ienumerator.Current);

        }


    }



}
