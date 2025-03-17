using System.Collections;
using System.Security.Cryptography;
using System.Text;
using UnoEngine.CardTypes;
using UnoEngine.CardValues;

namespace UnoEngine;

public class Deck : IEnumerable<Card>
{
    /// <summary>
    /// A list of all of the cards present in the deck.
    /// </summary>
    private readonly List<Card> _cards = [];
    
    /// <summary>
    /// The quantity of cards in the deck.
    /// </summary>
    public int Size => _cards.Count;
    
    /// <summary>
    /// Creates a new deck from specific parameters.
    /// </summary>
    /// <param name="contents">an array of properties:quantity describing the contents of the new deck</param>
    /// <param name="shuffle">Whether or not to shuffle the deck</param>
    public Deck((CardProperties prop, int qty)[]? contents = default, bool shuffle = true)
    {
        if (contents != default)
        {
            foreach (var card in contents)
            {
                // grow the _cards list
                _cards.EnsureCapacity(_cards.Count + card.qty);
                
                // add the requested amount of that card
                for (var i = 0; i < card.qty; i++)
                {
                    _cards.Add(Card.New(card.prop));
                }
            }
            
            // shuffle the cards
            if (shuffle)
            {
                var cardSpan = new Span<Card>(_cards.ToArray());
                RandomNumberGenerator.Shuffle(cardSpan);
                _cards = cardSpan.ToArray().ToList();
            }
        }
    }
    
    /// <summary>
    /// Creates a new deck from an <see cref="IEnumerable"/>.
    /// </summary>
    public Deck(IEnumerable<Card> cards)
    {
        _cards = cards.ToList();
    }
    
    /// <summary>
    /// Returns the card at the specified index, and removes it from the deck.
    /// </summary>
    /// <param name="index">the index to get the card at</param>
    /// <remarks>
    /// If the index resides outside of the deck, it will be clamped to remain within.<br></br>
    /// Will take the last card in the deck if <paramref name="index"/> is not set.
    /// </remarks>
    public Card Take(int index = -1)
    {
        if (Size == 0)
            throw new Exception("Unable to take card: deck is empty");
        
        if (index < 0) index = Size - 1;
        else if (index > Size-1) index = 0;
        
        // get and remove the card
        var nextCard = _cards[index];
        _cards.RemoveAt(index);
        
        return nextCard;
    }
    
    /// <summary>
    /// Takes a specific card from the deck.
    /// </summary>
    /// <param name="card">the card to take</param>
    /// <returns>whether the card was removed from the deck or not</returns>
    public bool Take(Card card)
    {
        if (Size == 0)
            throw new Exception("Unable to take card: deck is empty");

        return _cards.Remove(card);
    }
    
    /// <summary>
    /// Returns the top (<paramref name="qty"/>) cards.
    /// </summary>
    /// <param name="qty">the amount of cards to take</param>
    /// <remarks>
    /// If the <paramref name="qty"/> is larger than the size of the deck, it will be clamped to remain within.<br></br>
    /// Will take every card in the deck if <paramref name="qty"/> is not set.
    /// </remarks>
    public Deck TakeMultiple(int qty = -1)
    {
        if (Size == 0)
            throw new Exception("Unable to take cards: deck is empty");
        
        if (qty < 0) qty = Size - 1;
        else if (qty > Size-1) qty = Size-1;

        var retCards = new Card[qty];

        // get and remove all of the cards
        _cards.CopyTo(0, retCards, 0, qty);
        _cards.RemoveRange(0, qty);
        
        // create and return a deck with the cards
        return new Deck(retCards);
    }
    
    /// <summary>
    /// Clears the deck, voiding any cards held within.
    /// </summary>
    public void Clear()
    {
        _cards.Clear();
    }
    
    /// <summary>
    /// Returns the card at the specified index, without removing it from the deck.
    /// </summary>
    /// <param name="index">the index to get the card at</param>
    /// <returns>the card at the index</returns>
    /// <remarks>
    /// If the index resides outside of the deck, it will be clamped to remain within.
    /// </remarks>
    public Card Peek(int index = -1)
    {
        if (Size == 0)
            throw new Exception("Unable to peek card: deck is empty");
        
        if (index == -1) index = Size - 1;
        else if (index > Size-1) index = 0;
        
        
        return _cards[index];
    }
    
    /// <summary>
    /// Adds a card to the end of the deck.
    /// </summary>
    /// <param name="card">the card to add</param>
    public void Add(Card card)
    {
        _cards.Add(card);
    }
    
    /// <summary>
    /// Adds all of the cards in the supplied deck to end of this deck, removing them in the process.
    /// </summary>
    /// <param name="cards">the card to add</param>
    public void Add(Deck cards)
    {
        while (cards.Size > 0)
        {
            _cards.Add(cards.Take());
        }
    }
    
    public void Insert(Card card, int index)
    {
        _cards.Insert(index, card);
    }

    public Deck GetStackable(Card card)
    {
        var retDeck = new Deck();
        
        foreach (var c in _cards)
        {
            // if the card can stack, add it to the deck
            if (card.CanStack(c))
            {
                retDeck.Add(c);
            }
        }
        
        
        return retDeck;
    }
    
    /// <summary>
    /// Returns a bool describing if every card in the deck can stack on the card below it.
    /// </summary>
    public bool IsValid()
    {
        var valid = true;
        
        for (var i = 1; i < _cards.Count; i++)
        {
            valid &= _cards[i - 1].CanStack(_cards[i]);
        }
        
        return valid;
    }

    /// <summary>
    /// Returns a bool describing if the deck contains the card specified.
    /// </summary>
    public bool Has(Card card)
    {
        return _cards.Contains(card);
    }
    
    /// <summary>
    /// Returns the quantity of the specified card present in the deck.
    /// </summary>
    public int Count(Card card)
    {
        return _cards.FindAll(c => c == card).Count;
    }
    
    /// <summary>
    /// Returns all cards within this deck that match the supplied type and [optional] value.
    /// </summary>
    /// <param name="type">The type of card to match</param>
    /// <param name="value">[optional] The value of card to match</param>
    public Deck Get(CardType type, int value = 0)
    {
        return new Deck(_cards.FindAll(c => 
                c.Properties.Type == type && 
                c.Properties.Value == value
            ));
    }
    
    /// <summary>
    /// Returns all cards within this deck that match the supplied types and [optional] values.
    /// </summary>
    /// <param name="types">The types of card to match</param>
    /// <param name="values">[optional] The values of card to match</param>
    public Deck Get(CardType[] types, int[]? values = null)
    {

        var valuesNn = new int[types.Length];
        if (values != null && values.Length <= types.Length)
        {
            for (var i = 0; i < values.Length; i++)
            {
                valuesNn[i] = values[i];
            }
        }
        
        return new Deck(_cards.FindAll(c =>
        {
            var properties = c.Properties;

            for (var i = 0; i < types.Length; i++)
            {
                var value = valuesNn[i];
                
                if (properties.Type == types[i] && value == 0 || properties.Value == value)
                    return true;
            }
            
            return false;
        }));
    }
    
    /// <summary>
    /// Returns all cards within this deck that match the supplied color.
    /// </summary>
    /// <param name="color">The color of card to match</param>
    public Deck Get(CardColor color)
    {
        return new Deck(_cards.FindAll(c => c.Properties.Color == color));
    }
    
    public IEnumerator<Card> GetEnumerator()
    {
        return _cards.GetEnumerator();
    }
    
    public override string ToString()
    {
        var str = new StringBuilder("[");
        
        foreach (var card in _cards)
        {
            str.Append($"\n  {card.ToString()},");
        }
        
        str.Append("\n]");
        
        return str.ToString();
    }
    
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}