﻿

//using Projekt.Data.Basketball;
//using Projekt.Core.Basketball;
//using Projekt.Core.Football;
//using Projekt.Data.Common;
//using Projekt.Data.Football;

using System.Collections.Generic;
using System.Linq;
using Core;
using DriveByStore.Data;
using DriveByStore.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace DriveByStore.Infra
{
    public static class QuantityDbInitializer
    {
	    public static void Initialize(StoreDbContext db)
        {
            InitializeProductData(Products.Club, db);

            //if (db.BasketballClub.Any()) return;
            //InitializeBBData(AtlantaHawks.Club, AtlantaHawks.Players, db);
            //InitializeBBData(BostonCeltics.Club, BostonCeltics.Players, db);
            //InitializeBBData(BrooklynNets.Club, BrooklynNets.Players, db);
            //InitializeBBData(CharlotteHornets.Club, CharlotteHornets.Players, db);
            //InitializeBBData(Chicago_Bulls.Club, Chicago_Bulls.Players, db);
            //InitializeBBData(ClevelandCavaliers.Club, ClevelandCavaliers.Players, db);
            //InitializeBBData(DallasMavericks.Club, DallasMavericks.Players, db);
            //InitializeBBData(DenverNuggets.Club, DenverNuggets.Players, db);
            //InitializeBBData(Detroit_Pistons.Club, Detroit_Pistons.Players, db);
            //InitializeBBData(GoldenStateWarriors.Club, GoldenStateWarriors.Players, db);
            //InitializeBBData(HoustonRockets.Club, HoustonRockets.Players, db);
            //InitializeBBData(IndianaPacers.Club, IndianaPacers.Players, db);
            //InitializeBBData(Los_Angeles_Lakers.Club, Los_Angeles_Lakers.Players, db);
            //InitializeBBData(LosAngelesClippers.Club, LosAngelesClippers.Players, db);
            //InitializeBBData(MemphisGrizzlies.Club, MemphisGrizzlies.Players, db);
            //InitializeBBData(MiamiHeat.Club, MiamiHeat.Players, db);
            //InitializeBBData(MilwaukeeBucks.Club, MilwaukeeBucks.Players, db);
            //InitializeBBData(Minnesota_Timberwolves.Club, Minnesota_Timberwolves.Players, db);
            //InitializeBBData(NewOrleansPelicans.Club, NewOrleansPelicans.Players, db);
            //InitializeBBData(NewYorkKnicks.Club, NewYorkKnicks.Players, db);
            //InitializeBBData(OklahomaCityThunder.Club, OklahomaCityThunder.Players, db);
            //InitializeBBData(Orlando_Magic.Club, Orlando_Magic.Players, db);
            //InitializeBBData(Philadelphia76Ers.Club, Philadelphia76Ers.Players, db);
            //InitializeBBData(PhoenixSuns.Club, PhoenixSuns.Players, db);
            //InitializeBBData(PortlandTrailBlazers.Club, PortlandTrailBlazers.Players, db);
            //InitializeBBData(SacramentoKings.Club, SacramentoKings.Players, db);
            //InitializeBBData(SanAntonioSpurs.Club, SanAntonioSpurs.Players, db);
            //InitializeBBData(TorontoRaptors.Club, TorontoRaptors.Players, db);
            //InitializeBBData(UtahJazz.Club, UtahJazz.Players, db);
            //InitializeBBData(WashingtonWizards.Club, WashingtonWizards.Players, db);


            //InitializeFBData(Arsenal.Club, Arsenal.Players, db);
            //InitializeFBData(AstonVilla.Club, AstonVilla.Players, db);
            //InitializeFBData(Bournemouth.Club, Bournemouth.Players, db);
            //InitializeFBData(Brighton.Club, Brighton.Players, db);
            //InitializeFBData(Burnley.Club, Burnley.Players, db);
            //InitializeFBData(Chelsea.Club, Chelsea.Players, db);
            //InitializeFBData(CrystalPalace.Club, CrystalPalace.Players, db);
            //InitializeFBData(Everton.Club, Everton.Players, db);
            //InitializeFBData(LeicesterCity.Club, LeicesterCity.Players, db);
            //InitializeFBData(Liverpool.Club, Liverpool.Players, db);
            //InitializeFBData(ManCity.Club, ManCity.Players, db);
            //InitializeFBData(ManUnited.Club, ManUnited.Players, db);
            //InitializeFBData(NewcastleUnited.Club, NewcastleUnited.Players, db);
            //InitializeFBData(NorwitchCity.Club, NorwitchCity.Players, db);
            //InitializeFBData(SheffieldUnited.Club, SheffieldUnited.Players, db);
            //InitializeFBData(Southampton.Club, Southampton.Players, db);
            //InitializeFBData(Tottenham.Club, Tottenham.Players, db);
            //InitializeFBData(Watford.Club, Watford.Players, db);
            //InitializeFBData(WestHam.Club, WestHam.Players, db);
            //InitializeFBData(Wolverhampton.Club, Arsenal.Players, db);
        }

        private static void InitializeProductData(CoreProductData product,
            StoreDbContext db)
        {
            AddProductData(product, db);
            
            db.SaveChanges();
        }
        private static T getItem<T>(IQueryable<T> set, string id) where T : ProductData
            => set.FirstOrDefaultAsync(m => m.productId == id).GetAwaiter().GetResult();

        private static void AddProductData(CoreProductData product, StoreDbContext db)
        {
            var o = getItem(db.Products, product.ProductId);
            db.Products.Add(
                new ProductData
                {
                    productId = product.ProductId,
                    productName = product.ProductName,
                    productPrice = product.ProductPrice,
                    productImage = product.ProductImage,
                    productCategoryId = product.ProductCategoryId,
                    productCategoryName = product.ProductCategoryName,
                    productStock = product.ProductStock,
                    productDescription = product.ProductDescription,

                });
        }
        //private static void AddBasketballPlayers(IEnumerable<BBPlayerData> players, string clubId,
        //    StoreDbContext db)
        //{
        //    foreach (var d in from d in players
        //                      let o = getItem(db.BasketballPlayer, d.Id)
        //                      where o is null
        //                      select d)
        //    {
        //        db.BasketballPlayer.Add(
        //            new BasketballPlayerData
        //            {
        //                BasketballClubId = clubId,
        //                Code = d.Code,
        //                Name = d.Name,
        //                Date = d.Date
        //            });
        //    }
        //}




        //private static void InitializeFBData(FBClubData club, List<FBPlayerData> players,
        //    StoreDbContext db)
        //{
        //    AddFootballClub(club, db);
        //    db.SaveChanges();
        //    AddFootballPlayers(players, club.Id, db);
        //    db.SaveChanges();
        //}

        //private static void AddFootballClub(FBClubData club, StoreDbContext db)
        //{
        // var o = getItem(db.FootballClub, club.Id);
        //    db.FootballClub.Add(
        //        new FootballClubData
        //        {
        //            Id = club.Id,
        //            Code = club.Code,
        //            Name = club.Name
        //        });

        //}

        //private static void AddFootballPlayers(IEnumerable<FBPlayerData> players, string clubId,
        //    StoreDbContext db)
        //{
        // foreach (var d in from d in players
        //  let o = getItem(db.FootballPlayer, d.Id)
        //  where o is null
        //  select d)
        //    {
        //        db.FootballPlayer.Add(
        //            new FootballPlayerData
        //            {
        //                FootballClubId = clubId,
        //                Code = d.Code,
        //                Name = d.Name,
        //                Date = d.Date
        //            });
        //    }
        //}
    }
}
