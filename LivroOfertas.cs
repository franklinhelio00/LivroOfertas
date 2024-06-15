using System;
using System.Collections.Generic;
using System.Linq;

public class LivroDeOfertas
{
    public class Oferta
    {
        public int Posicao { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
    }

    public static void Main(string[] args)
    {
        // Solicitar o número de notificações ao usuário
        Console.WriteLine("Digite o número de notificações:");
        int numNotificacoes = int.Parse(Console.ReadLine());
        List<Oferta> ofertas = new List<Oferta>();

        // Processando cada notificação fornecida pelo usuário
        for (int i = 0; i < numNotificacoes; i++)
        {
            Console.WriteLine($"Digite a notificação {i + 1} no formato posição,ação,valor,quantidade:");
            string[] notificacao = Console.ReadLine().Split(',');
            int posicao = int.Parse(notificacao[0]);
            int acao = int.Parse(notificacao[1]);
            double valor = double.Parse(notificacao[2]);
            int quantidade = int.Parse(notificacao[3]);

            switch (acao)
            {
                case 0: // Inserir
                    InserirOferta(ofertas, posicao, valor, quantidade);
                    break;
                case 1: // Modificar
                    ModificarOferta(ofertas, posicao, valor, quantidade);
                    break;
                case 2: // Deletar
                    DeletarOferta(ofertas, posicao);
                    break;
            }
        }

        // Ordenar ofertas pela posição
        var ofertasOrdenadas = ofertas.OrderBy(o => o.Posicao).ToList();

        // Imprimindo resultado
        foreach (var oferta in ofertasOrdenadas)
        {
            Console.WriteLine($"{oferta.Posicao},{oferta.Valor:F2},{oferta.Quantidade}");
        }
    }

    private static void InserirOferta(List<Oferta> ofertas, int posicao, double valor, int quantidade)
    {
        ofertas.Add(new Oferta { Posicao = posicao, Valor = valor, Quantidade = quantidade });
    }

    private static void ModificarOferta(List<Oferta> ofertas, int posicao, double valor, int quantidade)
    {
        var oferta = ofertas.FirstOrDefault(o => o.Posicao == posicao);
        if (oferta != null)
        {
            if (valor != 0) oferta.Valor = valor;
            if (quantidade != 0) oferta.Quantidade = quantidade;
        }
    }

    private static void DeletarOferta(List<Oferta> ofertas, int posicao)
    {
        var oferta = ofertas.FirstOrDefault(o => o.Posicao == posicao);
        if (oferta != null)
        {
            ofertas.Remove(oferta);
        }
    }
}
