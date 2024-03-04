using System.Security.Cryptography;
using System.Text;
using UnoEngine.CardTypes;

namespace UnoEngine;

public class Deck
{
    private readonly List<Card> _cards = [];

    public int Size => _cards.Count;
    
    public Deck(List<(CardProperties type, int qty)>? contents = default, bool shuffle = true)
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
                    _cards.Add(new Card(card.type));
                }
            }

            if (shuffle)
            {
                var cardSpan = new Span<Card>(_cards.ToArray());
                RandomNumberGenerator.Shuffle(cardSpan);
                _cards = cardSpan.ToArray().ToList();
            }
        }
        
        
    }
    
    public void Add(Card card)
    {
        _cards.Add(card);
    }

    public Card Draw(int index = -1)
    {
        if (Size == 0)
            throw new Exception("Unable to draw card: deck is empty");
        
        if (index == -1) index = Size - 1;
        else if (index > Size-1) index = 0;
        
        // get and remove the card
        var nextCard = _cards[index];
        _cards.RemoveAt(index);
        
        return nextCard;
    }
    
    public bool Has(Card card)
    {
        return _cards.Contains(card);
    }
    
    public int Count(Card card)
    {
        return _cards.FindAll(c => c == card).Count;
    }
    
    public override string ToString()
    {
        var str = new StringBuilder("[");
        
        foreach (var card in _cards)
        {
            str.Append($"\n  {card.ToString()}");
        }
        
        str.Append("\n]");
        
        return str.ToString();
    }
}