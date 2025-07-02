using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaEmprestimoConsole.Models;

namespace SistemaEmprestimoConsole.Services
{
    public class BibliotecaService
    {
        private List<Livro> livros = new List<Livro>();
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Emprestimo> emprestimos = new List<Emprestimo>();

        private int livroIdCounter = 1;
        private int usaurioIdCounter = 1;
        private int emprestimoIdCounter = 1;

        public void MenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("\n ========== MENU BIBLIOTECA =========");

                Console.WriteLine("1. Gerenciar Livros");
                Console.WriteLine("2. Gerenciar Usuários");
                Console.WriteLine("3. Gerenciar Empréstimos");
                Console.WriteLine("0. Sair");
                Console.WriteLine("Escolha: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": MenuLivros(); break;
                    case "2": MenuUsuarios(); break;
                    case "3": MenuEmprestimo(); break;
                    case "0": return;
                    default: Console.WriteLine("Opção inválida."); break;
                }
            }
        }

        public void MenuLivros()
        {
            while (true)
            {
                Console.WriteLine("\n ========== Menu de Livros =========");

                Console.WriteLine("1. Adicionar Livro");
                Console.WriteLine("2. Listar livros");
                Console.WriteLine("3. Atualizar Livros");
                Console.WriteLine("4. Remover Livro");
                Console.WriteLine("0. Voltar");
                Console.Write("Escolha: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": AdicionarLivro(); break;
                    case "2": ListarLivros(); break;
                    case "3": AtualizarLivro(); break;
                    case "4": RemoverLivro(); break;
                    case "0": return;
                    default: Console.WriteLine("Opção inválida."); break;
                }
            }
        }

        public void MenuUsuarios()
        {
            while (true)
            {
                Console.WriteLine("\n ========== Menu de Usuários =========");

                Console.WriteLine("1. Adicionar Usuário");
                Console.WriteLine("2. Listar Usuários");
                Console.WriteLine("3. Atualizar Usuário");
                Console.WriteLine("4. Remover Usuário");
                Console.WriteLine("0. Voltar");
                Console.Write("Escolha: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": AdicionarUsuario(); break;
                    case "2": ListarUsuario(); break;
                    case "3": AtualizarUsuario(); break;
                    case "4": RemoverUsuario(); break;
                    case "0": return;
                    default: Console.WriteLine("Opção inválida."); break;
                } 
            }
        }

        public void MenuEmprestimo()
        {
            while (true)
            {
                Console.WriteLine("\n ========== Menu de Empréstimo =========");

                Console.WriteLine("1. Adicionar Empréstimo");
                Console.WriteLine("2. Listar Empréstimos Átivos");
                Console.WriteLine("3. Devolver livro");
                Console.WriteLine("4. Histórico de Empréstimos por Usuário");
                Console.WriteLine("0. Voltar");
                Console.Write("Escolha: ");
                string opcao = Console.ReadLine();

                  switch (opcao)
                 {
                     case "1": AdicionarEmprestimo(); break;
                     case "2": ListarEmprestimosAtivos(); break;
                     case "3": DevolverLivro(); break;
                     case "4": HistoricoEmprestimoUsuario(); break;
                     case "0": return;
                     default: Console.WriteLine("Opção inválida."); break; 
            } 
            }
        }

        //Métodos Livros
        private void AdicionarLivro()
        {
            Console.Write("Titulo: ");
            string titulo = Console.ReadLine();


            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            livros.Add(new Livro
            {
                Id = livroIdCounter++,
                Titulo = titulo,
                Autor = autor
            });

            Console.WriteLine("Livro adicionado com sucesso!");


        }

        private void ListarLivros()
        {
            Console.WriteLine("\nLista de livros: ");

            foreach (Livro livro in livros)
            {
                string status = livro.Disponivel ? "Disponivel" : "Emprestado";

                Console.WriteLine($"ID: {livro.Id} | Titulo: {livro.Titulo} | Autor: {livro.Autor} |  {status} ");
            }


        }

        private void AtualizarLivro()
        {
            Console.WriteLine("Id do livro a atualizar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Livro livro = livros.FirstOrDefault(l => l.Id == id);

            if (livro != null)
            {
                Console.Write("Novo Título: ");
                livro.Titulo = Console.ReadLine();

                Console.Write("Novo Autor: ");
                livro.Autor = Console.ReadLine();

                Console.WriteLine("Livro Atualizado!");

            }
            else
            {
                Console.Write("Livro não localizado!");
            }
        }

        private void RemoverLivro()
        {
            Console.WriteLine("Id do livro a remover: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Livro livro = livros.FirstOrDefault(l => l.Id == id);

            if (livro != null)
            {
                livros.RemoveAll(l => l.Id == id);
                Console.Write("Livro Removido!");
            }
            else
            {
                Console.Write("Livro não localizado!");
            }
        }

        //Métodos Usuário

        private void AdicionarUsuario()
        {
            Console.Write("Nome Usuário: ");
            var nome = Console.ReadLine();

            Console.Write("E-mail Usuário: ");
            var email = Console.ReadLine();


            usuarios.Add(new Usuario
            {
                Id = usaurioIdCounter++,
                Nome = nome,
                Email = email
            });

            Console.WriteLine("Usuário adicionado com sucesso!");
        }

        private void ListarUsuario()
        {
            Console.WriteLine("\nLista de Usuários: ");
           
            foreach(var usuario in usuarios)
            {
                Console.WriteLine($"Id: {usuario.Id} | Nome: {usuario.Nome} | Email: {usuario.Email}");
            }


            
        }

        private void AtualizarUsuario()
        {
            Console.Write("Id do Usuário: ");
            int id = Convert.ToInt32(Console.ReadLine());


            Usuario usuario = usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario != null)
            {
                 Console.Write("Novo Nome: ");
                 usuario.Nome = Console.ReadLine();

                 Console.Write("Novo E-mail: ");
                 usuario.Email = Console.ReadLine();
          
                Console.WriteLine("Usuário atualizava com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado");
            }
        }

        private void RemoverUsuario()
        {
            Console.Write("Id do Usuário: ");
            int id = Convert.ToInt32(Console.ReadLine());

            usuarios.RemoveAll(u => u.Id == id);

            Console.Write("Usuário removido com sucesso!");

        }

        // Métodos Empréstimo

        private void AdicionarEmprestimo()
        {
            Console.Write("Id do Livro: ");
            int livroId = Convert.ToInt32(Console.ReadLine());

            Livro livro = livros.FirstOrDefault(l => l.Id == livroId && l.Disponivel);

            if (livro == null)
            {
                Console.WriteLine("Livro não disponivel ou não encontrado");
                return;
            }

            Console.Write("Id do Usuário: ");
            int usuarioId = Convert.ToInt32(Console.ReadLine());

            if (!usuarios.Any(u => u.Id == usuarioId))
            {
                Console.WriteLine("Usuário não encontrado");
                return;
            }

            emprestimos.Add(new Emprestimo
            { 
                Id = emprestimoIdCounter++,
                LivroId = livroId,
                UsuarioId = usuarioId,  
                  
                
            });

            livro.Disponivel = false;

            Console.WriteLine("Empréstimo Registrado!");
        }

        private void ListarEmprestimosAtivos()
        {
            List<Emprestimo> ativos = emprestimos.Where(e => e.DataDevolucao == null).ToList();

            foreach (Emprestimo emprestimo  in ativos)
            {
                Usuario usuario = usuarios.FirstOrDefault(u => u.Id == emprestimo.UsuarioId);
                Livro livro = livros.FirstOrDefault(u => u.Id == emprestimo.LivroId);

                Console.WriteLine($"Id Empréstimo: {emprestimo.Id} | Livro: {livro.Titulo} | Usuário : {usuario.Nome} | Data Empréstimo: {emprestimo.DataEmprestimo.ToShortTimeString()}");
            }
        }

        private void DevolverLivro()
        {
            Console.Write("Id do  Emprestivo");
            int id = Convert.ToInt32(Console.ReadLine());

            Emprestimo emprestimo = emprestimos.FirstOrDefault(e => e.Id == id && e.DataDevolucao  == null);

            if (emprestimo ==  null)
            {
                Console.WriteLine("Emprestimo não encontrado ou já devolvido");
            }
             
            emprestimo.DataDevolucao = DateTime.Now;

            Livro livro = livros.FirstOrDefault(l => l.Id == emprestimo.LivroId);
            livro.Disponivel = true;

            Console.WriteLine("Livro devolvido com sucesso!");


            }

        private void HistoricoEmprestimoUsuario()
        {
            Console.WriteLine("Id do Usuário");
            int usuarioId = Convert.ToInt32((Console.ReadLine()));

            List<Emprestimo> historico = emprestimos.Where(e => e.UsuarioId == usuarioId).ToList();

            foreach (Emprestimo emprestimo in historico)
            {
                Livro livro = livros.FirstOrDefault(l => l.Id == emprestimo.LivroId);

                string devolucao = emprestimo.DataDevolucao.HasValue ? emprestimo.DataDevolucao?.ToShortDateString() : "Em aberto!";
                Console.WriteLine($"livro:  {livro.Titulo} | Empréstimo: {emprestimo.DataEmprestimo.ToShortDateString()} | Devolução: {devolucao}");
            } 
        }

        }
    }
