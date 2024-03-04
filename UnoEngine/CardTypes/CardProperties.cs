namespace UnoEngine.CardTypes;

public struct CardProperties
{
    public readonly CardType Type;
    public readonly CardColor Color;

    public CardProperties(CardType type, CardColor color)
    {
        Type = type;
        Color = color;
    }
    
    public static implicit operator CardProperties((CardType type, CardColor color) tuple)
    {
        return new CardProperties(tuple.type, tuple.color);
    }
}