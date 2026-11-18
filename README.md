# Flight Deconflicting Tool

A Windows Forms application in C# that simulates aircraft flying their flight plans inside a sector, detects losses of separation and helps resolve them, either manually by diverting an aircraft or automatically by changing speeds.

## Features

- **Simulation display:** aircraft move along their routes, step by step or automatically, with their safety zones and predicted trajectories drawn on the sector.
- **Conflict detection:** checks every pair of flights against a configurable safety distance, and predicts when a conflict will happen even when it is not happening yet.
- **Manual resolution:** click an aircraft and choose a diversion point to change its heading.
- **Automatic resolution** (`ConflictResolver`): conflicts are sorted by time to conflict and each one is solved by speeding up or slowing down one or both aircraft. Every candidate change is checked against the rest of the traffic so it does not create new conflicts. Pairs that cannot be solved are reported.
- **Flight plans:** add them manually or load them from text files, and export them to text or PDF (iTextSharp).
- **Users and data:** login, account creation, editing and deletion, and password recovery by email, with an SQLite database. Passwords are stored as SHA-256 hashes. There is also an airline directory with contact details.

## Architecture

```
FlightLib/          class library: model and logic
  Models/           FlightPlan, FlightPlanList, Position, Segment, flight history
  Utils/            ConflictResolver, data validation
  IO (DB)/          SQLite access (users, airlines) and flight-plan loader
  Text File Manager/ export to text and PDF
FormsMenu/          Windows Forms UI: simulation display, menus, user management
SimulatorConsole/   first console version of the simulator
```

## How to run

1. Open `DeconflictingTool.sln` in Visual Studio (.NET Framework 4.7.2).
2. Restore the NuGet packages (BouncyCastle, iTextSharp, FontAwesome.Sharp) and add **System.Data.SQLite** (the original project referenced a local DLL).
3. Build and run `FormsMenu`. The SQLite database in `FormsMenu/Database/` is copied to the output folder. It contains the tables and the airline directory, without any user accounts, so create an account from the login screen.
4. Password recovery by email is optional. To use it, set the environment variable `DECONFLICTING_SMTP_PASSWORD` with an app password for the sender account.

## Context

Team project for the Informàtica 2 course (C# and object-oriented programming) at EETAC–UPC, spring 2025.

## Author

Andreu Bueno Álvarez — Aerospace Systems Engineering, EETAC–UPC.
