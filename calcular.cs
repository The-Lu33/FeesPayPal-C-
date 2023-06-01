namespace Calcular.Models
{
    public class CommissionOfPaypal
    {

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