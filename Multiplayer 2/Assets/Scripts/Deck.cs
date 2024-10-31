using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cards = new List<Card>();  // Lista que cont�m as cartas do baralho

    // M�todo que carrega cartas de um arquivo JSON
    public void LoadCards(TextAsset jsonFile)
    {

        if (jsonFile == null)
        {
            Debug.LogError("JSON file is null. Check if the file is assigned in the Inspector.");
            return;
        }

        Debug.Log($"JSON Content: {jsonFile.text}"); // Mostra o conte�do do JSON


        // Usa JsonUtility para converter o JSON em um objeto CartasData
        CardsData data = JsonUtility.FromJson<CardsData>(jsonFile.text);

        if (data.cards == null || data.cards.Count == 0)
        {
            Debug.LogError("No cards loaded from the JSON file. Please check the file format.");
            return;
        }

        cards.AddRange(data.cards);  // Adiciona as cartas carregadas � lista
        Shuffle();  // Embaralha as cartas ap�s carregar
        Debug.Log($"Loaded {data.cards.Count} cards.");

    }

    // M�todo que embaralha as cartas
    public void Shuffle()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Card temp = cards[i];  // Armazena a carta atual
            int randomIndex = Random.Range(i, cards.Count);  // Gera um �ndice aleat�rio
            cards[i] = cards[randomIndex];  // Troca a carta atual pela carta em randomIndex
            cards[randomIndex] = temp;  // Coloca a carta armazenada na posi��o aleat�ria
        }
    }

    // M�todo que distribui um n�mero espec�fico de cartas
    public List<Card> Distribute(int numCartas)
    {
        if (numCartas > cards.Count)
        {
            Debug.LogError("Not enough cards to distribute.");
            numCartas = cards.Count;  // Ajusta para o n�mero dispon�vel
        }

        List<Card> cartasDistribuidas = cards.GetRange(0, numCartas);  // Pega as cartas do in�cio da lista
        cards.RemoveRange(0, numCartas);  // Remove as cartas distribu�das do baralho
        return cartasDistribuidas;  // Retorna as cartas distribu�das
    }
}

// Classe auxiliar para representar a estrutura do JSON
[System.Serializable]
public class CardsData
{
    public List<Card> cards;  // Lista de cartas carregadas do JSON
}