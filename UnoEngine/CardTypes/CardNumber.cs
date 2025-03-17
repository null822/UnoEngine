using UnoEngine.CardValues;

namespace UnoEngine.CardTypes;

public class CardNumber : Card
{
    public CardNumber(CardProperties properties) : base(properties)
    {
        
    }
    
    public override string ToString()
    {
        return $"{Properties.Color} {Properties.Value}";
    }
}