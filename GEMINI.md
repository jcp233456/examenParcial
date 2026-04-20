# Project Overview: examenParcial

This project is a medical appointment management system built as a C# Windows Forms application targeting the .NET Framework 4.7.2. It allows for the management of doctors, patients, and their appointments, with data persisted in local text files.

## Main Technologies
- **Language:** C#
- **Framework:** .NET Framework 4.7.2
- **UI Library:** Windows Forms (WinForms)
- **Data Persistence:** Plain text files (`.txt`) using `System.IO` (FileStream, StreamReader, StreamWriter).

## Project Structure and Architecture
The project follows a simple monolithic architecture for a desktop application:
- **Models:** 
  - `Doctor.cs`: Represents a medical professional (Id, Nombre, Especialidad).
  - `Paciente.cs`: Represents a patient (Dpi, Nombre, Telefono).
  - `Citas.cs`: Represents a scheduled appointment between a doctor and a patient.
  - `Reporte.cs`: Used for aggregating or displaying appointment data.
- **UI Logic:** 
  - `Form1.cs`: Contains the main application window, event handlers, and data loading/saving logic.
  - `Program.cs`: The entry point that initializes the application and launches the main form.
- **Data Storage:** 
  - Data is stored in `doctores.txt`, `pacientes.txt`, and `citas.txt`. Each object property is typically stored on a new line.

## Building and Running
### Prerequisites
- Visual Studio (2017 or later recommended) or MSBuild.
- .NET Framework 4.7.2 SDK.

### Build and Run Commands
- **Build:** Use Visual Studio's "Build Solution" or run `msbuild examenParcial.csproj` from the Developer Command Prompt.
- **Run:** Execute the compiled binary located in `bin\Debug\examenParcial.exe` or press `F5` in Visual Studio.
- **Testing:** No automated testing framework is currently configured. Manual testing via the UI is the primary validation method.

## Development Conventions
- **Naming:** 
  - Classes use `PascalCase`.
  - Private fields often use `camelCase`.
  - Properties use `PascalCase`.
- **Data Handling:** 
  - Data is loaded into `List<T>` collections upon application startup (`LeerDoctores`, `LeerPacientes`).
  - Appointments are saved to `citas.txt` immediately after creation.
- **UI Interaction:** 
  - Uses `ComboBox` for selection of doctors and patients.
  - Uses `DataGridView` for displaying reports and lists.
  - Uses `DateTimePicker` for date and time selection.

## TODOs / Improvement Areas
- [ ] Implement robust error handling for file I/O (e.g., missing files).
- [ ] Add data validation for input fields.
- [ ] Consider moving to a more structured data format like JSON or a database (SQLite).
- [ ] Implement unit tests for the core business logic in the models.
