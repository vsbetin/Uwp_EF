using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TermWorkDatabases.Models.DataAccess.Context;

namespace TermWorkDatabases.Migrations
{
    [DbContext(typeof(ProductAccountingDbContext))]
    partial class ProductAccountingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("TermWorkDatabases.Models.Enteties.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("MobileNumber")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("TermWorkDatabases.Models.Enteties.CompanyAccessData", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Company_access_data");
                });

            modelBuilder.Entity("TermWorkDatabases.Models.Enteties.CompanyProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyId");

                    b.Property<int>("Cost");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProductId");

                    b.ToTable("Companies_products");
                });

            modelBuilder.Entity("TermWorkDatabases.Models.Enteties.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("MobileNumber")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TermWorkDatabases.Models.Enteties.CustomerAccessData", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Customer_access_data");
                });

            modelBuilder.Entity("TermWorkDatabases.Models.Enteties.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanieProductId");

                    b.Property<int>("Count");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("FinishDate");

                    b.Property<bool>("IsFinished");

                    b.Property<bool>("IsStarted");

                    b.HasKey("Id");

                    b.HasIndex("CompanieProductId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TermWorkDatabases.Models.Enteties.OrderDetail", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("FinishWorkPlantDate");

                    b.Property<int>("PlantId");

                    b.Property<DateTime>("StartWorkPlantDate");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.ToTable("Order_details");
                });

            modelBuilder.Entity("TermWorkDatabases.Models.Enteties.Plant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyId");

                    b.Property<bool>("IsFree");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("TermWorkDatabases.Models.Enteties.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TermWorkDatabases.Models.Enteties.CompanyAccessData", b =>
                {
                    b.HasOne("TermWorkDatabases.Models.Enteties.Company", "Company")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TermWorkDatabases.Models.Enteties.CompanyProduct", b =>
                {
                    b.HasOne("TermWorkDatabases.Models.Enteties.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TermWorkDatabases.Models.Enteties.Product", "Product")
                        .WithMany("Companies")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TermWorkDatabases.Models.Enteties.CustomerAccessData", b =>
                {
                    b.HasOne("TermWorkDatabases.Models.Enteties.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TermWorkDatabases.Models.Enteties.Order", b =>
                {
                    b.HasOne("TermWorkDatabases.Models.Enteties.CompanyProduct", "CompanieProduct")
                        .WithMany("Orders")
                        .HasForeignKey("CompanieProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TermWorkDatabases.Models.Enteties.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TermWorkDatabases.Models.Enteties.OrderDetail", b =>
                {
                    b.HasOne("TermWorkDatabases.Models.Enteties.Order", "Order")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TermWorkDatabases.Models.Enteties.Plant", "Plant")
                        .WithMany("OrderDetails")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TermWorkDatabases.Models.Enteties.Plant", b =>
                {
                    b.HasOne("TermWorkDatabases.Models.Enteties.Company", "Company")
                        .WithMany("Plants")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
