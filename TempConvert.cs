namespace TempConvert;

class Program
{
    static void TempConvertions(ref float tempCelsius, out float tempFarenheit, out float tempKelvin)
    {
        tempFarenheit = (tempCelsius * 1.8f) + 32;
        tempKelvin = tempCelsius + 273.15f;
    }
    static void Main(string[] args)
    {

        Console.Write("Input the temperature in Celsius: ");
        float tempCelsius, tempFarenheit, tempKelvin;

        while(!float.TryParse(Console.ReadLine(), out tempCelsius))
        {
            Console.WriteLine("Invalid input, please try again");
            Console.Write("Input the temperature in Celsius: ");
        }

        TempConvertions(ref tempCelsius, out tempFarenheit, out tempKelvin);

        Console.WriteLine($"\nThe temperature: {tempCelsius} Celsius, {tempFarenheit} Farenheit, {tempKelvin} Kelvin");




    }
}
