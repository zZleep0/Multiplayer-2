using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string name;  // Nome do jogador
    public List<Card> playersHand = new List<Card>();  // M�o do jogador, que cont�m suas cartas

    // Construtor que inicializa o jogador com um nome
    public Player(string nome)
    {
        this.name = nome;
    }

    // M�todo que adiciona cartas � m�o do jogador
    public void GetCards(List<Card> cards)
    {
        playersHand = cards;
       // playersHand.AddRange(cards);  // Adiciona as cartas recebidas � m�o
    }
}
