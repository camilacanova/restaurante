﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PedidoAPI.Data;

namespace PedidoAPI.Migrations
{
    [DbContext(typeof(PedidoContext))]
    [Migration("20210413010509_statusmesa")]
    partial class statusmesa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("PedidoAPI.Model.ItemPedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<int>("CardapioId")
                        .HasColumnType("integer");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uuid");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<int>("StatusItemId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("StatusItemId");

                    b.ToTable("ItemPedido");
                });

            modelBuilder.Entity("PedidoAPI.Model.Mesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<int>("NumeroMesa")
                        .HasColumnType("integer");

                    b.Property<bool>("Ocupada")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Mesa");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            NumeroMesa = 1,
                            Ocupada = false
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            NumeroMesa = 2,
                            Ocupada = false
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            NumeroMesa = 3,
                            Ocupada = false
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            NumeroMesa = 4,
                            Ocupada = false
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            NumeroMesa = 5,
                            Ocupada = false
                        },
                        new
                        {
                            Id = 6,
                            Ativo = true,
                            NumeroMesa = 6,
                            Ocupada = false
                        },
                        new
                        {
                            Id = 7,
                            Ativo = true,
                            NumeroMesa = 7,
                            Ocupada = false
                        });
                });

            modelBuilder.Entity("PedidoAPI.Model.Pagamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<int>("Parcelas")
                        .HasColumnType("integer");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uuid");

                    b.Property<int>("TipoPagamentoId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId")
                        .IsUnique();

                    b.HasIndex("TipoPagamentoId");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("PedidoAPI.Model.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<int>("MesaId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusPedidoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MesaId");

                    b.HasIndex("StatusPedidoId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("PedidoAPI.Model.StatusItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("StatusItem");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Descricao = "Solicitado"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            Descricao = "Em Preparação"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            Descricao = "Pronto"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            Descricao = "Entregue"
                        });
                });

            modelBuilder.Entity("PedidoAPI.Model.StatusPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("StatusPedido");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Descricao = "Aberto"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            Descricao = "Encerrado"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            Descricao = "Pago"
                        });
                });

            modelBuilder.Entity("PedidoAPI.Model.TipoPagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TipoPagamento");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Descricao = "Cartão"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            Descricao = "Dinheiro"
                        });
                });

            modelBuilder.Entity("PedidoAPI.Model.ItemPedido", b =>
                {
                    b.HasOne("PedidoAPI.Model.Pedido", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PedidoAPI.Model.StatusItem", "StatusItem")
                        .WithMany()
                        .HasForeignKey("StatusItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("StatusItem");
                });

            modelBuilder.Entity("PedidoAPI.Model.Pagamento", b =>
                {
                    b.HasOne("PedidoAPI.Model.Pedido", "Pedido")
                        .WithOne("Pagamento")
                        .HasForeignKey("PedidoAPI.Model.Pagamento", "PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PedidoAPI.Model.TipoPagamento", "TipoPagamento")
                        .WithMany()
                        .HasForeignKey("TipoPagamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("TipoPagamento");
                });

            modelBuilder.Entity("PedidoAPI.Model.Pedido", b =>
                {
                    b.HasOne("PedidoAPI.Model.Mesa", "Mesa")
                        .WithMany()
                        .HasForeignKey("MesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PedidoAPI.Model.StatusPedido", "StatusPedido")
                        .WithMany()
                        .HasForeignKey("StatusPedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mesa");

                    b.Navigation("StatusPedido");
                });

            modelBuilder.Entity("PedidoAPI.Model.Pedido", b =>
                {
                    b.Navigation("Itens");

                    b.Navigation("Pagamento");
                });
#pragma warning restore 612, 618
        }
    }
}
