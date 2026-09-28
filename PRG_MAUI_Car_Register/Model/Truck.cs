namespace PRG_MAUI_Car_Register.Model
{
    public class Truck : Vehicle
    {
        public override string GetDescription()
        {
            return $"Truck\t{RegistrationNumber}\t{Manufacturer}\t{Model}\t{YearModel}";
        }
    }
}