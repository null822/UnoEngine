using UnoEngine.CardValues;

namespace UnoEngine.CardTypes;

public class CardBlock : Card
{
    public CardBlock(CardProperties properties) : base(properties)
    {
        
    }

    public override (int turn, sbyte direction, int[] pickupBuffer) ModifyGameState(int turn, sbyte direction, int[] pickupBuffer)
    {
        // increment turn by 1, skipping the next player
        turn += 1*direction;
        
        return base.ModifyGameState(turn, direction, pickupBuffer);
    }

    public override string ToString()
    {
        return $"{Properties.Color} {Properties.Type}";
    }
}