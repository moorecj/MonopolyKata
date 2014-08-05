using System;
using MonopolyKata.Player;
using MonopolyKata.Board.Spaces;
using MonopolyKata.Board.Spaces.RealEstate;

namespace MonopolyKata.Board
{
    public interface IMonopolyGameBoard
    {
        GoSpace Go { get; set; }
        RealEstateSpace MediterraneanAvenue { get; }
        MonopolyBoardSpace CommunityChest1 { get; }
        RealEstateSpace BalticAvenue { get;  }
        IncomeTaxSpace IncomeTax { get; }
        RealEstateSpace ReadingRailroad { get; }
        RealEstateSpace OrientalAvenue { get; }
        MonopolyBoardSpace Chance1 { get; }
        RealEstateSpace VermontAvenue { get;  }
        RealEstateSpace ConnecticutAvenue { get; }
        JailSpace Jail { get;  }
        RealEstateSpace StCharlesPlace { get; }
        RealEstateSpace ElectricCompany { get;}
        RealEstateSpace StatesAvenue { get; }
        RealEstateSpace VirginiaAvenue { get; }
        RealEstateSpace PennsylvaniaRailroad { get; }
        RealEstateSpace StJamesPlace { get; }
        MonopolyBoardSpace CommunityChest2 { get;}
        RealEstateSpace TessesseeAvenue { get; }
        RealEstateSpace NewYorkAvenue { get;}
        MonopolyBoardSpace FreeParking { get; }
        RealEstateSpace KentuckyAvenue { get; }
        MonopolyBoardSpace Chance2 { get; }
        RealEstateSpace IndianaAvenue { get; }
        RealEstateSpace IllinoisAvenue { get; }
        RealEstateSpace BnORailroad { get; }
        RealEstateSpace AtlanticAvenue { get;  }
        RealEstateSpace VentnorAvenue { get;}
        RealEstateSpace WaterWorks { get; }
        RealEstateSpace MarvinGardinsAvenue { get; }
        GoToJailSpace GoToJail { get; }
        RealEstateSpace PacificAvenue { get; }
        RealEstateSpace NorthCarolinaAvenue { get; }
        MonopolyBoardSpace CommunityChest3 { get; }
        RealEstateSpace PennsylvaniaAvenue { get; }
        RealEstateSpace ShortLineRailroad { get; }
        MonopolyBoardSpace Chance3 { get; }
        LuxuryTaxSpace LuxuryTax { get; }
        RealEstateSpace Boardwalk { get;}

        void LandOnNewSpace(IPlayer player);
        void Move(IPlayer player, int roll);
        int GetNumberOfBoardSpaces();
        int GetSpaceAddress(BoardSpace space);
    }
}
