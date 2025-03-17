using UnoEngine.CardTypes;

namespace UnoEngine.CardValues;

public readonly struct CardProperties(CardType type, int value, CardColor color)
{
    public readonly CardType Type = type;
    public readonly int Value = value;
    public readonly CardColor Color = color;
    
    public static implicit operator CardProperties((CardType type, int value, CardColor color) tuple)
    {
        return new CardProperties(tuple.type, tuple.value, tuple.color);
    }
    
    public static implicit operator CardProperties((CardType type, CardColor color) tuple)
    {
        return new CardProperties(tuple.type, 0, tuple.color);
    }
}