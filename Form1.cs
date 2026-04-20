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
        List<Citas>citass=new List<Citas>();
        List<Reporte>reportes=new List<Reporte>();
        public Form1()
        {
            InitializeComponent();
            LeerDoctores();
            LeerPacientes();
            //LeerCitas();
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
            citass.Add(cita);
            GuardarCita();
        }
        private void GuardarCita()
        {
            FileStream stream = new FileStream("citas.txt", FileMode.Create, FileAccess.Write);

            StreamWriter writer = new StreamWriter(stream);

            foreach (var item in citass)
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

        private void LeerCitas()
        {
            string fileName = "citas.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);



            while (reader.Peek() > -1)

            {
                Citas leercitas = new Citas();
                leercitas.Iddoctor = reader.ReadLine();
                leercitas.Idpaciente = reader.ReadLine();
                leercitas.Fechacita = Convert.ToDateTime(reader.ReadLine());
                leercitas.Horacita = Convert.ToDateTime(reader.ReadLine());


                citass.Add(leercitas);


            }
            reader.Close();

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
            //LeerCitas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            Reporte reporte= new Reporte();
            foreach (var item in citass)
            {
                reporte.Iddoctor = comboBoxDoctor.SelectedValue.ToString();
                reporte.Idpaciente = comboBoxPaciente.SelectedValue.ToString();
                reporte.Fechacita = dateTimePickerFecha.Value;
                reporte.Horacita = dateTimePickerHora.Value;


                reportes.Add(reporte);

            }
            dataGridView1.DataSource = reportes;

        }

        private void buttonPorDoctor_Click(object sender, EventArgs e)
        {
            reportes = reportes.OrderBy(c => c.Iddoctor).ToList();
            dataGridView1.DataSource = reportes;
        }

        private void buttonCantidad_Click(object sender, EventArgs e)
        {
            int total = citass.Count;
            MessageBox.Show("Total de citas registradas" + total);
        }
    }
}
