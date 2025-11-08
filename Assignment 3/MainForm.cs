using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace Assignment_3;

public partial class MainForm : Form
{
    private const string HANDS_FOLDER = @"C:\Users\coleh\source\repos\Assignment 3\Assignment 3\images";

    private const string DEFAULT_EXT = "txt";

    private Deck deck;

    private Card[] hand = new Card[5];

    private const int NO_CARD = -1;

    private DeckForm? deckForm;

    public MainForm()
    {
        InitializeComponent();
        deck = new Deck(cardsImageList);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        // starting hand
        ReshuffleDeck();
        for (int i = 0; i < hand.Length; i++)
        {
            DealCard(i);
        }
        UpdateHandPics();
    }

    private void DealCard(int pos)
    {
        hand[pos] = deck.DealCard();
    }

    private void ReshuffleDeck()
    {
        deck.Shuffle();
    }

    private bool IsRedraw()
    {
        return keep1CheckBox.Checked ||
            keep2CheckBox.Checked ||
            keep3CheckBox.Checked ||
            keep4CheckBox.Checked ||
            keep5CheckBox.Checked;
    }

    private void dealButton_Click(object sender, EventArgs e)
    {
        // if we aren't redrawing reshuffle the deck to start fresh
        if (!IsRedraw())
        {
            ReshuffleDeck();
        }

        // deal out the cards
        if (!keep1CheckBox.Checked)
        {
            DealCard(0);
        }

        if (!keep2CheckBox.Checked)
        {
            DealCard(1);
        }

        if (!keep3CheckBox.Checked)
        {
            DealCard(2);
        }

        if (!keep4CheckBox.Checked)
        {
            DealCard(3);
        }

        if (!keep5CheckBox.Checked)
        {
            DealCard(4);
        }

        UpdateHandPics();
        ResetKeepCheckboxes();
    }

    private void ResetKeepCheckboxes()
    {
        keep1CheckBox.Checked = false;
        keep2CheckBox.Checked = false;
        keep3CheckBox.Checked = false;
        keep4CheckBox.Checked = false;
        keep5CheckBox.Checked = false;
    }

    private void UpdateHandPics()
    {
        hand1PictureBox.Image = hand[0].CardImage;
        hand2PictureBox.Image = hand[1].CardImage;
        hand3PictureBox.Image = hand[2].CardImage;
        hand4PictureBox.Image = hand[3].CardImage;
        hand5PictureBox.Image = hand[4].CardImage;
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        deck.SaveHand("hand.txt", hand);
    }

    private void hand1PictureBox_Click(object sender, EventArgs e)
    {
        keep1CheckBox.Checked = !keep1CheckBox.Checked;
    }

    private void hand2PictureBox_Click(object sender, EventArgs e)
    {
        keep2CheckBox.Checked = !keep2CheckBox.Checked;
    }

    private void hand3PictureBox_Click(object sender, EventArgs e)
    {
        keep3CheckBox.Checked = !keep3CheckBox.Checked;
    }

    private void hand4PictureBox_Click(object sender, EventArgs e)
    {
        keep4CheckBox.Checked = !keep4CheckBox.Checked;
    }

    private void hand5PictureBox_Click(object sender, EventArgs e)
    {
        keep5CheckBox.Checked = !keep5CheckBox.Checked;
    }

    private void loadButton_Click(object sender, EventArgs e)
    {
        deck.LoadHand("hand.txt", hand);
        UpdateHandPics();
    }

    private void btnShow_Click(object sender, EventArgs e)
    {
        if (deckForm == null || !deckForm.Visible)
        {
            deckForm = new DeckForm(deck);
            deckForm.Show();
        }
        else
        {
            deckForm.Focus();
        }
    }
}

