using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public class Deck
    {
        private List<Card> cards = new List<Card>();
        private readonly ImageList imageList;
        public Deck(ImageList imageList)
        {
            this.imageList = imageList;
        }
        public int Count => cards.Count;

        public void Shuffle()
        {
            cards.Clear();
            for (int i = 0; i < imageList.Images.Count; i++)
            {
                Image image = imageList.Images[i];
                string name = imageList.Images.Keys[i];
                cards.Add(new Card(i, image, name));
            }

            Random rng = new Random();

            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }

           

        }

        public Card DealCard()
        {
            if (cards.Count == 0)
            {
                
                return Card.NoCard;
            }
            Card dealtCard = cards[0];
            cards.RemoveAt(0);
            return dealtCard;
        }

        public bool SaveHand(string fileName, Card[] hand)
        {
            try
            {
                using (StreamWriter writer = new(fileName))
                {
                    foreach (Card card in hand)
                    {
                        writer.WriteLine(card.id);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool LoadHand(string fileName, Card[] hand)
        {
            try
            {
                using (StreamReader reader = new(fileName))
                {
                    for (int i = 0; i < hand.Length; i++)
                    {
                        hand[i] = Card.NoCard;
                        string? line = reader.ReadLine();
                        int cardId;
                        if (int.TryParse(line, out cardId))
                        {
                            Image img = imageList.Images[i];
                            string name = imageList.Images.Keys[i];
                            hand[i] = new Card(cardId, img, name);
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Card GetCard(int index)
        {
            if (index < 0 || index >= cards.Count)
                return Card.NoCard;

            return cards[index];
        }

        public void SwapCards(int index1, int index2)
        {
            if (index1 < 0 || index1 >= cards.Count || index2 < 0 || index2 >= cards.Count)
                return;

            Card temp = cards[index1];
            cards[index1] = cards[index2];
            cards[index2] = temp;
        }
    }
}
