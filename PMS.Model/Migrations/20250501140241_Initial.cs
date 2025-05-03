using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PMS.Model.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pms");

            migrationBuilder.CreateTable(
                name: "AccessRole",
                schema: "pms",
                columns: table => new
                {
                    AccessRoleID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessRole", x => x.AccessRoleID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "pms",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                schema: "pms",
                columns: table => new
                {
                    ModuleID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.ModuleID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCategory",
                schema: "pms",
                columns: table => new
                {
                    ProjectCategoryID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCategory", x => x.ProjectCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectStatus",
                schema: "pms",
                columns: table => new
                {
                    ProjectStatusID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatus", x => x.ProjectStatusID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTaskCategory",
                schema: "pms",
                columns: table => new
                {
                    ProjectTaskCategoryID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskCategory", x => x.ProjectTaskCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTaskStatus",
                schema: "pms",
                columns: table => new
                {
                    ProjectTaskStatusID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskStatus", x => x.ProjectTaskStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Speciality",
                schema: "pms",
                columns: table => new
                {
                    SpecialityID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speciality", x => x.SpecialityID);
                });

            migrationBuilder.CreateTable(
                name: "SprintTaskStatus",
                schema: "pms",
                columns: table => new
                {
                    SprintTaskStatusID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprintTaskStatus", x => x.SprintTaskStatusID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "pms",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "WorkTeamRole",
                schema: "pms",
                columns: table => new
                {
                    WorkTeamRoleID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTeamRole", x => x.WorkTeamRoleID);
                });

            migrationBuilder.CreateTable(
                name: "WorkTeamStatus",
                schema: "pms",
                columns: table => new
                {
                    WorkTeamStatusID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTeamStatus", x => x.WorkTeamStatusID);
                });

            migrationBuilder.CreateTable(
                name: "ModuleAccessRole",
                schema: "pms",
                columns: table => new
                {
                    AccessRoleID = table.Column<int>(type: "integer", nullable: false),
                    ModuleID = table.Column<int>(type: "integer", nullable: false),
                    Create = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Read = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Update = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Delete = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleAccessRole", x => new { x.AccessRoleID, x.ModuleID });
                    table.ForeignKey(
                        name: "FK_ModuleAccessRole_AccessRole_AccessRoleID",
                        column: x => x.AccessRoleID,
                        principalSchema: "pms",
                        principalTable: "AccessRole",
                        principalColumn: "AccessRoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleAccessRole_Module_ModuleID",
                        column: x => x.ModuleID,
                        principalSchema: "pms",
                        principalTable: "Module",
                        principalColumn: "ModuleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "pms",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    SecondName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<bool>(type: "boolean", nullable: false),
                    Birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    SpecialityID = table.Column<int>(type: "integer", nullable: true),
                    DepartmentID = table.Column<int>(type: "integer", nullable: true),
                    UserID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalSchema: "pms",
                        principalTable: "Department",
                        principalColumn: "DepartmentID");
                    table.ForeignKey(
                        name: "FK_Employee_Speciality_SpecialityID",
                        column: x => x.SpecialityID,
                        principalSchema: "pms",
                        principalTable: "Speciality",
                        principalColumn: "SpecialityID");
                    table.ForeignKey(
                        name: "FK_Employee_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "pms",
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "pms",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EstimatedStartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ActualStartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EstimatedEndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ActualEndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedByUserID = table.Column<int>(type: "integer", nullable: false),
                    ManagerID = table.Column<int>(type: "integer", nullable: false),
                    ProjectStatusID = table.Column<int>(type: "integer", nullable: false),
                    ProjectCategoryID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Project_ProjectCategory_ProjectCategoryID",
                        column: x => x.ProjectCategoryID,
                        principalSchema: "pms",
                        principalTable: "ProjectCategory",
                        principalColumn: "ProjectCategoryID");
                    table.ForeignKey(
                        name: "FK_Project_ProjectStatus_ProjectStatusID",
                        column: x => x.ProjectStatusID,
                        principalSchema: "pms",
                        principalTable: "ProjectStatus",
                        principalColumn: "ProjectStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalSchema: "pms",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_User_ManagerID",
                        column: x => x.ManagerID,
                        principalSchema: "pms",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccessRole",
                schema: "pms",
                columns: table => new
                {
                    AccessRoleID = table.Column<int>(type: "integer", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccessRole", x => new { x.AccessRoleID, x.UserID });
                    table.ForeignKey(
                        name: "FK_UserAccessRole_AccessRole_AccessRoleID",
                        column: x => x.AccessRoleID,
                        principalSchema: "pms",
                        principalTable: "AccessRole",
                        principalColumn: "AccessRoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccessRole_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "pms",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectRelease",
                schema: "pms",
                columns: table => new
                {
                    ProjectReleaseID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Version = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    ProjectID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRelease", x => x.ProjectReleaseID);
                    table.ForeignKey(
                        name: "FK_ProjectRelease_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "pms",
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sprint",
                schema: "pms",
                columns: table => new
                {
                    SprintID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Goal = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ProjectID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprint", x => x.SprintID);
                    table.ForeignKey(
                        name: "FK_Sprint_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "pms",
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkTeam",
                schema: "pms",
                columns: table => new
                {
                    WorkTeamID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "integer", nullable: false),
                    WorkTeamStatusID = table.Column<int>(type: "integer", nullable: true),
                    ProjectID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTeam", x => x.WorkTeamID);
                    table.ForeignKey(
                        name: "FK_WorkTeam_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "pms",
                        principalTable: "Project",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "FK_WorkTeam_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalSchema: "pms",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkTeam_WorkTeamStatus_WorkTeamStatusID",
                        column: x => x.WorkTeamStatusID,
                        principalSchema: "pms",
                        principalTable: "WorkTeamStatus",
                        principalColumn: "WorkTeamStatusID");
                });

            migrationBuilder.CreateTable(
                name: "ProjectTask",
                schema: "pms",
                columns: table => new
                {
                    ProjectTaskID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedByUserID = table.Column<int>(type: "integer", nullable: false),
                    ResponsibleUserID = table.Column<int>(type: "integer", nullable: true),
                    ExecutorUserID = table.Column<int>(type: "integer", nullable: true),
                    ProjectReleaseID = table.Column<int>(type: "integer", nullable: false),
                    ProjectTaskStatusID = table.Column<int>(type: "integer", nullable: false),
                    ProjectTaskCategoryID = table.Column<int>(type: "integer", nullable: true),
                    ParentTaskID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTask", x => x.ProjectTaskID);
                    table.ForeignKey(
                        name: "FK_ProjectTask_ProjectRelease_ProjectReleaseID",
                        column: x => x.ProjectReleaseID,
                        principalSchema: "pms",
                        principalTable: "ProjectRelease",
                        principalColumn: "ProjectReleaseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTask_ProjectTaskCategory_ProjectTaskCategoryID",
                        column: x => x.ProjectTaskCategoryID,
                        principalSchema: "pms",
                        principalTable: "ProjectTaskCategory",
                        principalColumn: "ProjectTaskCategoryID");
                    table.ForeignKey(
                        name: "FK_ProjectTask_ProjectTaskStatus_ProjectTaskStatusID",
                        column: x => x.ProjectTaskStatusID,
                        principalSchema: "pms",
                        principalTable: "ProjectTaskStatus",
                        principalColumn: "ProjectTaskStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTask_ProjectTask_ParentTaskID",
                        column: x => x.ParentTaskID,
                        principalSchema: "pms",
                        principalTable: "ProjectTask",
                        principalColumn: "ProjectTaskID");
                    table.ForeignKey(
                        name: "FK_ProjectTask_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalSchema: "pms",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTask_User_ExecutorUserID",
                        column: x => x.ExecutorUserID,
                        principalSchema: "pms",
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_ProjectTask_User_ResponsibleUserID",
                        column: x => x.ResponsibleUserID,
                        principalSchema: "pms",
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "WorkTeamRoleUser",
                schema: "pms",
                columns: table => new
                {
                    WorkTeamID = table.Column<int>(type: "integer", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    WorkTeamRoleID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTeamRoleUser", x => new { x.UserID, x.WorkTeamID, x.WorkTeamRoleID });
                    table.ForeignKey(
                        name: "FK_WorkTeamRoleUser_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "pms",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkTeamRoleUser_WorkTeamRole_WorkTeamRoleID",
                        column: x => x.WorkTeamRoleID,
                        principalSchema: "pms",
                        principalTable: "WorkTeamRole",
                        principalColumn: "WorkTeamRoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkTeamRoleUser_WorkTeam_WorkTeamID",
                        column: x => x.WorkTeamID,
                        principalSchema: "pms",
                        principalTable: "WorkTeam",
                        principalColumn: "WorkTeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SprintTask",
                schema: "pms",
                columns: table => new
                {
                    SprintID = table.Column<int>(type: "integer", nullable: false),
                    ProjectTaskID = table.Column<int>(type: "integer", nullable: false),
                    SprintTaskStatusID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprintTask", x => new { x.SprintID, x.ProjectTaskID });
                    table.ForeignKey(
                        name: "FK_SprintTask_ProjectTask_ProjectTaskID",
                        column: x => x.ProjectTaskID,
                        principalSchema: "pms",
                        principalTable: "ProjectTask",
                        principalColumn: "ProjectTaskID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SprintTask_SprintTaskStatus_SprintTaskStatusID",
                        column: x => x.SprintTaskStatusID,
                        principalSchema: "pms",
                        principalTable: "SprintTaskStatus",
                        principalColumn: "SprintTaskStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SprintTask_Sprint_SprintID",
                        column: x => x.SprintID,
                        principalSchema: "pms",
                        principalTable: "Sprint",
                        principalColumn: "SprintID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentID",
                schema: "pms",
                table: "Employee",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SpecialityID",
                schema: "pms",
                table: "Employee",
                column: "SpecialityID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_UserID",
                schema: "pms",
                table: "Employee",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModuleAccessRole_ModuleID",
                schema: "pms",
                table: "ModuleAccessRole",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatedByUserID",
                schema: "pms",
                table: "Project",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ManagerID",
                schema: "pms",
                table: "Project",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectCategoryID",
                schema: "pms",
                table: "Project",
                column: "ProjectCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectStatusID",
                schema: "pms",
                table: "Project",
                column: "ProjectStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRelease_ProjectID",
                schema: "pms",
                table: "ProjectRelease",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_CreatedByUserID",
                schema: "pms",
                table: "ProjectTask",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_ExecutorUserID",
                schema: "pms",
                table: "ProjectTask",
                column: "ExecutorUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_ParentTaskID",
                schema: "pms",
                table: "ProjectTask",
                column: "ParentTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_ProjectReleaseID",
                schema: "pms",
                table: "ProjectTask",
                column: "ProjectReleaseID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_ProjectTaskCategoryID",
                schema: "pms",
                table: "ProjectTask",
                column: "ProjectTaskCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_ProjectTaskStatusID",
                schema: "pms",
                table: "ProjectTask",
                column: "ProjectTaskStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_ResponsibleUserID",
                schema: "pms",
                table: "ProjectTask",
                column: "ResponsibleUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Sprint_ProjectID",
                schema: "pms",
                table: "Sprint",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_SprintTask_ProjectTaskID",
                schema: "pms",
                table: "SprintTask",
                column: "ProjectTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_SprintTask_SprintTaskStatusID",
                schema: "pms",
                table: "SprintTask",
                column: "SprintTaskStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessRole_UserID",
                schema: "pms",
                table: "UserAccessRole",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTeam_CreatedByUserID",
                schema: "pms",
                table: "WorkTeam",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTeam_ProjectID",
                schema: "pms",
                table: "WorkTeam",
                column: "ProjectID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkTeam_WorkTeamStatusID",
                schema: "pms",
                table: "WorkTeam",
                column: "WorkTeamStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTeamRoleUser_WorkTeamID",
                schema: "pms",
                table: "WorkTeamRoleUser",
                column: "WorkTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTeamRoleUser_WorkTeamRoleID",
                schema: "pms",
                table: "WorkTeamRoleUser",
                column: "WorkTeamRoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "ModuleAccessRole",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "SprintTask",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "UserAccessRole",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "WorkTeamRoleUser",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "Speciality",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "Module",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "ProjectTask",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "SprintTaskStatus",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "Sprint",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "AccessRole",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "WorkTeamRole",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "WorkTeam",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "ProjectRelease",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "ProjectTaskCategory",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "ProjectTaskStatus",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "WorkTeamStatus",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "ProjectCategory",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "ProjectStatus",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "User",
                schema: "pms");
        }
    }
}
