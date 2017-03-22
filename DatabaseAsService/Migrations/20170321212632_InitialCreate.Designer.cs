using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DatabaseAsService.Data;

namespace DatabaseAsService.Migrations
{
    [DbContext(typeof(DatabaseAsServiceContext))]
    [Migration("20170321212632_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DatabaseAsService.Models.Keyword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Keywords");
                });

            modelBuilder.Entity("DatabaseAsService.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("DatabaseAsService.Models.SessionKeywordMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("KeywordId");

                    b.Property<int>("SessionId");

                    b.HasKey("Id");

                    b.HasIndex("KeywordId");

                    b.HasIndex("SessionId");

                    b.ToTable("SessionKeywordMappings");
                });

            modelBuilder.Entity("DatabaseAsService.Models.SessionKeywordMapping", b =>
                {
                    b.HasOne("DatabaseAsService.Models.Keyword")
                        .WithMany("SessionMappings")
                        .HasForeignKey("KeywordId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DatabaseAsService.Models.Session")
                        .WithMany("SessionMappings")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
