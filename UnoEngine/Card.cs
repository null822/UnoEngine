using UnoEngine.CardTypes;

namespace UnoEngine;

public class Card
{
    private readonly CardProperties _properties;
    
    
    public Card(CardProperties properties)
    {
        _properties = properties;
    }
    
    
    public bool CanStack(Card other)
    {
        if (_properties.Type == other._properties.Type)
            return true;
        
        if (_properties.Color == other._properties.Color)
            return true;
        
        
        return false;
    }

    public override string ToString()
    {
        return $"{_properties.Color} {_properties.Type}";
    }
    
}
