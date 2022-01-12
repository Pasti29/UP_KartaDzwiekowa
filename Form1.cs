namespace UP_KartaDzwiekowa
{
    public partial class Form1 : Form
    {

        FileStream file;

        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            if(file.CanRead)
            {
                string s = "Hello";
                richTextBox2.Text = s;
            }
        }

        private void loadButton_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file = (FileStream)openFileDialog1.OpenFile();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(file != null && file.CanRead)
            {
                var br = new BinaryReader(file);

                var chunkID = new string(br.ReadChars(4));
                var chunkSize = br.ReadInt32();
                var fileFormat = new string(br.ReadChars(4));
                var subchunk1ID = new string(br.ReadChars(4));
                var subchunk1Size = br.ReadInt32();
                var audioFormat = br.ReadInt16();
                var channels = br.ReadInt16();
                var sampleRate = br.ReadInt32();
                var byteRate = br.ReadInt32();
                var blockAlign = br.ReadInt16();
                var bitsPerSample = br.ReadInt16();
                var subchunk2ID = new string(br.ReadChars(4));
                var subchunk2Size = br.ReadInt32();
                br.Close();
                richTextBox2.Text = chunkID;
                richTextBox2.AppendText("\n" + chunkSize);
                richTextBox2.AppendText("\n" + fileFormat);
                richTextBox2.AppendText("\n" + subchunk1ID);
                richTextBox2.AppendText("\n" + subchunk1Size);
                richTextBox2.AppendText("\n" + audioFormat);
                richTextBox2.AppendText("\n" + channels);
                richTextBox2.AppendText("\n" + sampleRate);
                richTextBox2.AppendText("\n" + byteRate);
                richTextBox2.AppendText("\n" + blockAlign);
                richTextBox2.AppendText("\n" + bitsPerSample);
                richTextBox2.AppendText("\n" + subchunk2ID);
                richTextBox2.AppendText("\n" + subchunk2Size);
            }
        }
    }
}