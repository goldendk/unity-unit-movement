using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegimentFormation : MonoBehaviour
{


    public int rows = 4;
    public int cols = 6;
    public float colSpacing = 1f;
    public float rowSpacing = 1f;
    public float markerDiameter = 0.25f;

    // Start is called before the first frame update
    void Start()
    {



        GameObject leader = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leader.name = "Leader";
        leader.transform.parent = this.transform;
        leader.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        leader.transform.localPosition = new Vector3(0, 0, 0);
        
        Debug.Log(this.name);

        
        int sphereDiameter = 1;
        int rSpaces = rows - 1;
        int cSpaces = cols - 1;

        //add formation markers.
        for(int r = 0; r < rows; r++)
        {
            for(int c = 0; c < cols; c++)
            {
                // |0 <> 1 <> 2 <> 3 <> 4 <> 5|
                // |1 <> X <> X <> X <> X <> X|
                // |2 <> X <> X <> X <> X <> X|
                // |3 <> X <> X <> X <> X <> X|
                // |4 <> X <> X <> X <> X <> X|
             
                

                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.localScale = new Vector3(markerDiameter, markerDiameter, markerDiameter);
                sphere.name = "Formation_" + c + "_" + r;

                //calculate the left corner
                float sphereX =  (float) cols/2 -0.5f * sphereDiameter + ((float)cSpaces/2 * (float)colSpacing);
                sphereX *= -1;
                //add the current spheres location.
                sphereX += (c * (sphereDiameter + colSpacing));

                // y coordinate
                float sphereZ = r * sphereDiameter + r * rowSpacing;
                sphereZ *= -1;


                Vector3 position = new Vector3(sphereX, 0, sphereZ);
                Debug.Log(position);

                sphere.transform.parent = this.transform;
                sphere.transform.localPosition = position;
            
                
               




            }
        }

        

    }

    // Update is called once per frame
    void Update()
    {

    }
}
