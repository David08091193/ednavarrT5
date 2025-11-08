using ednavarrT5.Models;

namespace ednavarrT5.Views
{
    public partial class vPersona : ContentPage
    {
        public vPersona()
        {
            InitializeComponent();
        }
        //BOTON AGREGAR
        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
           
            lblMensaje.Text = "";
            App.personRepository.AddNewPerson(txtNombre.Text);
            lblMensaje.Text = App.personRepository.mensaje;
        }
        //BOTON LISTAR
        private void btnListar_Clicked(object sender, EventArgs e)
        {
         
            lblMensaje.Text = "";
            List<Persona> person = App.personRepository.GetAllPersons();
            ListaPersonas.ItemsSource = person;
            lblMensaje.Text = App.personRepository.mensaje;

        }

        //BOTÓN ACTUALIZAR
        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            lblMensaje.Text = "";

            try
            {
                // Validamos que el ID no esté vacío
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    lblMensaje.Text = "Debe ingresar un ID válido para actualizar.";
                    return;
                }

                int id = int.Parse(txtId.Text);
                string nuevoNombre = txtNombre.Text;

                App.personRepository.UpdatePerson(id, nuevoNombre);
                lblMensaje.Text = App.personRepository.mensaje;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error: {ex.Message}";
            }
        }
        //BOTÓN ELIMINAR
        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            lblMensaje.Text = "";

            try
            {
                // Validamos que el ID no esté vacío
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    lblMensaje.Text = "Debe ingresar un ID válido para eliminar.";
                    return;
                }

                int id = int.Parse(txtId.Text);
                App.personRepository.DeletePerson(id);
                lblMensaje.Text = App.personRepository.mensaje;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error: {ex.Message}";
            }
        }
    }
}
