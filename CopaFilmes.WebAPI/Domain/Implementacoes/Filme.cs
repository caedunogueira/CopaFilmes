﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace CopaFilmes.WebAPI.Domain.Implementacoes
{
    public class Filme : IComparable<Filme>
    {
        private readonly int _ano;
        private readonly decimal _nota;

        public string Id { get; private set; }

        public string Titulo { get; private set; }

        public Filme(string id, string titulo, int ano, decimal nota)
        {
            _ano = ano;
            _nota = nota;

            Id = id;
            Titulo = titulo;
        }

        public int CompareTo([AllowNull] Filme other) => Titulo.CompareTo(other.Titulo);

        public bool PossuiNotaMaior(Filme outroFilme) => _nota > outroFilme._nota;

        public bool PossuiNotaIgual(Filme outroFilme) => _nota == outroFilme._nota;
    }
}
