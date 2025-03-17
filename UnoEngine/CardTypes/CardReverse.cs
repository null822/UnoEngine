using UnoEngine.CardValues;

namespace UnoEngine.CardTypes;

public class CardReverse : Card
{
    public CardReverse(CardProperties properties) : base(properties)
    {
        
    }

    public override (int turn, sbyte direction, int[] pickupBuffer) ModifyGameState(int turn, sbyte direction, int[] pickupBuffer)
    {
        // if there are 2 players,
        if (Program.PlayerCount == 2)
            // act as a block card.
            turn += 1*direction;
        else
            // otherwise flip the game direction.
            direction = (sbyte)-direction;
        
        return base.ModifyGameState(turn, direction, pickupBuffer);
    }

    public override string ToString()
    {
        return $"{Properties.Color} {Properties.Type}";
    }
}