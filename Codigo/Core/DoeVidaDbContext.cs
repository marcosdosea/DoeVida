using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core
{
    public partial class DoeVidaDbContext : DbContext
    {
        public DoeVidaDbContext()
        {
        }

        public DoeVidaDbContext(DbContextOptions<DoeVidaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agendamento> Agendamento { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Organizacao> Organizacao { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Solicitacao> Solicitacao { get; set; }
        public virtual DbSet<Solicitacaoitem> Solicitacaoitem { get; set; }
        public virtual DbSet<Vagashorarios> Vagashorarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agendamento>(entity =>
            {
                entity.HasKey(e => e.IdAgendamento)
                    .HasName("PRIMARY");

                entity.ToTable("agendamento");

                entity.HasIndex(e => e.IdOrganizacao)
                    .HasName("fk_Agendamento_Organizacao1_idx");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_Agendamento_Pessoa_idx");

                entity.Property(e => e.IdAgendamento).HasColumnName("idAgendamento");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.HorarioAgendamento).HasColumnName("horarioAgendamento");

                entity.Property(e => e.IdOrganizacao).HasColumnName("idOrganizacao");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('AGENDADO','CANCELADO','ATENDIDO')")
                    .HasDefaultValueSql("'AGENDADO'");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasColumnType("enum('REMOTO','PRESENCIAL')");

                entity.HasOne(d => d.IdOrganizacaoNavigation)
                    .WithMany(p => p.Agendamento)
                    .HasForeignKey(d => d.IdOrganizacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Agendamento_Organizacao1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Agendamento)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Agendamento_Pessoa");
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasKey(e => e.IdComentario)
                    .HasName("PRIMARY");

                entity.ToTable("comentario");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_Comentario_Pessoa1_idx");

                entity.HasIndex(e => e.IdSolicitacao)
                    .HasName("fk_Comentario_Solicitacao1_idx");

                entity.Property(e => e.IdComentario).HasColumnName("idComentario");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.IdSolicitacao).HasColumnName("idSolicitacao");

                entity.Property(e => e.Texto)
                    .HasColumnName("texto")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Comentario_Pessoa1");

                entity.HasOne(d => d.IdSolicitacaoNavigation)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.IdSolicitacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Comentario_Solicitacao1");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.IdItem)
                    .HasName("PRIMARY");

                entity.ToTable("item");

                entity.HasIndex(e => e.IdOrganizacao)
                    .HasName("fk_Item_Organizacao1_idx");

                entity.Property(e => e.IdItem).HasColumnName("idItem");

                entity.Property(e => e.IdOrganizacao).HasColumnName("idOrganizacao");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("enum('DISPONIVEL','INDISPONIVEL')");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdOrganizacaoNavigation)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.IdOrganizacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Item_Organizacao1");
            });

            modelBuilder.Entity<Organizacao>(entity =>
            {
                entity.HasKey(e => e.IdOrganizacao)
                    .HasName("PRIMARY");

                entity.ToTable("organizacao");

                entity.Property(e => e.IdOrganizacao).HasColumnName("idOrganizacao");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cnpj)
                    .HasColumnName("cnpj")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasColumnName("complemento")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                    .IsRequired()
                    .HasColumnName("latitude")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasColumnName("logradouro")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasColumnName("longitude")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NomeOrganizacao)
                    .IsRequired()
                    .HasColumnName("nomeOrganizacao")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroEndereco)
                    .IsRequired()
                    .HasColumnName("numeroEndereco")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasColumnName("uf")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PRIMARY");

                entity.ToTable("pessoa");

                entity.HasIndex(e => e.Cpf)
                    .HasName("cpf_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("email_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasColumnName("complemento")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("dataNascimento")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasColumnName("logradouro")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroEndereco)
                    .IsRequired()
                    .HasColumnName("numeroEndereco")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('ATIVO','INATIVO')")
                    .HasDefaultValueSql("'ATIVO'");

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasColumnType("enum('SERVIDOR','DOADOR','MOTORISTA')");

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasColumnName("uf")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Solicitacao>(entity =>
            {
                entity.HasKey(e => e.IdSolicitacao)
                    .HasName("PRIMARY");

                entity.ToTable("solicitacao");

                entity.HasIndex(e => e.IdOrganizacao)
                    .HasName("fk_Solicitacao_Organizacao1_idx");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_Solicitacao_Pessoa1_idx");

                entity.Property(e => e.IdSolicitacao).HasColumnName("idSolicitacao");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.IdOrganizacao).HasColumnName("idOrganizacao");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('PROBLEMA NA ENTREGA','SOLICITADO','RECUSADO','APROVADO')");

                entity.HasOne(d => d.IdOrganizacaoNavigation)
                    .WithMany(p => p.Solicitacao)
                    .HasForeignKey(d => d.IdOrganizacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Solicitacao_Organizacao1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Solicitacao)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Solicitacao_Pessoa1");
            });

            modelBuilder.Entity<Solicitacaoitem>(entity =>
            {
                entity.HasKey(e => new { e.IdItem, e.IdSolicitacao })
                    .HasName("PRIMARY");

                entity.ToTable("solicitacaoitem");

                entity.HasIndex(e => e.IdItem)
                    .HasName("fk_SolicitacaoItem_Item1_idx");

                entity.HasIndex(e => e.IdSolicitacao)
                    .HasName("fk_SolicitacaoItem_Solicitacao1_idx");

                entity.Property(e => e.IdItem).HasColumnName("idItem");

                entity.Property(e => e.IdSolicitacao).HasColumnName("idSolicitacao");

                entity.Property(e => e.IdSolicitacaoItem).HasColumnName("idSolicitacaoItem");

                entity.HasOne(d => d.IdItemNavigation)
                    .WithMany(p => p.Solicitacaoitem)
                    .HasForeignKey(d => d.IdItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SolicitacaoItem_Item1");

                entity.HasOne(d => d.IdSolicitacaoNavigation)
                    .WithMany(p => p.Solicitacaoitem)
                    .HasForeignKey(d => d.IdSolicitacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SolicitacaoItem_Solicitacao1");
            });

            modelBuilder.Entity<Vagashorarios>(entity =>
            {
                entity.HasKey(e => e.IdVagasHorarios)
                    .HasName("PRIMARY");

                entity.ToTable("vagashorarios");

                entity.HasIndex(e => e.IdOrganizacao)
                    .HasName("fk_VagasHorarios_Organizacao1_idx");

                entity.Property(e => e.IdVagasHorarios).HasColumnName("idVagasHorarios");

                entity.Property(e => e.DiaSemana)
                    .HasColumnName("diaSemana")
                    .HasColumnType("enum('SEGUNDA-FEIRA','TERÇA-FEIRA','QUARTA-FEIRA','QUINTA-FEIRA','SEXTA-FEIRA','SABADO','DOMINGO')");

                entity.Property(e => e.HoraFinal).HasColumnName("horaFinal");

                entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");

                entity.Property(e => e.IdOrganizacao).HasColumnName("idOrganizacao");

                entity.Property(e => e.NumeroVagas).HasColumnName("numeroVagas");

                entity.HasOne(d => d.IdOrganizacaoNavigation)
                    .WithMany(p => p.Vagashorarios)
                    .HasForeignKey(d => d.IdOrganizacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_VagasHorarios_Organizacao1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
