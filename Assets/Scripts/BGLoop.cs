using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLoop : MonoBehaviour
{
    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 screenBounds;
    public float choke;

    void Start()
    {
        // Define a váriavel mainCamera com a componente Camera
        mainCamera = gameObject.GetComponent<Camera>();
        // pega os eixos x,y,z da posição da camera
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        foreach(GameObject obj in levels)
        {
            loadChildObjects(obj);
        }
    }

    // Faz o trabalho de carregar os clones
    void loadChildObjects(GameObject obj)
    {
        // Tamanho horizontal da sprite
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - choke;
        // Quantos clones eu preciso
        int childsNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth);
        // Crio um clone como molde do meu objeto (para clonar esse clone, não puxando os filhos criados de obj)
        GameObject clone = Instantiate(obj) as GameObject;
        // Loop que cria todos os meus objetos Filhos
        for (int i = 0; i <= childsNeeded; i++)
        {
            // Clone 
            GameObject c = Instantiate(clone) as GameObject;
            // Tranformo o clone em Filho do obj
            c.transform.SetParent(obj.transform);
            // Posiciono um após o outro
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        //Destroy(obj.GetComponent<SpriteRenderer>());
    }

    // Reposiciona o Filho para que ele sempre preecha a tela
    void repositionChildObjects(GameObject obj)
    {
        // Faz uma lista com todos os Filhos de obj
        Transform[] children = obj.GetComponentsInChildren<Transform>();

        if(children.Length > 1)
        {
            // [0] is the parent object
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;

            // Pegamos metade do comprimento do objeto
            // Fazemos isso pois o transform.postion está no centro do objeto, então se somarmos com metade de seu comprimento, encontramos o x da sua borda
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - choke;

            // Vê se a Camera está detectando o canto direito do elemento de fundo
            if(transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth)
            {
                // Se isso for verdadeiro, tranforma e move o primeiro Filho para o último Filho
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            
            }
            // Vê se a Camera está detectando o canto esquerdo do elemento de fundo
            else if (transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth)
            {
                // Se isso for verdadeiro, tranforma e move o último Filho para o primeiro Filho
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }

    void LateUpdate()
    {
        foreach(GameObject obj in levels)
        {
            repositionChildObjects(obj);
        }
    }
}
