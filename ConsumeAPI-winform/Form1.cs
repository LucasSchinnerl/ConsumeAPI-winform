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
        List<Note> allNotes;
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
            string jsonAllNotes = await GetNotesJsonAsync();
            TxtJsonResult.Text = jsonAllNotes;
            UpdateDGVNotes(jsonAllNotes);
        }

        private void UpdateDGVNotes(string jsonAllNotes)
        {
            allNotes = JsonConvert.DeserializeObject<List<Note>>(jsonAllNotes);
            DGVNotes.DataSource = allNotes;
        }

        private async Task<string> GetNotesJsonAsync()
        {
            Task<string> notesJson = client.GetStringAsync("api/note");
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

        private void TxtNoteID_TextChanged(object sender, EventArgs e)
        {

        }

        private async void BtnEditContent_Click(object sender, EventArgs e)
        {
            int id;
            string message = TxtNoteValue.Text;
            string idString = TxtNoteID.Text;

            if (int.TryParse(idString, out id))
            {
                Note changedNote = new Note();
                changedNote.Id = id;
                changedNote.Message = message;
                string changedNoteJson = JsonConvert.SerializeObject(changedNote);
                TxtJsonResult.Text = changedNoteJson;
                StringContent content = new StringContent(changedNoteJson);
                HttpResponseMessage response = await client.PutAsync($"api/note/{changedNote.Id}", content);
                //if (!response.IsSuccessStatusCode)
                //{
                //    return;
                //}
                //string resultJson = await response.Content.ReadAsStringAsync();
                //Note returnedNote = JsonConvert.DeserializeObject<Note>(resultJson);
                //foreach (var item in allNotes)
                //{
                //    if (item.Id == returnedNote.Id)
                //        item.Message = returnedNote.Message;
                //}
                DGVNotes.DataSource = allNotes;
                foreach (DataGridViewRow row in DGVNotes.Rows)
                {
                    if (row.Cells[0].Value.ToString()==idString)
                    {
                        row.DefaultCellStyle.BackColor = Color.Green;
                    }
                }
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            string id = TxtNoteID.Text;
            string message = TxtNoteValue.Text;
            string idString = TxtNoteID.Text;
            HttpResponseMessage response = await client.DeleteAsync($"api/note/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return;
            }
            string resultJson = await response.Content.ReadAsStringAsync();
            List<Note> deletedNotes = JsonConvert.DeserializeObject<List<Note>>(resultJson);
            string msg=string.Empty;
            foreach (Note delNote in deletedNotes)
            {
                msg += delNote.Id.ToString() + ":" + delNote.Message;
            }
            MessageBox.Show($"erfolgreich gelöscht: {msg}", "Delete");
            UpdateDGVNotes(await GetNotesJsonAsync());

        }
    }
}
