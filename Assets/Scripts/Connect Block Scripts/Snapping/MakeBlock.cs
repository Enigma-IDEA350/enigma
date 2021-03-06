using UnityEngine;

/*
Author: Logan Brown
Description:
Creates a new instance of a passed in block object 
*/

public class MakeBlock : MonoBehaviour
{

    bool tooManyBlocks = false;

    bool onlyOne = false;

    [SerializeField] private GameObject block;
    ErrorHandler errorHandler;
    public void setOnlyOne(bool one)
    {
        onlyOne = one;
    }
    public void setTooManyBlocks(bool toMany) { tooManyBlocks = toMany; }

    void Start()
    {
        errorHandler = GameObject.Find("ERROR_MESSAGE").GetComponent<ErrorHandler>();
    }
    void OnMouseDown()
    {

        if (!tooManyBlocks && !onlyOne)
        {
            Layer layer = FindObjectOfType<Layer>();


            SoundManager.PlaySound(SoundManager.Sound.BlockSnap);
            Vector3 center = GameObject.Find("Bounds").transform.position;
            center.z = layer.GetCurrentZ();
            layer.SetCurrentZ();


            GameObject newBlock = Instantiate(block, center, transform.rotation);
            newBlock.transform.parent = GameObject.Find("Current Blocks in Scene").transform;

            int layerInt = layer.GetCurrentLayer();
            SpriteRenderer blockRend = newBlock.GetComponent<SpriteRenderer>();

            blockRend.sortingOrder = layerInt == 0 ? 0 : layerInt + 1;

            if (newBlock.GetComponentsInChildren<Canvas>() != null || newBlock.GetComponentsInChildren<Canvas>().Length != 0)
            {
                foreach (Canvas text in newBlock.GetComponentsInChildren<Canvas>())
                {
                    text.sortingOrder = layerInt + 2;
                }
                newBlock.GetComponentInParent<Layer>().SetCurrentLayer(layerInt + 2);
            }
            else
            {
                newBlock.GetComponentInParent<Layer>().SetCurrentLayer(layerInt + 1);
            }
        }
        else if (onlyOne)
        {
            errorHandler.RaiseError("There can only be one of this block!");
        }
        else
        {
            errorHandler.RaiseError("Too many Blocks!");
        }


    }
}
