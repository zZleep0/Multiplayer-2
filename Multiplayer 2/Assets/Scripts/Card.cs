[System.Serializable]
public class Card  // Remover MonoBehaviour
{
    public string suit;  // Naipe da carta (ex: Copas, Ouros)
    public string value;  // Valor da carta (ex: �s, 2, 3)

    // M�todo que retorna uma representa��o em string da carta
    public string DisplayCardInfo()
    {
        return $"{suit} de {value}";
    }
}
