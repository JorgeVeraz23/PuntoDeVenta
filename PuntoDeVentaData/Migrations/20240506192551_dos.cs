using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class dos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "Logs",
                newName: "RequestID");

            migrationBuilder.RenameColumn(
                name: "StackStrace",
                table: "Logs",
                newName: "StackTrace");

            migrationBuilder.AddColumn<long>(
                name: "CiudadesIdCiudad",
                schema: "SEG",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RequestTraceIdentifier",
                table: "Logs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "AggregatedCounters",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<long>(type: "bigint", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AggregatedCounters", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Archivos",
                columns: table => new
                {
                    IdArchivo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnlacePublico = table.Column<string>(type: "nvarchar(1800)", maxLength: 1800, nullable: false),
                    EnlacePrivado = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    NombreOriginal = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    NombreSistema = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lectura = table.Column<bool>(type: "bit", nullable: false),
                    Escritura = table.Column<bool>(type: "bit", nullable: false),
                    Descarga = table.Column<bool>(type: "bit", nullable: false),
                    Sistema = table.Column<bool>(type: "bit", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    TamanioKb = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TamaniMb = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Imagen = table.Column<bool>(type: "bit", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Alto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ancho = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaCarga = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivos", x => x.IdArchivo);
                });

            migrationBuilder.CreateTable(
                name: "ArchivosCargas",
                columns: table => new
                {
                    idArchivosCarga = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreOriginal = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NombreSistema = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    RutaDescarga = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivosCargas", x => x.idArchivosCarga);
                });

            migrationBuilder.CreateTable(
                name: "AreasReclamos",
                columns: table => new
                {
                    IdAreaReclamos = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaReclamo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ResponsableNivel1 = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    Plazo1 = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    ResponsableNivel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plazo2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoReconocimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codrcsap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CasualSap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasReclamos", x => x.IdAreaReclamos);
                });

            migrationBuilder.CreateTable(
                name: "CargaCorreos",
                columns: table => new
                {
                    NombreResponsable = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargaCorreos", x => x.NombreResponsable);
                });

            migrationBuilder.CreateTable(
                name: "CargaMatrizs",
                columns: table => new
                {
                    IdCargaMatriz = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caso = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SubCodigo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AreaResponsable = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SubMotivo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Clasificacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RequisitosBasicos = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AccionInmediada = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ResponsableNivel1Ecuador = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ResponsableNivel1Perú = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Plazo1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ResponsableNivel2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Plazo2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoDeReconocimiento = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CodRcSap = table.Column<double>(type: "float", nullable: true),
                    CausalSap = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IdMotivo = table.Column<long>(type: "bigint", nullable: false),
                    IdSubMotivo = table.Column<long>(type: "bigint", nullable: false),
                    IdResponsable1 = table.Column<long>(type: "bigint", nullable: false),
                    IdResponsable2 = table.Column<long>(type: "bigint", nullable: false),
                    IdCaso = table.Column<long>(type: "bigint", nullable: false),
                    IdRequisito = table.Column<long>(type: "bigint", nullable: false),
                    IdTipoReconocimiento = table.Column<long>(type: "bigint", nullable: false),
                    IdAccion = table.Column<long>(type: "bigint", nullable: false),
                    IdTipoFicha = table.Column<long>(type: "bigint", nullable: false),
                    IdAreaResponsable = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargaMatrizs", x => x.IdCargaMatriz);
                });

            migrationBuilder.CreateTable(
                name: "Casos",
                columns: table => new
                {
                    IdCasos = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caso = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Motivo = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    SubMotivo = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    TipoFicha = table.Column<long>(type: "bigint", maxLength: 300, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casos", x => x.IdCasos);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaCamarons",
                columns: table => new
                {
                    IdCategoriaCamaron = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoriaCamaron = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaCamarons", x => x.IdCategoriaCamaron);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "ClaimsUsuarios",
                columns: table => new
                {
                    IdClaim = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimsUsuarios", x => x.IdClaim);
                    table.ForeignKey(
                        name: "FK_ClaimsUsuarios_Users_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "SEG",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Continentes",
                columns: table => new
                {
                    IdContinente = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continentes", x => x.IdContinente);
                });

            migrationBuilder.CreateTable(
                name: "CorreoNotifications",
                columns: table => new
                {
                    IdCorreoNotification = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCorreoNotification = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IdIncidencia = table.Column<long>(type: "bigint", nullable: false),
                    isSac = table.Column<bool>(type: "bit", nullable: false),
                    isEvaluacion = table.Column<bool>(type: "bit", nullable: false),
                    isResponsable = table.Column<bool>(type: "bit", nullable: false),
                    isExterno = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorreoNotifications", x => x.IdCorreoNotification);
                });

            migrationBuilder.CreateTable(
                name: "Counters",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    ExpiraAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counters", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Encuestas",
                columns: table => new
                {
                    IdEncuesta = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encuestas", x => x.IdEncuesta);
                });

            migrationBuilder.CreateTable(
                name: "EstadoProcesoFichas",
                columns: table => new
                {
                    IdEstadoProcesoFicha = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoProcesoFichas", x => x.IdEstadoProcesoFicha);
                });

            migrationBuilder.CreateTable(
                name: "EstadosIncidencias",
                columns: table => new
                {
                    IdEstadoIncidencias = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosIncidencias", x => x.IdEstadoIncidencias);
                });

            migrationBuilder.CreateTable(
                name: "Hoja2s",
                columns: table => new
                {
                    SubMotivo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Req = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoja2s", x => x.SubMotivo);
                });

            migrationBuilder.CreateTable(
                name: "Idiomas",
                columns: table => new
                {
                    IdIdiomas = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    WebLang = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AspCulture = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CodigoISO = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Defecto = table.Column<bool>(type: "bit", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idiomas", x => x.IdIdiomas);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<long>(type: "bigint", nullable: true),
                    StateName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    InvocationData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arguments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreguntaCatalogos",
                columns: table => new
                {
                    IdPreguntaCatalogo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pregunta = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreguntaCatalogos", x => x.IdPreguntaCatalogo);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProductos = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sku = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    NombreProducto = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProductos);
                });

            migrationBuilder.CreateTable(
                name: "PuntoVentas",
                columns: table => new
                {
                    IdPuntoVenta = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntoVentas", x => x.IdPuntoVenta);
                });

            migrationBuilder.CreateTable(
                name: "Rutass",
                columns: table => new
                {
                    IdApplicationRoute = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Controlador = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    Accion = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    Modulo = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    NombrePublico = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    MetodosPermitidos = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutass", x => x.IdApplicationRoute);
                });

            migrationBuilder.CreateTable(
                name: "SeguridadNiveles",
                columns: table => new
                {
                    IdNivel = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeguridadNiveles", x => x.IdNivel);
                });

            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Data = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    LastHeartbeat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Solicitantes",
                columns: table => new
                {
                    idSolicitante = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitateSap = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    NombreContacto = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ClienteFinal = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ContactoNombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CodigoSolicitante = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    CodigoNodo = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    Nodo = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    CodigoDestinatario = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    COD_GRUPO_CLIENTE_PRE = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    GRUPO_CLIENTE_PRE = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitantes", x => x.idSolicitante);
                });

            migrationBuilder.CreateTable(
                name: "TablaMatrizs",
                columns: table => new
                {
                    IdTablaMatriz = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caso = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    SubMotivo = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    TipoFicha = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    RequisitosBasico = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    AccionInmediata = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    AreaReclamo = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    ResponsableNivel1Ecuador = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    Plazo1 = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    Plazo2 = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    ResponsableNivel1 = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    ResponsableNivel2 = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    TipoReconocimiento = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    CODRSAP = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    CasualSAP = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    IdCaso = table.Column<long>(type: "bigint", nullable: false),
                    IdMotivo = table.Column<long>(type: "bigint", nullable: false),
                    IdSubMotivo = table.Column<long>(type: "bigint", nullable: false),
                    IdTipoFicha = table.Column<long>(type: "bigint", nullable: false),
                    IdRequisitoBasico = table.Column<long>(type: "bigint", nullable: false),
                    IdAccionInmediada = table.Column<long>(type: "bigint", nullable: false),
                    IdAreaReclamo = table.Column<long>(type: "bigint", nullable: false),
                    IdResponsableNivel1 = table.Column<long>(type: "bigint", nullable: false),
                    IdResponsableNivel2 = table.Column<long>(type: "bigint", nullable: false),
                    IdTipoReconocimiento = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaMatrizs", x => x.IdTablaMatriz);
                });

            migrationBuilder.CreateTable(
                name: "TemporalMatrizCausales",
                columns: table => new
                {
                    IdTemporalMatrizCausales = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caso = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SubCodigo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AreaResponsable = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SubCodigoSubMot = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SubMotivo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Clasificacion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RequisitosBasicos = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AccionInmediata = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    ResponsableNivel1Ecuador = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    ResponsableNivel2Ecuador = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    ResponsableNivel1Peru = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    Plazo1 = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    ResponsableNivel2Peru = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    Plazo2 = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    TipoReconocimientp = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    CodRCSAP = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    CasualSAP = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemporalMatrizCausales", x => x.IdTemporalMatrizCausales);
                });

            migrationBuilder.CreateTable(
                name: "Territorios",
                columns: table => new
                {
                    IdTerritorio = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CodigoTerritorio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Territorios", x => x.IdTerritorio);
                });

            migrationBuilder.CreateTable(
                name: "TipoIncidencias",
                columns: table => new
                {
                    IdTipoIncidencia = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIncidencias", x => x.IdTipoIncidencia);
                });

            migrationBuilder.CreateTable(
                name: "TipoReconocimientos",
                columns: table => new
                {
                    IdTipoReconocimiento = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoReconocimiento = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IdSubMotivo = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoReconocimientos", x => x.IdTipoReconocimiento);
                });

            migrationBuilder.CreateTable(
                name: "ValidacionPreguntas",
                columns: table => new
                {
                    IdValidacionPreguntas = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreValidacionPreguntas = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MaxStringLenght = table.Column<int>(type: "int", nullable: true),
                    MaxDecimals = table.Column<int>(type: "int", nullable: true),
                    MinDecimals = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidacionPreguntas", x => x.IdValidacionPreguntas);
                });

            migrationBuilder.CreateTable(
                name: "ViewDashboardResumenIncidencias",
                columns: table => new
                {
                    IdIncidencias = table.Column<long>(type: "bigint", nullable: false),
                    IdTipoIncidencias = table.Column<long>(type: "bigint", nullable: true),
                    CodReclamo = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    TipoSolicitud = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    FechaReclamo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Clasificacion = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    SubCodigo = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    SubMotivo = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    CodigoMotivo = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    Motivo = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    AreaEvaluado = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    DiasAnalisis = table.Column<int>(type: "int", nullable: true),
                    FechaMaximaCierreMatriz = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCierreAnalisis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dias = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    ClienteSolicitante = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    ClienteFinal = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Territorio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    CodSap = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    ReferenciaPedidoDevolucion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DecisoReclamo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Resolucion = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    Aprobacion = table.Column<int>(type: "int", nullable: true),
                    FechaCierreEfectivo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumeroFactura = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    GestorReclamos = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    CostoAsociadosTransporteDesinfeccionOtros = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    Mes = table.Column<int>(type: "int", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PromedioSatisfaccion = table.Column<double>(type: "float", nullable: true),
                    IdMotivo = table.Column<long>(type: "bigint", nullable: false),
                    IdSubMotivo = table.Column<long>(type: "bigint", nullable: false),
                    IdSolicitante = table.Column<long>(type: "bigint", nullable: false),
                    IdAreaReclamos = table.Column<long>(type: "bigint", nullable: false),
                    IdAsesorComercial = table.Column<long>(type: "bigint", nullable: false),
                    IdGestorReclamo = table.Column<long>(type: "bigint", nullable: false),
                    IdMatriz = table.Column<long>(type: "bigint", nullable: false),
                    IdTipoFicha = table.Column<long>(type: "bigint", nullable: false),
                    IdEstadoProcesoFicha = table.Column<long>(type: "bigint", nullable: false),
                    IdTerritorio = table.Column<long>(type: "bigint", nullable: false),
                    IdResponsableReclamos = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Motivos",
                columns: table => new
                {
                    IdMotivo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IdCaso = table.Column<long>(type: "bigint", nullable: true),
                    CodigoMotivo = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivos", x => x.IdMotivo);
                    table.ForeignKey(
                        name: "FK_Motivos_Casos_IdCaso",
                        column: x => x.IdCaso,
                        principalTable: "Casos",
                        principalColumn: "IdCasos");
                });

            migrationBuilder.CreateTable(
                name: "TipoFichas",
                columns: table => new
                {
                    IdTipoFicha = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IdCaso = table.Column<long>(type: "bigint", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoFichas", x => x.IdTipoFicha);
                    table.ForeignKey(
                        name: "FK_TipoFichas_Casos_IdCaso",
                        column: x => x.IdCaso,
                        principalTable: "Casos",
                        principalColumn: "IdCasos");
                });

            migrationBuilder.CreateTable(
                name: "Productoss",
                columns: table => new
                {
                    IdProducto = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdCategoria = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productoss", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Productoss_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EncuestaDetalles",
                columns: table => new
                {
                    IdEncuestaDetalle = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEncuesta = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaDetalles", x => x.IdEncuestaDetalle);
                    table.ForeignKey(
                        name: "FK_EncuestaDetalles_Encuestas_IdEncuesta",
                        column: x => x.IdEncuesta,
                        principalTable: "Encuestas",
                        principalColumn: "IdEncuesta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    IdPais = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", maxLength: 300, nullable: false),
                    Aplha2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Alpha3 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NombreCS = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    NombreDE = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    NombreEN = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    NombreES = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    NombreFR = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    NombreIT = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    NombreNl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DenominacionEstado = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CodigoTelefonico = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Defecto = table.Column<bool>(type: "bit", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    IdContinente = table.Column<long>(type: "bigint", nullable: false),
                    IdIdioma = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.IdPais);
                    table.ForeignKey(
                        name: "FK_Paises_Continentes_IdContinente",
                        column: x => x.IdContinente,
                        principalTable: "Continentes",
                        principalColumn: "IdContinente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paises_Idiomas_IdIdioma",
                        column: x => x.IdIdioma,
                        principalTable: "Idiomas",
                        principalColumn: "IdIdiomas",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    IdState = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JoId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.IdState);
                    table.ForeignKey(
                        name: "FK_States_Jobs_JoId",
                        column: x => x.JoId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    IdFactura = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<long>(type: "bigint", nullable: false),
                    IdPuntoVenta = table.Column<long>(type: "bigint", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Iva = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.IdFactura);
                    table.ForeignKey(
                        name: "FK_Facturas_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Facturas_PuntoVentas_IdPuntoVenta",
                        column: x => x.IdPuntoVenta,
                        principalTable: "PuntoVentas",
                        principalColumn: "IdPuntoVenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermisosRutas",
                columns: table => new
                {
                    IdApplicationRoutePermission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdApplicationRoute = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisosRutas", x => x.IdApplicationRoutePermission);
                    table.ForeignKey(
                        name: "FK_PermisosRutas_Rutass_IdApplicationRoute",
                        column: x => x.IdApplicationRoute,
                        principalTable: "Rutass",
                        principalColumn: "IdApplicationRoute",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeguridadAreas",
                columns: table => new
                {
                    IdArea = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    SecurityLevelIdNivel = table.Column<int>(type: "int", nullable: true),
                    SeguridadNiveleIdNivel = table.Column<long>(type: "bigint", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeguridadAreas", x => x.IdArea);
                    table.ForeignKey(
                        name: "FK_SeguridadAreas_SeguridadNiveles_SeguridadNiveleIdNivel",
                        column: x => x.SeguridadNiveleIdNivel,
                        principalTable: "SeguridadNiveles",
                        principalColumn: "IdNivel");
                });

            migrationBuilder.CreateTable(
                name: "AsesorComercials",
                columns: table => new
                {
                    IdAsesorComercial = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdTerritorio = table.Column<long>(type: "bigint", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsesorComercials", x => x.IdAsesorComercial);
                    table.ForeignKey(
                        name: "FK_AsesorComercials_Territorios_IdTerritorio",
                        column: x => x.IdTerritorio,
                        principalTable: "Territorios",
                        principalColumn: "IdTerritorio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AsesorTecnicos",
                columns: table => new
                {
                    IdAsesorTecnico = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdTerritorio = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsesorTecnicos", x => x.IdAsesorTecnico);
                    table.ForeignKey(
                        name: "FK_AsesorTecnicos_Territorios_IdTerritorio",
                        column: x => x.IdTerritorio,
                        principalTable: "Territorios",
                        principalColumn: "IdTerritorio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GestorReclamos",
                columns: table => new
                {
                    IdGestorReclamo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdTerritorio = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GestorReclamos", x => x.IdGestorReclamo);
                    table.ForeignKey(
                        name: "FK_GestorReclamos_Territorios_IdTerritorio",
                        column: x => x.IdTerritorio,
                        principalTable: "Territorios",
                        principalColumn: "IdTerritorio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponsableReclamos",
                columns: table => new
                {
                    IdResponsableReclamos = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreResposable = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NivelReclamo = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IdTerritorio = table.Column<long>(type: "bigint", nullable: false),
                    IdAreaReclamo = table.Column<long>(type: "bigint", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsableReclamos", x => x.IdResponsableReclamos);
                    table.ForeignKey(
                        name: "FK_ResponsableReclamos_AreasReclamos_IdAreaReclamo",
                        column: x => x.IdAreaReclamo,
                        principalTable: "AreasReclamos",
                        principalColumn: "IdAreaReclamos");
                    table.ForeignKey(
                        name: "FK_ResponsableReclamos_Territorios_IdTerritorio",
                        column: x => x.IdTerritorio,
                        principalTable: "Territorios",
                        principalColumn: "IdTerritorio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitosTipoFichas",
                columns: table => new
                {
                    IdRequisitoTipoFicha = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Requisito = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IdTipoFicha = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitosTipoFichas", x => x.IdRequisitoTipoFicha);
                    table.ForeignKey(
                        name: "FK_RequisitosTipoFichas_TipoFichas_IdTipoFicha",
                        column: x => x.IdTipoFicha,
                        principalTable: "TipoFichas",
                        principalColumn: "IdTipoFicha",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrupoDePreguntas",
                columns: table => new
                {
                    IdGrupoPreguntas = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreGrupoDePreguntas = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EncuestaDetalleIdEncuestaDetalle = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoDePreguntas", x => x.IdGrupoPreguntas);
                    table.ForeignKey(
                        name: "FK_GrupoDePreguntas_EncuestaDetalles_EncuestaDetalleIdEncuestaDetalle",
                        column: x => x.EncuestaDetalleIdEncuestaDetalle,
                        principalTable: "EncuestaDetalles",
                        principalColumn: "IdEncuestaDetalle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Regiones",
                columns: table => new
                {
                    IdRegiones = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdPais = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiones", x => x.IdRegiones);
                    table.ForeignKey(
                        name: "FK_Regiones_Paises_IdPais",
                        column: x => x.IdPais,
                        principalTable: "Paises",
                        principalColumn: "IdPais",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacturaDetalles",
                columns: table => new
                {
                    IdFacturaDetalle = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFactura = table.Column<long>(type: "bigint", nullable: false),
                    IdProducto = table.Column<long>(type: "bigint", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IVA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaDetalles", x => x.IdFacturaDetalle);
                    table.ForeignKey(
                        name: "FK_FacturaDetalles_Facturas_IdFactura",
                        column: x => x.IdFactura,
                        principalTable: "Facturas",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturaDetalles_Productoss_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productoss",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permiso",
                columns: table => new
                {
                    IdPermiso = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    IdArea = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.IdPermiso);
                    table.ForeignKey(
                        name: "FK_Permiso_SeguridadAreas_IdArea",
                        column: x => x.IdArea,
                        principalTable: "SeguridadAreas",
                        principalColumn: "IdArea",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreasResponsables",
                columns: table => new
                {
                    IdAreasResponsables = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdResponsableReclamo = table.Column<long>(type: "bigint", nullable: true),
                    IdAreaReclamo = table.Column<long>(type: "bigint", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasResponsables", x => x.IdAreasResponsables);
                    table.ForeignKey(
                        name: "FK_AreasResponsables_AreasReclamos_IdAreaReclamo",
                        column: x => x.IdAreaReclamo,
                        principalTable: "AreasReclamos",
                        principalColumn: "IdAreaReclamos");
                    table.ForeignKey(
                        name: "FK_AreasResponsables_ResponsableReclamos_IdResponsableReclamo",
                        column: x => x.IdResponsableReclamo,
                        principalTable: "ResponsableReclamos",
                        principalColumn: "IdResponsableReclamos");
                });

            migrationBuilder.CreateTable(
                name: "AccionesRequisitoFichas",
                columns: table => new
                {
                    IdAccionRequisitosFicha = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAccion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IdRequisitoTipoFicha = table.Column<long>(type: "bigint", nullable: true),
                    IdAreaReclamo = table.Column<long>(type: "bigint", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccionesRequisitoFichas", x => x.IdAccionRequisitosFicha);
                    table.ForeignKey(
                        name: "FK_AccionesRequisitoFichas_AreasReclamos_IdAreaReclamo",
                        column: x => x.IdAreaReclamo,
                        principalTable: "AreasReclamos",
                        principalColumn: "IdAreaReclamos");
                    table.ForeignKey(
                        name: "FK_AccionesRequisitoFichas_RequisitosTipoFichas_IdRequisitoTipoFicha",
                        column: x => x.IdRequisitoTipoFicha,
                        principalTable: "RequisitosTipoFichas",
                        principalColumn: "IdRequisitoTipoFicha");
                });

            migrationBuilder.CreateTable(
                name: "SubMotivos",
                columns: table => new
                {
                    IdSubMotivo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreSubMotivo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IdMotivoss = table.Column<long>(type: "bigint", nullable: false),
                    IdTipoReconocimiento = table.Column<long>(type: "bigint", nullable: false),
                    IdRequisitoTipoFicha = table.Column<long>(type: "bigint", nullable: false),
                    PlazoNivel1 = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    PlazoNivel2 = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    CodigoSubMotivo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubMotivos", x => x.IdSubMotivo);
                    table.ForeignKey(
                        name: "FK_SubMotivos_Motivos_IdMotivoss",
                        column: x => x.IdMotivoss,
                        principalTable: "Motivos",
                        principalColumn: "IdMotivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubMotivos_RequisitosTipoFichas_IdRequisitoTipoFicha",
                        column: x => x.IdRequisitoTipoFicha,
                        principalTable: "RequisitosTipoFichas",
                        principalColumn: "IdRequisitoTipoFicha",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubMotivos_TipoReconocimientos_IdTipoReconocimiento",
                        column: x => x.IdTipoReconocimiento,
                        principalTable: "TipoReconocimientos",
                        principalColumn: "IdTipoReconocimiento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Preguntas",
                columns: table => new
                {
                    IdPreguntas = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pregunta = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    IdGrupoDePreguntas = table.Column<long>(type: "bigint", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preguntas", x => x.IdPreguntas);
                    table.ForeignKey(
                        name: "FK_Preguntas_GrupoDePreguntas_IdGrupoDePreguntas",
                        column: x => x.IdGrupoDePreguntas,
                        principalTable: "GrupoDePreguntas",
                        principalColumn: "IdGrupoPreguntas");
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    IdEstado = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IdPais = table.Column<long>(type: "bigint", nullable: false),
                    IdRegion = table.Column<long>(type: "bigint", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.IdEstado);
                    table.ForeignKey(
                        name: "FK_Estados_Paises_IdPais",
                        column: x => x.IdPais,
                        principalTable: "Paises",
                        principalColumn: "IdPais",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estados_Regiones_IdRegion",
                        column: x => x.IdRegion,
                        principalTable: "Regiones",
                        principalColumn: "IdRegiones");
                });

            migrationBuilder.CreateTable(
                name: "Incidencias",
                columns: table => new
                {
                    IdIncidencias = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaReporteIncidencia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceptorIncidencia = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NotificacionNivel2Enviada = table.Column<bool>(type: "bit", nullable: false),
                    IdAsesorComercial = table.Column<long>(type: "bigint", nullable: true),
                    IdAsesorTecnico = table.Column<long>(type: "bigint", nullable: true),
                    IdGestorReclamo = table.Column<long>(type: "bigint", nullable: true),
                    FechaProcedeIncidencia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ComentarioProcede = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ComnetarioEvComercial = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PersonaEvComercial = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FechaFicha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CodigoFicha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTerritorio = table.Column<long>(type: "bigint", nullable: true),
                    DevolucionProducto = table.Column<bool>(type: "bit", nullable: false),
                    CambioProducto = table.Column<bool>(type: "bit", nullable: false),
                    Otros = table.Column<bool>(type: "bit", nullable: false),
                    Compensacion = table.Column<bool>(type: "bit", nullable: false),
                    CantidadDevolucionProducto = table.Column<int>(type: "int", nullable: true),
                    MontoDevolucionProducto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CantidadCambioProducto = table.Column<int>(type: "int", nullable: true),
                    OtrosMotivosProductos = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    MontoCambioProducto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CantidadCompensacion = table.Column<int>(type: "int", nullable: true),
                    MontoCompensacion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdTipoIncidencias = table.Column<long>(type: "bigint", nullable: true),
                    IdSolicitante = table.Column<long>(type: "bigint", nullable: true),
                    FinalObservacion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IdEstadoIncidencias = table.Column<long>(type: "bigint", nullable: true),
                    IdResponsableNivel1 = table.Column<long>(type: "bigint", nullable: true),
                    IdResponsableNivel2 = table.Column<long>(type: "bigint", nullable: true),
                    IdCaso = table.Column<long>(type: "bigint", nullable: true),
                    IdAreaReclamo = table.Column<long>(type: "bigint", nullable: true),
                    IdMotivo = table.Column<long>(type: "bigint", nullable: true),
                    IdSubmotivo = table.Column<long>(type: "bigint", nullable: true),
                    IdCorreoNotificacion = table.Column<long>(type: "bigint", nullable: true),
                    IdEstadoProcesoFicha = table.Column<long>(type: "bigint", nullable: true),
                    EvNivel1 = table.Column<bool>(type: "bit", nullable: false),
                    Generada = table.Column<bool>(type: "bit", nullable: false),
                    FechaEvNivel1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EvNivel2 = table.Column<bool>(type: "bit", nullable: false),
                    FechaEvNivel2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CostoAsociado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ObservacionesCostoAsociado = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AnalisisConcluido = table.Column<bool>(type: "bit", nullable: false),
                    ProcedeAnalisisConcluido = table.Column<bool>(type: "bit", nullable: false),
                    NoProcedeAnalisisConcluido = table.Column<bool>(type: "bit", nullable: false),
                    ProcedeEvComercial = table.Column<bool>(type: "bit", nullable: false),
                    NoProcedeEvComercial = table.Column<bool>(type: "bit", nullable: false),
                    OtroComentario = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    FechaAnalisisConcluido = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaMaximaCierreAnalisis = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEvComercialAccion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiasCierreEfectivo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiasCierreAnalisis = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumeroFactura = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Aprobacion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EvComercial = table.Column<bool>(type: "bit", nullable: false),
                    FechaEvComercial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CodigoSAP = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CierreEfectivo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCierreEfectivo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Resolucion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SubCodigo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IdTipoFicha = table.Column<long>(type: "bigint", nullable: true),
                    DecisorNivel1 = table.Column<bool>(type: "bit", nullable: false),
                    DecisorNivel2 = table.Column<bool>(type: "bit", nullable: false),
                    PlazoNivel1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlazoNivel2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlazoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NombrePersonaProcede = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    NombreEvComercial = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ComentarioVistaEvComercial = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    ReferenciaPedidoDevolucion = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    FechaEnvioCorreoEvComercial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoFichaIdTipoFicha = table.Column<long>(type: "bigint", nullable: true),
                    EstadosIncidenciasIdEstadoIncidencias = table.Column<long>(type: "bigint", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidencias", x => x.IdIncidencias);
                    table.ForeignKey(
                        name: "FK_Incidencias_AreasReclamos_IdAreaReclamo",
                        column: x => x.IdAreaReclamo,
                        principalTable: "AreasReclamos",
                        principalColumn: "IdAreaReclamos");
                    table.ForeignKey(
                        name: "FK_Incidencias_AsesorComercials_IdAsesorComercial",
                        column: x => x.IdAsesorComercial,
                        principalTable: "AsesorComercials",
                        principalColumn: "IdAsesorComercial");
                    table.ForeignKey(
                        name: "FK_Incidencias_AsesorTecnicos_IdAsesorTecnico",
                        column: x => x.IdAsesorTecnico,
                        principalTable: "AsesorTecnicos",
                        principalColumn: "IdAsesorTecnico");
                    table.ForeignKey(
                        name: "FK_Incidencias_Casos_IdCaso",
                        column: x => x.IdCaso,
                        principalTable: "Casos",
                        principalColumn: "IdCasos");
                    table.ForeignKey(
                        name: "FK_Incidencias_CorreoNotifications_IdCorreoNotificacion",
                        column: x => x.IdCorreoNotificacion,
                        principalTable: "CorreoNotifications",
                        principalColumn: "IdCorreoNotification");
                    table.ForeignKey(
                        name: "FK_Incidencias_EstadoProcesoFichas_IdEstadoProcesoFicha",
                        column: x => x.IdEstadoProcesoFicha,
                        principalTable: "EstadoProcesoFichas",
                        principalColumn: "IdEstadoProcesoFicha");
                    table.ForeignKey(
                        name: "FK_Incidencias_EstadosIncidencias_EstadosIncidenciasIdEstadoIncidencias",
                        column: x => x.EstadosIncidenciasIdEstadoIncidencias,
                        principalTable: "EstadosIncidencias",
                        principalColumn: "IdEstadoIncidencias");
                    table.ForeignKey(
                        name: "FK_Incidencias_GestorReclamos_IdGestorReclamo",
                        column: x => x.IdGestorReclamo,
                        principalTable: "GestorReclamos",
                        principalColumn: "IdGestorReclamo");
                    table.ForeignKey(
                        name: "FK_Incidencias_Motivos_IdMotivo",
                        column: x => x.IdMotivo,
                        principalTable: "Motivos",
                        principalColumn: "IdMotivo");
                    table.ForeignKey(
                        name: "FK_Incidencias_ResponsableReclamos_IdResponsableNivel1",
                        column: x => x.IdResponsableNivel1,
                        principalTable: "ResponsableReclamos",
                        principalColumn: "IdResponsableReclamos");
                    table.ForeignKey(
                        name: "FK_Incidencias_ResponsableReclamos_IdResponsableNivel2",
                        column: x => x.IdResponsableNivel2,
                        principalTable: "ResponsableReclamos",
                        principalColumn: "IdResponsableReclamos");
                    table.ForeignKey(
                        name: "FK_Incidencias_Solicitantes_IdSolicitante",
                        column: x => x.IdSolicitante,
                        principalTable: "Solicitantes",
                        principalColumn: "idSolicitante");
                    table.ForeignKey(
                        name: "FK_Incidencias_SubMotivos_IdSubmotivo",
                        column: x => x.IdSubmotivo,
                        principalTable: "SubMotivos",
                        principalColumn: "IdSubMotivo");
                    table.ForeignKey(
                        name: "FK_Incidencias_Territorios_IdTerritorio",
                        column: x => x.IdTerritorio,
                        principalTable: "Territorios",
                        principalColumn: "IdTerritorio");
                    table.ForeignKey(
                        name: "FK_Incidencias_TipoFichas_TipoFichaIdTipoFicha",
                        column: x => x.TipoFichaIdTipoFicha,
                        principalTable: "TipoFichas",
                        principalColumn: "IdTipoFicha");
                    table.ForeignKey(
                        name: "FK_Incidencias_TipoIncidencias_IdTipoIncidencias",
                        column: x => x.IdTipoIncidencias,
                        principalTable: "TipoIncidencias",
                        principalColumn: "IdTipoIncidencia");
                });

            migrationBuilder.CreateTable(
                name: "Matrizs",
                columns: table => new
                {
                    IdMatriz = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCasos = table.Column<long>(type: "bigint", nullable: false),
                    IdMotivos = table.Column<long>(type: "bigint", nullable: false),
                    IdSubMotivo = table.Column<long>(type: "bigint", nullable: true),
                    IdTipoReconocimiento = table.Column<long>(type: "bigint", nullable: false),
                    IdTipoFicha = table.Column<long>(type: "bigint", nullable: true),
                    IdAreaReclamos = table.Column<long>(type: "bigint", nullable: false),
                    IdRequisitoFicha = table.Column<long>(type: "bigint", nullable: false),
                    IdAccionesRequisitoFicha = table.Column<long>(type: "bigint", nullable: false),
                    IdResponsableReclamo1 = table.Column<long>(type: "bigint", nullable: true),
                    IdResponsableReclamo2 = table.Column<long>(type: "bigint", nullable: true),
                    Plazo1 = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    Plazo2 = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    CODRCSAP = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CausalSAP = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    CodigoMotivo = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    CodigoSubMotivo = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matrizs", x => x.IdMatriz);
                    table.ForeignKey(
                        name: "FK_Matrizs_AccionesRequisitoFichas_IdAccionesRequisitoFicha",
                        column: x => x.IdAccionesRequisitoFicha,
                        principalTable: "AccionesRequisitoFichas",
                        principalColumn: "IdAccionRequisitosFicha",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matrizs_AreasReclamos_IdAreaReclamos",
                        column: x => x.IdAreaReclamos,
                        principalTable: "AreasReclamos",
                        principalColumn: "IdAreaReclamos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matrizs_Casos_IdCasos",
                        column: x => x.IdCasos,
                        principalTable: "Casos",
                        principalColumn: "IdCasos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matrizs_Motivos_IdMotivos",
                        column: x => x.IdMotivos,
                        principalTable: "Motivos",
                        principalColumn: "IdMotivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matrizs_RequisitosTipoFichas_IdRequisitoFicha",
                        column: x => x.IdRequisitoFicha,
                        principalTable: "RequisitosTipoFichas",
                        principalColumn: "IdRequisitoTipoFicha",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matrizs_ResponsableReclamos_IdResponsableReclamo1",
                        column: x => x.IdResponsableReclamo1,
                        principalTable: "ResponsableReclamos",
                        principalColumn: "IdResponsableReclamos");
                    table.ForeignKey(
                        name: "FK_Matrizs_ResponsableReclamos_IdResponsableReclamo2",
                        column: x => x.IdResponsableReclamo2,
                        principalTable: "ResponsableReclamos",
                        principalColumn: "IdResponsableReclamos");
                    table.ForeignKey(
                        name: "FK_Matrizs_SubMotivos_IdSubMotivo",
                        column: x => x.IdSubMotivo,
                        principalTable: "SubMotivos",
                        principalColumn: "IdSubMotivo");
                    table.ForeignKey(
                        name: "FK_Matrizs_TipoFichas_IdTipoFicha",
                        column: x => x.IdTipoFicha,
                        principalTable: "TipoFichas",
                        principalColumn: "IdTipoFicha");
                    table.ForeignKey(
                        name: "FK_Matrizs_TipoReconocimientos_IdTipoReconocimiento",
                        column: x => x.IdTipoReconocimiento,
                        principalTable: "TipoReconocimientos",
                        principalColumn: "IdTipoReconocimiento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemporalIncidencias",
                columns: table => new
                {
                    IdIncidencias = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaReporteIncidencias = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceptorIncidencia = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    IdAsesorComercial = table.Column<long>(type: "bigint", nullable: false),
                    IdAsesorTecnico = table.Column<long>(type: "bigint", nullable: true),
                    IdGestorReclamo = table.Column<long>(type: "bigint", nullable: true),
                    FechaFicha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodigoFicha = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    IdTerritorio = table.Column<long>(type: "bigint", nullable: true),
                    DevolucionProducto = table.Column<bool>(type: "bit", nullable: false),
                    CambioProducto = table.Column<bool>(type: "bit", nullable: false),
                    Compensacion = table.Column<bool>(type: "bit", nullable: false),
                    CantidadDevolucionProducto = table.Column<int>(type: "int", nullable: false),
                    MontoDevolucionProducto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CantidadCambioProducto = table.Column<int>(type: "int", nullable: false),
                    MontoCompensacion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoCambioProducto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CantidadCompensacion = table.Column<int>(type: "int", nullable: false),
                    IdTipoIncidencias = table.Column<long>(type: "bigint", nullable: false),
                    IdSolicitante = table.Column<long>(type: "bigint", nullable: false),
                    FinalObservacion = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    IdEstadoIncidencias = table.Column<long>(type: "bigint", nullable: false),
                    IdResponsableNivel1 = table.Column<long>(type: "bigint", nullable: true),
                    IdCaso = table.Column<long>(type: "bigint", nullable: false),
                    IdAreaReclamo = table.Column<long>(type: "bigint", nullable: false),
                    IdMotivo = table.Column<long>(type: "bigint", nullable: true),
                    IdSubMotivo = table.Column<long>(type: "bigint", nullable: false),
                    IdResponsableNivel2 = table.Column<long>(type: "bigint", nullable: true),
                    IdEstadoProcesoFicha = table.Column<long>(type: "bigint", nullable: false),
                    EvNivel1 = table.Column<bool>(type: "bit", nullable: false),
                    FechaEvNivel1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EvNivel2 = table.Column<bool>(type: "bit", nullable: false),
                    FechaEvNivel2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CostoAsociado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ObservacionesCostoAsociado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalisisConcluido = table.Column<bool>(type: "bit", nullable: false),
                    FechaAnalisisConcluido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EvComercial = table.Column<bool>(type: "bit", nullable: false),
                    FechaEvComercial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CierreEfectivo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCierreEfectivo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Generada = table.Column<bool>(type: "bit", nullable: false),
                    FechaMaximaCierreAnalisis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiasCierreEfectivo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CodigoSAP = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    Resolucion = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    SubCodigo = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    IdTipoFicha = table.Column<long>(type: "bigint", nullable: true),
                    DecisoNivel1 = table.Column<bool>(type: "bit", nullable: false),
                    DecisorNivel2 = table.Column<bool>(type: "bit", nullable: false),
                    ProcedeAnalisisConcluido = table.Column<bool>(type: "bit", nullable: false),
                    NoProcedeAnalisisConcluido = table.Column<bool>(type: "bit", nullable: false),
                    OtroComentario = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    PlazoNivel1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlazoNivel2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlazoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FehaProcedeIncidencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComentarioProcede = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    NombrePersonaProcede = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ComentarioEvComercial = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    PersonaEvComercial = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ProcedeEvComercial = table.Column<bool>(type: "bit", nullable: false),
                    NoProcedeEvComercial = table.Column<bool>(type: "bit", nullable: false),
                    FechaEvComercialAccion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreEvComercial = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FechaEnvioCorreoEvComercial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotificacionNivel2Enviado = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemporalIncidencias", x => x.IdIncidencias);
                    table.ForeignKey(
                        name: "FK_TemporalIncidencias_AreasReclamos_IdAreaReclamo",
                        column: x => x.IdAreaReclamo,
                        principalTable: "AreasReclamos",
                        principalColumn: "IdAreaReclamos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemporalIncidencias_AsesorComercials_IdAsesorComercial",
                        column: x => x.IdAsesorComercial,
                        principalTable: "AsesorComercials",
                        principalColumn: "IdAsesorComercial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemporalIncidencias_AsesorTecnicos_IdAsesorTecnico",
                        column: x => x.IdAsesorTecnico,
                        principalTable: "AsesorTecnicos",
                        principalColumn: "IdAsesorTecnico");
                    table.ForeignKey(
                        name: "FK_TemporalIncidencias_Casos_IdCaso",
                        column: x => x.IdCaso,
                        principalTable: "Casos",
                        principalColumn: "IdCasos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemporalIncidencias_EstadoProcesoFichas_IdEstadoProcesoFicha",
                        column: x => x.IdEstadoProcesoFicha,
                        principalTable: "EstadoProcesoFichas",
                        principalColumn: "IdEstadoProcesoFicha",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemporalIncidencias_EstadosIncidencias_IdEstadoIncidencias",
                        column: x => x.IdEstadoIncidencias,
                        principalTable: "EstadosIncidencias",
                        principalColumn: "IdEstadoIncidencias",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemporalIncidencias_GestorReclamos_IdGestorReclamo",
                        column: x => x.IdGestorReclamo,
                        principalTable: "GestorReclamos",
                        principalColumn: "IdGestorReclamo");
                    table.ForeignKey(
                        name: "FK_TemporalIncidencias_Motivos_IdMotivo",
                        column: x => x.IdMotivo,
                        principalTable: "Motivos",
                        principalColumn: "IdMotivo");
                    table.ForeignKey(
                        name: "FK_TemporalIncidencias_ResponsableReclamos_IdResponsableNivel1",
                        column: x => x.IdResponsableNivel1,
                        principalTable: "ResponsableReclamos",
                        principalColumn: "IdResponsableReclamos");
                    table.ForeignKey(
                        name: "FK_TemporalIncidencias_ResponsableReclamos_IdResponsableNivel2",
                        column: x => x.IdResponsableNivel2,
                        principalTable: "ResponsableReclamos",
                        principalColumn: "IdResponsableReclamos");
                    table.ForeignKey(
                        name: "FK_TemporalIncidencias_Solicitantes_IdSolicitante",
                        column: x => x.IdSolicitante,
                        principalTable: "Solicitantes",
                        principalColumn: "idSolicitante",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemporalIncidencias_SubMotivos_IdSubMotivo",
                        column: x => x.IdSubMotivo,
                        principalTable: "SubMotivos",
                        principalColumn: "IdSubMotivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemporalIncidencias_Territorios_IdTerritorio",
                        column: x => x.IdTerritorio,
                        principalTable: "Territorios",
                        principalColumn: "IdTerritorio");
                    table.ForeignKey(
                        name: "FK_TemporalIncidencias_TipoFichas_IdTipoFicha",
                        column: x => x.IdTipoFicha,
                        principalTable: "TipoFichas",
                        principalColumn: "IdTipoFicha");
                    table.ForeignKey(
                        name: "FK_TemporalIncidencias_TipoIncidencias_IdTipoIncidencias",
                        column: x => x.IdTipoIncidencias,
                        principalTable: "TipoIncidencias",
                        principalColumn: "IdTipoIncidencia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    IdCiudad = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Latitud = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitud = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdEstado = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.IdCiudad);
                    table.ForeignKey(
                        name: "FK_Ciudades_Estados_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "Estados",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArchivosCargaIncidencia",
                columns: table => new
                {
                    IdArchivoCargaIncidencia = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdIncidencias = table.Column<long>(type: "bigint", nullable: false),
                    ProcesoIncidencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdArchivosCarga = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivosCargaIncidencia", x => x.IdArchivoCargaIncidencia);
                    table.ForeignKey(
                        name: "FK_ArchivosCargaIncidencia_ArchivosCargas_IdArchivosCarga",
                        column: x => x.IdArchivosCarga,
                        principalTable: "ArchivosCargas",
                        principalColumn: "idArchivosCarga",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArchivosCargaIncidencia_Incidencias_IdIncidencias",
                        column: x => x.IdIncidencias,
                        principalTable: "Incidencias",
                        principalColumn: "IdIncidencias",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaSeleccionadas",
                columns: table => new
                {
                    IdCategoriaSeleccionada = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdIncidencia = table.Column<long>(type: "bigint", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IdCategoriaCamaron = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaSeleccionadas", x => x.IdCategoriaSeleccionada);
                    table.ForeignKey(
                        name: "FK_CategoriaSeleccionadas_CategoriaCamarons_IdCategoriaCamaron",
                        column: x => x.IdCategoriaCamaron,
                        principalTable: "CategoriaCamarons",
                        principalColumn: "IdCategoriaCamaron",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaSeleccionadas_Incidencias_IdIncidencia",
                        column: x => x.IdIncidencia,
                        principalTable: "Incidencias",
                        principalColumn: "IdIncidencias",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EncuestaIncidencias",
                columns: table => new
                {
                    IdEncuesta = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdIncidencia = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaIncidencias", x => x.IdEncuesta);
                    table.ForeignKey(
                        name: "FK_EncuestaIncidencias_Incidencias_IdIncidencia",
                        column: x => x.IdIncidencia,
                        principalTable: "Incidencias",
                        principalColumn: "IdIncidencias",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogAccionesIncidencias",
                columns: table => new
                {
                    IdLogAccionesInciencia = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdIncidencia = table.Column<long>(type: "bigint", nullable: false),
                    Acciones = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    DescripcionAccion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IdArchivo = table.Column<long>(type: "bigint", nullable: false),
                    CorreoEnvioLog = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CorreoEnviado = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FechaEnvioCorreo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CorreoDerivado = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogAccionesIncidencias", x => x.IdLogAccionesInciencia);
                    table.ForeignKey(
                        name: "FK_LogAccionesIncidencias_Archivos_IdArchivo",
                        column: x => x.IdArchivo,
                        principalTable: "Archivos",
                        principalColumn: "IdArchivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogAccionesIncidencias_Incidencias_IdIncidencia",
                        column: x => x.IdIncidencia,
                        principalTable: "Incidencias",
                        principalColumn: "IdIncidencias",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductosIncidencias",
                columns: table => new
                {
                    IdProductosIncidencias = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdIncidencias = table.Column<long>(type: "bigint", nullable: false),
                    IdProducto = table.Column<long>(type: "bigint", nullable: false),
                    Lote = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoFactura = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    NoGuiaRemision = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CantidadComprada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CantidadReclamo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DetalleProblema = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosIncidencias", x => x.IdProductosIncidencias);
                    table.ForeignKey(
                        name: "FK_ProductosIncidencias_Incidencias_IdIncidencias",
                        column: x => x.IdIncidencias,
                        principalTable: "Incidencias",
                        principalColumn: "IdIncidencias",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductosIncidencias_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProductos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RespuestaEncuestaIncidencias",
                columns: table => new
                {
                    IdRespuestaEncuestaIncidencia = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEncuesta = table.Column<long>(type: "bigint", nullable: false),
                    IdPregunta = table.Column<long>(type: "bigint", nullable: false),
                    Respuesta = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespuestaEncuestaIncidencias", x => x.IdRespuestaEncuestaIncidencia);
                    table.ForeignKey(
                        name: "FK_RespuestaEncuestaIncidencias_EncuestaIncidencias_IdEncuesta",
                        column: x => x.IdEncuesta,
                        principalTable: "EncuestaIncidencias",
                        principalColumn: "IdEncuesta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespuestaEncuestaIncidencias_PreguntaCatalogos_IdPregunta",
                        column: x => x.IdPregunta,
                        principalTable: "PreguntaCatalogos",
                        principalColumn: "IdPreguntaCatalogo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respuestas",
                columns: table => new
                {
                    IdRespuesta = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEncuesta = table.Column<long>(type: "bigint", nullable: false),
                    IdPregunta = table.Column<long>(type: "bigint", nullable: false),
                    RespuestaPregunta = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    EncuestaIncidenciaIdEncuesta = table.Column<long>(type: "bigint", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IpModification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpDelete = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuestas", x => x.IdRespuesta);
                    table.ForeignKey(
                        name: "FK_Respuestas_EncuestaDetalles_IdEncuesta",
                        column: x => x.IdEncuesta,
                        principalTable: "EncuestaDetalles",
                        principalColumn: "IdEncuestaDetalle",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Respuestas_EncuestaIncidencias_EncuestaIncidenciaIdEncuesta",
                        column: x => x.EncuestaIncidenciaIdEncuesta,
                        principalTable: "EncuestaIncidencias",
                        principalColumn: "IdEncuesta");
                    table.ForeignKey(
                        name: "FK_Respuestas_Preguntas_IdPregunta",
                        column: x => x.IdPregunta,
                        principalTable: "Preguntas",
                        principalColumn: "IdPreguntas",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "SEG",
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "CiudadesIdCiudad",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CiudadesIdCiudad",
                schema: "SEG",
                table: "Users",
                column: "CiudadesIdCiudad");

            migrationBuilder.CreateIndex(
                name: "IX_AccionesRequisitoFichas_IdAreaReclamo",
                table: "AccionesRequisitoFichas",
                column: "IdAreaReclamo");

            migrationBuilder.CreateIndex(
                name: "IX_AccionesRequisitoFichas_IdRequisitoTipoFicha",
                table: "AccionesRequisitoFichas",
                column: "IdRequisitoTipoFicha");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosCargaIncidencia_IdArchivosCarga",
                table: "ArchivosCargaIncidencia",
                column: "IdArchivosCarga");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosCargaIncidencia_IdIncidencias",
                table: "ArchivosCargaIncidencia",
                column: "IdIncidencias");

            migrationBuilder.CreateIndex(
                name: "IX_AreasResponsables_IdAreaReclamo",
                table: "AreasResponsables",
                column: "IdAreaReclamo");

            migrationBuilder.CreateIndex(
                name: "IX_AreasResponsables_IdResponsableReclamo",
                table: "AreasResponsables",
                column: "IdResponsableReclamo");

            migrationBuilder.CreateIndex(
                name: "IX_AsesorComercials_IdTerritorio",
                table: "AsesorComercials",
                column: "IdTerritorio");

            migrationBuilder.CreateIndex(
                name: "IX_AsesorTecnicos_IdTerritorio",
                table: "AsesorTecnicos",
                column: "IdTerritorio");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaSeleccionadas_IdCategoriaCamaron",
                table: "CategoriaSeleccionadas",
                column: "IdCategoriaCamaron");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaSeleccionadas_IdIncidencia",
                table: "CategoriaSeleccionadas",
                column: "IdIncidencia");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_IdEstado",
                table: "Ciudades",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimsUsuarios_IdUsuario",
                table: "ClaimsUsuarios",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaDetalles_IdEncuesta",
                table: "EncuestaDetalles",
                column: "IdEncuesta");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaIncidencias_IdIncidencia",
                table: "EncuestaIncidencias",
                column: "IdIncidencia");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_IdPais",
                table: "Estados",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_IdRegion",
                table: "Estados",
                column: "IdRegion");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalles_IdFactura",
                table: "FacturaDetalles",
                column: "IdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalles_IdProducto",
                table: "FacturaDetalles",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_IdCliente",
                table: "Facturas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_IdPuntoVenta",
                table: "Facturas",
                column: "IdPuntoVenta");

            migrationBuilder.CreateIndex(
                name: "IX_GestorReclamos_IdTerritorio",
                table: "GestorReclamos",
                column: "IdTerritorio");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoDePreguntas_EncuestaDetalleIdEncuestaDetalle",
                table: "GrupoDePreguntas",
                column: "EncuestaDetalleIdEncuestaDetalle");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_EstadosIncidenciasIdEstadoIncidencias",
                table: "Incidencias",
                column: "EstadosIncidenciasIdEstadoIncidencias");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_IdAreaReclamo",
                table: "Incidencias",
                column: "IdAreaReclamo");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_IdAsesorComercial",
                table: "Incidencias",
                column: "IdAsesorComercial");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_IdAsesorTecnico",
                table: "Incidencias",
                column: "IdAsesorTecnico");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_IdCaso",
                table: "Incidencias",
                column: "IdCaso");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_IdCorreoNotificacion",
                table: "Incidencias",
                column: "IdCorreoNotificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_IdEstadoProcesoFicha",
                table: "Incidencias",
                column: "IdEstadoProcesoFicha");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_IdGestorReclamo",
                table: "Incidencias",
                column: "IdGestorReclamo");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_IdMotivo",
                table: "Incidencias",
                column: "IdMotivo");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_IdResponsableNivel1",
                table: "Incidencias",
                column: "IdResponsableNivel1");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_IdResponsableNivel2",
                table: "Incidencias",
                column: "IdResponsableNivel2");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_IdSolicitante",
                table: "Incidencias",
                column: "IdSolicitante");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_IdSubmotivo",
                table: "Incidencias",
                column: "IdSubmotivo");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_IdTerritorio",
                table: "Incidencias",
                column: "IdTerritorio");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_IdTipoIncidencias",
                table: "Incidencias",
                column: "IdTipoIncidencias");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_TipoFichaIdTipoFicha",
                table: "Incidencias",
                column: "TipoFichaIdTipoFicha");

            migrationBuilder.CreateIndex(
                name: "IX_LogAccionesIncidencias_IdArchivo",
                table: "LogAccionesIncidencias",
                column: "IdArchivo");

            migrationBuilder.CreateIndex(
                name: "IX_LogAccionesIncidencias_IdIncidencia",
                table: "LogAccionesIncidencias",
                column: "IdIncidencia");

            migrationBuilder.CreateIndex(
                name: "IX_Matrizs_IdAccionesRequisitoFicha",
                table: "Matrizs",
                column: "IdAccionesRequisitoFicha");

            migrationBuilder.CreateIndex(
                name: "IX_Matrizs_IdAreaReclamos",
                table: "Matrizs",
                column: "IdAreaReclamos");

            migrationBuilder.CreateIndex(
                name: "IX_Matrizs_IdCasos",
                table: "Matrizs",
                column: "IdCasos");

            migrationBuilder.CreateIndex(
                name: "IX_Matrizs_IdMotivos",
                table: "Matrizs",
                column: "IdMotivos");

            migrationBuilder.CreateIndex(
                name: "IX_Matrizs_IdRequisitoFicha",
                table: "Matrizs",
                column: "IdRequisitoFicha");

            migrationBuilder.CreateIndex(
                name: "IX_Matrizs_IdResponsableReclamo1",
                table: "Matrizs",
                column: "IdResponsableReclamo1");

            migrationBuilder.CreateIndex(
                name: "IX_Matrizs_IdResponsableReclamo2",
                table: "Matrizs",
                column: "IdResponsableReclamo2");

            migrationBuilder.CreateIndex(
                name: "IX_Matrizs_IdSubMotivo",
                table: "Matrizs",
                column: "IdSubMotivo");

            migrationBuilder.CreateIndex(
                name: "IX_Matrizs_IdTipoFicha",
                table: "Matrizs",
                column: "IdTipoFicha");

            migrationBuilder.CreateIndex(
                name: "IX_Matrizs_IdTipoReconocimiento",
                table: "Matrizs",
                column: "IdTipoReconocimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Motivos_IdCaso",
                table: "Motivos",
                column: "IdCaso");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_IdContinente",
                table: "Paises",
                column: "IdContinente");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_IdIdioma",
                table: "Paises",
                column: "IdIdioma");

            migrationBuilder.CreateIndex(
                name: "IX_Permiso_IdArea",
                table: "Permiso",
                column: "IdArea");

            migrationBuilder.CreateIndex(
                name: "IX_PermisosRutas_IdApplicationRoute",
                table: "PermisosRutas",
                column: "IdApplicationRoute");

            migrationBuilder.CreateIndex(
                name: "IX_Preguntas_IdGrupoDePreguntas",
                table: "Preguntas",
                column: "IdGrupoDePreguntas");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosIncidencias_IdIncidencias",
                table: "ProductosIncidencias",
                column: "IdIncidencias");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosIncidencias_IdProducto",
                table: "ProductosIncidencias",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Productoss_IdCategoria",
                table: "Productoss",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Regiones_IdPais",
                table: "Regiones",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitosTipoFichas_IdTipoFicha",
                table: "RequisitosTipoFichas",
                column: "IdTipoFicha");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsableReclamos_IdAreaReclamo",
                table: "ResponsableReclamos",
                column: "IdAreaReclamo");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsableReclamos_IdTerritorio",
                table: "ResponsableReclamos",
                column: "IdTerritorio");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaEncuestaIncidencias_IdEncuesta",
                table: "RespuestaEncuestaIncidencias",
                column: "IdEncuesta");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaEncuestaIncidencias_IdPregunta",
                table: "RespuestaEncuestaIncidencias",
                column: "IdPregunta");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_EncuestaIncidenciaIdEncuesta",
                table: "Respuestas",
                column: "EncuestaIncidenciaIdEncuesta");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_IdEncuesta",
                table: "Respuestas",
                column: "IdEncuesta");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_IdPregunta",
                table: "Respuestas",
                column: "IdPregunta");

            migrationBuilder.CreateIndex(
                name: "IX_SeguridadAreas_SeguridadNiveleIdNivel",
                table: "SeguridadAreas",
                column: "SeguridadNiveleIdNivel");

            migrationBuilder.CreateIndex(
                name: "IX_States_JoId",
                table: "States",
                column: "JoId");

            migrationBuilder.CreateIndex(
                name: "IX_SubMotivos_IdMotivoss",
                table: "SubMotivos",
                column: "IdMotivoss");

            migrationBuilder.CreateIndex(
                name: "IX_SubMotivos_IdRequisitoTipoFicha",
                table: "SubMotivos",
                column: "IdRequisitoTipoFicha");

            migrationBuilder.CreateIndex(
                name: "IX_SubMotivos_IdTipoReconocimiento",
                table: "SubMotivos",
                column: "IdTipoReconocimiento");

            migrationBuilder.CreateIndex(
                name: "IX_TemporalIncidencias_IdAreaReclamo",
                table: "TemporalIncidencias",
                column: "IdAreaReclamo");

            migrationBuilder.CreateIndex(
                name: "IX_TemporalIncidencias_IdAsesorComercial",
                table: "TemporalIncidencias",
                column: "IdAsesorComercial");

            migrationBuilder.CreateIndex(
                name: "IX_TemporalIncidencias_IdAsesorTecnico",
                table: "TemporalIncidencias",
                column: "IdAsesorTecnico");

            migrationBuilder.CreateIndex(
                name: "IX_TemporalIncidencias_IdCaso",
                table: "TemporalIncidencias",
                column: "IdCaso");

            migrationBuilder.CreateIndex(
                name: "IX_TemporalIncidencias_IdEstadoIncidencias",
                table: "TemporalIncidencias",
                column: "IdEstadoIncidencias");

            migrationBuilder.CreateIndex(
                name: "IX_TemporalIncidencias_IdEstadoProcesoFicha",
                table: "TemporalIncidencias",
                column: "IdEstadoProcesoFicha");

            migrationBuilder.CreateIndex(
                name: "IX_TemporalIncidencias_IdGestorReclamo",
                table: "TemporalIncidencias",
                column: "IdGestorReclamo");

            migrationBuilder.CreateIndex(
                name: "IX_TemporalIncidencias_IdMotivo",
                table: "TemporalIncidencias",
                column: "IdMotivo");

            migrationBuilder.CreateIndex(
                name: "IX_TemporalIncidencias_IdResponsableNivel1",
                table: "TemporalIncidencias",
                column: "IdResponsableNivel1");

            migrationBuilder.CreateIndex(
                name: "IX_TemporalIncidencias_IdResponsableNivel2",
                table: "TemporalIncidencias",
                column: "IdResponsableNivel2");

            migrationBuilder.CreateIndex(
                name: "IX_TemporalIncidencias_IdSolicitante",
                table: "TemporalIncidencias",
                column: "IdSolicitante");

            migrationBuilder.CreateIndex(
                name: "IX_TemporalIncidencias_IdSubMotivo",
                table: "TemporalIncidencias",
                column: "IdSubMotivo");

            migrationBuilder.CreateIndex(
                name: "IX_TemporalIncidencias_IdTerritorio",
                table: "TemporalIncidencias",
                column: "IdTerritorio");

            migrationBuilder.CreateIndex(
                name: "IX_TemporalIncidencias_IdTipoFicha",
                table: "TemporalIncidencias",
                column: "IdTipoFicha");

            migrationBuilder.CreateIndex(
                name: "IX_TemporalIncidencias_IdTipoIncidencias",
                table: "TemporalIncidencias",
                column: "IdTipoIncidencias");

            migrationBuilder.CreateIndex(
                name: "IX_TipoFichas_IdCaso",
                table: "TipoFichas",
                column: "IdCaso");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Ciudades_CiudadesIdCiudad",
                schema: "SEG",
                table: "Users",
                column: "CiudadesIdCiudad",
                principalTable: "Ciudades",
                principalColumn: "IdCiudad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Ciudades_CiudadesIdCiudad",
                schema: "SEG",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AggregatedCounters");

            migrationBuilder.DropTable(
                name: "ArchivosCargaIncidencia");

            migrationBuilder.DropTable(
                name: "AreasResponsables");

            migrationBuilder.DropTable(
                name: "CargaCorreos");

            migrationBuilder.DropTable(
                name: "CargaMatrizs");

            migrationBuilder.DropTable(
                name: "CategoriaSeleccionadas");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "ClaimsUsuarios");

            migrationBuilder.DropTable(
                name: "Counters");

            migrationBuilder.DropTable(
                name: "FacturaDetalles");

            migrationBuilder.DropTable(
                name: "Hoja2s");

            migrationBuilder.DropTable(
                name: "LogAccionesIncidencias");

            migrationBuilder.DropTable(
                name: "Matrizs");

            migrationBuilder.DropTable(
                name: "Permiso");

            migrationBuilder.DropTable(
                name: "PermisosRutas");

            migrationBuilder.DropTable(
                name: "ProductosIncidencias");

            migrationBuilder.DropTable(
                name: "RespuestaEncuestaIncidencias");

            migrationBuilder.DropTable(
                name: "Respuestas");

            migrationBuilder.DropTable(
                name: "Servers");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "TablaMatrizs");

            migrationBuilder.DropTable(
                name: "TemporalIncidencias");

            migrationBuilder.DropTable(
                name: "TemporalMatrizCausales");

            migrationBuilder.DropTable(
                name: "ValidacionPreguntas");

            migrationBuilder.DropTable(
                name: "ViewDashboardResumenIncidencias");

            migrationBuilder.DropTable(
                name: "ArchivosCargas");

            migrationBuilder.DropTable(
                name: "CategoriaCamarons");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Productoss");

            migrationBuilder.DropTable(
                name: "Archivos");

            migrationBuilder.DropTable(
                name: "AccionesRequisitoFichas");

            migrationBuilder.DropTable(
                name: "SeguridadAreas");

            migrationBuilder.DropTable(
                name: "Rutass");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "PreguntaCatalogos");

            migrationBuilder.DropTable(
                name: "EncuestaIncidencias");

            migrationBuilder.DropTable(
                name: "Preguntas");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Regiones");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "PuntoVentas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "SeguridadNiveles");

            migrationBuilder.DropTable(
                name: "Incidencias");

            migrationBuilder.DropTable(
                name: "GrupoDePreguntas");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "AsesorComercials");

            migrationBuilder.DropTable(
                name: "AsesorTecnicos");

            migrationBuilder.DropTable(
                name: "CorreoNotifications");

            migrationBuilder.DropTable(
                name: "EstadoProcesoFichas");

            migrationBuilder.DropTable(
                name: "EstadosIncidencias");

            migrationBuilder.DropTable(
                name: "GestorReclamos");

            migrationBuilder.DropTable(
                name: "ResponsableReclamos");

            migrationBuilder.DropTable(
                name: "Solicitantes");

            migrationBuilder.DropTable(
                name: "SubMotivos");

            migrationBuilder.DropTable(
                name: "TipoIncidencias");

            migrationBuilder.DropTable(
                name: "EncuestaDetalles");

            migrationBuilder.DropTable(
                name: "Continentes");

            migrationBuilder.DropTable(
                name: "Idiomas");

            migrationBuilder.DropTable(
                name: "AreasReclamos");

            migrationBuilder.DropTable(
                name: "Territorios");

            migrationBuilder.DropTable(
                name: "Motivos");

            migrationBuilder.DropTable(
                name: "RequisitosTipoFichas");

            migrationBuilder.DropTable(
                name: "TipoReconocimientos");

            migrationBuilder.DropTable(
                name: "Encuestas");

            migrationBuilder.DropTable(
                name: "TipoFichas");

            migrationBuilder.DropTable(
                name: "Casos");

            migrationBuilder.DropIndex(
                name: "IX_Users_CiudadesIdCiudad",
                schema: "SEG",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CiudadesIdCiudad",
                schema: "SEG",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "RequestID",
                table: "Logs",
                newName: "RequestId");

            migrationBuilder.RenameColumn(
                name: "StackTrace",
                table: "Logs",
                newName: "StackStrace");

            migrationBuilder.AlterColumn<string>(
                name: "RequestTraceIdentifier",
                table: "Logs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }
    }
}
