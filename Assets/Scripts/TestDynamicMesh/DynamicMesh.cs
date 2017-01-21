using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DynamicMesh : MonoBehaviour
{
    [SerializeField] private MeshFilter Renderer;
    [SerializeField] private Transform Eye;
    [SerializeField] private Vector3 Target;
    [SerializeField] private Vector3 RightTarget;
    [SerializeField] private Vector3 UpTarget;
    [SerializeField] private float nbVertexConeBase;
    public float _sphereRadius;

    private List<Vector3> _vertices { get; set; }

    void Start()
    {
        _vertices = new List<Vector3>();
    }

    void Update()
    {
        Renderer.mesh = CalculateMesh();
    }

    internal void UpdateScaleSphere(float radius)
    {
        _sphereRadius = radius;
    }

    private Mesh CalculateMesh()
    {
        float dist = (Target - Eye.position).magnitude;
        Vector3 firstVertice = new Vector3(Eye.position.x, Eye.position.y, Eye.position.z);
        Mesh rendering = new Mesh();
        _vertices.Add(firstVertice);

        float angle = 0;
        
        /**
         * Calcul des vertex de la base du cone.
         */
        for(int i = 0; i < nbVertexConeBase; i++)
        {
            float x = (RightTarget * _sphereRadius * Mathf.Cos(angle)).x;
            float y = (UpTarget * _sphereRadius * Mathf.Sin(angle)).y;
            float z = 0;

            _vertices.Add(new Vector3(x, y, z));

            angle += 2 * Mathf.PI / nbVertexConeBase;
        }

        Vector3[] toMesh = new Vector3[_vertices.Count];
        List<int> triangles = new List<int>();
        for (int i = 0; i < _vertices.Count; i++)
        {
            toMesh[i] = _vertices[i];
        }
        rendering.vertices = toMesh;
        for (int i = 1; i < _vertices.Count - 1; i++)
        {
            triangles.Add(0);
            triangles.Add(i);
            triangles.Add(i+1);
        }
        triangles.Add(0);
        triangles.Add(1);
        triangles.Add(_vertices.Count - 1);
        int[] trianglesToMesh = new int[triangles.Count];
        for (int i = 0; i < triangles.Count; i++)
        {
            triangles[i] = trianglesToMesh[i];
        }
        rendering.triangles = trianglesToMesh;

        rendering.RecalculateNormals();

        return rendering;

        /**
         * Calcul des vertex de la sphere collée à la base du cone.
         *//*
        float teta = 0;
        float phy = 0;
        for (int i = 0; i < 11; i++)
        {
            teta = 0;
            for(int j = 0; j < nbVertexConeBase; j++0)
            {

                teta += 2 * Mathf.PI / nbVertexConeBase;
            }

            phy += Mathf.PI / 22;
        }*/
    }
}
