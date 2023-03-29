using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestFullAppTemplate.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamePromoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Promotions_EPromoId",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Prizes_Promotions_EPromoId",
                table: "Prizes");

            migrationBuilder.DropForeignKey(
                name: "FK_PromoResults_Prizes_EPrizeId",
                table: "PromoResults");

            migrationBuilder.DropForeignKey(
                name: "FK_PromoResults_Promotions_EPromoId",
                table: "PromoResults");

            migrationBuilder.DropIndex(
                name: "IX_PromoResults_EPrizeId",
                table: "PromoResults");

            migrationBuilder.DropColumn(
                name: "EPrizeId",
                table: "PromoResults");

            migrationBuilder.RenameColumn(
                name: "EPromoId",
                table: "PromoResults",
                newName: "PromoId");

            migrationBuilder.RenameIndex(
                name: "IX_PromoResults_EPromoId",
                table: "PromoResults",
                newName: "IX_PromoResults_PromoId");

            migrationBuilder.RenameColumn(
                name: "EPromoId",
                table: "Prizes",
                newName: "PromoId");

            migrationBuilder.RenameIndex(
                name: "IX_Prizes_EPromoId",
                table: "Prizes",
                newName: "IX_Prizes_PromoId");

            migrationBuilder.RenameColumn(
                name: "EPromoId",
                table: "Participants",
                newName: "PromoId");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_EPromoId",
                table: "Participants",
                newName: "IX_Participants_PromoId");

            migrationBuilder.AlterColumn<int>(
                name: "PromoId",
                table: "PromoResults",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PromoResults_PrizeId",
                table: "PromoResults",
                column: "PrizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Promotions_PromoId",
                table: "Participants",
                column: "PromoId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prizes_Promotions_PromoId",
                table: "Prizes",
                column: "PromoId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PromoResults_Prizes_PrizeId",
                table: "PromoResults",
                column: "PrizeId",
                principalTable: "Prizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PromoResults_Promotions_PromoId",
                table: "PromoResults",
                column: "PromoId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Promotions_PromoId",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Prizes_Promotions_PromoId",
                table: "Prizes");

            migrationBuilder.DropForeignKey(
                name: "FK_PromoResults_Prizes_PrizeId",
                table: "PromoResults");

            migrationBuilder.DropForeignKey(
                name: "FK_PromoResults_Promotions_PromoId",
                table: "PromoResults");

            migrationBuilder.DropIndex(
                name: "IX_PromoResults_PrizeId",
                table: "PromoResults");

            migrationBuilder.RenameColumn(
                name: "PromoId",
                table: "PromoResults",
                newName: "EPromoId");

            migrationBuilder.RenameIndex(
                name: "IX_PromoResults_PromoId",
                table: "PromoResults",
                newName: "IX_PromoResults_EPromoId");

            migrationBuilder.RenameColumn(
                name: "PromoId",
                table: "Prizes",
                newName: "EPromoId");

            migrationBuilder.RenameIndex(
                name: "IX_Prizes_PromoId",
                table: "Prizes",
                newName: "IX_Prizes_EPromoId");

            migrationBuilder.RenameColumn(
                name: "PromoId",
                table: "Participants",
                newName: "EPromoId");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_PromoId",
                table: "Participants",
                newName: "IX_Participants_EPromoId");

            migrationBuilder.AlterColumn<int>(
                name: "EPromoId",
                table: "PromoResults",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "EPrizeId",
                table: "PromoResults",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PromoResults_EPrizeId",
                table: "PromoResults",
                column: "EPrizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Promotions_EPromoId",
                table: "Participants",
                column: "EPromoId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prizes_Promotions_EPromoId",
                table: "Prizes",
                column: "EPromoId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PromoResults_Prizes_EPrizeId",
                table: "PromoResults",
                column: "EPrizeId",
                principalTable: "Prizes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PromoResults_Promotions_EPromoId",
                table: "PromoResults",
                column: "EPromoId",
                principalTable: "Promotions",
                principalColumn: "Id");
        }
    }
}
