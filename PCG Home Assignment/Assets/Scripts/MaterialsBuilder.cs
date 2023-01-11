using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsBuilder
{
    private List<Material> materialsListSkyscraper = new List<Material>();
    private List<Material> materialsListBase = new List<Material>();
    private List<Material> materialsListDoor = new List<Material>();
    private List<Material> materialsListWindow = new List<Material>();

    public MaterialsBuilder()
    {
        Material blueMaterial = new Material(Shader.Find("Specular"));
        blueMaterial.color = Color.blue;

        Material whiteMaterial = new Material(Shader.Find("Specular"));
        whiteMaterial.color = Color.white;

        Material greyMaterial = new Material(Shader.Find("Specular"));
        greyMaterial.color = Color.grey;

        Material blackMaterial = new Material(Shader.Find("Specular"));
        blackMaterial.color = Color.black;


        materialsListSkyscraper.Add(blackMaterial);
        materialsListSkyscraper.Add(blackMaterial);
        materialsListSkyscraper.Add(blackMaterial);
        materialsListSkyscraper.Add(blackMaterial);
        materialsListSkyscraper.Add(blackMaterial);
        materialsListSkyscraper.Add(blackMaterial);

        materialsListBase.Add(greyMaterial);

        materialsListDoor.Add(blueMaterial);
        materialsListDoor.Add(blueMaterial);
        materialsListDoor.Add(blueMaterial);
        materialsListDoor.Add(blueMaterial);
        materialsListDoor.Add(blueMaterial);
        materialsListDoor.Add(blueMaterial);

        materialsListWindow.Add(whiteMaterial);
        materialsListWindow.Add(whiteMaterial);
        materialsListWindow.Add(whiteMaterial);
        materialsListWindow.Add(whiteMaterial);
        materialsListWindow.Add(whiteMaterial);
        materialsListWindow.Add(whiteMaterial);
    }

    public List<Material> MaterialsListSkyscraper(){
        return materialsListSkyscraper;
    }

    public List<Material> MaterialsListBase(){
        return materialsListBase;
    }

    public List<Material> MaterialsListDoor(){
        return materialsListDoor;
    }

    public List<Material> MaterialsListWindow(){
        return materialsListWindow;
    }
}
