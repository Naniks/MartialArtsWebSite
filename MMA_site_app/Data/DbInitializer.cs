using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MMA_site_app.Models;
using Microsoft.EntityFrameworkCore;

namespace MMA_site_app.Data {
    public class DbInitializer {
        public static void Initialize(FighterContext context) {

            //context.Database.EnsureCreated(); unusable for migrations

            context.Database.Migrate();

            if (context.Fighters.Any()) {
                return; //DB has been seeded
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

                new Fighter{   FirstName ="Jose",
                LastName ="Aldo"
                },

                new Fighter{   FirstName ="Nate",
                LastName ="Diaz"
                }
            };

            foreach(Fighter f in fighters) {
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
                Video="",                
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
                ProfileLink="",
                ImageTitle="http://media.ufc.tv/generated_images_sorted/Fighter/Demetrious-Johnson/Demetrious-Johnson_1161_belt_thumbnail.png"
            },
            new TitleHolder{
                FirstName="TJ",
                LastName="Dillashaw",
                Record="16-3-0",
                WeightCategory="BANTAMWEIGHT",
                Order =2,
                ProfileLink="",
                ImageTitle="http://media.ufc.tv/generated_images_sorted/Fighter/TJ-Dillashaw/TJ-Dillashaw_231394_belt_thumbnail.png"
            },
            new TitleHolder{
                FirstName="Max",
                LastName="Holloway",
                Record="18-3-0",
                WeightCategory="FEATHERWEIGHT",
                Order =3,
                ProfileLink="",
                ImageTitle="http://media.ufc.tv/generated_images_sorted/Fighter/Max-Holloway/Max-Holloway_235332_belt_thumbnail.png"
            },
            new TitleHolder{
                FirstName="Conor",
                LastName="McGregor",
                Record="21-3-0",
                WeightCategory="LIGHTWIEGHT",
                Order =4,
                ProfileLink="",
                ImageTitle="http://media.ufc.tv/generated_images_sorted/Fighter/Conor-McGregor/Conor-McGregor_302601_belt_thumbnail.png"
            },
            new TitleHolder{
                FirstName="Tyron",
                LastName="Woodley",
                Record="18-3-1",
                WeightCategory="WELTERWEIGHT",
                Order =5,
                ProfileLink="",
                ImageTitle="http://media.ufc.tv/generated_images_sorted/Fighter/Tyron-Woodley/Tyron-Woodley_241944_belt_thumbnail.png"
            },
            new TitleHolder{
                FirstName="Robert",
                LastName="Whittaker",
                Record="20-4-0",
                WeightCategory="MIDDLEWEIGHT",
                Order =6,
                ProfileLink="",
                ImageTitle="http://media.ufc.tv/generated_images_sorted/Fighter/robert-whittaker/robert-whittaker_290162_belt_thumbnail.png"
            },
            new TitleHolder{
                FirstName="Daniel",
                LastName="Cormier",
                Record="19-1-0, 1NC",
                WeightCategory="LIGHT HEAVYWEIGHT",
                Order =7,
                ProfileLink="",
                ImageTitle="http://media.ufc.tv/generated_images_sorted/Fighter/Daniel-Cormier/Daniel-Cormier_241888_belt_thumbnail.png"
            },
            new TitleHolder{
                FirstName="Stipe",
                LastName="Miocic",
                Record="17-2-0",
                WeightCategory="HEAVYWEIGHT",
                Order =8,
                ProfileLink="",
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
