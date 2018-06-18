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
        List<Control> inputFields;
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
            inputFields = new List<Control>{
                TxtNoteIDCreate,
                TxtNoteValueCreate,
                TxtNoteIDEditOrDelete,
                TxtNoteValueEditOrDelete};
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
            TxtNoteIDEditOrDelete.Text = selectedId;
            TxtNoteValueEditOrDelete.Text = selectedMessage;

        }

        private async void BtnEditContent_Click(object sender, EventArgs e)
        {
            string message = TxtNoteValueEditOrDelete.Text;
            string idString = TxtNoteIDEditOrDelete.Text;

            Note changedNote = new Note();
            changedNote.Id = Convert.ToInt32(idString);
            changedNote.Message = message;
            string changedNoteJson = JsonConvert.SerializeObject(changedNote);
            TxtJsonResult.Text = changedNoteJson;
            StringContent content = new StringContent(changedNoteJson, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"api/note/{changedNote.Id}", content);
            if (!response.IsSuccessStatusCode)
            {
                return;
            }
            string resultJson = await response.Content.ReadAsStringAsync();
            Note returnedNote = JsonConvert.DeserializeObject<Note>(resultJson);
            foreach (var item in allNotes)
            {
                if (item.Id == returnedNote.Id)
                    item.Message = returnedNote.Message;
            }
            DGVNotes.DataSource = allNotes;
            foreach (DataGridViewRow row in DGVNotes.Rows)
            {
                if (row.Cells[0].Value.ToString() == idString)
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
            }
            ClearInputFieldsAndSelectNone();
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            string id = TxtNoteIDEditOrDelete.Text;
            string message = TxtNoteValueEditOrDelete.Text;
            //string idString = TxtNoteIDEditOrDelete.Text;
            HttpResponseMessage response = await client.DeleteAsync($"api/note/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return;
            }
            string resultJson = await response.Content.ReadAsStringAsync();
            List<Note> deletedNotes = JsonConvert.DeserializeObject<List<Note>>(resultJson);
            string msg = string.Empty;
            foreach (Note delNote in deletedNotes)
            {
                msg += delNote.Id.ToString() + ":" + delNote.Message;
            }
            MessageBox.Show($"erfolgreich gelöscht: {msg}", "Delete");
            UpdateDGVNotes(await GetNotesJsonAsync());
            ClearInputFieldsAndSelectNone();
        }

        private async void BtnCreate_Click(object sender, EventArgs e)
        {
            //string id = TxtNoteIDCreate.Text;
            string message = TxtNoteValueCreate.Text;
            Note newNote = new Note
            {
                Message = message
            };
            string jsonString = JsonConvert.SerializeObject(newNote);
            StringContent content = new StringContent(jsonString, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync($"api/note", content);
            if (!response.IsSuccessStatusCode)
            {
                return;
            }
            string resultJson = await response.Content.ReadAsStringAsync();
            if (resultJson.StartsWith("ERROR"))
            {
                return;
            }
            Note createdNote = JsonConvert.DeserializeObject<Note>(resultJson);
            string msg = createdNote.Id.ToString() + ":" + createdNote.Message;

            MessageBox.Show($"erfolgreich erzeugt: {msg}", "New Note");
            UpdateDGVNotes(await GetNotesJsonAsync());
            ClearInputFieldsAndSelectNone();

        }
        void ClearInputFieldsAndSelectNone()
        {
            foreach (Control c in inputFields)
                c.Text = "";
            DGVNotes.ClearSelection();
        }

    }
}
