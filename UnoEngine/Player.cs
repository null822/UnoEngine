namespace UnoEngine;

public class Player
{
    /// <summary>
    /// The cards that the player currently has
    /// </summary>
    private readonly Deck _hand = new ();

    public int CardCount => _hand.Size;
    
    
    public Deck Turn(Card activeCard)
    {
        var stackables = _hand.GetStackable(activeCard);
        
        // if we can't play a card, return an empty deck
        if (stackables.Size == 0)
            return new Deck();
        

        var card = stackables.Take();
        _hand.Take(card);
        
        return new Deck([card]);
    }
    
    public void Pickup(Deck cards)
    {
        _hand.Add(cards);
    }
    
    public void Pickup(Card cards)
    {
        _hand.Add(cards);
    }
}