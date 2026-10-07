using System;

public class AtividadeRespiracao : Atividade
{
    public AtividadeRespiracao()
        : base(
            "Atividade de Respiração",
            "Esta atividade ajudará você a relaxar, inspirando e expirando lentamente. " +
            "Limpe sua mente e concentre-se na sua respiração."
        )
    {
    }

    public void Executar()
    {
        ExibirMensagemInicial();

        DateTime tempoFinal =
            DateTime.Now.AddSeconds(ObterDuracao());

        while (DateTime.Now < tempoFinal)
        {
            Console.Write("\nInspire... ");
            MostrarContagemRegressiva(4);

            Console.Write("\nExpire... ");
            MostrarContagemRegressiva(6);
        }

        ExibirMensagemFinal();
    }
}