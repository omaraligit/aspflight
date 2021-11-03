using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight_Tracking.Models;

    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<Flight_Tracking.FlightContext>();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

            //Cinema
            if (!context.Avions.Any())
                {
                    context.Avions.AddRange(new List<Avion>()
                    {
                        new Avion()
                        {
                            code = "BOWEING",
                            consomationKM = 120,
                            consomationDepart = 120,
                            libelle = "boeing",
                            nombrePlace = 120
                        },
                        new Avion()
                        {
                            code = "AIRBUS",
                            consomationKM = 120,
                            consomationDepart = 120,
                            libelle = "airbus",
                            nombrePlace = 120
                        },
                        new Avion()
                        {
                            code = "USJET",
                            consomationKM = 120,
                            consomationDepart = 120,
                            libelle = "usjet",
                            nombrePlace = 120
                        }
                    });
                    context.SaveChangesAsync();
                }
                //Actors
                if (!context.Aeroports.Any())
                {
                    context.Aeroports.AddRange(new List<Aeroport>()
                    {
                        new Aeroport()
                        {
                            code = "KECH",
                            latitude = 31.6017011,
                            longitude = -8.0266516,
                            libelle = "Marrakech menara"

                        },
                        new Aeroport()
                        {
                            code = "CASA",
                            latitude = 33.3707664,
                            longitude = -7.5659304,
                            libelle = "casa Mohamed V"

                        }
                    });
                    context.SaveChangesAsync();
                }
                if (!context.Vols.Any())
                {
                    context.Vols.AddRange(new List<Vol>()
                    {
                        new Vol()
                        {
                            AeroportId = 1,
                            AvionId = 1,
                            dateArrivee = new DateTime().AddDays(1),
                            dateDepart = new DateTime().AddDays(1).AddHours(2),
                            AeroportArriveeId = 2
                        },
                        new Vol()
                        {
                            AeroportId = 2,
                            AvionId = 2,
                            dateArrivee = new DateTime().AddDays(2),
                            dateDepart = new DateTime().AddDays(2).AddHours(3),
                            AeroportArriveeId = 1
                        }
                    });
                    context.SaveChangesAsync();
                }
            }

        }
    }

