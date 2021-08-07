﻿// <auto-generated />
using System;
using CaseCore.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CaseCore.Persistence.Migrations
{
    [DbContext(typeof(CaseCoreDbContext))]
    partial class CaseCoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CaseCore.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Beat")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportingArea")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Suite")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("AddressTypeId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CaseCore.Domain.Entities.Case", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CaseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("CaseCore.Domain.Entities.CaseAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CaseId");

                    b.ToTable("CaseAddress");
                });

            modelBuilder.Entity("CaseCore.Domain.Entities.EmailAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("EmailAddress");
                });

            modelBuilder.Entity("CaseCore.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CaseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suffix")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("CaseId");

                    b.HasIndex("PersonTypeId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("CaseCore.Domain.Entities.PersonAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonAddress");
                });

            modelBuilder.Entity("CaseCore.Domain.Entities.PersonEmailAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmailAddressId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmailAddressId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonEmailAddress");
                });

            modelBuilder.Entity("CaseCore.Domain.Entities.PersonPhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("PhoneNumberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("PhoneNumberId");

                    b.ToTable("PersonPhoneNumber");
                });

            modelBuilder.Entity("CaseCore.Domain.Entities.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("PhoneNumberTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumberTypeId");

                    b.ToTable("PhoneNumber");
                });

            modelBuilder.Entity("CaseCore.Domain.Types.AddressType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("AddressTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abbreviation = "LOI",
                            Name = "Location of Incident"
                        },
                        new
                        {
                            Id = 2,
                            Abbreviation = "HOME",
                            Name = "Home Address"
                        },
                        new
                        {
                            Id = 3,
                            Abbreviation = "WORK",
                            Name = "Work Address"
                        },
                        new
                        {
                            Id = 4,
                            Abbreviation = "MAIL",
                            Name = "Mailing Address"
                        },
                        new
                        {
                            Id = 5,
                            Abbreviation = "LOA",
                            Name = "Location of Apprehension"
                        });
                });

            modelBuilder.Entity("CaseCore.Domain.Types.PersonType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("PersonTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abbreviation = "V",
                            Name = "Victim"
                        },
                        new
                        {
                            Id = 2,
                            Abbreviation = "W",
                            Name = "Witness"
                        },
                        new
                        {
                            Id = 3,
                            Abbreviation = "S",
                            Name = "Suspect"
                        },
                        new
                        {
                            Id = 4,
                            Abbreviation = "POC",
                            Name = "Point of Contact"
                        },
                        new
                        {
                            Id = 5,
                            Abbreviation = "NOK",
                            Name = "Next of Kin"
                        },
                        new
                        {
                            Id = 6,
                            Abbreviation = "A",
                            Name = "Arrestee"
                        },
                        new
                        {
                            Id = 7,
                            Abbreviation = "O",
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("CaseCore.Domain.Types.PhoneNumberType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("PhoneNumberTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abbreviation = "H",
                            Name = "Home"
                        },
                        new
                        {
                            Id = 2,
                            Abbreviation = "W",
                            Name = "Work"
                        },
                        new
                        {
                            Id = 3,
                            Abbreviation = "M",
                            Name = "Mobile"
                        },
                        new
                        {
                            Id = 4,
                            Abbreviation = "F",
                            Name = "Fax"
                        });
                });

            modelBuilder.Entity("CaseCore.Domain.Entities.Address", b =>
                {
                    b.HasOne("CaseCore.Domain.Types.AddressType", "AddressType")
                        .WithMany()
                        .HasForeignKey("AddressTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CaseCore.Domain.Entities.CaseAddress", b =>
                {
                    b.HasOne("CaseCore.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaseCore.Domain.Entities.Case", "Case")
                        .WithMany("Addresses")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CaseCore.Domain.Entities.Person", b =>
                {
                    b.HasOne("CaseCore.Domain.Entities.Case", null)
                        .WithMany("Persons")
                        .HasForeignKey("CaseId");

                    b.HasOne("CaseCore.Domain.Types.PersonType", "PersonType")
                        .WithMany()
                        .HasForeignKey("PersonTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CaseCore.Domain.Entities.PersonAddress", b =>
                {
                    b.HasOne("CaseCore.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaseCore.Domain.Entities.Person", "Person")
                        .WithMany("Addresses")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CaseCore.Domain.Entities.PersonEmailAddress", b =>
                {
                    b.HasOne("CaseCore.Domain.Entities.EmailAddress", "EmailAddress")
                        .WithMany()
                        .HasForeignKey("EmailAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaseCore.Domain.Entities.Person", "Person")
                        .WithMany("EmailAddresses")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CaseCore.Domain.Entities.PersonPhoneNumber", b =>
                {
                    b.HasOne("CaseCore.Domain.Entities.Person", "Person")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaseCore.Domain.Entities.PhoneNumber", "PhoneNumber")
                        .WithMany()
                        .HasForeignKey("PhoneNumberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CaseCore.Domain.Entities.PhoneNumber", b =>
                {
                    b.HasOne("CaseCore.Domain.Types.PhoneNumberType", "PhoneNumberType")
                        .WithMany()
                        .HasForeignKey("PhoneNumberTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}