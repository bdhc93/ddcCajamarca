﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Mapping
{
    public class EventoEnsayoMap : EntityTypeConfiguration<EventoEnsayo>
    {
        public EventoEnsayoMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.IdAmbiente)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(p => p.NombreActividad).IsRequired();
            this.Property(p => p.InstitucionEncargada).IsOptional();
            this.Property(p => p.InformacionAdicional).IsOptional();
            this.Property(p => p.TodoDia).IsOptional();
            this.Property(p => p.Lunes).IsOptional();
            this.Property(p => p.Martes).IsOptional();
            this.Property(p => p.Miercoles).IsOptional();
            this.Property(p => p.Jueves).IsOptional();
            this.Property(p => p.Viernes).IsOptional();
            this.Property(p => p.Sabado).IsOptional();
            this.Property(p => p.Domingo).IsOptional();
            //this.Property(p => p.Estado).IsOptional();

            this.Property(p => p.Evento).IsOptional();
            this.Property(p => p.FechaInicio).IsRequired().HasColumnType("datetime2");
            this.Property(p => p.FechaFin).IsRequired().HasColumnType("datetime2");
            this.Property(p => p.FechaRegistro).IsRequired().HasColumnType("datetime2");

            this.ToTable("EventoEnsayo");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.IdAmbiente).HasColumnName("IdAmbiente");
            this.Property(c => c.NombreActividad).HasColumnName("NombreActividad");
            this.Property(c => c.InstitucionEncargada).HasColumnName("InstitucionEncargada");
            this.Property(c => c.TodoDia).HasColumnName("TodoDia");
            this.Property(c => c.FechaFin).HasColumnName("FechaFin");
            this.Property(c => c.FechaRegistro).HasColumnName("FechaRegistro");
            this.Property(c => c.FechaInicio).HasColumnName("FechaInicio");
            this.Property(c => c.Evento).HasColumnName("Evento");
            this.Property(c => c.Lunes).HasColumnName("Lunes");
            this.Property(c => c.Martes).HasColumnName("Martes");
            this.Property(c => c.Miercoles).HasColumnName("Miercoles");
            this.Property(c => c.Jueves).HasColumnName("Jueves");
            this.Property(c => c.Viernes).HasColumnName("Viernes");
            this.Property(c => c.Sabado).HasColumnName("Sabado");
            this.Property(c => c.Domingo).HasColumnName("Domingo");
            //this.Property(c => c.Estado).HasColumnName("Estado");

            this.HasRequired(h => h.Ambiente)
                .WithMany(h => h.EventoEnsayos)
                .HasForeignKey(p => p.IdAmbiente)
                .WillCascadeOnDelete(false);

        }
    }
}
