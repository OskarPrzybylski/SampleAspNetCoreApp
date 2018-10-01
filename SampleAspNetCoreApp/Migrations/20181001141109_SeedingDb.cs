using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SampleAspNetCoreApp.Migrations
{
    public partial class SeedingDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Addresses (Street,City) VALUES('Piotrkowska', 'Lódź')");
            migrationBuilder.Sql("INSERT INTO Addresses (Street,City) VALUES('Rybna', 'Lódź')");
            migrationBuilder.Sql("INSERT INTO Addresses (Street,City) VALUES('Kwiatowa', 'Raszków')");

            migrationBuilder.Sql("INSERT INTO Owners (Name, Surname, Phone) VALUES('Michał', 'Kempa', '123584483')");
            migrationBuilder.Sql("INSERT INTO Owners (Name, Surname, Phone) VALUES('Mateusz', 'Dębski', '123320645')");
            migrationBuilder.Sql("INSERT INTO Owners (Name, Surname, Phone) VALUES('Adam', 'Przybylski', '536584483')");

            migrationBuilder.Sql("INSERT INTO Properties (Type, Description, Rooms, Area, Washer, Refrigerator, Iron, AddressId, OwnerId) VALUES(0, 'Opis produktu', 8, 170, 1,0,1,1,1)");
            migrationBuilder.Sql("INSERT INTO Properties (Type, Description, Rooms, Area, Washer, Refrigerator, Iron, AddressId, OwnerId) VALUES(0, 'Opis produktu2', 5, 120, 0,0,1,2,2)");
            migrationBuilder.Sql("INSERT INTO Properties (Type, Description, Rooms, Area, Washer, Refrigerator, Iron, AddressId, OwnerId) VALUES(1, 'Opis produktu3', 4, 110, 1,1,1,3,3)");
        
    }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Owners");
            migrationBuilder.Sql("DELETE FROM Addresses");
            migrationBuilder.Sql("DELETE FROM Properties");
        }
    }
}
