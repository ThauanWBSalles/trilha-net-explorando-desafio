namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verificar se a capacidade da suíte é suficiente para o número de hóspedes
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Lançar uma exceção se a capacidade for menor que o número de hóspedes
                throw new Exception("A quantidade de hóspedes excede a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes cadastrados
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // Calcular o valor da diária com base nos dias reservados e o valor da suíte
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Se a reserva for para 10 dias ou mais, aplicar um desconto de 10%
            if (DiasReservados >= 10)
            {
                valor -= valor * 0.10m; // Desconto de 10%
            }

            return valor;
        }
    }
}
