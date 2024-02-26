using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Windows.Forms.LinkLabel;
using Newtonsoft.Json;
using System.Globalization;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace NoSchedule
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            String[] toPlan;
            String[] plannedDays;
            String[] plannedPar;

            comboBox3.Text = DateTime.Now.Year.ToString();
            comboBox4.Text = DateTime.Now.Year.ToString();
            label19.Text = $"Anno: {DateTime.Now.Year.ToString()}";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            monthCalendar1.MinDate = DateTime.Parse($"01/01/{DateTime.Now.Year.ToString()}");
            monthCalendar1.MaxDate = DateTime.Parse($"31/12/{DateTime.Now.Year.ToString()}");
            getMonthDaysComboBox();

            if (initializeFiles())
            {
                toPlan = readToPlan();
                plannedDays = readPlannedDays();
                plannedPar = readPlannedPar();
                calculateToPlan(toPlan);
                calculateDays(plannedDays);
                calculatePar(plannedPar);
                boldCalendarDates();
            }
            else
            {
                MessageBox.Show("Errore - impossibile inizializzare correttamente i file.");
                Application.Exit();
            }

        }

        public static bool initializeFiles()
        {
            var currentYear = Path.Combine(Directory.GetCurrentDirectory(), $"{DateTime.Now.Year.ToString()}_TO_PLAN.txt");
            var plannedDays = Path.Combine(Directory.GetCurrentDirectory(), $"{DateTime.Now.Year.ToString()}_PLANNED_DAYS.txt");
            var plannedPar = Path.Combine(Directory.GetCurrentDirectory(), $"{DateTime.Now.Year.ToString()}_PLANNED_PAR.txt");

            try
            {
                // Check if file exists.
                if (!File.Exists(currentYear))
                {
                    MessageBox.Show($"I dati dell'anno {DateTime.Now.Year.ToString()} non sono presenti. Verranno adesso generati i nuovi file.");
                    FileStream fs = File.Create(currentYear);
                    fs.Close();
                    String ferie = Interaction.InputBox("Inserisci i giorni di ferie totali da fruire", "NoSchedule", "");
                    String par = Interaction.InputBox("Inserisci in ore i PAR totali da fruire", "NoSchedule", "");
                    using (StreamWriter outputFile = new StreamWriter(currentYear))
                    {
                        outputFile.WriteLine(ferie);
                        outputFile.WriteLine(par);
                    }
                    FileStream fs2 = File.Create(plannedDays);
                    fs2.Close();
                    FileStream fs3 = File.Create(plannedPar);
                    fs3.Close();
                    return true;
                }
                else
                {
                    // Check if file empty.
                    if (new FileInfo(currentYear).Length == 0)
                    {
                        MessageBox.Show($"I dati dell'anno {DateTime.Now.Year.ToString()} sono presenti ma incompleti o corrotti. Dovrai nuovamente inserire ferie/par.");
                        String ferie = Interaction.InputBox("Inserisci i giorni di ferie totali da fruire", "NoSchedule", "");
                        String par = Interaction.InputBox("Inserisci in ore i PAR totali da fruire", "NoSchedule", "");
                        using (StreamWriter outputFile = new StreamWriter(currentYear))
                        {
                            outputFile.WriteLine(ferie);
                            outputFile.WriteLine(par);
                        }
                        FileStream fs2 = File.Create(plannedDays);
                        fs2.Close();
                        FileStream fs3 = File.Create(plannedPar);
                        fs3.Close();
                        return true;
                    }
                    else
                    {
                        if (!File.Exists(plannedDays))
                        {
                            FileStream fs2 = File.Create(plannedDays);
                            fs2.Close();
                        }
                        if (!File.Exists(plannedPar))
                        {
                            FileStream fs2 = File.Create(plannedPar);
                            fs2.Close();
                        }
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Errore: {e}");
                return false;
            }
        }

        public String[] readToPlan()
        {
            var currentYear = Path.Combine(Directory.GetCurrentDirectory(), $"{DateTime.Now.Year.ToString()}_TO_PLAN.txt");
            List<String> responses = new List<String>();
            try
            {
                using (StreamReader sr = File.OpenText(currentYear))
                {
                    string? s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        responses.Add(s);
                    }
                    return responses.ToArray();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Errore durante la lettura dei giorni da pianificare.");
                Application.Exit();
            }
            return [];
        }

        public String[] readPlannedDays()
        {
            var currentFile = Path.Combine(Directory.GetCurrentDirectory(), $"{DateTime.Now.Year.ToString()}_PLANNED_DAYS.txt");
            List<String> responses = new List<String>();
            try
            {
                using (StreamReader sr = File.OpenText(currentFile))
                {
                    string? s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        responses.Add(s);
                    }
                    return responses.ToArray();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Errore durante la lettura delle ferie pianificate.");
                Application.Exit();
            }
            return [];
        }

        public String[] readPlannedPar()
        {
            var currentYear = Path.Combine(Directory.GetCurrentDirectory(), $"{DateTime.Now.Year.ToString()}_PLANNED_PAR.txt");
            List<String> responses = new List<String>();
            try
            {
                using (StreamReader sr = File.OpenText(currentYear))
                {
                    string? s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        responses.Add(s);
                    }
                    return responses.ToArray();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Errore durante la lettura dei PAR pianificati.");
                Application.Exit();
            }
            return [];
        }

        public bool calculateToPlan(String[] toPlan)
        {
            this.label10.Text = toPlan[0];
            this.label9.Text = toPlan[1];

            this.label5.Text = toPlan[0];
            this.label6.Text = toPlan[1];
            return true;
        }

        public bool calculateDays(String[] plannedDays)
        {
            this.label5.Text = (Int32.Parse(this.label5.Text) - plannedDays.Length).ToString();
            this.label7.Text = plannedDays.Length.ToString();

            foreach (String day in plannedDays)
            {
                int index = getListIndex(day);
                this.listBox1.Items.Insert(index, day + " -- FERIE");
            }
            return true;
        }

        public bool calculatePar(String[] plannedPar)
        {
            IDictionary<string, string> parMap = new Dictionary<string, string>();

            foreach (String p in plannedPar)
            {
                String[] splitted = p.Split(',');
                parMap.Add(splitted[0], splitted[1]);
                this.label6.Text = (Int32.Parse(this.label6.Text) - Int32.Parse(splitted[1])).ToString();
                this.label8.Text = (Int32.Parse(this.label8.Text) + Int32.Parse(splitted[1])).ToString();

                int index = getListIndex(splitted[0]);

                switch (Int32.Parse(splitted[1]))
                {
                    case 2:
                        this.listBox1.Items.Insert(index, splitted[0] + " -- PAR 2H");
                        break;
                    case 4:
                        this.listBox1.Items.Insert(index, splitted[0] + " -- PAR 4H");
                        break;
                    case 6:
                        this.listBox1.Items.Insert(index, splitted[0] + " -- PAR 6H");
                        break;
                    case 8:
                        this.listBox1.Items.Insert(index, splitted[0] + " -- PAR 8H");
                        break;
                }
            }

            return true;
        }

        public int getListIndex(String date)
        {
            foreach (string listboxItem in listBox1.Items)
            {
                String[] splitItem = listboxItem.Split(" -");
                DateTime itemDate = DateTime.Parse(splitItem[0]);
                DateTime holidayDate = DateTime.Parse(date);

                int value = DateTime.Compare(holidayDate, itemDate);

                if (value < 0)
                    return listBox1.Items.IndexOf(listboxItem);
            }
            return listBox1.Items.Count;
        }

        public void getMonthDaysComboBox()
        {

            String month1 = comboBox1.Text;
            String month2 = comboBox6.Text;

            int month1Int = 0;
            int month2Int = 0;

            int daysInMonth1 = 0;
            int daysInMonth2 = 0;

            comboBox2.Items.Clear();
            comboBox5.Items.Clear();

            switch (month1)
            {
                case "Gennaio":
                    month1Int = 1;
                    break;
                case "Febbraio":
                    month1Int = 2;
                    break;
                case "Marzo":
                    month1Int = 3;
                    break;
                case "Aprile":
                    month1Int = 4;
                    break;
                case "Maggio":
                    month1Int = 5;
                    break;
                case "Giugno":
                    month1Int = 6;
                    break;
                case "Luglio":
                    month1Int = 7;
                    break;
                case "Agosto":
                    month1Int = 8;
                    break;
                case "Settembre":
                    month1Int = 9;
                    break;
                case "Ottobre":
                    month1Int = 10;
                    break;
                case "Novembre":
                    month1Int = 11;
                    break;
                case "Dicembre":
                    month1Int = 12;
                    break;
            }

            switch (month2)
            {
                case "Gennaio":
                    month2Int = 1;
                    break;
                case "Febbraio":
                    month2Int = 2;
                    break;
                case "Marzo":
                    month2Int = 3;
                    break;
                case "Aprile":
                    month2Int = 4;
                    break;
                case "Maggio":
                    month2Int = 5;
                    break;
                case "Giugno":
                    month2Int = 6;
                    break;
                case "Luglio":
                    month2Int = 7;
                    break;
                case "Agosto":
                    month2Int = 8;
                    break;
                case "Settembre":
                    month2Int = 9;
                    break;
                case "Ottobre":
                    month2Int = 10;
                    break;
                case "Novembre":
                    month2Int = 11;
                    break;
                case "Dicembre":
                    month2Int = 12;
                    break;
            }

            daysInMonth1 = DateTime.DaysInMonth(DateTime.Now.Year, month1Int);
            daysInMonth2 = DateTime.DaysInMonth(DateTime.Now.Year, month2Int);

            for (int i = 0; i < daysInMonth1; i++)
            {
                comboBox2.Items.Add((i + 1).ToString("00"));
            }

            for (int i = 0; i < daysInMonth2; i++)
            {
                comboBox5.Items.Add((i + 1).ToString("00"));
            }

            comboBox2.Text = "01";
            comboBox5.Text = "01";
        }

        public int getMonthNumber(String month)
        {
            switch (month)
            {
                case "Gennaio":
                    return 1;
                case "Febbraio":
                    return 2;
                case "Marzo":
                    return 3;
                case "Aprile":
                    return 4;
                case "Maggio":
                    return 5;
                case "Giugno":
                    return 6;
                case "Luglio":
                    return 7;
                case "Agosto":
                    return 8;
                case "Settembre":
                    return 9;
                case "Ottobre":
                    return 10;
                case "Novembre":
                    return 11;
                case "Dicembre":
                    return 12;
                default:
                    return 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Text = "01";
            getMonthDaysComboBox();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Text = "01";
            getMonthDaysComboBox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in tabControl1.TabPages)
            {
                tab.Enabled = false;
            }
            (tabControl1.TabPages[1] as TabPage).Enabled = true;

            String dateDa = $"{comboBox2.Text}/{getMonthNumber(comboBox1.Text).ToString("00")}/{comboBox3.Text}";
            String dateA = $"{comboBox5.Text}/{getMonthNumber(comboBox6.Text).ToString("00")}/{comboBox4.Text}";
            DateTime dateDaDate = DateTime.Parse(dateDa);
            DateTime dateADate = DateTime.Parse(dateA);

            IEnumerable<DateTime> range = GetDateRange(dateDaDate, dateADate);

            int error = 0;
            foreach (DateTime date in range)
            {
                foreach (string listboxItem in listBox1.Items)
                {
                    String[] splitItem = listboxItem.Split(" -");
                    DateTime itemDate = DateTime.Parse(splitItem[0]);

                    int value = DateTime.Compare(date, itemDate);

                    if (value == 0)
                        error = 1;
                }
            }

            if (error == 1)
            {
                MessageBox.Show("Una o più date specificate sono già presenti nella lista dei giorni programmati. Modifica i parametri e riprova.");
            }
            else
            {
                foreach (DateTime date in range)
                {
                    listBox1.Items.Add($"{date.ToShortDateString()} -- FERIE");
                }
            }
        }

        public static IEnumerable<DateTime> GetDateRange(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                MessageBox.Show("La data di inizio deve essere inferiore a quella di fine.");
                yield return startDate;
            }

            while (startDate <= endDate)
            {
                yield return startDate;
                startDate = startDate.AddDays(1);
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage != null && !e.TabPage.Enabled)
            {
                e.Cancel = true;
                MessageBox.Show("Devi prima salvare le modifiche");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in tabControl1.TabPages)
            {
                tab.Enabled = false;
            }
            (tabControl1.TabPages[1] as TabPage).Enabled = true;

            String dateDa = $"{comboBox2.Text}/{getMonthNumber(comboBox1.Text).ToString("00")}/{comboBox3.Text}";
            String dateA = $"{comboBox5.Text}/{getMonthNumber(comboBox6.Text).ToString("00")}/{comboBox4.Text}";
            DateTime dateDaDate = DateTime.Parse(dateDa);
            DateTime dateADate = DateTime.Parse(dateA);

            IEnumerable<DateTime> pippo = GetDateRange(dateDaDate, dateADate);

            int error = 0;
            foreach (DateTime date in pippo)
            {
                foreach (string listboxItem in listBox1.Items)
                {
                    String[] splitItem = listboxItem.Split(" -");
                    DateTime itemDate = DateTime.Parse(splitItem[0]);

                    int value = DateTime.Compare(date, itemDate);

                    if (value == 0)
                        error = 1;
                }
            }

            if (error == 1)
            {
                MessageBox.Show("Una o più date specificate sono già presenti nella lista dei giorni programmati. Modifica i parametri e riprova.");
            }
            else
            {
                foreach (DateTime date in pippo)
                {
                    listBox1.Items.Add($"{date.ToShortDateString()} -- PAR 8H");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in tabControl1.TabPages)
            {
                tab.Enabled = false;
            }
            (tabControl1.TabPages[1] as TabPage).Enabled = true;

            String dateDa = $"{comboBox2.Text}/{getMonthNumber(comboBox1.Text).ToString("00")}/{comboBox3.Text}";
            String dateA = $"{comboBox5.Text}/{getMonthNumber(comboBox6.Text).ToString("00")}/{comboBox4.Text}";
            DateTime dateDaDate = DateTime.Parse(dateDa);
            DateTime dateADate = DateTime.Parse(dateA);

            IEnumerable<DateTime> pippo = GetDateRange(dateDaDate, dateADate);

            int error = 0;
            foreach (DateTime date in pippo)
            {
                foreach (string listboxItem in listBox1.Items)
                {
                    String[] splitItem = listboxItem.Split(" -");
                    DateTime itemDate = DateTime.Parse(splitItem[0]);

                    int value = DateTime.Compare(date, itemDate);

                    if (value == 0)
                        error = 1;
                }
            }

            if (error == 1)
            {
                MessageBox.Show("Una o più date specificate sono già presenti nella lista dei giorni programmati. Modifica i parametri e riprova.");
            }
            else
            {
                foreach (DateTime date in pippo)
                {
                    listBox1.Items.Add($"{date.ToShortDateString()} -- PAR 6H");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in tabControl1.TabPages)
            {
                tab.Enabled = false;
            }
            (tabControl1.TabPages[1] as TabPage).Enabled = true;

            String dateDa = $"{comboBox2.Text}/{getMonthNumber(comboBox1.Text).ToString("00")}/{comboBox3.Text}";
            String dateA = $"{comboBox5.Text}/{getMonthNumber(comboBox6.Text).ToString("00")}/{comboBox4.Text}";
            DateTime dateDaDate = DateTime.Parse(dateDa);
            DateTime dateADate = DateTime.Parse(dateA);

            IEnumerable<DateTime> pippo = GetDateRange(dateDaDate, dateADate);

            int error = 0;
            foreach (DateTime date in pippo)
            {
                foreach (string listboxItem in listBox1.Items)
                {
                    String[] splitItem = listboxItem.Split(" -");
                    DateTime itemDate = DateTime.Parse(splitItem[0]);

                    int value = DateTime.Compare(date, itemDate);

                    if (value == 0)
                        error = 1;
                }
            }

            if (error == 1)
            {
                MessageBox.Show("Una o più date specificate sono già presenti nella lista dei giorni programmati. Modifica i parametri e riprova.");
            }
            else
            {
                foreach (DateTime date in pippo)
                {
                    listBox1.Items.Add($"{date.ToShortDateString()} -- PAR 4H");
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in tabControl1.TabPages)
            {
                tab.Enabled = false;
            }
            (tabControl1.TabPages[1] as TabPage).Enabled = true;

            String dateDa = $"{comboBox2.Text}/{getMonthNumber(comboBox1.Text).ToString("00")}/{comboBox3.Text}";
            String dateA = $"{comboBox5.Text}/{getMonthNumber(comboBox6.Text).ToString("00")}/{comboBox4.Text}";
            DateTime dateDaDate = DateTime.Parse(dateDa);
            DateTime dateADate = DateTime.Parse(dateA);

            IEnumerable<DateTime> pippo = GetDateRange(dateDaDate, dateADate);

            int error = 0;
            foreach (DateTime date in pippo)
            {
                foreach (string listboxItem in listBox1.Items)
                {
                    String[] splitItem = listboxItem.Split(" -");
                    DateTime itemDate = DateTime.Parse(splitItem[0]);

                    int value = DateTime.Compare(date, itemDate);

                    if (value == 0)
                        error = 1;
                }
            }

            if (error == 1)
            {
                MessageBox.Show("Una o più date specificate sono già presenti nella lista dei giorni programmati. Modifica i parametri e riprova.");
            }
            else
            {
                foreach (DateTime date in pippo)
                {
                    listBox1.Items.Add($"{date.ToShortDateString()} -- PAR 2H");
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in tabControl1.TabPages)
            {
                tab.Enabled = false;
            }
            (tabControl1.TabPages[1] as TabPage).Enabled = true;

            try
            {
                listBox1.Items.Remove(listBox1.Items[listBox1.SelectedIndex]);
            }
            catch (Exception)
            {
                MessageBox.Show("Non riesco ad eliminare l'oggetto. Verifica di aver selezionato un giorno.");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            var plannedDays = Path.Combine(Directory.GetCurrentDirectory(), $"{DateTime.Now.Year.ToString()}_PLANNED_DAYS.txt");
            var plannedPar = Path.Combine(Directory.GetCurrentDirectory(), $"{DateTime.Now.Year.ToString()}_PLANNED_PAR.txt");

            File.Create(plannedDays).Close();
            File.Create(plannedPar).Close();

            foreach (string listboxItem in listBox1.Items)
            {
                String[] dateSplit = listboxItem.Split(" -");

                if (dateSplit[1].Contains("FERIE"))
                {

                    try
                    {
                        using (StreamWriter w = File.AppendText(plannedDays))
                        {
                            w.WriteLine(dateSplit[0]);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Errore durante la scrittura delle ferie.");
                        Application.Exit();
                    }

                }
                else if (dateSplit[1].Contains("PAR 8H"))
                {

                    try
                    {
                        using (StreamWriter w = File.AppendText(plannedPar))
                        {
                            w.WriteLine(dateSplit[0] + ", 8");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Errore durante la scrittura delle ferie.");
                        Application.Exit();
                    }

                }
                else if (dateSplit[1].Contains("PAR 6H"))
                {

                    try
                    {
                        using (StreamWriter w = File.AppendText(plannedPar))
                        {
                            w.WriteLine(dateSplit[0] + ", 6");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Errore durante la scrittura delle ferie.");
                        Application.Exit();
                    }

                }
                else if (dateSplit[1].Contains("PAR 4H"))
                {

                    try
                    {
                        using (StreamWriter w = File.AppendText(plannedPar))
                        {
                            w.WriteLine(dateSplit[0] + ", 4");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Errore durante la scrittura delle ferie.");
                        Application.Exit();
                    }

                }
                else if (dateSplit[1].Contains("PAR 2H"))
                {

                    try
                    {
                        using (StreamWriter w = File.AppendText(plannedPar))
                        {
                            w.WriteLine(dateSplit[0] + ", 2");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Errore durante la scrittura delle ferie.");
                        Application.Exit();
                    }

                }
            }

            MainForm main = new MainForm();
            this.Hide();
            main.ShowDialog();
            this.Close();

        }

        public async void boldCalendarDates()
        {
            List<DateTime> l = new List<DateTime>();
            List<HolidayJson> holidayList;
            String[]? holidayDays = null;

            holidayList = await retrieveHolidaysAPI($"https://date.nager.at/api/v3/publicholidays/{DateTime.Now.Year.ToString()}/IT");
            holidayDays = extractHolidays(holidayList);

            IEnumerable<DateTime> weekends = GetDaysBetween(DateTime.Parse($"01/01/{DateTime.Now.Year.ToString()}"), DateTime.Parse($"31/12/{DateTime.Now.Year.ToString()}"))
                .Where(d => d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday).ToArray();

            foreach (String holiday in holidayDays)
            {
                DateTime date = DateTime.Parse(holiday);
                l.Add(date);
            }

            foreach (String scheduled in listBox1.Items)
            {
                String[] splitted = scheduled.Split(" -");
                DateTime date = DateTime.Parse(splitted[0]);
                l.Add(date);
            }

            foreach (DateTime weekend in weekends)
            {
                l.Add(weekend);
            }

            monthCalendar1.RemoveAllBoldedDates();
            monthCalendar1.BoldedDates = l.ToArray();
        }

        IEnumerable<DateTime> GetDaysBetween(DateTime start, DateTime end)
        {
            for (DateTime i = start; i <= end; i = i.AddDays(1))
            {
                yield return i;
            }
        }

        private static async Task<List<HolidayJson>> retrieveHolidaysAPI(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    if (response != null)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8603 // Possible null reference return.
                        return JsonConvert.DeserializeObject<List<HolidayJson>>(jsonString);
#pragma warning restore CS8603 // Possible null reference return.
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Errore durante il recupero dei giorni festivi dall'API");
                Application.Exit();
            }
            return [];
        }

        private static String[] extractHolidays(List<HolidayJson> holidayList)
        {
            bool isNullOrEmpty = holidayList.Any() != true;
            List<string> dates = new List<string>();

            if (!isNullOrEmpty)
            {
                foreach (var holiday in holidayList)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    dates.Add(holiday.date);
#pragma warning restore CS8604 // Possible null reference argument.
                }
                return dates.ToArray();
            }
            else
            {
                MessageBox.Show("Errore nell'estrazione delle giornate festive");
                Application.Exit();
                return [];
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NoSchedule - Versione 1.0 - Daniele Bonadonna - 2024");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sei sicuro di voler eliminare tutti i dati dell'anno corrente?", "NoSchedule", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var toPlan = Path.Combine(Directory.GetCurrentDirectory(), $"{DateTime.Now.Year.ToString()}_TO_PLAN.txt");
                var plannedDays = Path.Combine(Directory.GetCurrentDirectory(), $"{DateTime.Now.Year.ToString()}_PLANNED_DAYS.txt");
                var plannedPar = Path.Combine(Directory.GetCurrentDirectory(), $"{DateTime.Now.Year.ToString()}_PLANNED_PAR.txt");

                File.Delete(toPlan);
                File.Delete(plannedDays);
                File.Delete(plannedPar);

                MainForm main = new MainForm();
                this.Hide();
                main.ShowDialog();
                this.Close();
            }
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("L'esportazione dell'Excel fa utilizzo di Interop Excel - Quindi presuppone la presenza di Excel installato in questa macchina. Inoltre, per funzionare correttamente, dovrai impostare il formato di sistema a English (Europe) dal pannello di controllo di sistema.");

            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;

            try
            {
                //Start Excel and get Application object.
                oXL = new Excel.Application();
                oXL.Visible = false;

                //Initialize variables
                IEnumerable<DateTime> allDaysInYear = GetDateRange(DateTime.Parse($"01/01/{DateTime.Now.Year.ToString()}"), DateTime.Parse($"31/12/{DateTime.Now.Year.ToString()}"));
                List<HolidayJson> holidayList;
                String[]? holidayDays = null;
                holidayList = await retrieveHolidaysAPI($"https://date.nager.at/api/v3/publicholidays/{DateTime.Now.Year.ToString()}/IT");
                holidayDays = extractHolidays(holidayList);


                //Get a new workbook and create sheets
                oWB = oXL.Workbooks.Add(Missing.Value);
                oSheet = oWB.ActiveSheet;
                oSheet.Name = $"CALENDARIO PRESENZE {DateTime.Now.Year.ToString()}";

                // Print all days
                int i = 0;
                foreach (DateTime day in allDaysInYear)
                {
                    i++;
                    oSheet.Cells[1, i] = day;
                    oSheet.Range[oSheet.Cells[1, i], oSheet.Cells[1, i]].NumberFormat = "dd/mm";
                    oSheet.Range[oSheet.Cells[1, i], oSheet.Cells[1, i]].Font.Size = 9;
                    oSheet.Range[oSheet.Cells[1, i], oSheet.Cells[1, i]].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(-4194304));
                    oSheet.Range[oSheet.Cells[1, i], oSheet.Cells[1, i]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(-855310));
                    oSheet.Range[oSheet.Cells[1, i], oSheet.Cells[1, i]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    oSheet.Range[oSheet.Cells[1, i], oSheet.Cells[1, i]].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    oSheet.Range[oSheet.Cells[1, i], oSheet.Cells[1, i]].ColumnWidth = 5.71;
                }

                // Print all ferie and par
                i = 0;
                foreach (DateTime day in allDaysInYear)
                {
                    i++;
                    foreach (String ferie in listBox1.Items)
                    {
                        String[] splitted = ferie.Split(" -");
                        DateTime ferieDate = DateTime.Parse(splitted[0]);
                        if ((DateTime.Compare(day, ferieDate)) == 0 && splitted[1].Contains("FERIE"))
                        {
                            oSheet.Cells[2, i] = "FERIE";
                            oSheet.Range[oSheet.Cells[2, i], oSheet.Cells[2, i]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(-7155632));
                            oSheet.Range[oSheet.Cells[2, i], oSheet.Cells[2, i]].RowHeight = 30.00;
                            oSheet.Range[oSheet.Cells[2, i], oSheet.Cells[2, i]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            oSheet.Range[oSheet.Cells[2, i], oSheet.Cells[2, i]].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        }
                        else if ((DateTime.Compare(day, ferieDate)) == 0 && splitted[1].Contains("PAR"))
                        {
                            if (splitted[1].Contains("8H"))
                                oSheet.Cells[2, i] = "8H";
                            if (splitted[1].Contains("6H"))
                                oSheet.Cells[2, i] = "6H";
                            if (splitted[1].Contains("4H"))
                                oSheet.Cells[2, i] = "4H";
                            if (splitted[1].Contains("2H"))
                                oSheet.Cells[2, i] = "2H";

                            oSheet.Range[oSheet.Cells[2, i], oSheet.Cells[2, i]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(-16384));
                            oSheet.Range[oSheet.Cells[2, i], oSheet.Cells[2, i]].RowHeight = 30.00;
                            oSheet.Range[oSheet.Cells[2, i], oSheet.Cells[2, i]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            oSheet.Range[oSheet.Cells[2, i], oSheet.Cells[2, i]].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        }
                    }
                }

                // Print all holidays
                i = 0;
                foreach (DateTime day in allDaysInYear)
                {
                    i++;
                    foreach (String holiday in holidayDays)
                    {
                        if ((DateTime.Compare(day, DateTime.Parse(holiday))) == 0)
                        {
                            oSheet.Cells[2, i] = "ROSSO";
                            oSheet.Range[oSheet.Cells[2, i], oSheet.Cells[2, i]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(-4194304));
                            oSheet.Range[oSheet.Cells[2, i], oSheet.Cells[2, i]].RowHeight = 30.00;
                            oSheet.Range[oSheet.Cells[2, i], oSheet.Cells[2, i]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            oSheet.Range[oSheet.Cells[2, i], oSheet.Cells[2, i]].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        }
                    }
                }

                // Print all weekends
                i = 0;
                foreach (DateTime day in allDaysInYear)
                {
                    i++;
                    if ((day.DayOfWeek == DayOfWeek.Saturday) || (day.DayOfWeek == DayOfWeek.Sunday))
                    {
                        oSheet.Cells[2, i] = "WEEKEND";
                        oSheet.Range[oSheet.Cells[2, i], oSheet.Cells[2, i]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(-4210753));
                        oSheet.Range[oSheet.Cells[2, i], oSheet.Cells[2, i]].RowHeight = 30.00;
                        oSheet.Range[oSheet.Cells[2, i], oSheet.Cells[2, i]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        oSheet.Range[oSheet.Cells[2, i], oSheet.Cells[2, i]].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        oSheet.Range[oSheet.Cells[2, i], oSheet.Cells[2, i]].WrapText = true;

                    }
                }

                // Create borders for all written cells, unlock all written cells
                Excel.Range last = oSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                oSheet.Range["A1", last].Cells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                //Make sure Excel is visible and give the user the save prompt
                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"FATAL ERROR: {ex}");
                Application.Exit();
            }
        }
    }
}
