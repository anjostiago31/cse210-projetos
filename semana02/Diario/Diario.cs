using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Diario
{
    private List<Registro> _registros = new List<Registro>();

    public void AdicionarRegistro(Registro registro)
    {
        _registros.Add(registro);
    }

    public void Exibir()
    {
        if (_registros.Count == 0)
        {
            Console.WriteLine("O diário ainda não possui registros.");
            return;
        }

        foreach (Registro registro in _registros)
        {
            registro.Exibir();
        }
    }

    public void Salvar(string nomeArquivo)
    {
        JsonSerializerOptions opcoes = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(_registros, opcoes);
        File.WriteAllText(nomeArquivo, json);
    }

    public void Carregar(string nomeArquivo)
    {
        string json = File.ReadAllText(nomeArquivo);

        List<Registro> registrosCarregados =
            JsonSerializer.Deserialize<List<Registro>>(json)
            ?? throw new JsonException("O arquivo não contém uma lista de registros.");

        // Valida antes de substituir os registros atuais.
        foreach (Registro registro in registrosCarregados)
        {
            if (registro == null ||
                string.IsNullOrWhiteSpace(registro.Data) ||
                string.IsNullOrWhiteSpace(registro.Pergunta) ||
                string.IsNullOrWhiteSpace(registro.Resposta))
            {
                throw new JsonException("O arquivo contém um registro inválido.");
            }
        }

        _registros = registrosCarregados;
    }
}