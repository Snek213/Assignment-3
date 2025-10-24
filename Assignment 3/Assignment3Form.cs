using System.Windows.Forms;

//I was unsure wether cards drawn should be shuffled back in deck or not. I assumed cards shouldnt be re-entered in the pool of cards.
namespace Assignment_3
{
    public partial class MainForm : Form
    {
        private const int HAND_SIZE = 5;
        private const string DEFAULT_EXTENSION = "txt";
        private const string DEFAULT_DIRECTORY = @"C:\Hands";

        private int[] hand = new int[5];
        private List<int> deck = new List<int>();
        Random rng = new Random();

        public MainForm()
        {
            InitializeComponent();
            Shuffle();
            DealHand();
        }

        private void DealHand()
        {

            foreach (int card in hand)
            {
                if (deck.Contains(card))
                    deck.Remove(card);
            }


            for (int i = 0; i < 5; i++)
            {
                bool keepCard = false;

                switch (i)
                {
                    case 0: 
                        keepCard = chkKeep1.Checked; 
                        break;
                    case 1: 
                        keepCard = chkKeep2.Checked; 
                        break;
                    case 2: 
                        keepCard = chkKeep3.Checked; 
                        break;
                    case 3: 
                        keepCard = chkKeep4.Checked; 
                        break;
                    case 4: 
                        keepCard = chkKeep5.Checked; 
                        break;
                }


                if (!keepCard && deck.Count > 0)
                {
                    hand[i] = deck[0];
                    deck.RemoveAt(0);
                }
            }


            foreach (int card in hand)
            {
                if (deck.Contains(card))
                    deck.Remove(card);
            }


            picCard1.Image = lstHands.Images[hand[0]];
            picCard2.Image = lstHands.Images[hand[1]];
            picCard3.Image = lstHands.Images[hand[2]];
            picCard4.Image = lstHands.Images[hand[3]];
            picCard5.Image = lstHands.Images[hand[4]];
        }

        private void Shuffle()
        {
            deck.Clear();
            for (int i = 0; i < 52; i++)
            {
                deck.Add(i);
            }

            for (int i = deck.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                int temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }

            for (int i = 0; i < 5; i++)
            {
                hand[i] = deck[i];
            }
        }

        private void SaveHand()
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                InitialDirectory = DEFAULT_DIRECTORY,
                DefaultExt = DEFAULT_EXTENSION,
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Save Poker Hand"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                    {
                        foreach (int card in hand)
                        {
                            writer.WriteLine(card);
                        }
                    }
                    MessageBox.Show("Hand saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving hand: {ex.Message}");
                }
            }
        }



        private void LoadHand()
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                InitialDirectory = DEFAULT_DIRECTORY,
                DefaultExt = DEFAULT_EXTENSION,
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Load Poker Hand"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] lines = File.ReadAllLines(openDialog.FileName);
                    for (int i = 0; i < HAND_SIZE; i++)
                    {
                        if (i < lines.Length && int.TryParse(lines[i], out int val))
                            hand[i] = val;
                        else
                            hand[i] = -1;
                    }

                   
                    PictureBox[] pictureBoxes = { picCard1, picCard2, picCard3, picCard4, picCard5 };
                    for (int i = 0; i < HAND_SIZE; i++)
                    {
                        UpdateCardImage(pictureBoxes[i], hand[i]);
                    }

                    MessageBox.Show("Hand loaded successfully!", "Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading hand: {ex.Message}");
                }
            }
        }

        private void UpdateCardImage(PictureBox box, int cardIndex)
        {
            if (cardIndex >= 0 && cardIndex < lstHands.Images.Count)
                box.Image = lstHands.Images[cardIndex];
            else
                box.Image = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            DealHand();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveHand();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadHand();
        }

        private void picCard1_Click(object sender, EventArgs e)
        {
            chkKeep1.Checked = !chkKeep1.Checked;
        }

        private void picCard2_Click(object sender, EventArgs e)
        {
            chkKeep2.Checked = !chkKeep2.Checked;
        }

        private void picCard3_Click(object sender, EventArgs e)
        {
            chkKeep3.Checked = !chkKeep3.Checked;
        }

        private void picCard4_Click(object sender, EventArgs e)
        {
            chkKeep4.Checked = !chkKeep4.Checked;
        }

        private void picCard5_Click(object sender, EventArgs e)
        {
            chkKeep5.Checked = !chkKeep5.Checked;
        }
    }
}