using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Member_hy.Entitys
{
    public partial class MemberContext : DbContext
    {
        public MemberContext()
        {
        }

        public MemberContext(DbContextOptions<MemberContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cluber> Cluber { get; set; }
        public virtual DbSet<Clubercar> Clubercar { get; set; }
        public virtual DbSet<Consumption> Consumption { get; set; }
        public virtual DbSet<IniUser> IniUser { get; set; }
        public virtual DbSet<Price_ay> Price_ay { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cluber>(entity =>
            {
                entity.HasKey(e => e.ClubId);

                entity.ToTable("cluber");

                entity.Property(e => e.ClubId).HasColumnName("clubId");

                entity.Property(e => e.CBirthday)
                    .HasColumnName("cBirthday")
                    .HasColumnType("datetime");

                entity.Property(e => e.CMobile)
                    .HasColumnName("cMobile")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CRemarks)
                    .HasColumnName("cRemarks")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CSex)
                    .HasColumnName("cSex")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CSort).HasColumnName("cSort");

                entity.Property(e => e.CType)
                    .HasColumnName("cType")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Clubname)
                    .HasColumnName("clubname")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Clubercar>(entity =>
            {
                entity.HasKey(e => e.CCardId);

                entity.ToTable("clubercar");

                entity.Property(e => e.CCardId)
                    .HasColumnName("cCardId")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CExpiretime)
                    .HasColumnName("cExpiretime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CFrequency)
                    .HasColumnName("cFrequency")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CUdeadline)
                    .HasColumnName("cUdeadline")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cardseller).HasColumnName("cardseller");

                entity.Property(e => e.Cardtype)
                    .HasColumnName("cardtype")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cda).HasColumnName("cda");

                entity.Property(e => e.Collectiontype)
                    .HasColumnName("collectiontype")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sort).HasColumnName("sort");

                entity.Property(e => e.Consum).HasColumnName("consum");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Xda).HasColumnName("xda");
            });

            modelBuilder.Entity<Consumption>(entity =>
            {
                entity.HasKey(e => e.Consumptioncode);

                entity.ToTable("consumption");

                entity.Property(e => e.Consumptioncode).HasColumnName("consumptioncode");

                entity.Property(e => e.Consum).HasColumnName("consum");


                entity.Property(e => e.CCardId)
                    .HasColumnName("cCardId")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CDate)
                    .HasColumnName("cDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CItems)
                    .HasColumnName("cItems")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cda).HasColumnName("cda");

                entity.Property(e => e.Discount).HasColumnName("discount");
                entity.Property(e => e.je).HasColumnName("je");

                entity.Property(e => e.Frequency)
                    .HasColumnName("frequency")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ItemId)
                    .HasColumnName("itemId")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PAmount).HasColumnName("pAmount");
            });

            modelBuilder.Entity<IniUser>(entity =>
            {
                entity.HasKey(e => e.Usercode);

                entity.ToTable("ini_user");

                entity.Property(e => e.Usercode).HasColumnName("usercode");

                entity.Property(e => e.UDeptid).HasColumnName("uDeptid");

                entity.Property(e => e.URealnaem)
                    .HasColumnName("uRealnaem")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Usertype)
                    .HasColumnName("usertype")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Userword)
                    .HasColumnName("userword")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Usex)
                    .HasColumnName("usex")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });
            ////
            modelBuilder.Entity<Price_ay>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Projectname)
                  .HasColumnName("projectname")
                  .HasMaxLength(50)
                  .IsUnicode(false);

                entity.Property(e => e.Projectname_ay)
                 .HasColumnName("projectname_ay")
                 .HasMaxLength(20)
                 .IsUnicode(false);

                entity.Property(e => e.Pyear)
                    .HasColumnName("pyear")
                    .HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnName("price");
            });



        }
    }
}
