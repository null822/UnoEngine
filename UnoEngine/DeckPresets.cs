using UnoEngine.CardTypes;

namespace UnoEngine;

public static class DeckPresets
{
    public static readonly List<(CardProperties type, int qty)> Standard =
    [
        // Wildcards
        ((CardType.None, CardColor.Wild), 4),
        ((CardType.Draw4, CardColor.Wild), 4),
        
        // Draw, Reverse, Block
        ((CardType.Draw2, CardColor.Red), 2),
        ((CardType.Draw2, CardColor.Yellow), 2),
        ((CardType.Draw2, CardColor.Green), 2),
        ((CardType.Draw2, CardColor.Blue), 2),
        
        ((CardType.Reverse, CardColor.Red), 2),
        ((CardType.Reverse, CardColor.Yellow), 2),
        ((CardType.Reverse, CardColor.Green), 2),
        ((CardType.Reverse, CardColor.Blue), 2),
        
        ((CardType.Block, CardColor.Red), 2),
        ((CardType.Block, CardColor.Yellow), 2),
        ((CardType.Block, CardColor.Green), 2),
        ((CardType.Block, CardColor.Blue), 2),
        
        // Numbers
        ((CardType.N0, CardColor.Red), 1),
        ((CardType.N0, CardColor.Yellow), 1),
        ((CardType.N0, CardColor.Green), 1),
        ((CardType.N0, CardColor.Blue), 1),
        
        ((CardType.N1, CardColor.Red), 2),
        ((CardType.N1, CardColor.Yellow), 2),
        ((CardType.N1, CardColor.Green), 2),
        ((CardType.N1, CardColor.Blue), 2),
        
        ((CardType.N2, CardColor.Red), 2),
        ((CardType.N2, CardColor.Yellow), 2),
        ((CardType.N2, CardColor.Green), 2),
        ((CardType.N2, CardColor.Blue), 2),
        
        ((CardType.N3, CardColor.Red), 2),
        ((CardType.N3, CardColor.Yellow), 2),
        ((CardType.N3, CardColor.Green), 2),
        ((CardType.N3, CardColor.Blue), 2),
        
        ((CardType.N4, CardColor.Red), 2),
        ((CardType.N4, CardColor.Yellow), 2),
        ((CardType.N4, CardColor.Green), 2),
        ((CardType.N4, CardColor.Blue), 2),
        
        ((CardType.N5, CardColor.Red), 2),
        ((CardType.N5, CardColor.Yellow), 2),
        ((CardType.N5, CardColor.Green), 2),
        ((CardType.N5, CardColor.Blue), 2),
        
        ((CardType.N6, CardColor.Red), 2),
        ((CardType.N6, CardColor.Yellow), 2),
        ((CardType.N6, CardColor.Green), 2),
        ((CardType.N6, CardColor.Blue), 2),
        
        ((CardType.N7, CardColor.Red), 2),
        ((CardType.N7, CardColor.Yellow), 2),
        ((CardType.N7, CardColor.Green), 2),
        ((CardType.N7, CardColor.Blue), 2),
        
        ((CardType.N8, CardColor.Red), 2),
        ((CardType.N8, CardColor.Yellow), 2),
        ((CardType.N8, CardColor.Green), 2),
        ((CardType.N8, CardColor.Blue), 2),
        
        ((CardType.N9, CardColor.Red), 2),
        ((CardType.N9, CardColor.Yellow), 2),
        ((CardType.N9, CardColor.Green), 2),
        ((CardType.N9, CardColor.Blue), 2),
    ];
}
