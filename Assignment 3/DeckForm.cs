using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_3
{
    public partial class DeckForm : Form
    {
        private readonly Deck deck;



        public DeckForm(Deck deck)
        {

            InitializeComponent();
            this.deck = deck;
        }


        private void DeckForm_Load(object? sender, EventArgs e)
        {
            UpdateDeck();
        }

        public void UpdateDeck()
        {
            lstDeckBox.Items.Clear();
            for (int i = 0; i < deck.Count; i++)
            {
                lstDeckBox.Items.Add(deck.GetCard(i));
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // make sure you understand the ?'s do here
            Card? card = (Card?)lstDeckBox.SelectedItem;

            // the ? here does something related but slightly different
            // make sure you understand what it is doing
            imgPictureBox.Image = card?.CardImage;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int index = lstDeckBox.SelectedIndex;
            if (index <= 0) return;

            deck.SwapCards(index, index - 1);
            UpdateDeck();
            lstDeckBox.SelectedIndex = index - 1;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int index = lstDeckBox.SelectedIndex;
            if (index < 0 || index >= deck.Count - 1) return;

            deck.SwapCards(index, index + 1);
            UpdateDeck();
            lstDeckBox.SelectedIndex = index + 1;
        }
    }
}
