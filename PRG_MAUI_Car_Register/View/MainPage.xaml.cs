using System.Collections.ObjectModel;
using PRG_MAUI_Car_Register.Model;


namespace PRG_MAUI_Car_Register.View
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Vehicle> vehicleList = new ObservableCollection<Vehicle>();


        public MainPage()
        {
            InitializeComponent();
            pickerType.SelectedIndex = 0;
            listViewVehicles.ItemsSource = vehicleList;
        }


        private void OnRegisterClicked(object sender, EventArgs e)
        {
            try
            {
                Vehicle vehicle = pickerType.SelectedIndex switch
                {
                    0 => new Car(),
                    1 => new MC(),
                    2 => new Truck(),
                    _ => throw new InvalidOperationException("Ogiltig typ vald"),
                };

                vehicle.RegistrationNumber = entryRegistrationNumber.Text;
                vehicle.Manufacturer = entryManufacturer.Text;
                vehicle.Model = entryModel.Text;
                vehicle.YearModel = entryYear.Text;

                vehicleList.Add(vehicle);

                ClearTextFields();
            }
            catch (ArgumentException ex)
            {
                DisplayAlert("Fel", ex.Message, "OK");
            }
        }

        private void OnRadioCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value != true) return;

            IEnumerable<Vehicle> filteredList;

            if (radioCar.IsChecked)
            {
                filteredList = vehicleList.OfType<Car>();
            }
            else if (radioMC.IsChecked)
            {
                filteredList = vehicleList.OfType<MC>();
            }
            else if (radioTruck.IsChecked)
            {
                filteredList = vehicleList.OfType<Truck>();
            }
            else
            {
                
                filteredList = vehicleList;
            }

            listViewVehicles.ItemsSource = filteredList;
        }

        private void OnSearchClicked(object sender, EventArgs e)
        {
            string searchTerm = entrySearchRegistrationNumber.Text?.ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                entrySearchRegistrationNumber.Text = "Ange ett registreringsnummer för att söka.";
                return;
            }

            var foundVehicle = vehicleList.FirstOrDefault(v => v.RegistrationNumber?.ToLower() == searchTerm);

            if (foundVehicle != null)
            {
                labelSearchResult.Text = $"Fordon hittat: \n{foundVehicle.GetDescription()}\n";
            }
            else
            {
                labelSearchResult.Text = "Inget fordon hittades med det registreringsnumret.";
            }
        }

        private void ClearTextFields()
        {
            entryRegistrationNumber.Text = string.Empty;
            entryManufacturer.Text = string.Empty;
            entryModel.Text = string.Empty;
            entryYear.Text = string.Empty;
        }
    }
}
