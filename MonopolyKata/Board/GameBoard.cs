using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Board.Spaces;
using MonopolyKata.Board.Spaces.RealEstate;
using MonopolyKata.Board.Spaces.RealEstate.Property;

namespace MonopolyKata.Board
{
    public class GameBoard : MonopolyKata.Board.IGameBoard
    {
        private List<BoardSpace> spaces;

        GoSpace Go;
        RealEstateSpace MediterraneanAvenue;
        MonopolyBoardSpace CommunityChest1;
        RealEstateSpace BalticAvenue;
        IncomeTaxSpace IncomeTax;
        RealEstateSpace ReadingRailroad;
        RealEstateSpace OrientalAvenue;
        MonopolyBoardSpace Chance1;
        RealEstateSpace VermontAvenue;
        RealEstateSpace ConnecticutAvenue;
        MonopolyBoardSpace Jail;
        RealEstateSpace StCharlesPlace;
        RealEstateSpace ElectricCompany;
        RealEstateSpace StatesAvenue;
        RealEstateSpace VirginiaAvenue;
        RealEstateSpace PennsylvaniaRailroad;
        RealEstateSpace StJamesPlace;
        MonopolyBoardSpace CommunityChest2;
        RealEstateSpace TessesseeAvenue;
        RealEstateSpace NewYorkAvenue;
        MonopolyBoardSpace FreeParking;
        RealEstateSpace KentuckyAvenue;
        MonopolyBoardSpace Chance2;
        RealEstateSpace IndianaAvenue;
        RealEstateSpace IllinoisAvenue;
        RealEstateSpace BnORailroad;
        RealEstateSpace AtlanticAvenue;
        RealEstateSpace VentnorAvenue;
        RealEstateSpace WaterWorks;
        RealEstateSpace MarvinGardinsAvenue;
        GoToJailSpace GoToJail;
        RealEstateSpace PacificAvenue;
        RealEstateSpace NorthCarolinaAvenue;
        MonopolyBoardSpace CommunityChest3;
        RealEstateSpace PennsylvaniaAvenue;
        RealEstateSpace ShortLineRailroad;
        MonopolyBoardSpace Chance3;
        RealEstateSpace ParkPlace;
        LuxuryTaxSpace LuxuryTax;
        RealEstateSpace Boardwalk;

        public const int GO_LOCATION = 0;
        public const int MEDITERRANEAN_AVENUE_LOCATION = 1;
        public const int COMMUNITY_CHEST1_LOCATION = 2;
        public const int BALTIC_AVENUE_LOCATION = 3;
        public const int INCOME_TAX_LOCATION = 4;
        public const int READING_RAILROAD_LOCATION = 5;
        public const int ORIENTAL_AVENUE_LOCATION = 6;
        public const int CHANCE1_LOCATION = 7;
        public const int VERMONT_AVENUE_LOCATION = 8;
        public const int CONNECTICUT_AVENUE_LOCATION = 9;
        public const int JAIL_LOCATION = 10;
        public const int ST_CHARLES_PLACE_LOCATION = 11;
        public const int ELECTRIC_COMPANY_LOCATION = 12;
        public const int STATES_AVENUE_LOCATION = 13;
        public const int VIRGINIA_AVENUE_LOCATION = 14;
        public const int PENNSYLVANIA_RAILROAD_LOCATION = 15;
        public const int ST_JAMES_PLACE_LOCATION = 16;
        public const int COMMUNITY_CHEST2_LOCATION = 17;
        public const int TESSESSEE_AVENUE_LOCATION = 18;
        public const int NEW_YORK_AVENUE_LOCATION = 19;
        public const int FREE_PARKING_LOCATION = 20;
        public const int KENTUCKY_AVENUE_LOCATION = 21;
        public const int CHANCE2_LOCATION = 22;
        public const int INDIANA_AVENUE_LOCATION = 23;
        public const int ILLINOIS_AVENUE_LOCATION = 24;
        public const int B_AND_O_RAILROAD_LOCATION = 25;
        public const int ATLANTIC_AVENUE_LOCATION = 26;
        public const int VENTNOR_AVENUE_LOCATION = 27;
        public const int WATER_WORKS_LOCATION = 28;
        public const int MARVIN_GARDINS_AVENUE_LOCATION = 29;
        public const int GO_TO_JAIL_LOCATION = 30;
        public const int PACIFIC_AVENUE_LOCATION = 31;
        public const int NORTH_CAROLINA_AVENUE_LOCATION = 32;
        public const int COMMUNITY_CHEST_LOCATION = 33;
        public const int PENNSYLVANIA_AVENUE_LOCATION = 34;
        public const int SHORT_LINE_RAILROAD_LOCATION = 35;
        public const int CHANCE3_LOCATION = 36;
        public const int PARK_PLACE_LOCATION = 37;
        public const int LUXURY_TAX_LOCATION = 38;
        public const int BOARDWALK_LOCATION = 39;

        public GameBoard()
        {

            spaces = new List<BoardSpace>();
            
            CreateBoardSpaces();
            AddBoardSpacesToList();

            AddPrintWhereLandedDecoration();

        }

        public void LandOnNewSpace( MonopolyPlayer player )
        {
            spaces[player.Location].LandOn(player);
        }

        public int GetNumberOfBoardSpaces()
        {
            return (spaces.Count());
        }



        private void SetUpPropertyGroups()
        {

            RealEstateSpace.GroupSpaces(ReadingRailroad, PennsylvaniaRailroad, BnORailroad, ShortLineRailroad);

            RealEstateSpace.GroupSpaces(ElectricCompany, WaterWorks);

            RealEstateSpace.GroupSpaces(MediterraneanAvenue, BalticAvenue);
            RealEstateSpace.GroupSpaces(OrientalAvenue, VermontAvenue, ConnecticutAvenue);
            RealEstateSpace.GroupSpaces(StCharlesPlace, StatesAvenue, VirginiaAvenue);
            RealEstateSpace.GroupSpaces(StJamesPlace, TessesseeAvenue, NewYorkAvenue);
            RealEstateSpace.GroupSpaces(KentuckyAvenue, IndianaAvenue, IllinoisAvenue);
            RealEstateSpace.GroupSpaces(AtlanticAvenue, VentnorAvenue, MarvinGardinsAvenue);
            RealEstateSpace.GroupSpaces(PacificAvenue, NorthCarolinaAvenue, PennsylvaniaAvenue);
            RealEstateSpace.GroupSpaces(ParkPlace, Boardwalk);
        }

        private void CreateBoardSpaces()
        {
            Go = new GoSpace("Go");
            MediterraneanAvenue = new PropertySpace ("Mediterranean Avenue",2,60);
            CommunityChest1 = new MonopolyBoardSpace("Community Chest");
            BalticAvenue = new PropertySpace("Baltic Avenue",4,60);
            IncomeTax= new IncomeTaxSpace("Income Tax");
            ReadingRailroad = new RealEstateSpace("Reading Railroad");
            OrientalAvenue = new PropertySpace("Oriental Avenue",6,100);
            Chance1 = new MonopolyBoardSpace ("Chance");
            VermontAvenue = new PropertySpace("Vermont Avenue",6,100);
            ConnecticutAvenue = new PropertySpace("Connecticut Avenue",8,120);
            Jail =  new MonopolyBoardSpace("Jail");
            StCharlesPlace = new PropertySpace("St Charles Place",10,140);
            ElectricCompany= new RealEstateSpace ("Electric Company");
            StatesAvenue = new PropertySpace("States Avenue",10,140);
            VirginiaAvenue = new PropertySpace("Virginia Avenue",12,160);
            PennsylvaniaRailroad = new RealEstateSpace ("Pennsylvania Railroad");
            StJamesPlace = new PropertySpace("St James Place",14,180);
            CommunityChest2= new MonopolyBoardSpace ("Community Chest");
            TessesseeAvenue = new PropertySpace("Tessessee Avenue",14,180);
            NewYorkAvenue = new PropertySpace("New York Avenue",16,200);
            FreeParking = new MonopolyBoardSpace("Free Parking");
            KentuckyAvenue = new PropertySpace("Kentucky Avenue",18,220);
            Chance2 = new MonopolyBoardSpace("Chance");
            IndianaAvenue = new PropertySpace("Indiana Avenue",18,220);
            IllinoisAvenue = new PropertySpace("Illinois Avenue",20,240);
            BnORailroad= new RealEstateSpace ("B&O Railroad");
            AtlanticAvenue = new PropertySpace("Atlantic Avenue",22,260);
            VentnorAvenue = new PropertySpace("Ventnor Avenue",22,260);
            WaterWorks= new RealEstateSpace ("Water Works");
            MarvinGardinsAvenue = new PropertySpace("Marvin Gardins Avenue",22,280);
            GoToJail = new GoToJailSpace("Go To Jail");
            PacificAvenue = new PropertySpace("Pacific Avenue",26,300);
            NorthCarolinaAvenue = new PropertySpace("North Carolina Avenue",26,300);
            CommunityChest3 = new MonopolyBoardSpace("Community Chest");
            PennsylvaniaAvenue = new PropertySpace("Pennsylvania Avenue",28,320);
            ShortLineRailroad = new RealEstateSpace ("Short Line Railroad");
            Chance3 = new MonopolyBoardSpace("Chance");
            ParkPlace = new PropertySpace("Park Place",35,350);
            LuxuryTax = new LuxuryTaxSpace("Luxury Tax");
            Boardwalk = new PropertySpace("Boardwalk",50,400);
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

        private void AddPrintWhereLandedDecoration()
        {
            for (int i = 0; i < spaces.Count(); ++i)
            {
                spaces[i] = new PrintWhereLandedDecoration(spaces[i]);
            }
        }

    }
}
