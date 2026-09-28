using System.Text.RegularExpressions;

namespace PRG_MAUI_Car_Register.Model
{
    public abstract class Vehicle
    {
        private string registrationNumber = string.Empty;
        private string manufacturer = string.Empty;
        private string model = string.Empty;
        private string year = string.Empty;

        public Vehicle() { }

        public string RegistrationNumber
        {
            get => registrationNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ett registreringsnummer får inte vara tomt.");

                if (value.Length != 6)
                    throw new ArgumentException("Ett registreringsnummer måste bestå av exakt 6 tecken");

                for (int i = 0; i < 3; i++)
                {
                    if (!char.IsLetter(value[i]))
                        throw new ArgumentException("Inkorrekt registreringsnummer: De första tre tecknen måste vara bokstäver.");
                }

                for (int i = 3; i < 6; i++)
                {
                    if (i < 5)
                    {
                        if (!char.IsDigit(value[i]))
                            throw new ArgumentException("Inkorrekt registreringsnummer: Det fjärde och femte tecknet måste vara siffror.");
                    }
                    else
                    {
                        if (!char.IsDigit(value[i]) && !char.IsLetter(value[i]))
                            throw new ArgumentException("Inkorrekt registreringsnummer: Det sjätte tecknet måste vara en siffra eller en bokstav.");
                    }
                }

                registrationNumber = value.ToUpper();
            }
        }

        public string Model
        {
            get => model;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Modell får inte vara tomt.");

                foreach (char i in value)
                {
                    if (!char.IsLetterOrDigit(i) && i != ' ' && i != '-')
                    {
                        throw new ArgumentException($"Modellen får inte innehålla tecknet '{i}'. Endast bokstäver, siffror, mellanslag och bindestreck är tillåtna.");
                    }
                }
                model = value;
            }
        }

        public string Manufacturer
        {
            get => manufacturer;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tillverkare får inte vara tomt.");

                foreach (char i in value)
                {
                    if (!char.IsLetterOrDigit(i) && i != ' ' && i != '-')
                        throw new ArgumentException("Ett märke ska inte kunna bestå av icke relevanta symboler, bara '-' eller mellanslag");
                }

                manufacturer = value;
            }
        }

        public string YearModel
        {
            get => year;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Årsmodell får inte vara tomt.");

                if (!Regex.IsMatch(value, "^[1-2][0-9][0-9][0-9]$"))
                    throw new ArgumentException("Årsmodell måste vara fyra siffror. T.ex 2011.");

                int enteredYear = int.Parse(value);
                int currentYear = DateTime.Now.Year;

                if (enteredYear < 1895)
                    throw new ArgumentException("Tidigare modeller än 1895 kan inte registrerars.");

                if (enteredYear > currentYear)
                    throw new ArgumentException("Årsmodell kan inte vara i framtiden.");

                year = value;
            }
        }
        public abstract string GetDescription();

        public override string ToString()
        {
            return GetDescription();
        }
    }
}