using System;
using System.Collections.Generic;
using System.Drawing;
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
        List<Control> inputFields;  // zum leichteren Löschen des Inhalts der textboxen
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
        #region Create
        /// <summary>
        /// Create a new record and give feedback about success
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnCreate_Click(object sender, EventArgs e)
        {
            string message = TxtNoteValueCreate.Text;
            StringContent content = PrepareContentForCreating(message);
            HttpResponseMessage response = await client.PostAsync($"api/note", content);
            if (!response.IsSuccessStatusCode)
            {
                return;
            }
            string resultJson = await response.Content.ReadAsStringAsync();
            if (resultJson.StartsWith("ERROR"))         // the response can be successful, even if the creating fails
            {
                return;
            }
            Note createdNote = JsonConvert.DeserializeObject<Note>(resultJson); // here we get only a single object back
            await GiveFeedbackAfterCreating(createdNote);

        }
        /// <summary>
        /// Prepare the HttpContent needed for PostAsync
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static StringContent PrepareContentForCreating(string message)
        {
            Note newNote = new Note
            {
                Id = 0,                 // we treat 0 like "none given"
                Message = message
            };
            string jsonString = JsonConvert.SerializeObject(newNote);
            // Erzeugen von Httpcontent
            // encoding ist (vermutlich) nicht wirklich wichtig, aber mediaType!!
            StringContent content = new StringContent(jsonString, UnicodeEncoding.UTF8, "application/json");
            return content;
        }
        /// <summary>
        /// Give visual feedback about successful creation
        /// </summary>
        /// <param name="createdNote"></param>
        /// <returns></returns>
        private async Task GiveFeedbackAfterCreating(Note createdNote)
        {
            string msg = createdNote.Id.ToString() + ":" + createdNote.Message;

            MessageBox.Show($"erfolgreich erzeugt: {msg}", "New Note");
            UpdateDGVNotes(await GetNotesJsonAsync());
            ClearInputFieldsAndSelectNone();
        }
        #endregion Create
      
        #region Editing
        /// <summary>
        /// Send edited content and give Feedback 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnEditContent_Click(object sender, EventArgs e)
        {
            string message = TxtNoteValueEditOrDelete.Text;
            string idString = TxtNoteIDEditOrDelete.Text;

            Note changedNote = new Note();
            changedNote.Id = Convert.ToInt32(idString);         // alternative way for populating the object
            changedNote.Message = message;
            string changedNoteJson = JsonConvert.SerializeObject(changedNote);
            TxtJsonResult.Text = changedNoteJson;               // not really needed..., just for testing
            // here, again, we need the media type
            StringContent content = new StringContent(changedNoteJson, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"api/note/{changedNote.Id}", content);
            if (!response.IsSuccessStatusCode)
            {
                return;
            }
            string resultJson = await response.Content.ReadAsStringAsync();     // we want a string
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
        #endregion Editing


        #region Delete
        /// <summary>
        /// delete a selected record and give feedback about success
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            string id = TxtNoteIDEditOrDelete.Text;
            string message = TxtNoteValueEditOrDelete.Text;
            HttpResponseMessage response = await client.DeleteAsync($"api/note/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return;
            }
            string resultJson = await response.Content.ReadAsStringAsync();// response contains a list of deleted items, even if only one
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
        #endregion Delete


        /// <summary>
        /// Retrieve and display all records
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnGo_Click(object sender, EventArgs e)
        {
            string jsonAllNotes = await GetNotesJsonAsync();
            TxtJsonResult.Text = jsonAllNotes;
            UpdateDGVNotes(jsonAllNotes);
        }
        #region Tools
        private void UpdateDGVNotes(string jsonAllNotes)
        {
            allNotes = JsonConvert.DeserializeObject<List<Note>>(jsonAllNotes);
            DGVNotes.DataSource = allNotes;
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

        void ClearInputFieldsAndSelectNone()
        {
            foreach (Control c in inputFields)
                c.Text = "";
            DGVNotes.ClearSelection();
        }

        #endregion Tools

        #region Get
        private async Task<string> GetNotesJsonAsync()
        {
            Task<string> notesJson = client.GetStringAsync("api/note");
            return await notesJson;
        }
        #endregion Get


    }
}
