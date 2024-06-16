using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaApi.Models;
using BibliotecaApi.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BibliotecaApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options)
        {
            
        }

        public DbSet<Livro> TB_LIVRO { get; set; }
        public DbSet<Usuario> TB_USUARIOS { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Livro>().ToTable("TB_LIVRO");
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");

             modelBuilder.Entity<Livro>().HasData
            (
                new Livro() { Id = 1, NomedoLivro = "Bíblia", Autor = "Deus", Genero= "Livro Sagrado", Disponibilidade= true, DataLivro = "Desconhecido" , preco = 50 },
                new Livro() { Id = 2, NomedoLivro = "1984", Autor = "George Orwell", Genero = "Ficção política", Disponibilidade= true, DataLivro = "1949", preco = 30},
                new Livro() { Id = 3, NomedoLivro = "O Menino, a Toupeira, a Raposa e o Cavalo", Autor = "Charlie Mackesy", Genero= "Animação", Disponibilidade= true, DataLivro = "2020" , preco = 60},
                new Livro() { Id = 4, NomedoLivro = "O Poder do Hábito", Autor = "Charles Duhigg", Genero = "Livro de autoajuda", Disponibilidade= true, DataLivro = "2012" , preco = 55},
                new Livro() { Id = 5, NomedoLivro = "A tríade do tempo", Autor = "Christian Barbosa", Genero= "Livro de autoajuda", Disponibilidade= true, DataLivro = "2008" , preco =40}
            );


            Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[] salt);
            user.Id = 1;
            user.Username = "UsuarioAmin";
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            user.Perfil = "Admin";
            user.Email = "seuEmail@gmail.com";
            user.Latitude = -23.5200241;
            user.longitude = -46.596498;

            modelBuilder.Entity<Usuario>().HasData(user);
            // Fim da Crição do usuário padrão.

            //Define que se o Perfil não for informado, o valor padrão será jogardor
            modelBuilder.Entity<Usuario>().Property(u => u.Perfil).HasDefaultValue("Jogador");
        }
        
    }
}