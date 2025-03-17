using UnoEngine.CardTypes;
using UnoEngine.CardValues;

namespace UnoEngine;

public static class DeckPresets
{
    /// <summary>
    /// The standard UNO deck of 112 cards
    /// </summary>
    public static readonly (CardProperties type, int qty)[] Standard =
    [
        // Wildcards
        ((CardType.None, CardColor.Wild), 4),
        ((CardType.Pickup, 4, CardColor.Wild), 4),
        
        // Pickup, Reverse, Block
        ((CardType.Pickup, 2, CardColor.Red), 2),
        ((CardType.Pickup, 2, CardColor.Yellow), 2),
        ((CardType.Pickup, 2, CardColor.Green), 2),
        ((CardType.Pickup, 2, CardColor.Blue), 2),
        
        ((CardType.Reverse, CardColor.Red), 2),
        ((CardType.Reverse, CardColor.Yellow), 2),
        ((CardType.Reverse, CardColor.Green), 2),
        ((CardType.Reverse, CardColor.Blue), 2),
        
        ((CardType.Block, CardColor.Red), 2),
        ((CardType.Block, CardColor.Yellow), 2),
        ((CardType.Block, CardColor.Green), 2),
        ((CardType.Block, CardColor.Blue), 2),
        
        // Numbers
        ((CardType.Number, 0, CardColor.Red), 2),
        ((CardType.Number, 0, CardColor.Yellow), 2),
        ((CardType.Number, 0, CardColor.Green), 2),
        ((CardType.Number, 0, CardColor.Blue), 2),
        
        ((CardType.Number, 1, CardColor.Red), 2),
        ((CardType.Number, 1, CardColor.Yellow), 2),
        ((CardType.Number, 1, CardColor.Green), 2),
        ((CardType.Number, 1, CardColor.Blue), 2),
        
        ((CardType.Number, 2, CardColor.Red), 2),
        ((CardType.Number, 2, CardColor.Yellow), 2),
        ((CardType.Number, 2, CardColor.Green), 2),
        ((CardType.Number, 2, CardColor.Blue), 2),
        
        ((CardType.Number, 3, CardColor.Red), 2),
        ((CardType.Number, 3, CardColor.Yellow), 2),
        ((CardType.Number, 3, CardColor.Green), 2),
        ((CardType.Number, 3, CardColor.Blue), 2),
        
        ((CardType.Number, 4, CardColor.Red), 2),
        ((CardType.Number, 4, CardColor.Yellow), 2),
        ((CardType.Number, 4, CardColor.Green), 2),
        ((CardType.Number, 4, CardColor.Blue), 2),
        
        ((CardType.Number, 5, CardColor.Red), 2),
        ((CardType.Number, 5, CardColor.Yellow), 2),
        ((CardType.Number, 5, CardColor.Green), 2),
        ((CardType.Number, 5, CardColor.Blue), 2),
        
        ((CardType.Number, 6, CardColor.Red), 2),
        ((CardType.Number, 6, CardColor.Yellow), 2),
        ((CardType.Number, 6, CardColor.Green), 2),
        ((CardType.Number, 6, CardColor.Blue), 2),
        
        ((CardType.Number, 7, CardColor.Red), 2),
        ((CardType.Number, 7, CardColor.Yellow), 2),
        ((CardType.Number, 7, CardColor.Green), 2),
        ((CardType.Number, 7, CardColor.Blue), 2),
        
        ((CardType.Number, 8, CardColor.Red), 2),
        ((CardType.Number, 8, CardColor.Yellow), 2),
        ((CardType.Number, 8, CardColor.Green), 2),
        ((CardType.Number, 8, CardColor.Blue), 2),
        
        ((CardType.Number, 9, CardColor.Red), 2),
        ((CardType.Number, 9, CardColor.Yellow), 2),
        ((CardType.Number, 9, CardColor.Green), 2),
        ((CardType.Number, 9, CardColor.Blue), 2),
    ];
}
