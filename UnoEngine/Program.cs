
using UnoEngine.CardTypes;
using UnoEngine.CardValues;

namespace UnoEngine;

public static class Program
{
    private static readonly List<Player> Players = [];
    
    private static int[] _pickupBuffer = [];
    private static int _turn = 0;
    private static sbyte _direction = 1;

    public static int PlayerCount => Players.Count;
    
    /// <summary>
    /// The active/play deck. Cards get placed here.
    /// </summary>
    private static readonly Deck ActiveDeck = new ();
    
    /// <summary>
    /// The pickup deck. Cards get taken from here
    /// </summary>
    private static readonly Deck PickupDeck = new (DeckPresets.Standard);

    
    private static void Main()
    {
        // create players
        Players.AddRange([
            new Player(),
            new Player()
        ]);
        
        _pickupBuffer = new int[PlayerCount];
        
        // play the first card
        ActiveDeck.Add(PickupDeck.Take());
        
        // deal the cards to the players

        for (var i = 0; i < PlayerCount * 7; i++)
        {
            Players[i % PlayerCount].Pickup(PickupDeck.Take());
        }
        
        // turn loop
        while (true)
        {
            var player = Players[_turn];
            var activeCard = ActiveDeck.Peek();
            
            Console.WriteLine(activeCard);

            if (player.CardCount == 0)
            {
                Console.WriteLine($"Player {_turn} Has Won");
                break;
            }
            
            var playedCards = player.Turn(activeCard);
            
            
            // if the player did not play any cards, draw 1 card
            if (playedCards.Size == 0)
            {
                var pickup = PickupDeck.Take();
                
                Console.WriteLine($"    P{_turn}: Pickup \"{pickup}\"");
                player.Pickup(pickup);
            }
            else
            {
                //TODO: check if the player actually has the cards they played
                
                // place/apply all of the cards in playedCards
                if (activeCard.CanStack(playedCards.Peek(0)) && playedCards.IsValid())
                {
                    Console.WriteLine(playedCards.Size == 1
                        ? $"    P{_turn}: Play \"{playedCards.Peek()}\""
                        : $"    P{_turn}: Play {playedCards}");
                    
                    ActiveDeck.Add(playedCards);
                    
                    
                    foreach (var playedCard in playedCards)
                    {
                        (_turn, _direction, _pickupBuffer) = playedCard.ModifyGameState(_turn, _direction, _pickupBuffer);
                    }
                    
                }
                else
                {
                    Console.WriteLine("Invalid Played Cards");
                }
                
                
                
            }
            
            playedCards.Clear();
            
        }
        
    }
}