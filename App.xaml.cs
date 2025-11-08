namespace ednavarrT5
{
    public partial class App : Application
    {

        public static Utils.PersonRepo personRepository { get; private set; }

        
        public App(Utils.PersonRepo _personRepo)
        {
            InitializeComponent();
            personRepository = _personRepo;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vPersona());//EJECUTA LA NUEVA VISTA
        }
    }
}