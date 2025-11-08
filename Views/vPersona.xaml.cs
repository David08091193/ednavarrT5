using ednavarrT5.Models;

namespace ednavarrT5.Views
{
    public partial class vPersona : ContentPage
    {
        public vPersona()
        {
            InitializeComponent();
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
           
            lblMensaje.Text = "";
            App.personRepository.AddNewPerson(txtNombre.Text);
            lblMensaje.Text = App.personRepository.mensaje;
        }

        private void btnListar_Clicked(object sender, EventArgs e)
        {
         
            lblMensaje.Text = "";
            List<Persona> person = App.personRepository.GetAllPersons();
            ListaPersonas.ItemsSource = person;
            lblMensaje.Text = App.personRepository.mensaje;
        }
    }
}

//BOTON ACTUALIZAR 

//BOTON ELIMINAR