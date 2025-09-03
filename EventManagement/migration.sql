CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;
CREATE TABLE "Clients" (
    "ClientId" uuid NOT NULL,
    "Name" text NOT NULL,
    "Email" text NOT NULL,
    "PhoneNumber" text NOT NULL,
    "Address" text NOT NULL,
    "Company" text,
    CONSTRAINT "PK_Clients" PRIMARY KEY ("ClientId")
);

CREATE TABLE "Resources" (
    "ResourceId" uuid NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL,
    "Type" text NOT NULL,
    "QuantityAvailable" integer NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Resources" PRIMARY KEY ("ResourceId")
);

CREATE TABLE "Staffs" (
    "StaffId" uuid NOT NULL,
    "Name" text NOT NULL,
    "Role" text NOT NULL,
    "Email" text NOT NULL,
    "PhoneNumber" text NOT NULL,
    "AvailabilityStatus" integer NOT NULL,
    CONSTRAINT "PK_Staffs" PRIMARY KEY ("StaffId")
);

CREATE TABLE "Users" (
    "UserId" uuid NOT NULL,
    "Username" text NOT NULL,
    "PasswordHash" text NOT NULL,
    "Role" text NOT NULL,
    CONSTRAINT "PK_Users" PRIMARY KEY ("UserId")
);

CREATE TABLE "Events" (
    "EventId" uuid NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL,
    "StartDate" timestamp with time zone NOT NULL,
    "EndDate" timestamp with time zone NOT NULL,
    "Location" text NOT NULL,
    "Venue" text NOT NULL,
    "Status" integer NOT NULL,
    "ClientId" uuid NOT NULL,
    "StaffId" uuid NOT NULL,
    CONSTRAINT "PK_Events" PRIMARY KEY ("EventId"),
    CONSTRAINT "FK_Events_Clients_ClientId" FOREIGN KEY ("ClientId") REFERENCES "Clients" ("ClientId") ON DELETE CASCADE
);

CREATE TABLE "Billing" (
    "BillId" uuid NOT NULL,
    "TotalAmount" integer NOT NULL,
    "PaidAmount" integer NOT NULL,
    "DueAmount" integer NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    "UpdatedAt" timestamp with time zone NOT NULL,
    "PaymentStatus" integer NOT NULL,
    "EventId" uuid NOT NULL,
    CONSTRAINT "PK_Billing" PRIMARY KEY ("BillId"),
    CONSTRAINT "FK_Billing_Events_EventId" FOREIGN KEY ("EventId") REFERENCES "Events" ("EventId") ON DELETE CASCADE
);

CREATE TABLE "EventResources" (
    "EventResourceId" uuid NOT NULL,
    "EventId" uuid NOT NULL,
    "ResourceId" uuid NOT NULL,
    "QuantityUsed" integer NOT NULL,
    CONSTRAINT "PK_EventResources" PRIMARY KEY ("EventResourceId"),
    CONSTRAINT "FK_EventResources_Events_EventId" FOREIGN KEY ("EventId") REFERENCES "Events" ("EventId") ON DELETE CASCADE,
    CONSTRAINT "FK_EventResources_Resources_ResourceId" FOREIGN KEY ("ResourceId") REFERENCES "Resources" ("ResourceId") ON DELETE CASCADE
);

CREATE TABLE "EventStaffs" (
    "EventStaffId" uuid NOT NULL,
    "EventId" uuid NOT NULL,
    "StaffId" uuid NOT NULL,
    CONSTRAINT "PK_EventStaffs" PRIMARY KEY ("EventStaffId"),
    CONSTRAINT "FK_EventStaffs_Events_EventId" FOREIGN KEY ("EventId") REFERENCES "Events" ("EventId") ON DELETE CASCADE,
    CONSTRAINT "FK_EventStaffs_Staffs_StaffId" FOREIGN KEY ("StaffId") REFERENCES "Staffs" ("StaffId") ON DELETE CASCADE
);

CREATE UNIQUE INDEX "IX_Billing_EventId" ON "Billing" ("EventId");

CREATE INDEX "IX_EventResources_EventId" ON "EventResources" ("EventId");

CREATE INDEX "IX_EventResources_ResourceId" ON "EventResources" ("ResourceId");

CREATE INDEX "IX_Events_ClientId" ON "Events" ("ClientId");

CREATE INDEX "IX_EventStaffs_EventId" ON "EventStaffs" ("EventId");

CREATE INDEX "IX_EventStaffs_StaffId" ON "EventStaffs" ("StaffId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250903073042_UpdateModels', '9.0.8');

COMMIT;

