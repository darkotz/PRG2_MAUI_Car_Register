namespace PRG_MAUI_Car_Register.Model
{
    public class Car : Vehicle
    {
        public override string GetDescription()
        {
            return $"Bil\t{RegistrationNumber}\t{Manufacturer}\t{Model}\t{YearModel}";
        }
    }
}