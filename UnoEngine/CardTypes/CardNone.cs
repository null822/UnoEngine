using UnoEngine.CardValues;

namespace UnoEngine.CardTypes;

public class CardNone : Card
{
    public CardNone(CardProperties properties) : base(properties)
    {
        
    }
    
    public override string ToString()
    {
        return $"{Properties.Color} {Properties.Value}";
    }
}