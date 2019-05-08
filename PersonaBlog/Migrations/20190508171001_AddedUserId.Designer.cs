﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonaBlog.Models;

namespace PersonaBlog.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20190508171001_AddedUserId")]
    partial class AddedUserId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersonaBlog.Models.AcceptedRequests", b =>
                {
                    b.Property<string>("AcceptedId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Priority");

                    b.Property<string>("RequestID");

                    b.HasKey("AcceptedId");

                    b.HasIndex("RequestID");

                    b.ToTable("AcceptedRequests");
                });

            modelBuilder.Entity("PersonaBlog.Models.Registration", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.HasKey("UserId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("PersonaBlog.Models.RequestsModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AcceptRequest");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Subject")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("PersonaBlog.Models.AcceptedRequests", b =>
                {
                    b.HasOne("PersonaBlog.Models.RequestsModel", "Request")
                        .WithMany()
                        .HasForeignKey("RequestID");
                });
#pragma warning restore 612, 618
        }
    }
}
