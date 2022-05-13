using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHeatmap : MonoBehaviour {

    public int width = 256;
    public int height = 256;

    public float scale = 10f;

    public float offsetX = 1000f;
    public float offsetY = 1000f;

    public float[,] temps;

    // Start is called before the first frame update
    void Start() {
        offsetX = Random.Range(0, 9999f);
        offsetY = Random.Range(0, 9999f);

        temps = GenerateTemps();
    }

    float[,] GenerateTemps() {
        float[,] localtemps = new float[width,height];
        for(int x = 0; x < width; x++) {
            for(int y = 0; y < height; y++) {
                localtemps[x,y] = GenerateTemp(x,y);
            }
        }
        return localtemps;
    }

    float GenerateTemp(int x, int y) {
        float localX = (float)x / width * scale + offsetX;
        float localY = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(localX, localY);
    }

}
