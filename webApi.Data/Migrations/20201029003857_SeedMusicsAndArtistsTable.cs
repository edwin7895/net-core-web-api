using Microsoft.EntityFrameworkCore.Migrations;

namespace webApi.Data.Migrations
{
    public partial class SeedMusicsAndArtistsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO artists (Name) Values ('Linkin Park')");
            migrationBuilder.Sql("INSERT INTO artists (Name) Values ('Iron Maiden')");
            migrationBuilder.Sql("INSERT INTO artists (Name) Values ('Flogging Molly')");
            migrationBuilder.Sql("INSERT INTO artists (Name) Values ('Red Hot Chilli Peppers')");
            migrationBuilder.Sql("INSERT INTO musics (Name, ArtistId) Values ('In The End', (SELECT Id FROM Artists WHERE Name = 'Linkin Park'))");
            migrationBuilder.Sql("INSERT INTO musics (Name, ArtistId) Values ('Numb', (SELECT Id FROM Artists WHERE Name = 'Linkin Park'))");
            migrationBuilder.Sql("INSERT INTO musics (Name, ArtistId) Values ('Breaking The Habit', (SELECT Id FROM Artists WHERE Name = 'Linkin Park'))");
            migrationBuilder.Sql("INSERT INTO musics (Name, ArtistId) Values ('Fear of the dark', (SELECT Id FROM Artists WHERE Name = 'Iron Maiden'))");
            migrationBuilder.Sql("INSERT INTO musics (Name, ArtistId) Values ('Number of the beast', (SELECT Id FROM Artists WHERE Name = 'Iron Maiden'))");
            migrationBuilder.Sql("INSERT INTO musics (Name, ArtistId) Values ('The Trooper', (SELECT Id FROM Artists WHERE Name = 'Iron Maiden'))");
            migrationBuilder.Sql("INSERT INTO musics (Name, ArtistId) Values ('What''s left of the flag', (SELECT Id FROM Artists WHERE Name = 'Flogging Molly'))");
            migrationBuilder.Sql("INSERT INTO musics (Name, ArtistId) Values ('Drunken Lullabies', (SELECT Id FROM Artists WHERE Name = 'Flogging Molly'))");
            migrationBuilder.Sql("INSERT INTO musics (Name, ArtistId) Values ('If I Ever Leave this World Alive', (SELECT Id FROM Artists WHERE Name = 'Flogging Molly'))");
            migrationBuilder.Sql("INSERT INTO musics (Name, ArtistId) Values ('Californication', (SELECT Id FROM Artists WHERE Name = 'Red Hot Chilli Peppers'))");
            migrationBuilder.Sql("INSERT INTO musics (Name, ArtistId) Values ('Tell Me Baby', (SELECT Id FROM Artists WHERE Name = 'Red Hot Chilli Peppers'))");
            migrationBuilder.Sql("INSERT INTO musics (Name, ArtistId) Values ('Parallel Universe', (SELECT Id FROM Artists WHERE Name = 'Red Hot Chilli Peppers'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM musics");
            migrationBuilder.Sql("DELETE FROM artists");
        }
    }
}
