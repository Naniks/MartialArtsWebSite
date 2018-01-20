using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MMA_site_app.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

namespace MMA_site_app.Data {
    public class SeedData {
        public static void EnsurePopulated(IServiceProvider services) {
            FighterContext context =
                services.GetRequiredService<FighterContext>();
            //next 2 methods mutually exclusive to each other
            //context.Database.EnsureCreated(); unusable for migrations 
            //context.Database.Migrate();       //uses migrations 

            //I have also commented out the statement that automatically applies any pending migrations,(.Migrate())
            //which can cause data loss and should be used only with the greatest care in production systems.

            context.Database.Migrate();

            if (context.Fighters.Any()) {
                return;                       //DB has been seeded
            }

            var fighters = new Fighter[] {new Fighter{
                FirstName ="Conor",
                LastName ="McGregor",
                Nickname ="The Notorious",
                From ="Dublin Ireland",
                FightsOutOf ="Dublin Ireland",
                Age =29,
                Height="5' 9\"",
                Weight ="155 lb",
                HeightCm ="175 cm ",
                WeightKg ="70 kg",
                Reach ="74\"",
                LegReach ="40\"",
                Record ="21-3-0",
                Summary ="My Beliefff",
                ImageInList ="//media.ufc.tv/generated_images_sorted/Fighter/Conor-McGregor/Conor-McGregor_302601_small_thumbnail.jpg",
                ImageMainProfile ="http://media.ufc.tv/fighter_images/Conor_McGregor/205-McGREGOR_CONOR.png"
                },

                new Fighter{
                FirstName ="Demitrious",
                LastName ="Johnson",
                Nickname ="Mighty Mouse",
                From ="Madisonville, Kentuky United States",
                FightsOutOf ="Parkland, Washington United States",
                Age =   31,
                Height="5' 3\"",
                Weight ="125 lb",
                HeightCm ="160 cm ",
                WeightKg ="56 kg",
                Reach ="66\"",
                LegReach ="34\"",
                Record ="27-2-1",
                Summary ="Speed, conditioning & technique",
                ImageInList ="http://media.ufc.tv/generated_images_sorted/Fighter/Demetrious-Johnson/Demetrious-Johnson_1161_small_thumbnail.jpg",
                ImageMainProfile ="http://media.ufc.tv/fighter_images/Demitrious_Johnson/JOHNSON_DEMETRIOUS_BELT_LS.png"
                },

                new Fighter{
                FirstName ="TJ",
                LastName ="Dillashaw",
                Nickname ="",
                From ="Angels Camp, California USA",
                FightsOutOf ="Denver, Colorado USA",
                Age = 31  ,
                Height="5' 6\"",
                Weight ="135 lb",
                HeightCm ="167 cm",
                WeightKg ="61 kg",
                Reach ="67\"",
                LegReach ="38\"",
                Record ="16-3-0",
                Summary ="Wrestling, Ground and Pound",
                ImageInList ="http://media.ufc.tv/generated_images_sorted/Fighter/TJ-Dillashaw/TJ-Dillashaw_231394_small_thumbnail.jpg",
                ImageMainProfile ="http://media.ufc.tv/fighter_images/TJ_Dillashaw/DILLASHAW_TJ.png"
                },

                new Fighter{
                FirstName ="Max",
                LastName ="Holloway",
                Nickname ="Blessed",
                From ="Oahu, Hawaii United States",
                FightsOutOf ="Waianae, Hawaii United States",
                Age = 26  ,
                Height="",
                Weight ="",
                HeightCm ="180 cm",
                WeightKg ="65 kg",
                Reach ="69",
                LegReach ="42",
                Record ="19-3-0",
                Summary ="Striking, heart, cardio",
                ImageInList ="http://media.ufc.tv/generated_images_sorted/Fighter/Max-Holloway/Max-Holloway_235332_small_thumbnail.jpg",
                ImageMainProfile ="http://media.ufc.tv/fighter_images/Max_Holloway/HOLLOWAY_MAX_BELT.png"
                },

                new Fighter{
                FirstName ="Tyron",
                LastName ="Woodly",
                Nickname ="The Chosen One",
                From ="St. Louis, Missouri United States",
                FightsOutOf ="St. Louis, Missouri United States",
                Age = 35  ,
                Height="",
                Weight ="",
                HeightCm ="175 cm",
                WeightKg ="77 kg",
                Reach ="74",
                LegReach ="42",
                Record ="18-3-1",
                Summary ="Explosiveness, speed, power, wrestling, pressure and technique",
                ImageInList ="http://media.ufc.tv/generated_images_sorted/Fighter/Tyron-Woodley/Tyron-Woodley_241944_small_thumbnail.jpg",
                ImageMainProfile ="http://media.ufc.tv/fighter_images/Tyrone_Woodley/WOODLEY_TYRON.png"
                },

                new Fighter{
                FirstName ="Robert",
                LastName ="Whittaker",
                Nickname ="The Reaper",
                From ="Middlemore New Zealand",
                FightsOutOf ="Sydney Australia",
                Age = 27 ,
                Height="",
                Weight ="",
                HeightCm ="182 cm",
                WeightKg ="84 kg",
                Reach ="73",
                LegReach ="43",
                Record ="20-4-0",
                Summary ="Unorthodox striking",
                ImageInList ="http://media.ufc.tv/generated_images_sorted/Fighter/robert-whittaker/robert-whittaker_290162_small_thumbnail.jpg",
                ImageMainProfile ="http://media.ufc.tv/fighter_images/Robert_Whittaker/WHITTAKER_ROBERT.png"
                },

                new Fighter{
                FirstName ="Daniel",
                LastName ="Cormier",
                Nickname ="DC",
                From ="Lafayette, Louisiana United States",
                FightsOutOf ="San Jose, California United States",
                Age = 38  ,
                Height="",
                Weight ="",
                HeightCm ="180 cm",
                WeightKg ="93 kg",
                Reach ="72",
                LegReach ="41",
                Record ="19-1-0, 1NC",
                Summary ="Wrestling",
                ImageInList ="http://media.ufc.tv/generated_images_sorted/Fighter/Daniel-Cormier/Daniel-Cormier_241888_small_thumbnail.jpg",
                ImageMainProfile ="http://media.ufc.tv/fighter_images/Daniel_Cormier/CORMIER_DANIEL.png"
                },

                new Fighter{
                FirstName ="Stipe",
                LastName ="Miocic",
                Nickname ="",
                From ="Euclid, Ohio United States",
                FightsOutOf ="Independence, Ohio United States",
                Age = 35  ,
                Height="",
                Weight ="",
                HeightCm ="193 cm",
                WeightKg ="109 kg",
                Reach ="80",
                LegReach ="39",
                Record ="",
                Summary ="",
                ImageInList ="http://media.ufc.tv/generated_images_sorted/Fighter/Stipe-Miocic/Stipe-Miocic_205676_small_thumbnail.jpg",
                ImageMainProfile ="http://media.ufc.tv/fighter_images/Stipe_Miocic/MIOCIC_STIPE.png"
                },

                new Fighter{   FirstName ="Unknown",
                LastName ="Unknown"
                },

                new Fighter{   FirstName ="Unknown",
                LastName ="Unknown"
                }
            };

            foreach (Fighter f in fighters) {
                context.Fighters.Add(f);
            }

            context.SaveChanges();

            var Perfomanses = new Perfomanse[] {new Perfomanse{
                FighterID=fighters.Single(f=>f.FirstName=="Conor").ID,
                Result="Поражение",
                Tournament="UFC 196 - McGregor vs. Diaz",
                Date="5 марта 2016",
                Method ="Cдача (удушающий «Удушение сзади»)",
                Round=2,
                Time ="4:12",
                Video=""
            },
            new Perfomanse{
                FighterID=fighters.Single(f=>f.FirstName=="Conor").ID,
                EnemyName="Max Holloway",
                EnemyLink="/Home/AllFighters/MaxHolloway",
                Result="Победа",
                Tournament="UFC 196 - McGregor vs. Holloway",
                Date="10 марта 2015",
                Method ="Решение",
                Round=3,
                Time ="5:00",
                Video="https://www.stormo.tv/embed/30876/"
            }
            };

            foreach (Perfomanse h in Perfomanses) {
                context.Perfomanses.Add(h);
            }

            context.SaveChanges();

            var TitleHolders = new TitleHolder[] {new TitleHolder{
                FirstName="Demetrious",
                LastName="Johnson",
                Record="27-2-1",
                WeightCategory="FLYWEIGHT",
                Order =1,
                ProfileLink="/Home/AllFighters/DemitriousJohnson",
                ImageTitle="http://media.ufc.tv/generated_images_sorted/Fighter/Demetrious-Johnson/Demetrious-Johnson_1161_belt_thumbnail.png"
            },
            new TitleHolder{
                FirstName="TJ",
                LastName="Dillashaw",
                Record="16-3-0",
                WeightCategory="BANTAMWEIGHT",
                Order =2,
                ProfileLink="/Home/AllFighters/TJDillashaw",
                ImageTitle="http://media.ufc.tv/generated_images_sorted/Fighter/TJ-Dillashaw/TJ-Dillashaw_231394_belt_thumbnail.png"
            },
            new TitleHolder{
                FirstName="Max",
                LastName="Holloway",
                Record="18-3-0",
                WeightCategory="FEATHERWEIGHT",
                Order =3,
                ProfileLink="/Home/AllFighters/MaxHolloway",
                ImageTitle="http://media.ufc.tv/generated_images_sorted/Fighter/Max-Holloway/Max-Holloway_235332_belt_thumbnail.png"
            },
            new TitleHolder{
                FirstName="Conor",
                LastName="McGregor",
                Record="21-3-0",
                WeightCategory="LIGHTWIEGHT",
                Order =4,
                ProfileLink="/Home/AllFighters/ConorMcGregor",
                ImageTitle="http://media.ufc.tv/generated_images_sorted/Fighter/Conor-McGregor/Conor-McGregor_302601_belt_thumbnail.png"
            },
            new TitleHolder{
                FirstName="Tyron",
                LastName="Woodley",
                Record="18-3-1",
                WeightCategory="WELTERWEIGHT",
                Order =5,
                ProfileLink="/Home/AllFighters/TyronWoodly",
                ImageTitle="http://media.ufc.tv/generated_images_sorted/Fighter/Tyron-Woodley/Tyron-Woodley_241944_belt_thumbnail.png"
            },
            new TitleHolder{
                FirstName="Robert",
                LastName="Whittaker",
                Record="20-4-0",
                WeightCategory="MIDDLEWEIGHT",
                Order =6,
                ProfileLink="/Home/AllFighters/RobertWhittaker",
                ImageTitle="http://media.ufc.tv/generated_images_sorted/Fighter/robert-whittaker/robert-whittaker_290162_belt_thumbnail.png"
            },
            new TitleHolder{
                FirstName="Daniel",
                LastName="Cormier",
                Record="19-1-0, 1NC",
                WeightCategory="LIGHT HEAVYWEIGHT",
                Order =7,
                ProfileLink="/Home/AllFighters/DanielCormier",
                ImageTitle="http://media.ufc.tv/generated_images_sorted/Fighter/Daniel-Cormier/Daniel-Cormier_241888_belt_thumbnail.png"
            },
            new TitleHolder{
                FirstName="Stipe",
                LastName="Miocic",
                Record="17-2-0",
                WeightCategory="HEAVYWEIGHT",
                Order =8,
                ProfileLink="/Home/AllFighters/StipeMiocic",
                ImageTitle="http://media.ufc.tv/generated_images_sorted/Fighter/Stipe-Miocic/Stipe-Miocic_205676_belt_thumbnail.png"
            }

            };

            foreach (TitleHolder h in TitleHolders) {
                context.TitleHolders.Add(h);
            }

            context.SaveChanges();

        }
    }
}
