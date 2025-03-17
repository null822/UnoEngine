using UnoEngine.CardTypes;
using UnoEngine.CardValues;

namespace UnoEngine;

public abstract class Card
{
    public readonly CardProperties Properties;
    
    
    public Card(CardProperties properties)
    {
        Properties = properties;
    }
    
    /// <summary>
    /// Returns a boolean describing if the supplied card (<paramref name="other"/>) can stack on this card.
    /// </summary>
    public bool CanStack(Card other)
    {
        // if type and values are equal, return true
        if (Properties.Type == other.Properties.Type && Properties.Value == other.Properties.Value)
            return true;
        
        // if color is equal, return true
        if (Properties.Color == other.Properties.Color)
            return true;
        
        // if color is wild, return true
        if (Properties.Color == CardColor.Wild || other.Properties.Color == CardColor.Wild)
            return true;
        
        // otherwise, return false
        return false;
    }
    
    public override string ToString()
    {
        return $"{Properties.Color} {Properties.Type} {Properties.Value}";
    }
    
    /// <summary>
    /// Modified the game state, updating turn, direction, and pickups.
    /// </summary>
    /// <param name="turn">the index of the player who is playing next turn</param>
    /// <param name="direction">the current play direction</param>
    /// <param name="pickupBuffer">a buffer containing the amount of cards each player must pick up / put down.
    /// The index within this array is the index of the player referred to</param>
    /// <returns>The new turn, direction, and pickup buffer</returns>
    /// <remarks>By default, only increments the <paramref name="turn"/> (and clamps it to be less than <see cref="Program.PlayerCount"/>)</remarks>
    public virtual (int turn, sbyte direction, int[] pickupBuffer) ModifyGameState(int turn, sbyte direction, int[] pickupBuffer)
    {
        // increment turn
        turn += 1*direction;
        
        // keep turn within bounds
        turn %= Program.PlayerCount;
        
        return (turn, direction, pickupBuffer);
    }

    
    public static Card New(CardProperties properties)
    {
        var type = properties.Type;

        return type switch
        {
            CardType.None => new CardNone(properties),
            CardType.Number => new CardNumber(properties),
            CardType.Pickup => new CardDraw(properties),
            CardType.Block => new CardBlock(properties),
            CardType.Reverse => new CardReverse(properties),
            
            
            
            _ => throw new Exception($"Invalid CardType \"{type}\"")
        };
    }
    
}
