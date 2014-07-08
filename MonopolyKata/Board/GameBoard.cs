using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Board.Spaces;

namespace MonopolyKata.Board
{
    public class GameBoard
    {
        private List<BoardSpace> spaces;

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

        public const int NUMBER_OF_GAME_BOARD_SPACES = 40;

        public GameBoard()
        {

            spaces = new List<BoardSpace>();
            SetUpBoardSpaces();

        }

        public void LandOnNewSpace( MonopolyPlayer player )
        {
            spaces[player.Location].LandOn(player);
        }

        private void SetUpBoardSpaces()
        {
            spaces.Add(new GoSpace("Go"));
            spaces.Add(new MonopolyBoardSpace("Mediterranean Avenue"));
            spaces.Add(new MonopolyBoardSpace("Community Chest"));
            spaces.Add(new MonopolyBoardSpace("Baltic Avenue"));
            spaces.Add(new IncomeTaxSpace("Income Tax"));
            spaces.Add(new MonopolyBoardSpace("Reading Railroad"));
            spaces.Add(new MonopolyBoardSpace("Oriental Avenue"));
            spaces.Add(new MonopolyBoardSpace("Chance"));
            spaces.Add(new MonopolyBoardSpace("Vermont Avenue"));
            spaces.Add(new MonopolyBoardSpace("Connecticut Avenue"));
            spaces.Add(new MonopolyBoardSpace("Jail"));
            spaces.Add(new MonopolyBoardSpace("St Charles Place"));
            spaces.Add(new MonopolyBoardSpace("Electric Company"));
            spaces.Add(new MonopolyBoardSpace("States Avenue"));
            spaces.Add(new MonopolyBoardSpace("Virginia Avenue"));
            spaces.Add(new MonopolyBoardSpace("Pennsylvania Railroad"));
            spaces.Add(new MonopolyBoardSpace("St James Place"));
            spaces.Add(new MonopolyBoardSpace("Community Chest"));
            spaces.Add(new MonopolyBoardSpace("Tessessee Avenue"));
            spaces.Add(new MonopolyBoardSpace("New York Avenue"));
            spaces.Add(new MonopolyBoardSpace("Free Parking"));
            spaces.Add(new MonopolyBoardSpace("Kentucky Avenue"));
            spaces.Add(new MonopolyBoardSpace("Chance"));
            spaces.Add(new MonopolyBoardSpace("Indiana Avenue"));
            spaces.Add(new MonopolyBoardSpace("Illinois Avenue"));
            spaces.Add(new MonopolyBoardSpace("B&O Railroad"));
            spaces.Add(new MonopolyBoardSpace("Atlantic Avenue"));
            spaces.Add(new MonopolyBoardSpace("Ventnor Avenue"));
            spaces.Add(new MonopolyBoardSpace("Water Works"));
            spaces.Add(new MonopolyBoardSpace("Marvin Gardins Avenue"));
            spaces.Add(new GoToJailSpace("Go To Jail"));
            spaces.Add(new MonopolyBoardSpace("Pacific Avenue"));
            spaces.Add(new MonopolyBoardSpace("North Carolina Avenue"));
            spaces.Add(new MonopolyBoardSpace("Community Chest"));
            spaces.Add(new MonopolyBoardSpace("Pennsylvania Avenue"));
            spaces.Add(new MonopolyBoardSpace("Short Line Railroad"));
            spaces.Add(new MonopolyBoardSpace("Chance"));
            spaces.Add(new MonopolyBoardSpace("Park Place"));
            spaces.Add(new LuxuryTaxSpace("Luxury Tax"));
            spaces.Add(new MonopolyBoardSpace("Boardwalk"));


            for(int i = 0; i < spaces.Count(); ++i)
            {
                spaces[i] = new PrintWhereLanded(spaces[i]);
            }

            
        }
    }
}
