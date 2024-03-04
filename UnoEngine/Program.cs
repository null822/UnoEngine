using UnoEngine.CardTypes;

namespace UnoEngine;

internal static class Program
{
    private static readonly Deck Discard = new ();
    private static readonly Deck Pickup = new (DeckPresets.Standard);
    
    
    private static void Main(string[] args)
    {
        Console.WriteLine(Pickup.ToString());
        
        // // draw every single card in the deck
        // while (Pickup.Size > 0)
        // {
        //     Console.WriteLine(Pickup.Draw(4));
        // }
        
    }
}