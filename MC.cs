namespace PRG_MAUI_Car_Register.Model
{
    public class MC : Vehicle
    {
        public override string GetDescription()
        {
            return $"MC\t{RegistrationNumber}\t{Manufacturer}\t{Model}\t{YearModel}";
        }
    }
}