using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    public class JogoDaMarcia
    {
        private bool fimDeJogo;
        private char[] posicoes;
        private char vez;
        private int quantidadePreenchida = 0;

        public JogoDaMarcia()
        {
            fimDeJogo = false;
            posicoes = new[] {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
            vez = 'X';
        }

        public void Start()
        {
            while (!fimDeJogo)
            {
                RenderizarTabela();
                LerEscolhaDoUsuario();
                RenderizarTabela();
                VerificarFimDeJogo();
                MudarVez();
            }
        }

        private void RenderizarTabela()
        {
            Console.Clear();
            Console.WriteLine(ObterTabela());
        }
        
        private void LerEscolhaDoUsuario()
        {

            Console.WriteLine($"Agora é a vez do {vez}. Insira uma posição de 1 ~ 9.");

            bool conversao = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);

            while (!conversao || !ValidarEscolha(posicaoEscolhida))
            {
                Console.WriteLine("Valor inserido é inválido ! Favor digite um número entre 1 ~ 9");
                conversao = int.TryParse(Console.ReadLine(), out posicaoEscolhida);

            }

            PreencherEscolha(posicaoEscolhida);
        }

        private void PreencherEscolha(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            posicoes[indice] = vez;

            quantidadePreenchida++;
        }

        private bool ValidarEscolha(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            return posicoes[indice] != 'O' && posicaoEscolhida != 'X';

        }

        private void VerificarFimDeJogo()
        {
            if (quantidadePreenchida < 5)
                return;

            if (ExisteVitoriaDiagonal() || ExisteVitoriaHorizontal() || ExisteVitoriaVertical())
            {
                fimDeJogo = true;
                Console.WriteLine($"Fim de jogo! Vitória de {vez}");
                return;
            }

            if (quantidadePreenchida is 9)
            {
                fimDeJogo = true;
                Console.WriteLine("Que pena ! Empatou. FIM DE JOGO!");
            }
        }

        private bool ExisteVitoriaHorizontal()
        {
            bool linha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool linha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool linha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];

            return linha1 || linha2 || linha3;
        }

        private bool ExisteVitoriaVertical()
        {
            bool linha1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool linha2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool linha3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];

            return linha1 || linha2 || linha3;
        }

        private bool ExisteVitoriaDiagonal()
        {
            bool linha1 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];
            bool linha2 = posicoes[6] == posicoes[4] && posicoes[6] == posicoes[2];

            return linha1 || linha2;
        }

        public void MudarVez()
        {
            vez = vez == 'X' ? 'O' : 'X';
        }

        private string ObterTabela()
        {
            return  $"__{posicoes[0]}__|__{posicoes[1]}__|__{posicoes[2]}__\n" +
                    $"__{posicoes[3]}__|__{posicoes[4]}__|__{posicoes[5]}__\n" +
                    $"__{posicoes[6]}__|__{posicoes[7]}__|__{posicoes[8]}__\n";

                                       
        }

    }
}
