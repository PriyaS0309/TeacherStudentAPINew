﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeacherStudentAPINew.DbContextDb;

namespace TeacherStudentAPINew.Migrations
{
    [DbContext(typeof(TeacherDbContext))]
    [Migration("20220912091729_addedTeacherStudent")]
    partial class addedTeacherStudent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TeacherStudentAPINew.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Teacher_ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Teacher_ID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TeacherStudentAPINew.Models.Teacher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("TeacherStudentAPINew.Models.Student", b =>
                {
                    b.HasOne("TeacherStudentAPINew.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("Teacher_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
