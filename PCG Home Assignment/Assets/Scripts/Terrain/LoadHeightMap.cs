using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TerrainTextureData{
    public Texture2D terrainTexture;
    public Vector2 tileSize;
    public float minHeight;
    public float maxHeight;
}

[ExecuteInEditMode]
public class LoadHeightMap : MonoBehaviour
{
    private Terrain terrain;
    private TerrainData terrainData;

    [SerializeField]
    private Texture2D heightMapImage;

    [SerializeField]
    private Vector3 heightMapScale = new Vector3(1, 1, 1);

    [Header("On Play")]
    [SerializeField]
    private bool loadHeightMap = true;
    
    [SerializeField]
    private bool flattenTerrainOnExit = true;

    [Header("On Edit")]
    [SerializeField]
    private bool loadHeightMapInEditMode = false;

    [SerializeField]
    private bool flattenTerrainInEdit = false;


    [Header("Texture Data")]
    [SerializeField]
    private List<TerrainTextureData> terrainTextureData;

    [SerializeField]
    private bool addTerrainTexture = false;

    [SerializeField]
    private float terrainTextureBlendOffset = 0.01f;


    // Start is called before the first frame update
    void Start()
    {
        if(loadHeightMap){
            LoadHeightMapImage();
        } 

        AddTerrainTextures();
    }

    void LoadHeightMapImage(){
        terrain = this.GetComponent<Terrain>();
        terrainData = Terrain.activeTerrain.terrainData;

        float[,] heightMap = new float[terrainData.heightmapResolution, terrainData.heightmapResolution];

        for(int width = 0; width < terrainData.heightmapResolution; width++){
            for(int height = 0; height < terrainData.heightmapResolution; height++){
                heightMap[width, height] = heightMapImage.GetPixel((int)(width * heightMapScale.x), (int)(height * heightMapScale.z)).grayscale * heightMapScale.y;
            }
        }

        terrainData.SetHeights(0, 0, heightMap);
    }

    void FlattenTerrain(){
        float[,] heightMap = new float[terrainData.heightmapResolution, terrainData.heightmapResolution];

        for(int width = 0; width < terrainData.heightmapResolution; width++){
            for(int height = 0; height < terrainData.heightmapResolution; height++){
                heightMap[width, height] = 0;
            }
        }

        terrainData.SetHeights(0, 0, heightMap);
    }

    private void AddTerrainTextures(){
        TerrainLayer[] terrainLayers = new TerrainLayer[terrainTextureData.Count];

        for(int i = 0; i < terrainTextureData.Count; i++){
            if(addTerrainTexture){
                terrainLayers[i] = new TerrainLayer();
                terrainLayers[i].diffuseTexture = terrainTextureData[i].terrainTexture;
                terrainLayers[i].tileSize = terrainTextureData[i].tileSize;
            }
            else{
                terrainLayers[i] = new TerrainLayer();
                terrainLayers[i].diffuseTexture = null;
            }
        }
        terrainData.terrainLayers = terrainLayers;

        float[,] heightMap = terrainData.GetHeights(0, 0, terrainData.heightmapResolution, terrainData.heightmapResolution);
        float[, ,] alphamapList = new float[terrainData.alphamapWidth, terrainData.alphamapHeight, terrainData.alphamapLayers];

        for(int height = 0; height < terrainData.alphamapHeight; height++){
            for(int width = 0; width < terrainData.alphamapWidth; width++){
                float[] alphamap = new float[terrainData.alphamapLayers];

                for(int i = 0; i < terrainTextureData.Count; i++){
                    float heightBegin = terrainTextureData[i].minHeight - terrainTextureBlendOffset;
                    float heightEnd = terrainTextureData[i].maxHeight - terrainTextureBlendOffset;

                    if(heightMap[width, height] >= heightBegin && heightMap[width, height] <= heightEnd){
                        alphamap[i] = 1;
                    }
                }
                Blend(alphamap);

                for(int j = 0; j < terrainTextureData.Count; j++){
                    alphamapList[width, height, j] = alphamap[j];
                }
            }
        }
        terrainData.SetAlphamaps(0, 0, alphamapList);
    }

    private void Blend(float[] alphamap){
        float total = 0;

        for(int i = 0; i < alphamap.Length; i++){
            total += alphamap[i];
        }

        for(int i = 0; i < alphamap.Length; i++){
            alphamap[i] = alphamap[i] / total;
        }
    }

    void OnValidate(){
        if(flattenTerrainInEdit){
            FlattenTerrain();
        }
        else if(loadHeightMapInEditMode){
            LoadHeightMapImage();
        }
    }

    void OnDestroy(){
        if(flattenTerrainOnExit){
            FlattenTerrain();
        }
    }
}