using System;

namespace Calculadore
{
    class comissionsOfPaypal
    {
        static void Main(string[] args)
        {
            float porcentajeComision = 5.4f;
            float comisionFija = 0.30f;
            float monto = 0f;
            string selectMethod = "";
            string repeat = "y";

            Console.WriteLine("Bienvenido a su calculadora de Paypal");
            Console.WriteLine($"Porcentaje {porcentajeComision}% + comision fija {comisionFija}$");

            comissionsOfPaypal calculadora = new comissionsOfPaypal(); // Crear una instancia de la clase

            while (repeat.ToLower() == "y")
            {
                Console.WriteLine($"Por favor seleccionar el metodo de calculo, si desea Calacular para Recivir 'r', Calcular para Enviar 'e' ");
                selectMethod = Console.ReadLine() ?? "";

                if (selectMethod.ToLower() == "r")
                {
                    Console.WriteLine("Por favor indique el monto a calcular");
                    monto = float.Parse(Console.ReadLine());
                    float envia = calculadora.Enviar(porcentajeComision, comisionFija, monto);
                    Console.WriteLine($"Si envia ${monto}, recibira: {envia}");
                }
                else if (selectMethod.ToLower() == "e")
                {
                    Console.WriteLine("Por favor indique el monto a calcular");
                    monto = float.Parse(Console.ReadLine());
                    float recibe = calculadora.Recibir(porcentajeComision, comisionFija, monto);
                    Console.WriteLine($"Si desea recibir {monto} debe enviar: {recibe}");
                }

                Console.WriteLine("Desea hacer otra operacion? (y/n)");
                repeat = Console.ReadLine() ?? "";
            }
        }

        public float Enviar(float porcentajeComision, float comisionFija, float monto)
        {
            float crrValue = monto;
            float paypalCommissionPorcentaje = porcentajeComision / 100;
            float crrCommision = crrValue * paypalCommissionPorcentaje + comisionFija;
            float result = MathF.Round(monto - crrCommision, 2);
            return result;
        }
        public float Recibir(float porcentajeComision, float comisionFija, float monto)
        {
            float crrValue = monto;
            float paypalCommissionPorcentaje = porcentajeComision / 100;

            float crrCommision = (crrValue + comisionFija) / (1 - paypalCommissionPorcentaje);
            float result = MathF.Round(crrCommision, 2);
            return result;
        }
    }
}
