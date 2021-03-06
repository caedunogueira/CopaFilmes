﻿using CopaFilmes.Tests.Domain.Implementacoes.TestBuilders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CopaFilmes.Tests.Domain.Implementacoes
{
    [TestClass]
    public class FilmeTests
    {
        [TestMethod]
        [DynamicData(nameof(NotasDistintasEntreDoisFilmes), DynamicDataSourceType.Property)]
        public void FilmeTests_Dado_Que_Filme_Possui_Nota_Maior_Em_Relacao_Ao_Filme_Comparado_Quando_Consultar_Se_Possui_Nota_Maior_Retorna_Verdadeiro(decimal notaFilmeA, decimal notaFilmeB)
        {
            var filmeA = new FilmeTestBuilder().ComNota(notaFilmeA).Build();
            var filmeB = new FilmeTestBuilder().ComNota(notaFilmeB).Build();

            Assert.IsTrue(filmeA.PossuiNotaMaior(filmeB), $"Filme A possui nota {notaFilmeA} e maior que Filme B que possui nota {notaFilmeB}.");
        }

        [TestMethod]
        [DynamicData(nameof(NotasDistintasEntreDoisFilmes), DynamicDataSourceType.Property)]
        public void FilmeTests_Dado_Que_Filme_Possui_Nota_Menor_Em_Relacao_Ao_Filme_Comparado_Quando_Consultar_Se_Possui_Nota_Maior_Retorna_Falso(decimal notaFilmeA, decimal notaFilmeB)
        {
            var filmeA = new FilmeTestBuilder().ComNota(notaFilmeA).Build();
            var filmeB = new FilmeTestBuilder().ComNota(notaFilmeB).Build();

            Assert.IsFalse(filmeB.PossuiNotaMaior(filmeA), $"Filme A possui nota {notaFilmeA} e menor que Filme B possui nota {notaFilmeB}.");
        }

        [TestMethod]
        public void FilmeTests_Dado_Que_Filme_Possui_Nota_Igual_Em_Relacao_Ao_Filme_Comparado_Quando_Consultar_Se_Possui_Nota_Maior_Retorna_Falso()
        {
            var filmeA = new FilmeTestBuilder().ComNota(8.5m).Build();
            var filmeB = new FilmeTestBuilder().ComNota(8.5m).Build();

            Assert.IsFalse(filmeA.PossuiNotaMaior(filmeB));
        }


        [TestMethod]
        public void FilmeTests_Dado_Que_Filme_Possui_Nota_Igual_Em_Relacao_Ao_Filme_Comparado_Quando_Consultar_Se_Possui_Nota_Igual_Retorna_True()
        {
            var filmeA = new FilmeTestBuilder().ComNota(8.5m).Build();
            var filmeB = new FilmeTestBuilder().ComNota(8.5m).Build();

            Assert.IsTrue(filmeA.PossuiNotaIgual(filmeB));
        }

        [TestMethod]
        [DynamicData(nameof(NotasDistintasEntreDoisFilmes), DynamicDataSourceType.Property)]
        public void FilmeTests_Dado_Que_Filme_Possui_Nota_Diferente_Em_Relacao_Ao_Filme_Comparado_Quando_Consultar_Se_Possui_Nota_Igual_Retorna_Falso(decimal notaFilmeA, decimal notaFilmeB)
        {
            var filmeA = new FilmeTestBuilder().ComNota(notaFilmeA).Build();
            var filmeB = new FilmeTestBuilder().ComNota(notaFilmeB).Build();

            Assert.IsFalse(filmeA.PossuiNotaIgual(filmeB), $"Filme A possui nota {notaFilmeA} e Filme B possui nota {notaFilmeB}.");
        }

        /// <summary>
        /// Propriedade utilizada de entrada para cenários de testes.
        /// </summary>
        public static IEnumerable<object[]> NotasDistintasEntreDoisFilmes
        {
            get
            {
                yield return new object[] { 8.5m, 8.4m };
                yield return new object[] { 8.8m, 8.1m };
                yield return new object[] { 7.9m, 7.2m };
                yield return new object[] { 8.5m, 7.8m };
                yield return new object[] { 6.7m, 6.3m };
                yield return new object[] { 8.8m, 7.9m };
                yield return new object[] { 8.5m, 6.7m };
                yield return new object[] { 8.8m, 8.5m };
            }
        }

        [TestMethod]
        public void FilmeTests_Dado_Ordenacao_Ascendente_Que_Filme_Possui_Titulo_Igual_Em_Relacao_Ao_Filme_Comparado_Quando_Sao_Comparados_Retorna_Zero()
        {
            var filme = new FilmeTestBuilder().ComTitulo("Filme A").Build();
            var outroFilme = new FilmeTestBuilder().ComTitulo("Filme A").Build();

            var resultado = filme.CompareTo(outroFilme);

            Assert.AreEqual(expected: 0, actual: resultado);
        }

        [TestMethod]
        [DataRow("Filme A", "Filme B")]
        [DataRow("Jurassic World: Reino Ameaçado", "Os Incríveis 2")]
        [DataRow("Hereditário", "Oito Mulheres e um Segredo")]
        [DataRow("Deadpool 2", "Vingadores: Guerra Infinita")]
        [DataRow("Han Solo: Uma História Star Wars", "Thor: Ragnarok")]
        public void FilmeTests_Dado_Ordenacao_Ascendente_Que_Filme_Possui_Titulo_Que_Precede_Em_Relacao_Ao_Filme_Comparado_Quando_Sao_Comparados_Retorna_Menos_Um(string tituloFilmeA, string tituloFilmeB)
        {
            var filmeA = new FilmeTestBuilder().ComTitulo(tituloFilmeA).Build();
            var filmeB = new FilmeTestBuilder().ComTitulo(tituloFilmeB).Build();

            var resultado = filmeA.CompareTo(filmeB);

            Assert.AreEqual(expected: -1, resultado, $"Filme A com título {tituloFilmeA} precede Filme B com título {tituloFilmeB} como objeto comparado na ordenação.");
        }

        [TestMethod]
        [DataRow("Filme A", "Filme B")]
        [DataRow("Jurassic World: Reino Ameaçado", "Os Incríveis 2")]
        [DataRow("Hereditário", "Oito Mulheres e um Segredo")]
        [DataRow("Deadpool 2", "Vingadores: Guerra Infinita")]
        [DataRow("Han Solo: Uma História Star Wars", "Thor: Ragnarok")]
        public void FilmeTests_Dado_Ordenacao_Ascendente_Que_Filme_Possui_Titulo_Que_Sucede_Em_Relacao_Ao_Filme_Comparado_Quando_Sao_Comparados_Retorna_Um(string tituloFilmeA, string tituloFilmeB)
        {
            var filmeA = new FilmeTestBuilder().ComTitulo("Filme A").Build();
            var filmeB = new FilmeTestBuilder().ComTitulo("Filme B").Build();

            var resultado = filmeB.CompareTo(filmeA);

            Assert.AreEqual(expected: 1, resultado, $"Filme A com título {tituloFilmeA} sucede Filme B com título {tituloFilmeB} como objeto comparado na ordenação.");
        }

        [TestMethod]
        public void FilmeTests_Dado_Nulo_Argumento_Outro_Filme_Quando_Consulta_Se_Possui_Nota_Maior_Lanca_Excecao()
        {
            var filme = new FilmeTestBuilder().Build();

            _ = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                try
                {
                    _ = filme.PossuiNotaMaior(null);
                }
                catch (ArgumentNullException excecao)
                {
                    if (excecao.ParamName == "outroFilme")
                        throw;

                    Assert.Fail($"A exceção esperada {nameof(ArgumentNullException)} foi lançada mas com uma mensagem inesperada. A mensagem da exceção foi {excecao.Message}");
                }
                catch (Exception excecao)
                {
                    Assert.Fail($"A exceção esperada não foi lançada. O tipo da exceção esperada é {nameof(ArgumentNullException)} mas foi {excecao.GetType().FullName}.");
                }
            });
        }

        [TestMethod]
        public void FilmeTests_Dado_Nulo_Argumento_Outro_Filme_Quando_Consulta_Se_Possui_Nota_Igual_Lanca_Excecao()
        {
            var filme = new FilmeTestBuilder().Build();

            _ = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                try
                {
                    _ = filme.PossuiNotaIgual(null);
                }
                catch (ArgumentNullException excecao)
                {
                    if (excecao.ParamName == "outroFilme")
                        throw;

                    Assert.Fail($"A exceção esperada {nameof(ArgumentNullException)} foi lançada mas com uma mensagem inesperada. A mensagem da exceção foi {excecao.Message}");
                }
                catch (Exception excecao)
                {
                    Assert.Fail($"A exceção esperada não foi lançada. O tipo da exceção esperada é {nameof(ArgumentNullException)} mas foi {excecao.GetType().FullName}.");
                }
            });
        }
    }
}
