using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using System.Text;

namespace StringConcatenationBenchmark.Tests;

[Config(typeof(Config))]
[MemoryDiagnoser]
[HideColumns(Column.RatioSD)]
public class StringConcatenation
{
    private string Description = "Minha Casa:";
    private string Street = "Rua das Oliveiras";
    private string Number = "323";
    private string Complement = "Apartamento 502";
    private string District = "Cidade Nova";
    private string ZipCode = "93900-000";
    private string City = "Novo Hamburgo";
    private string State = "RS";

    [Benchmark]
    public string StringPlus()
    {
        return Description +
               ' ' +
               Street +
               ' ' +
               Number +
               ' ' +
               Complement +
               ' ' +
               District +
               ' ' +
               ZipCode +
               ' ' +
               City +
               ' ' +
               State;
    }

    [Benchmark]
    public string StringBuilder()
    {
        var sb = new StringBuilder();

        sb.Append(Description)
          .Append(' ')
          .Append(Street)
          .Append(' ')
          .Append(Number)
          .Append(' ')
          .Append(Complement)
          .Append(' ')
          .Append(District)
          .Append(' ')
          .Append(ZipCode)
          .Append(' ')
          .Append(City)
          .Append(' ')
          .Append(State);

        return sb.ToString();
    }

    [Benchmark]
    public string StringBuilderAppendJoin()
    {
        var sb = new StringBuilder();

        sb.AppendJoin(' ',
            Description,
            Street,
            Number,
            Complement,
            District,
            ZipCode,
            City,
            State);

        return sb.ToString();
    }

    [Benchmark]
    public string StringBuilderAppendFormat()
    {
        var sb = new StringBuilder();

        sb.AppendFormat("{0} {1} {2} {3} {4} {5} {6} {7}",
            Description,
            Street,
            Number,
            Complement,
            District,
            ZipCode,
            City,
            State);

        return sb.ToString();
    }

    [Benchmark]
    public string StringBuilderExact()
    {
        var sb = new StringBuilder(102);

        sb.Append(Description)
          .Append(' ')
          .Append(Street)
          .Append(' ')
          .Append(Number)
          .Append(' ')
          .Append(Complement)
          .Append(' ')
          .Append(District)
          .Append(' ')
          .Append(ZipCode)
          .Append(' ')
          .Append(City)
          .Append(' ')
          .Append(State);

        return sb.ToString();
    }

    [Benchmark]
    public string StringBuilderEstimate()
    {
        var sb = new StringBuilder(200);

        sb.Append(Description)
          .Append(' ')
          .Append(Street)
          .Append(' ')
          .Append(Number)
          .Append(' ')
          .Append(Complement)
          .Append(' ')
          .Append(District)
          .Append(' ')
          .Append(ZipCode)
          .Append(' ')
          .Append(City)
          .Append(' ')
          .Append(State);

        return sb.ToString();
    }

    [Benchmark]
    public string StringFormat()
    {
        return string.Format("{0} {1} {2} {3} {4} {5} {6} {7}",
            Description,
            Street,
            Number,
            Complement,
            District,
            ZipCode,
            City,
            State);
    }

    [Benchmark]
    public string StringInterpolation()
    {
        return $"{Description} {Street} {Number} {Complement} {District} {ZipCode} {City} {State}";
    }

    [Benchmark]
    public string StringJoin()
    {
        return string.Join(' ',
            Description,
            Street,
            Number,
            Complement,
            District,
            ZipCode,
            City,
            State);
    }

    [Benchmark]
    public string StringJoinArray()
    {
        return string.Join(' ', new string[] {
            Description,
            Street,
            Number,
            Complement,
            District,
            ZipCode,
            City,
            State
        });
    }

    [Benchmark]
    public string StringConcat()
    {
        return string.Concat(
            Description, ' ',
            Street, ' ',
            Number, ' ',
            Complement, ' ',
            District, ' ',
            ZipCode, ' ',
            City, ' ',
            State);
    }

    [Benchmark]
    public string StringConcatArray()
    {
        return string.Concat(new string[] {
            Description, " ",
            Street, " ",
            Number, " ",
            Complement, " ",
            District, " ",
            ZipCode, " ",
            City, " ",
            State
        });
    }

    private class Config : ManualConfig
    {
        public Config()
        {
            SummaryStyle = SummaryStyle.Default.WithRatioStyle(RatioStyle.Percentage);
        }
    }
}

