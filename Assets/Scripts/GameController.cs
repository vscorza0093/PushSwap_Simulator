using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static int total_blocks = 8;
    private int stackAX = -1;
    private int stackBX = 9;
    private int contador;

    [SerializeField]
    GameObject[] gameObjects;

    [SerializeField]
    Text contadorTxt;

    private GameObject[] stackA = new GameObject[total_blocks];
    private GameObject[] stackB = new GameObject[total_blocks];

    public int[] positions;
    public void RestartGame()
    {
        int[] index = new int[total_blocks];
        int i = 0;
        contador = 0;
        contadorTxt.text = contador.ToString();
        while (i < total_blocks)
        {
            if (stackA != null)
            {
                Destroy(stackA[i]);
            }
            if (stackB != null)
            {
                Destroy(stackB[i]);
            }
            stackA[i] = null;
            stackB[i] = null;
            i++;
        }
        Randomizador(index);
        i = 0;
        while (i < total_blocks)
        {
            stackA[i] = gameObjects[index[i] - 1];
            stackA[i] = Instantiate(stackA[i]);
            i++;
        }
        UpdatePositions();
    }
    void Randomizador(int[] index)
    {
        for (int i = 0; i < index.Length; i++)
        {
            while(index[i] == 0)
            {
                int numeroAleatorio = Random.Range(1, 9);
                bool repetido = false;
                for(int j = 0; j < total_blocks; j++)
                {
                    if (index[j] == numeroAleatorio)
                    {
                        repetido = true;
                    }
                }
                if (!repetido) index[i] = numeroAleatorio;
            }
        }
    }
    void UpdatePositions()
    {
        int i = 0;
        while (i < total_blocks)
        {
            if (stackA[i] != null)
            {
                stackA[i].transform.position = new Vector3(stackAX, positions[i], 0f);
            }
            if (stackB[i] != null)
            {
                stackB[i].transform.position = new Vector3(stackBX, positions[i], 0f);
            }
            i++;
        }
    }
    public void SwapA()
    {
        GameObject temp;
        int i = 0;
        while (i < total_blocks && stackA[i] != null) i++;
        if (i >= 2)
        {
            temp = stackA[i - 1];
            stackA[i - 1] = stackA[i - 2];
            stackA[i - 2] = temp;
            UpdatePositions();
        }
        
    }
    public void SwapB()
    {
        GameObject temp;
        int i = 0;
        while (i < total_blocks && stackB[i] != null) i++;
        if (i >= 2)
        {
            temp = stackB[i - 1];
            stackB[i - 1] = stackB[i - 2];
            stackB[i - 2] = temp;
            UpdatePositions();
        }
    }
    public void PushB()
    {
        int iA = 0;
        int iB = 0;
        while (iA < total_blocks && stackA[iA] != null) iA++;
        while (iB < total_blocks && stackB[iB] != null) iB++;
        if (iA >= 1)
        {
            stackB[iB] = stackA[iA - 1];
            stackA[iA - 1] = null;
            UpdatePositions();
        }
    }
    public void PushA()
    {
        int iA = 0;
        int iB = 0;
        while (iA < total_blocks && stackA[iA] != null) iA++;
        while (iB < total_blocks && stackB[iB] != null) iB++;
        if (iB >= 1)
        {
            stackA[iA] = stackB[iB - 1];
            stackB[iB - 1] = null;
            UpdatePositions();
        }
    }
    public void ShifthA()
    {
        GameObject temp;
        int i = 0;
        while (i < total_blocks && stackA[i] != null) i++;
        if (i >= 2)
        {
            temp = stackA[i - 1];
            int j = i - 1;
            while (j > 0)
            {
                stackA[j] = stackA[j - 1];
                j--;
            }
            stackA[0] = temp;
            UpdatePositions();
        }
    }
    public void ShifthB()
    {
        GameObject temp;
        int i = 0;
        while (i < total_blocks && stackB[i] != null) i++;
        if (i >= 2)
        {
            temp = stackB[i - 1];
            int j = i - 1;
            while (j > 0)
            {
                stackB[j] = stackB[j - 1];
                j--;
            }
            stackB[0] = temp;
            UpdatePositions();
        }
    }
    public void ReverseShifthA()
    {
        GameObject temp;
        int i = 0;
        while (i < total_blocks && stackA[i] != null) i++;
        if (i >= 2)
        {
            temp = stackA[0];
            int j = 0;
            while (j < i - 1)
            {
                stackA[j] = stackA[j + 1];
                j++;
            }
            stackA[i - 1] = temp;
            UpdatePositions();
        }
    }
    public void ReverseShifthB()
    {
        GameObject temp;
        int i = 0;
        while (i < total_blocks && stackB[i] != null) i++;
        if (i >= 2)
        {
            temp = stackB[0];
            int j = 0;
            while (j < i - 1)
            {
                stackB[j] = stackB[j + 1];
                j++;
            }
            stackB[i - 1] = temp;
            UpdatePositions();
        }
    }
    public void Contador()
    {
        contador++;
        contadorTxt.text = contador.ToString();
    }
    void Start()
    {
        contador = 0;
        contadorTxt.text = contador.ToString();
        int i = 0;
        while (i < total_blocks)
        {
            stackA[i] = Instantiate(gameObjects[i]);
            i++;
        }
        UpdatePositions();
    }  
}
