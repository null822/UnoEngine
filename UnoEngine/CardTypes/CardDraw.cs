using UnoEngine.CardValues;

namespace UnoEngine.CardTypes;

public class CardDraw : Card
{
    public CardDraw(CardProperties properties) : base(properties)
    {
        
    }

    public override (int turn, sbyte direction, int[] pickupBuffer) ModifyGameState(int turn, sbyte direction, int[] pickupBuffer)
    {
        // add `Properties.Value` cards to the next player's pickup buffer entry
        pickupBuffer[turn + 1*direction] += Properties.Value;
        
        // get how many cards we need to draw
        var draw = pickupBuffer[turn];

        if (draw != 0)
        {
            
        }
        
        return base.ModifyGameState(turn, direction, pickupBuffer);
    }

    public override string ToString()
    {
        return $"{Properties.Color} {(Properties.Value > 0 ? $"+{Properties.Value}" : $"{Properties.Value}")}";
    }
}
