﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Player;
using MonopolyKata.Board.Spaces;
using MonopolyKata.Board.Spaces.RealEstate;

namespace MonopolyKata.Board
{
    public class MonopolyGameBoard : IMonopolyGameBoard
    {
        private List<IBoardSpace> spaces;

        public GoSpace Go{get;set;}
        public RealEstateSpace MediterraneanAvenue { get; private set; }
        public MonopolyBoardSpace CommunityChest1 { get; private set; }
        public RealEstateSpace BalticAvenue { get; private set; }
        public IncomeTaxSpace IncomeTax { get; private set; }
        public RealEstateSpace ReadingRailroad { get; private set; }
        public RealEstateSpace OrientalAvenue { get; private set; }
        public MonopolyBoardSpace Chance1 { get; private set; }
        public RealEstateSpace VermontAvenue { get; private set; }
        public RealEstateSpace ConnecticutAvenue { get; private set; }
        public JailSpace Jail { get; private set; }
        public RealEstateSpace StCharlesPlace{ get; private set; }
        public RealEstateSpace ElectricCompany{ get; private set; }
        public RealEstateSpace StatesAvenue{ get; private set; }
        public RealEstateSpace VirginiaAvenue{ get; private set; }
        public RealEstateSpace PennsylvaniaRailroad{ get; private set; }
        public RealEstateSpace StJamesPlace{ get; private set; }
        public MonopolyBoardSpace CommunityChest2{ get; private set; }
        public RealEstateSpace TessesseeAvenue{ get; private set; }
        public RealEstateSpace NewYorkAvenue{ get; private set; }
        public MonopolyBoardSpace FreeParking{ get; private set; }
        public RealEstateSpace KentuckyAvenue{ get; private set; }
        public MonopolyBoardSpace Chance2{ get; private set; }
        public RealEstateSpace IndianaAvenue{ get; private set; }
        public RealEstateSpace IllinoisAvenue{ get; private set; }
        public RealEstateSpace BnORailroad{ get; private set; }
        public RealEstateSpace AtlanticAvenue{ get; private set; }
        public RealEstateSpace VentnorAvenue{ get; private set;}
        public RealEstateSpace WaterWorks{ get; private set; }
        public RealEstateSpace MarvinGardinsAvenue{ get; private set; }
        public GoToJailSpace GoToJail{ get; private set; }
        public RealEstateSpace PacificAvenue{ get; private set; }
        public RealEstateSpace NorthCarolinaAvenue{ get; private set; }
        public MonopolyBoardSpace CommunityChest3{ get; private set; }
        public RealEstateSpace PennsylvaniaAvenue{ get; private set; }
        public RealEstateSpace ShortLineRailroad{ get; private set; }
        public MonopolyBoardSpace Chance3{ get; private set; }
        public RealEstateSpace ParkPlace{ get; private set; }
        public LuxuryTaxSpace LuxuryTax{ get; private set; }
        public RealEstateSpace Boardwalk{ get; private set; }


        public MonopolyGameBoard()
        {
            spaces = new List<IBoardSpace>();
            
            CreateBoardSpaces();
            AddBoardSpacesToList();
        }

        public void LandOnNewSpace(IPlayer player)
        {
            spaces[player.Location].LandOn(player);
        }

        public void Move(IPlayer player, int roll)
        {
            player.Location += roll;

            player.lastRoll = roll;

            while (player.Location >= GetNumberOfBoardSpaces())
            {
                player.Location -= GetNumberOfBoardSpaces();
            }
        }

        public static void GroupSpaces(params RealEstateSpace[] spaces)
        {
            for (int i = 0; i < spaces.Length - 1; ++i)
            {
                for (int j = i + 1; j < spaces.Length; ++j)
                {
                    spaces[i].AddSpaceToGroup(spaces[j]);
                    spaces[j].AddSpaceToGroup(spaces[i]);
                }
            }
        }

        public int GetSpaceAddress(IBoardSpace space)
        {
            int spaceAddress = -1;

            for(int i = 0; i < spaces.Count; ++i)
            {
                if(space ==  spaces[i])
                {
                    spaceAddress = i;
                }
            }

            return spaceAddress;
        }

        public int GetForwardDistanceToSpace(int location, IBoardSpace space)
        {
            int spaceAddress = GetSpaceAddress(space); 
            
            if(location <= GetSpaceAddress(space))
            {
                return (spaceAddress - location);
            }
            else
            {
                return( spaceAddress + (GetNumberOfBoardSpaces()-location));
            }

        }

        public bool DidPlayerPassGo(IPlayer player)
        {
            return ((player.Location - player.lastRoll) < 0) && player.Location != GetSpaceAddress(Go);
        }

        public void PutPlayerInJail(IPlayer player)
        {
            Jail.LockUp(player);
        }

        public int GetNumberOfBoardSpaces()
        {
            return (spaces.Count());
        }

        private void SetUpPropertyGroups()
        {
            GroupSpaces(ReadingRailroad, PennsylvaniaRailroad, BnORailroad, ShortLineRailroad);

            GroupSpaces(ElectricCompany, WaterWorks);

            GroupSpaces(MediterraneanAvenue, BalticAvenue);
            GroupSpaces(OrientalAvenue, VermontAvenue, ConnecticutAvenue);
            GroupSpaces(StCharlesPlace, StatesAvenue, VirginiaAvenue);
            GroupSpaces(StJamesPlace, TessesseeAvenue, NewYorkAvenue);
            GroupSpaces(KentuckyAvenue, IndianaAvenue, IllinoisAvenue);
            GroupSpaces(AtlanticAvenue, VentnorAvenue, MarvinGardinsAvenue);
            GroupSpaces(PacificAvenue, NorthCarolinaAvenue, PennsylvaniaAvenue);
            GroupSpaces(ParkPlace, Boardwalk);
        }

        private void CreateBoardSpaces()
        {
            Go = new GoSpace("Go", this);
            MediterraneanAvenue = new RealEstateSpace("Mediterranean Avenue", this, 2, 60, new PropertyChargingStrategy(),new MortgageChargingStrategy());
            CommunityChest1 = new MonopolyBoardSpace("Community Chest", this);
            BalticAvenue = new RealEstateSpace("Baltic Avenue", this, 4, 60, new PropertyChargingStrategy(), new MortgageChargingStrategy());
            IncomeTax= new IncomeTaxSpace("Income Tax", this);
            ReadingRailroad = new RealEstateSpace("Reading Railroad", this, 25, 200, new RailRoadChargingStrategy(), new MortgageChargingStrategy());
            OrientalAvenue = new RealEstateSpace("Oriental Avenue", this, 6, 100, new PropertyChargingStrategy(), new MortgageChargingStrategy());
            Chance1 = new MonopolyBoardSpace ("Chance", this);
            VermontAvenue = new RealEstateSpace("Vermont Avenue", this, 6, 100, new PropertyChargingStrategy(), new MortgageChargingStrategy());
            ConnecticutAvenue = new RealEstateSpace("Connecticut Avenue", this, 8, 120, new PropertyChargingStrategy(), new MortgageChargingStrategy());
            Jail =  new JailSpace("Jail", this);
            StCharlesPlace = new RealEstateSpace("St Charles Place", this, 10, 140, new PropertyChargingStrategy(), new MortgageChargingStrategy());
            ElectricCompany = new RealEstateSpace("Electric Company", this, 4, 140, new UtilityChargingStrategy(), new MortgageChargingStrategy());
            StatesAvenue = new RealEstateSpace("States Avenue", this, 10, 140, new PropertyChargingStrategy(), new MortgageChargingStrategy());
            VirginiaAvenue = new RealEstateSpace("Virginia Avenue", this, 12, 160, new PropertyChargingStrategy(), new MortgageChargingStrategy());
            PennsylvaniaRailroad = new RealEstateSpace("Pennsylvania Railroad", this, 25, 200, new RailRoadChargingStrategy(), new MortgageChargingStrategy());
            StJamesPlace = new RealEstateSpace("St James Place", this, 14, 180, new PropertyChargingStrategy(), new MortgageChargingStrategy());
            CommunityChest2= new MonopolyBoardSpace ("Community Chest", this);
            TessesseeAvenue = new RealEstateSpace("Tessessee Avenue", this, 14, 180, new PropertyChargingStrategy(), new MortgageChargingStrategy());
            NewYorkAvenue = new RealEstateSpace("New York Avenue", this, 16, 200, new PropertyChargingStrategy(), new MortgageChargingStrategy());
            FreeParking = new MonopolyBoardSpace("Free Parking", this);
            KentuckyAvenue = new RealEstateSpace("Kentucky Avenue", this, 18, 220, new PropertyChargingStrategy(), new MortgageChargingStrategy());
            Chance2 = new MonopolyBoardSpace("Chance", this);
            IndianaAvenue = new RealEstateSpace("Indiana Avenue", this, 18, 220, new PropertyChargingStrategy(), new MortgageChargingStrategy());
            IllinoisAvenue = new RealEstateSpace("Illinois Avenue", this, 20, 240, new PropertyChargingStrategy(), new MortgageChargingStrategy());
            BnORailroad = new RealEstateSpace("B&O Railroad", this, 25, 200, new RailRoadChargingStrategy(), new MortgageChargingStrategy());
            AtlanticAvenue = new RealEstateSpace("Atlantic Avenue", this, 22, 260, new PropertyChargingStrategy(), new MortgageChargingStrategy());
            VentnorAvenue = new RealEstateSpace("Ventnor Avenue", this, 22, 260, new PropertyChargingStrategy(), new MortgageChargingStrategy());
            WaterWorks = new RealEstateSpace("Water Works", this, 4, 140, new UtilityChargingStrategy(), new MortgageChargingStrategy());
            MarvinGardinsAvenue = new RealEstateSpace("Marvin Gardins Avenue", this, 22, 280, new PropertyChargingStrategy(), new MortgageChargingStrategy());
            GoToJail = new GoToJailSpace("Go To Jail", this);
            PacificAvenue = new RealEstateSpace("Pacific Avenue", this, 26, 300, new PropertyChargingStrategy(), new MortgageChargingStrategy());
            NorthCarolinaAvenue = new RealEstateSpace("North Carolina Avenue", this, 26, 300, new PropertyChargingStrategy(), new MortgageChargingStrategy());
            CommunityChest3 = new MonopolyBoardSpace("Community Chest", this);
            PennsylvaniaAvenue = new RealEstateSpace("Pennsylvania Avenue", this, 28, 320, new PropertyChargingStrategy(), new MortgageChargingStrategy());
            ShortLineRailroad = new RealEstateSpace("Short Line Railroad", this, 25, 200, new RailRoadChargingStrategy(), new MortgageChargingStrategy());
            Chance3 = new MonopolyBoardSpace("Chance", this);
            ParkPlace = new RealEstateSpace("Park Place", this, 35, 350, new PropertyChargingStrategy(), new MortgageChargingStrategy());
            LuxuryTax = new LuxuryTaxSpace("Luxury Tax", this);
            Boardwalk = new RealEstateSpace("Boardwalk", this, 50, 400, new PropertyChargingStrategy(), new MortgageChargingStrategy());
        }

        private void AddBoardSpacesToList()
        {
            spaces.Add(Go);
            spaces.Add( MediterraneanAvenue);
            spaces.Add(CommunityChest1);
            spaces.Add( BalticAvenue );
            spaces.Add(IncomeTax );
            spaces.Add( ReadingRailroad );
            spaces.Add( OrientalAvenue );
            spaces.Add( Chance1 );
            spaces.Add( VermontAvenue );
            spaces.Add( ConnecticutAvenue );
            spaces.Add(Jail);
            spaces.Add( StCharlesPlace );
            spaces.Add( ElectricCompany );
            spaces.Add( StatesAvenue );
            spaces.Add( VirginiaAvenue );
            spaces.Add( PennsylvaniaRailroad );
            spaces.Add( StJamesPlace );
            spaces.Add( CommunityChest2 );
            spaces.Add( TessesseeAvenue );
            spaces.Add( NewYorkAvenue );
            spaces.Add(FreeParking );
            spaces.Add( KentuckyAvenue );
            spaces.Add(Chance2 );
            spaces.Add( IndianaAvenue );
            spaces.Add( IllinoisAvenue );
            spaces.Add( BnORailroad );
            spaces.Add( AtlanticAvenue );
            spaces.Add( VentnorAvenue );
            spaces.Add( WaterWorks );
            spaces.Add(MarvinGardinsAvenue);
            spaces.Add( GoToJail );
            spaces.Add( PacificAvenue );
            spaces.Add( NorthCarolinaAvenue );
            spaces.Add( CommunityChest3 );
            spaces.Add( PennsylvaniaAvenue );
            spaces.Add( ShortLineRailroad );
            spaces.Add( Chance3 );
            spaces.Add( ParkPlace );
            spaces.Add(LuxuryTax );
            spaces.Add( Boardwalk );
        }

    }
}
