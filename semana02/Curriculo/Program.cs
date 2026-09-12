public class Program
{
    public static void Main(string[] args)
    {
        Emprego emprego1 = new Emprego();
        emprego1._empresa = "Lenovo";
        emprego1._cargo = "Engenheiro de Software";
        emprego1._anoInicio = 2010;
        emprego1._anoFim = 2024;

        Emprego emprego2 = new Emprego();
        emprego2._empresa = "IBM";
        emprego2._cargo = "CEO";
        emprego2._anoInicio = 2024;
        emprego2._anoFim = 2026;

        Curriculo meuCurriculo = new Curriculo();
        meuCurriculo._nome = "Tiago dos Anjos";

        meuCurriculo._empregos.Add(emprego1);
        meuCurriculo._empregos.Add(emprego2);

        meuCurriculo.Exibir();
    }
}