using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examenParcial
{
    public partial class Form1 : Form
    {
        List<Doctor>doctores=new List<Doctor>();
        List<Paciente> pacientes = new List<Paciente>();
        List<Citas>citas=new List<Citas>();
        public Form1()
        {
            InitializeComponent();
            LeerDoctores();
            LeerPacientes();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonCita_Click(object sender, EventArgs e)
        {
            Citas cita = new Citas();
            cita.Iddoctor = comboBoxDoctor.SelectedValue.ToString();
            cita.Idpaciente = comboBoxPaciente.SelectedValue.ToString();
            cita.Fechacita = dateTimePickerFecha.Value;
            cita.Horacita = dateTimePickerHora.Value;
            citas.Add(cita);
            GuardarCita();
        }
        private void GuardarCita()
        {
            FileStream stream = new FileStream("citas.txt", FileMode.Create, FileAccess.Write);

            StreamWriter writer = new StreamWriter(stream);

            foreach (var item in citas)
            {
                writer.WriteLine(item.Iddoctor);
                writer.WriteLine(item.Idpaciente);
                writer.WriteLine(item.Fechacita);
                writer.WriteLine(item.Horacita);
            }
            writer.Close();
        }

        private void LeerDoctores()
        {
            string fileName = "doctores.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);



            while (reader.Peek() > -1)

            {
                Doctor leerdoctor = new Doctor();
                leerdoctor.Id = reader.ReadLine();
                leerdoctor.Nombre = reader.ReadLine();
                leerdoctor.Especialidad = reader.ReadLine();


                doctores.Add(leerdoctor);


            }
            reader.Close();
            comboBoxDoctor.ValueMember = "Nombre";
            comboBoxDoctor.SelectedValue = "Id";
            comboBoxDoctor.DataSource = doctores;
        }

        private void LeerPacientes()
        {
            string fileName = "pacientes.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);



            while (reader.Peek() > -1)

            {
                Paciente leerpaciente = new Paciente();
                leerpaciente.Dpi = reader.ReadLine();
                leerpaciente.Nombre = reader.ReadLine();
                leerpaciente.Telefono = reader.ReadLine();


                pacientes.Add(leerpaciente);


            }
            reader.Close();
            comboBoxPaciente.ValueMember = "Nombre";
            comboBoxPaciente.SelectedValue = "Dpi";
            comboBoxPaciente.DataSource = pacientes;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeerDoctores();
            LeerPacientes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            Citas citas = new Citas();
            foreach (var item in citas)
            {
                citas.Iddoctor = comboBoxDoctor.SelectedValue.ToString();
                citas.Idpaciente = comboBoxPaciente.SelectedValue.ToString();
                citas.Fechacita = dateTimePickerFecha.Value;
                citas.Horacita = dateTimePickerHora.Value


                reportes.Add(reporte);

            }
            dataGridView1.DataSource = reportes;
        }
    }
}
