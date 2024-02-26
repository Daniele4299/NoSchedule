namespace NoSchedule
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panel1 = new Panel();
            groupBox5 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            label7 = new Label();
            label8 = new Label();
            groupBox4 = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            label5 = new Label();
            label6 = new Label();
            groupBox3 = new GroupBox();
            label12 = new Label();
            label11 = new Label();
            label9 = new Label();
            label10 = new Label();
            label19 = new Label();
            tabPage2 = new TabPage();
            button10 = new Button();
            groupBox2 = new GroupBox();
            button9 = new Button();
            label22 = new Label();
            listBox1 = new ListBox();
            groupBox1 = new GroupBox();
            button8 = new Button();
            button4 = new Button();
            button7 = new Button();
            comboBox1 = new ComboBox();
            button6 = new Button();
            comboBox2 = new ComboBox();
            button5 = new Button();
            comboBox3 = new ComboBox();
            label20 = new Label();
            comboBox4 = new ComboBox();
            label21 = new Label();
            comboBox5 = new ComboBox();
            comboBox6 = new ComboBox();
            tabPage4 = new TabPage();
            monthCalendar1 = new MonthCalendar();
            tabPage5 = new TabPage();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(508, 355);
            tabControl1.TabIndex = 0;
            tabControl1.Selecting += tabControl1_Selecting;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(500, 327);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Resoconto";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(groupBox5);
            panel1.Controls.Add(groupBox4);
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(label19);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(494, 321);
            panel1.TabIndex = 0;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label4);
            groupBox5.Controls.Add(label3);
            groupBox5.Controls.Add(label7);
            groupBox5.Controls.Add(label8);
            groupBox5.Location = new Point(8, 197);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(481, 91);
            groupBox5.TabIndex = 21;
            groupBox5.TabStop = false;
            groupBox5.Text = "Pianificati";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(6, 19);
            label4.Name = "label4";
            label4.Size = new Size(133, 30);
            label4.TabIndex = 2;
            label4.Text = "Ferie (giorni):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(6, 51);
            label3.Name = "label3";
            label3.Size = new Size(104, 30);
            label3.TabIndex = 3;
            label3.Text = "PAR (ore):";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(145, 19);
            label7.Name = "label7";
            label7.Size = new Size(24, 30);
            label7.TabIndex = 6;
            label7.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(145, 51);
            label8.Name = "label8";
            label8.Size = new Size(24, 30);
            label8.TabIndex = 7;
            label8.Text = "0";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label1);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(label6);
            groupBox4.Location = new Point(8, 100);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(481, 91);
            groupBox4.TabIndex = 20;
            groupBox4.TabStop = false;
            groupBox4.Text = "Rimanenti";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 19);
            label1.Name = "label1";
            label1.Size = new Size(133, 30);
            label1.TabIndex = 0;
            label1.Text = "Ferie (giorni):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(8, 51);
            label2.Name = "label2";
            label2.Size = new Size(104, 30);
            label2.TabIndex = 1;
            label2.Text = "PAR (ore):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(145, 19);
            label5.Name = "label5";
            label5.Size = new Size(24, 30);
            label5.TabIndex = 4;
            label5.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(145, 51);
            label6.Name = "label6";
            label6.Size = new Size(24, 30);
            label6.TabIndex = 5;
            label6.Text = "0";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label10);
            groupBox3.Location = new Point(8, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(481, 91);
            groupBox3.TabIndex = 19;
            groupBox3.TabStop = false;
            groupBox3.Text = "Totali";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(6, 19);
            label12.Name = "label12";
            label12.Size = new Size(133, 30);
            label12.TabIndex = 8;
            label12.Text = "Ferie (giorni):";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(6, 51);
            label11.Name = "label11";
            label11.Size = new Size(104, 30);
            label11.TabIndex = 9;
            label11.Text = "PAR (ore):";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(145, 51);
            label9.Name = "label9";
            label9.Size = new Size(24, 30);
            label9.TabIndex = 11;
            label9.Text = "0";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(145, 19);
            label10.Name = "label10";
            label10.Size = new Size(24, 30);
            label10.TabIndex = 10;
            label10.Text = "0";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.Location = new Point(188, 289);
            label19.Name = "label19";
            label19.Size = new Size(118, 30);
            label19.TabIndex = 18;
            label19.Text = "Anno: 2024";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button10);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(500, 327);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Gestione";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            button10.Location = new Point(10, 278);
            button10.Name = "button10";
            button10.Size = new Size(480, 42);
            button10.TabIndex = 7;
            button10.Text = "Salva";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button9);
            groupBox2.Controls.Add(label22);
            groupBox2.Controls.Add(listBox1);
            groupBox2.Location = new Point(276, 7);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(214, 265);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Consulta o Modifica";
            // 
            // button9
            // 
            button9.Location = new Point(8, 229);
            button9.Name = "button9";
            button9.Size = new Size(195, 30);
            button9.TabIndex = 6;
            button9.Text = "Elimina giorno selezionato";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(8, 30);
            label22.Name = "label22";
            label22.Size = new Size(80, 15);
            label22.TabIndex = 5;
            label22.Text = "Programmati:";
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.White;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(10, 48);
            listBox1.Name = "listBox1";
            listBox1.ScrollAlwaysVisible = true;
            listBox1.Size = new Size(193, 169);
            listBox1.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button8);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button7);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(comboBox3);
            groupBox1.Controls.Add(label20);
            groupBox1.Controls.Add(comboBox4);
            groupBox1.Controls.Add(label21);
            groupBox1.Controls.Add(comboBox5);
            groupBox1.Controls.Add(comboBox6);
            groupBox1.Location = new Point(10, 7);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(260, 265);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Aggiungi Ferie o PAR";
            // 
            // button8
            // 
            button8.Location = new Point(10, 229);
            button8.Name = "button8";
            button8.Size = new Size(238, 30);
            button8.TabIndex = 14;
            button8.Text = "Aggiungi PAR 2H";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button4
            // 
            button4.Location = new Point(10, 85);
            button4.Name = "button4";
            button4.Size = new Size(238, 30);
            button4.TabIndex = 10;
            button4.Text = "Aggiungi Ferie";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button7
            // 
            button7.Location = new Point(10, 193);
            button7.Name = "button7";
            button7.Size = new Size(238, 30);
            button7.TabIndex = 13;
            button7.Text = "Aggiungi PAR 4H";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownHeight = 90;
            comboBox1.FormattingEnabled = true;
            comboBox1.IntegralHeight = false;
            comboBox1.Items.AddRange(new object[] { "Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre" });
            comboBox1.Location = new Point(92, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(88, 23);
            comboBox1.TabIndex = 0;
            comboBox1.Text = "Gennaio";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button6
            // 
            button6.Location = new Point(10, 157);
            button6.Name = "button6";
            button6.Size = new Size(238, 30);
            button6.TabIndex = 12;
            button6.Text = "Aggiungi PAR 6H";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // comboBox2
            // 
            comboBox2.DropDownHeight = 90;
            comboBox2.FormattingEnabled = true;
            comboBox2.IntegralHeight = false;
            comboBox2.Location = new Point(39, 22);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(47, 23);
            comboBox2.TabIndex = 2;
            comboBox2.Text = "01";
            // 
            // button5
            // 
            button5.Location = new Point(10, 121);
            button5.Name = "button5";
            button5.Size = new Size(238, 30);
            button5.TabIndex = 11;
            button5.Text = "Aggiungi PAR 8H";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // comboBox3
            // 
            comboBox3.Enabled = false;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(186, 22);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(62, 23);
            comboBox3.TabIndex = 3;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(11, 26);
            label20.Name = "label20";
            label20.Size = new Size(27, 15);
            label20.TabIndex = 4;
            label20.Text = "Da: ";
            // 
            // comboBox4
            // 
            comboBox4.Enabled = false;
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(186, 51);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(62, 23);
            comboBox4.TabIndex = 9;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(13, 55);
            label21.Name = "label21";
            label21.Size = new Size(21, 15);
            label21.TabIndex = 6;
            label21.Text = "A: ";
            // 
            // comboBox5
            // 
            comboBox5.DropDownHeight = 90;
            comboBox5.FormattingEnabled = true;
            comboBox5.IntegralHeight = false;
            comboBox5.Location = new Point(39, 51);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(47, 23);
            comboBox5.TabIndex = 8;
            comboBox5.Text = "01";
            // 
            // comboBox6
            // 
            comboBox6.DropDownHeight = 90;
            comboBox6.FormattingEnabled = true;
            comboBox6.IntegralHeight = false;
            comboBox6.Items.AddRange(new object[] { "Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre" });
            comboBox6.Location = new Point(92, 51);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(88, 23);
            comboBox6.TabIndex = 7;
            comboBox6.Text = "Gennaio";
            comboBox6.SelectedIndexChanged += comboBox6_SelectedIndexChanged;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(monthCalendar1);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(500, 327);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Calendario";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            monthCalendar1.CalendarDimensions = new Size(2, 2);
            monthCalendar1.Location = new Point(21, 9);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 0;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(button11);
            tabPage5.Controls.Add(button12);
            tabPage5.Controls.Add(button13);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(500, 327);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Utilità";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            button11.Location = new Point(8, 250);
            button11.Name = "button11";
            button11.Size = new Size(484, 70);
            button11.TabIndex = 5;
            button11.Text = "About";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.Location = new Point(8, 7);
            button12.Name = "button12";
            button12.Size = new Size(484, 147);
            button12.TabIndex = 4;
            button12.Text = "Esporta Excel";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button13
            // 
            button13.Location = new Point(8, 160);
            button13.Name = "button13";
            button13.Size = new Size(484, 84);
            button13.TabIndex = 3;
            button13.Text = "Cancella tutti i dati";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 355);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NoSchedule";
            Load += MainForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tabPage2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label4;
        private ComboBox comboBox1;
        private Label label19;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private ListBox listBox1;
        private GroupBox groupBox2;
        private Label label22;
        private GroupBox groupBox1;
        private Button button8;
        private Button button4;
        private Button button7;
        private Button button6;
        private ComboBox comboBox2;
        private Button button5;
        private ComboBox comboBox3;
        private Label label20;
        private ComboBox comboBox4;
        private Label label21;
        private ComboBox comboBox5;
        private ComboBox comboBox6;
        private Button button9;
        private Button button10;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private MonthCalendar monthCalendar1;
        private Button button11;
        private Button button12;
        private Button button13;
        private GroupBox groupBox5;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
    }
}