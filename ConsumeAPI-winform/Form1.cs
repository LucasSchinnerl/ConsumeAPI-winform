using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ConsumeAPI_winform
{
    public partial class Form1 : Form
    {
        HttpClient client;
        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("http://localhost:3000/");
        }

        private async void BtnGo_Click(object sender, EventArgs e)
        {
            string jsonAllNotes= await GetNotesJsonAsync();
            TxtJsonResult.Text = jsonAllNotes;
            List<Note> allNotes = JsonConvert.DeserializeObject<List<Note>>(jsonAllNotes);
            DGVNotes.DataSource = allNotes;
        }
        private async Task<string> GetNotesJsonAsync()
        {
            Task<string> notesJson =client.GetStringAsync("api/note");
            return await notesJson;
        }

        private void DGVNotes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRowIndex = e.RowIndex;
            var dgv = (DataGridView)sender;
            var selectedId = dgv.Rows[selectedRowIndex].Cells[0].Value.ToString();
            var selectedMessage = dgv.Rows[selectedRowIndex].Cells[1].Value.ToString();
            TxtNoteID.Text = selectedId;
            TxtNoteValue.Text = selectedMessage;

        }
    }
}
