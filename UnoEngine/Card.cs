using UnoEngine.CardTypes;

namespace UnoEngine;

public class Card
{
    public readonly CardType Type;
    public readonly CardColor Color;
    
    
    public readonly string Name => 
    
    
    public Card(CardProperties properties)
    {
        Type = properties.Type;
        Color = properties.Color;
    }
    
    
    public void CanStack(Card other)
    {
        
    }
}
